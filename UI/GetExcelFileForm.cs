using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace UI
{
    public partial class GetExcelFileForm : Form
    {
        private LoadGlobalChineseCharacters loadGlobalChineseCharacters;
        private HandleData handleData;
        private string excelFilePath = "";
        private static bool isFirstRowColumn = true;
        private static string stringTypeString = "string";
        private static string dateTypeString = "date";
        private static string numberTypeString = "number";
        private static string dateRegStr;
        private static string numberRegStr;
        public GetExcelFileForm()
        {
            dateRegStr = PatternMatchingString.dateRegStr;
            numberRegStr = PatternMatchingString.numberRegStr;
            InitializeComponent();
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            handleData = new HandleData();
            initUI();
        }

        private void initUI()
        {
            this.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["chooseExcelFile"];
            chooseExcelFileButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["chooseExcelFile"];
            OKbutton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["ok"];
            cancelButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["cancel"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenExcelFileDialog();
        }

        private void OpenExcelFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer);
            openFileDialog.Filter = loadGlobalChineseCharacters.GlobalChineseCharactersDict["excelFileFilter"];
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                excelFilePath = openFileDialog.FileName;
                ExcelFilePathlabel.Text = excelFilePath;
            }
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (excelFilePath.Equals(PatternMatchingString.emptyString))
            {
                DialogResult dr = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["pleaseChooseExcelFile"], "regular expression result");
            }
            else
            {
                InputExcel inputExcel = new InputExcel(excelFilePath);
                DataTable dataTable = inputExcel.ExcelToDataTable(loadGlobalChineseCharacters.GlobalChineseCharactersDict["customerLoanBill"], isFirstRowColumn);
                List<string> columnsNameList = getColumnName(dataTable);
                Dictionary<string, string> columnTypeDict = judgeColumnType(dataTable);
                //printColumnsName(columnsList);
                //List<ColumnType> columnTypeList = judgeColumnType(dataTable);
                //printColumnsType(columnTypeList);
                List<Column<string>> noRepeatingColumnList = handleData.filterRepeatingData(dataTable);
                //string columnStr = handleData.getColumnListString(columnList);
                //showMessage(columnStr);
                TransmitData transmitData = new TransmitData(dataTable, columnsNameList, columnTypeDict, noRepeatingColumnList);
                ChooseColumnForm chooseColumnForm = new ChooseColumnForm(transmitData);
                chooseColumnForm.Show();
            }
        }

        private Dictionary<string, string> judgeColumnType(DataTable dataTable)
        {
            //List<ColumnType> columnTypeList = new List<ColumnType>();
            Dictionary<string, string> columnTypeDict = new Dictionary<string, string>();
            List<string> columnNameList = getColumnName(dataTable);
            initColumnType(columnNameList, columnTypeDict);

            Regex dateReg = new Regex(dateRegStr);
            Regex numberReg = new Regex(numberRegStr);

            //string exceptionStr = "";
            foreach (string columnName in columnNameList) 
            {
                //
                string thisColumnType = "";
                bool isBlankColumn = true;

                //hypothesis
                bool allRowsIsString = false;
                bool allRowsIsDate = true;
                bool allRowIsNumber = true;

                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string cell = dataTable.Rows[i][columnName].ToString().Trim();

                    if (!cell.Equals(""))
                        isBlankColumn = false;
                    //exceptionStr = testTypeException(columnName, cell, exceptionStr, dateReg, numberReg);

                    bool matchDate = dateReg.IsMatch(cell);
                    bool matchNumber = numberReg.IsMatch(cell);

                    if (!matchDate && allRowsIsDate)
                    {
                        allRowsIsDate = false;
                    }
                    if (!matchNumber && allRowIsNumber)
                    {
                        allRowIsNumber = false;
                    }

                    if (!allRowsIsDate && !allRowIsNumber && !allRowsIsString)
                    {
                        allRowsIsString = true;
                        break;
                    }
                }

                if (allRowsIsString && !allRowsIsDate && !allRowIsNumber)
                {
                    thisColumnType = stringTypeString;
                }
                else if (!allRowsIsString && allRowsIsDate && !allRowIsNumber)
                {
                    thisColumnType = dateTypeString;
                }
                else if (!allRowsIsString && !allRowsIsDate && allRowIsNumber)
                {
                    thisColumnType = numberTypeString;
                }
                //blank
                else if (!allRowsIsString && allRowsIsDate && allRowIsNumber && isBlankColumn)
                {
                    thisColumnType = stringTypeString;
                }
                //20170322
                else if (!allRowsIsString && allRowsIsDate && allRowIsNumber && !isBlankColumn)
                {
                    thisColumnType = dateTypeString;
                }

                if (!thisColumnType.Equals(""))
                {
                    //foreach (ColumnType columnType in columnTypeList)
                    //{
                        //if (columnType.columnName.Equals(columnName))
                        //{
                            //columnType.columnType = thisColumnType;
                            //break;
                        //}
                           
                    //}
                    columnTypeDict[columnName] = thisColumnType;
                }
            }
            //printExceptionString(exceptionStr);
            return columnTypeDict;
                
        }

        private void showMessage(string message)
        {
            DialogResult dr1 = MessageBox.Show(message, "message");
        }

        private void printExceptionString(string exceptionString)
        {
            DialogResult dr1 = MessageBox.Show(exceptionString, "exception");
        }

        private string testTypeException(string columnName, string cell, string exceptionStr, Regex dateReg, Regex numberReg)
        {
            if (columnName.Equals(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception1"])) 
            {
                if (!numberReg.IsMatch(cell))
                    exceptionStr += columnName + ":" + cell + ",";
            }
            else if (columnName.Equals(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception2"]))
            {
                if (!numberReg.IsMatch(cell))
                    exceptionStr += columnName + ":" + cell + ",";
            }
            else if (columnName.Equals(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception4"]))
            {
                if (!numberReg.IsMatch(cell))
                    exceptionStr += columnName + ":" + cell + ",";
            }
            else if (columnName.Equals(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception5"]))
            {
                if (!dateReg.IsMatch(cell))
                    exceptionStr += columnName + ":" + cell + ",";
            }
            else if (columnName.Equals(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception6"]))
            {
                if (!dateReg.IsMatch(cell))
                    exceptionStr += columnName + ":" + cell + ",";
            }
            else if (columnName.Equals(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception7"]))
            {
                if (!numberReg.IsMatch(cell))
                    exceptionStr += columnName + ":" + cell + ",";
            }
            return exceptionStr;
        }

        private void initColumnType(List<string> columnNameList, Dictionary<string, string> columnTypeDict)
        {
            foreach (string columnName in columnNameList)
            {
                //ColumnType columnType = new ColumnType();
                //columnType.columnName = columnName;
                //columnType.columnType = stringTypeString;
                //columnTypeList.Add(columnType);
                columnTypeDict.Add(columnName, stringTypeString);
            }
        }

        private void showExcelData(DataTable dataTable)
        {
            string row = "";
            foreach (DataRow dr in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    string cell = (string)dr[i];
                    row += cell + ",";
                }
                row += "\n";
            }
            DialogResult dr1 = MessageBox.Show(row, "result");
        }

        private List<string> getColumnName(DataTable dataTable)
        {
            List<string> columns = new List<string>();
            for(int i = 0; i < dataTable.Columns.Count; i++)
            {
                string col = dataTable.Columns[i].ToString();
                columns.Add(col);
            }
            return columns;
        }

        private void printColumnsName(List<string> columns)
        {
            string columnsStr = "";
            foreach(string col in columns)
            {
                columnsStr += col + ",";
            }
            DialogResult dr1 = MessageBox.Show(columnsStr, "column");
        }

        private void printColumnsType(List<Model.ColumnType> columnTypeList)
        {
            string str = "";
            foreach (Model.ColumnType ct in columnTypeList)
            {
                str += ct.columnName + ":" + ct.columnType +",";
            }
            DialogResult dr1 = MessageBox.Show(str, "column");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
