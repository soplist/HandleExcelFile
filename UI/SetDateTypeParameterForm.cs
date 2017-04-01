using System;
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
    public partial class SetDateTypeParameterForm : Form
    {
        private List<string> selectColumnList; 
        private LoadGlobalChineseCharacters loadGlobalChineseCharacters;
        private Dictionary<string, string> columnTypeDict;
        private TwoDateColumnRelationContainer<string> tmpTwoDateColumnRelationContainer;
        private List<TwoDateColumnRelationContainer<string>> relationContainerList;
        private ExcelHandle excelHandle;
        private static string relationExcelFolderPath = System.Environment.CurrentDirectory + "\\..\\..\\..\\UI\\excel\\";
        private static bool isFirstRowColumn = true;
        private string currentEditRelationExcel;
        private Dictionary<string, char> selectedColumnVariableDict;
        private TransmitData transmitData;

        public SetDateTypeParameterForm()
        {
            InitializeComponent();
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            initUI();
        }

        public SetDateTypeParameterForm(TransmitData transmitData)
        {
            this.transmitData = transmitData;
            InitializeComponent();
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            this.selectColumnList = transmitData.selectedColumn;
            this.columnTypeDict = transmitData.columnTypeDict;
            this.selectedColumnVariableDict = transmitData.selectedColumnVariableDict;
            tmpTwoDateColumnRelationContainer = new TwoDateColumnRelationContainer<string>();
            //relationContainerList = new List<TwoDateColumnRelationContainer<string>>();
            excelHandle = new ExcelHandle();
            relationContainerList = excelHandle.getExistRelationFormExistExcel();
            initUI();
        }

        private void initUI()
        {
            DateTypeParameterGroupBox.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["dateTypeParameter"];
            RelevanceTwoDateTypeColumnButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["relevanceTwoDateTypeColumn"];
            cancelButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["cancel"];
            okButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["ok"];
            RelationColumnContentGroupBox.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationColumnContent"];
            thisTaskDateRelationGroupBox.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["thisTaskDateRelation"];
            initDateTypeCheckBox();
            initTwoColumnBeRelatedCheckedListBox();
            initThisTaskDateRelationCheckedListBox();
            saveRelationExcelButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["save"];
            saveRelationExcelButton.Enabled = false;
        }

        private void initThisTaskDateRelationCheckedListBox()
        {
            for (int i = 0; i < relationContainerList.Count; i++)
            {
                CheckBox TwoDateColumnRelationCheckBox = new CheckBox();
                TwoDateColumnRelationCheckBox.Text = relationContainerList[i][0] + "-" + relationContainerList[i][1];
                TwoDateColumnRelationCheckBox.Width = 150;
                TwoDateColumnRelationCheckBox.Location = new Point(10, 10 + i * 30);
                thisTaskDateRelationCheckedListBox.Controls.Add(TwoDateColumnRelationCheckBox);
            }
        }

        private void initTwoColumnBeRelatedCheckedListBox()
        {
            for (int i = 0; i < relationContainerList.Count; i++)
            {
                CheckBox TwoDateColumnRelationCheckBox = new CheckBox();
                TwoDateColumnRelationCheckBox.Text = relationContainerList[i][0] + "-" + relationContainerList[i][1];
                TwoDateColumnRelationCheckBox.Width = 150;
                TwoDateColumnRelationCheckBox.Location = new Point(10, 10 + i * 30);
                TwoDateColumnRelationCheckBox.CheckedChanged += relation_CheckedChanged;
                TwoColumnBeRelatedCheckedListBox.Controls.Add(TwoDateColumnRelationCheckBox);
            }

            
        }

        

        private void initDateTypeCheckBox()
        {
            int dateTypeNumber = 0;
            foreach (string select in selectColumnList)
            {
                if (columnTypeDict[select].Equals(ColumnType.dateTypeString))
                {
                    dateTypeNumber++;
                    CheckBox dateTypeColumnCheckBox = new CheckBox();
                    dateTypeColumnCheckBox.Text = select;
                    dateTypeColumnCheckBox.Location = new Point(120 * dateTypeNumber, 10);
                    dateTypeColumnCheckBox.CheckedChanged += dateColumn_CheckedChanged;
                    DateTypeParameterGroupBox.Controls.Add(dateTypeColumnCheckBox);
                }
            }
        }

        void dateColumn_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = (CheckBox)sender;
            string currentChackBoxText = currentCheckBox.Text;

            if (currentCheckBox.Checked)
            {
                if (!tmpTwoDateColumnRelationContainer.Contains(currentChackBoxText))
                {
                    try
                    {
                        tmpTwoDateColumnRelationContainer.Add(currentChackBoxText);
                        if (tmpTwoDateColumnRelationContainer.count == TwoDateColumnRelationContainer<string>.sizeLimit)
                        {
                            MessageBoxButtons button = MessageBoxButtons.OKCancel;
                            DialogResult dr = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["beSureAddRelationForThisDateTypeColumn"], loadGlobalChineseCharacters.GlobalChineseCharactersDict["ok"], button);
                            if (dr == DialogResult.OK)
                            {
                                //DialogResult dr1 = MessageBox.Show(tmpTwoDateColumnRelationContainer[0] + "," + tmpTwoDateColumnRelationContainer[1], "message");
                                addTwoDateTypeColumnRelation();
                            }
                            else
                            {

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        currentCheckBox.Checked = false;
                        DialogResult dr1 = MessageBox.Show(ex.Message, "exception");
                    }
                }
            }
            else
            {
                if (tmpTwoDateColumnRelationContainer.Contains(currentChackBoxText))
                {
                    tmpTwoDateColumnRelationContainer.Remove(currentChackBoxText);
                }
            }
            
        }

        private void addTwoDateTypeColumnRelation()
        {
            
            if (!checkTwoDateTypeColumnRelationExist(this.tmpTwoDateColumnRelationContainer))
            {
                addRelationForCheckedListBox();
                addThisTaskDateRelationCheckedListBox();
                TwoDateColumnRelationContainer<string> newTwoDateColumnRelationContainer = new TwoDateColumnRelationContainer<string>();
                newTwoDateColumnRelationContainer.Add(tmpTwoDateColumnRelationContainer[0]);
                newTwoDateColumnRelationContainer.Add(tmpTwoDateColumnRelationContainer[1]);
                relationContainerList.Add(newTwoDateColumnRelationContainer);
                addRelationExcelFile();
                setExcelDataToCurrentRelationContentDataGridView(tmpTwoDateColumnRelationContainer[0] + "-" + tmpTwoDateColumnRelationContainer[1] + ExcelHandle.excelExtensions[0]);
            }
            else
            {
                DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception10"], "exception");
            }
                
        }

        private void setExcelDataToCurrentRelationContentDataGridView(string excelName)
        {
            InputExcel inputExcel = new InputExcel(relationExcelFolderPath + excelName);
            DataTable dataTable = inputExcel.ExcelToDataTable(loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationContent"], isFirstRowColumn);
            this.currentRelationContentDataGridView.DataSource = dataTable;
            saveRelationExcelButton.Enabled = true;
        }

        private void addRelationExcelFile()
        {
            excelHandle.CreateRelationExcelFile(relationExcelFolderPath + tmpTwoDateColumnRelationContainer[0] + "-" + tmpTwoDateColumnRelationContainer[1]);
        }


        private bool checkTwoDateTypeColumnRelationExist(TwoDateColumnRelationContainer<string> twoDateColumnRelationContainer)
        {
            bool exist = false;
            foreach (TwoDateColumnRelationContainer<string> relationContainer in relationContainerList)
            {
                if (relationContainer[0].Equals(twoDateColumnRelationContainer[0]) && relationContainer[1].Equals(twoDateColumnRelationContainer[1]))
                    exist = true;
            }
            return exist;
        }
        
        private void addRelationForCheckedListBox()
        {
            CheckBox TwoDateColumnRelationCheckBox = new CheckBox();
            TwoDateColumnRelationCheckBox.Text = tmpTwoDateColumnRelationContainer[0] + "-" + tmpTwoDateColumnRelationContainer[1];
            TwoDateColumnRelationCheckBox.Width = 150;
            TwoDateColumnRelationCheckBox.Location = new Point(10, 10 + relationContainerList.Count*30);
            TwoDateColumnRelationCheckBox.CheckedChanged += relation_CheckedChanged;
            TwoDateColumnRelationCheckBox.Checked = true;
            TwoColumnBeRelatedCheckedListBox.Controls.Add(TwoDateColumnRelationCheckBox);
            setSingleSelectForTwoColumnBeRelatedCheckedListBox(TwoDateColumnRelationCheckBox);
        }

        private void addThisTaskDateRelationCheckedListBox()
        {
            CheckBox TwoDateColumnRelationCheckBox = new CheckBox();
            TwoDateColumnRelationCheckBox.Text = tmpTwoDateColumnRelationContainer[0] + "-" + tmpTwoDateColumnRelationContainer[1];
            TwoDateColumnRelationCheckBox.Width = 150;
            TwoDateColumnRelationCheckBox.Location = new Point(10, 10 + relationContainerList.Count * 30);
            thisTaskDateRelationCheckedListBox.Controls.Add(TwoDateColumnRelationCheckBox);
        }

        void relation_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox currentCheckBox = (CheckBox)sender;
            //DialogResult dr1 = MessageBox.Show(currentCheckBox.TabIndex+"", "exception");
            if (currentCheckBox.Checked)
            {
                setSingleSelectForTwoColumnBeRelatedCheckedListBox(currentCheckBox);

                currentEditRelationExcel = currentCheckBox.Text + ExcelHandle.excelExtensions[0];
                //DialogResult dr1 = MessageBox.Show(currentEditRelationExcel, "message");
                //string[] relationColumns = currentCheckBox.Text.Split(new char[1] { '-' });

                //InputExcel inputExcel = new InputExcel(relationExcelFolderPath + currentEditRelationExcel);
                //DataTable dataTable = inputExcel.ExcelToDataTable(loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationContent"], isFirstRowColumn);
                //this.currentRelationContentDataGridView.DataSource = dataTable;

                setExcelDataToCurrentRelationContentDataGridView(currentEditRelationExcel);

            }
            else
            {
                setNullForRelationContentDataGridView();
            }
            
        }

        private void setNullForRelationContentDataGridView()
        {
            this.currentRelationContentDataGridView.DataSource = null;
            saveRelationExcelButton.Enabled = false;
        }

        private void setSingleSelectForTwoColumnBeRelatedCheckedListBox(CheckBox currentCheckBox)
        {
            for (int i = 0; i < TwoColumnBeRelatedCheckedListBox.Controls.Count; i++)
            {
                if (i != currentCheckBox.TabIndex)
                {
                    ((CheckBox)TwoColumnBeRelatedCheckedListBox.Controls[i]).Checked = false;
                }
            }
        }

        

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RelevanceTwoDateTypeColumnbutton_Click(object sender, EventArgs e)
        {
            if (tmpTwoDateColumnRelationContainer.count != TwoDateColumnRelationContainer<string>.sizeLimit)
            {
                DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception9"], "exception");
            }
            else
            {
                addTwoDateTypeColumnRelation();
            }
        }

        private void saveRelationExcelButton_Click(object sender, EventArgs e)
        {
            if (checkRelationContentData())
            {
                DataTable dt = (currentRelationContentDataGridView.DataSource as DataTable);
                InputExcel inputExcel = new InputExcel(relationExcelFolderPath + currentEditRelationExcel);
                inputExcel.DataTableToExcel(dt, loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationContent"]);
            }
            else
            {
                DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception12"], "exception");
            }
        }

        private bool checkRelationContentData()
        {
            bool result = true;
            int rowCount = this.currentRelationContentDataGridView.RowCount;
            int colCount = this.currentRelationContentDataGridView.ColumnCount;

            for (int i = 0; i < rowCount; i++ )
            {
                if ((currentRelationContentDataGridView.Rows[i].Cells[0].Value != null) && (currentRelationContentDataGridView.Rows[i].Cells[1].Value != null))
                {
                    string col1Context = currentRelationContentDataGridView.Rows[i].Cells[0].Value.ToString();
                    string col2Context = currentRelationContentDataGridView.Rows[i].Cells[1].Value.ToString();

                    if ((col1Context.Equals("") && !col2Context.Equals("")) || (!col1Context.Equals("") && col2Context.Equals("")))
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        private void currentRelationContentDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = this.currentRelationContentDataGridView.CurrentCell.RowIndex;
            int col = this.currentRelationContentDataGridView.CurrentCell.ColumnIndex;

            if (currentRelationContentDataGridView.Rows[row].Cells[col].Value != null)
            {

                if (col == 0)
                {
                    string context = currentRelationContentDataGridView.Rows[row].Cells[col].Value.ToString();
                    if (row == 0)
                    {
                        
                        bool isYear = Regex.IsMatch(context, PatternMatchingString.yearRegStr);

                        if (!isYear)
                        {
                            DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["mustYear"], "message");
                            //this.selectedColumnDataGridView.Rows[row].Cells[col].Selected = true;
                            //this.selectedColumnDataGridView.BeginEdit(true);
                            this.currentRelationContentDataGridView.Rows[row].Cells[col].Value = "";
                        }
                    }
                    else if (row > 0)
                    {
                        bool isYear = Regex.IsMatch(context, PatternMatchingString.yearRegStr);

                        if (!isYear)
                        {
                            DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["mustYear"], "message");
                            //this.selectedColumnDataGridView.Rows[row].Cells[col].Selected = true;
                            //this.selectedColumnDataGridView.BeginEdit(true);
                            this.currentRelationContentDataGridView.Rows[row].Cells[col].Value = "";
                        }
                        else
                        {
                            string PreviousRowYearContent = currentRelationContentDataGridView.Rows[row - 1].Cells[col].Value.ToString();

                            if (!context.Equals("") && !PreviousRowYearContent.Equals(""))
                            {
                                float current = Convert.ToSingle(context);
                                float previous = Convert.ToSingle(PreviousRowYearContent);

                                if (!(current > previous))
                                {
                                    DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception11"], "exception");
                                    this.currentRelationContentDataGridView.Rows[row].Cells[col].Value = "";
                                }
                            }
                            else if (PreviousRowYearContent.Equals(""))
                            {
                                DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception13"], "exception");
                                this.currentRelationContentDataGridView.Rows[row].Cells[col].Value = "";
                            }
                            
                        }

                    }
                }

                else if(col == 1)
                {
                    string context = currentRelationContentDataGridView.Rows[row].Cells[col].Value.ToString();
                    bool isNumber = Regex.IsMatch(context, PatternMatchingString.numberRegStr_1);

                    if (!isNumber)
                    {
                        DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["mustNumber"], "message");
                        //this.selectedColumnDataGridView.Rows[row].Cells[col].Selected = true;
                        //this.selectedColumnDataGridView.BeginEdit(true);
                        this.currentRelationContentDataGridView.Rows[row].Cells[col].Value = "";
                    }
                }
                
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            List<string> thisTaskDateRelationCheckedList = new List<string>();
            List<DateRelationDictionary> dateRelationDictionaryList = new List<DateRelationDictionary>();

            for (int i = 0; i < thisTaskDateRelationCheckedListBox.Controls.Count; i++)
            {
                CheckBox checkBox = (CheckBox)thisTaskDateRelationCheckedListBox.Controls[i];
                if (checkBox.Checked == true)
                {
                    thisTaskDateRelationCheckedList.Add(checkBox.Text);
                }
                
            }

            foreach (string relationName in thisTaskDateRelationCheckedList)
            {
                DateRelationDictionary dateRelationDictionary = new DateRelationDictionary();
                string[] relationColumns = relationName.Split(new char[1] { '-' });
                char fristVariable = selectedColumnVariableDict[relationColumns[0]];
                char secondVariable = selectedColumnVariableDict[relationColumns[1]];
                dateRelationDictionary.variableName = fristVariable + "" + secondVariable;
                dateRelationDictionary.name = relationName;

                InputExcel inputExcel = new InputExcel(relationExcelFolderPath + relationName + ExcelHandle.excelExtensions[0]);
                DataTable dataTable = inputExcel.ExcelToDataTable(loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationContent"], isFirstRowColumn);

                foreach (DataRow dr in dataTable.Rows)
                {
                    if (!dr[0].Equals("")&&!dr[1].Equals(""))
                    {
                        float year = Convert.ToSingle(dr[0]);
                        float weight = Convert.ToSingle(dr[1]);
                        dateRelationDictionary.Add(year, weight);
                        dateRelationDictionaryList.Add(dateRelationDictionary);
                    }
                    
                }     
            }

            //printThisTaskDateRelation(dateRelationDictionaryList);
            transmitData.dateRelationDictionaryList = dateRelationDictionaryList;
            this.Close();
        }

        private void printThisTaskDateRelation(List<DateRelationDictionary> dateRelationDictionaryList)
        {
            string str = "";

            foreach(DateRelationDictionary dateRelationDictionary in dateRelationDictionaryList)
            {
                str += dateRelationDictionary.variableName+"!";
                foreach (KeyValuePair<float, float> kvp in dateRelationDictionary)
                {
                    str += kvp.Key + "," + kvp.Value + ";";
                }
                str += "\n";
            }
            DialogResult dr1 = MessageBox.Show(str, "message");
        }

    }
}
