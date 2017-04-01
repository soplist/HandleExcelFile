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
    public partial class AssignmentForm : Form
    {
        private LoadGlobalChineseCharacters loadGlobalChineseCharacters;
        private TransmitData transmitData;
        private List<string> selectedColumnList;
        private Dictionary<string, char> selectedColumnVariableDict;
        private Dictionary<int, int> weightRelation;
        private List<WeightDictionary> allStringWeightList;
        private Dictionary<int, string> weightAndColumnNameRelation;

        private int startASCII = 65;
        private int endASCII = 122;
        private bool weightAndColumnNameRelationIndexConverted = false;
        //private int 

        private static int Z_ASCII = 90;
        private static int intervalZ_a = 7;
        private static int oneStringLength = 86;
        private static int oneStringHeight = 33;

        public AssignmentForm()
        {
            InitializeComponent();
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            initUI();
        }

        public AssignmentForm(TransmitData transmitData)
        {
            this.transmitData = transmitData;
            selectedColumnList = transmitData.selectedColumn;
            InitializeComponent();
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            this.selectedColumnVariableDict = assignVariableName();
            this.weightRelation = new Dictionary<int, int>();
            this.weightAndColumnNameRelation = new Dictionary<int, string>();
            initUI();
            initDataGridView();
            clearNotNeedData(transmitData);
            transmitData.selectedColumnVariableDict = this.selectedColumnVariableDict;
        }

        public void clearNotNeedData(TransmitData transmitData)
        {
            
        }

        public DataTable convertNoRepeatingColumnListToDataTable(List<Column<string>> noRepeatingColumnList, List<string> selected)
        {
            DataTable dt = new DataTable("columnNoRepeatingData");

            foreach (string col in selected)
            {
                DataColumn dc = new DataColumn(col, Type.GetType("System.String"));
                dt.Columns.Add(dc);
            }

            int columnMaxSize = getColumnMaxSize(noRepeatingColumnList);
            for(int i = 0;i < columnMaxSize; i++) 
            {
                DataRow dr = dt.NewRow();
                foreach (Column<string> col in noRepeatingColumnList)
                {
                    if (selected.Contains(col.columnName))
                    {
                        if (i < col.Count)
                        {
                            dr[col.columnName] = col[i];
                        }
                        else
                        {
                            dr[col.columnName] = "";
                        }
                    }
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        public int getColumnMaxSize(List<Column<string>> noRepeatingColumnList)
        {
            int columnSize = 0;
            foreach (Column<string> col in noRepeatingColumnList)
            {
                if (columnSize < col.Count)
                    columnSize = col.Count;
                 
            }
            return columnSize;
        }

        private Dictionary<string, char> assignVariableName()
        {
            Dictionary<string, char> selectedColumnAndVariableNameDict = new Dictionary<string, char>();

            int cursorASCII = startASCII;
            foreach (string select in selectedColumnList)
            {
                
                if (cursorASCII > endASCII)
                {
                    throw new Exception(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception8"]);
                }
                selectedColumnAndVariableNameDict.Add(select, (char)cursorASCII);
                if (cursorASCII == Z_ASCII)
                {
                    cursorASCII += intervalZ_a;
                }
                else
                {
                    cursorASCII++;
                }

            }

            return selectedColumnAndVariableNameDict;
        }


        private void initUI()
        {
            OKButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["ok"];
            cancelButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["cancel"];
            SetWeightButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["setWeightValue"];
            variableGroupBox.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["columnVariableName"];
            SetDateTypeParameterButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["setDateTypeParameter"];
            columnVariableLabel.Text = mosaicColumnVariableLabelStr();
            variableGroupBox.Height = (int)(oneStringHeight * Math.Ceiling((double)mosaicColumnVariableLabelStr().Length / oneStringLength));//* Math.Ceiling((double)mosaicColumnVariableLabelStr().Length / 86)
        }

        private void setCanNotEditColumn(DataTable dt)
        {
            foreach (DataColumn dc in dt.Columns)
            {
                dc.ReadOnly = true;
            }
        }

        private void setCanNotSort()
        {
            for(int i = 0;i < selectedColumnDataGridView.ColumnCount;i++)
            {
                selectedColumnDataGridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void initDataGridView()
        {
            DataTable dt = convertNoRepeatingColumnListToDataTable(transmitData.noRepeatingColumnList, transmitData.selectedColumn);
            this.selectedColumnDataGridView.DataSource = dt;
            setCanNotEditColumn(dt);
            initWeightColumn(dt, transmitData.selectedColumn, transmitData.columnTypeDict);
            setCanNotSort();
        }

        private void initWeightColumn(DataTable dt, List<string> selectedColumn, Dictionary<string, string> columnTypeDict)
        {
            int displayIndexIncrement = 1;
            foreach (string column in selectedColumn)
            {
                int index = dt.Columns.IndexOf(column);
                int displayIndex = index + displayIndexIncrement;
                if (columnTypeDict[column].Equals(Tool.ColumnType.stringTypeString)) 
                {
                    DataGridViewTextBoxColumn tbc = new DataGridViewTextBoxColumn();
                    tbc.DisplayIndex = displayIndex;
                    tbc.HeaderText = column + loadGlobalChineseCharacters.GlobalChineseCharactersDict["weight"];
                    tbc.ReadOnly = false;
                    
                    this.selectedColumnDataGridView.Columns.Add(tbc);
                    //DialogResult dr1 = MessageBox.Show("" + tbc.Index, "index");
                    weightRelation.Add(tbc.Index, index);
                    weightAndColumnNameRelation.Add(tbc.Index,column);
                    displayIndexIncrement++;
                }
            }
        }


        private string mosaicColumnVariableLabelStr()
        {
            string str = "";

            foreach (KeyValuePair<String, char> kvp in selectedColumnVariableDict)
            {
                str += kvp.Key + ":" + kvp.Value + ".   ";
            }

            return str;
        }


        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            //printSelectedColumnVariableDict();
            //printThisTaskDateRelation(transmitData.dateRelationDictionaryList);

            EditFormulaForm editFormulaForm = new EditFormulaForm(transmitData);
            editFormulaForm.Show();
        }

        private void printThisTaskDateRelation(List<DateRelationDictionary> dateRelationDictionaryList)
        {
            string str = "";

            foreach (DateRelationDictionary dateRelationDictionary in dateRelationDictionaryList)
            {
                str += dateRelationDictionary.variableName + "!";
                foreach (KeyValuePair<float, float> kvp in dateRelationDictionary)
                {
                    str += kvp.Key + "," + kvp.Value + ";";
                }
                str += "\n";
            }
            DialogResult dr1 = MessageBox.Show(str, "message");
        }

        private void printSelectedColumnVariableDict()
        {
            string str = "";

            foreach (KeyValuePair<String, char> kvp in selectedColumnVariableDict)
            {
                str += kvp.Key + ":" + kvp.Value + "," ;
            }

            DialogResult dr1 = MessageBox.Show(str, "message");
        }

        private void selectedColumnDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = this.selectedColumnDataGridView.CurrentCell.RowIndex;
            int col = this.selectedColumnDataGridView.CurrentCell.ColumnIndex;

            //string context = selectedColumnDataGridView.Rows[row].Cells[col - 1].Value.ToString();
            //int relationColumnIndex = weightRelation[col+transmitData.selectedColumn.Count];
            //int realColumnIndex = relationColumnIndex + weightRelation.Count;
            //string context = selectedColumnDataGridView.Rows[row].Cells[realColumnIndex].Value.ToString();

            Dictionary<int, int> weightRelation = convertColumnIndex(this.weightRelation);
            string context = selectedColumnDataGridView.Rows[row].Cells[weightRelation[col]].Value.ToString();
            if (context.Equals(""))
            {
                e.Cancel = true;
                DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["weightRelationCellVallEmpty"], "message");
            }
            
            //DialogResult dr1 = MessageBox.Show(row+","+col, "message");
            //DialogResult dr1 = MessageBox.Show(relationColumnIndex+"", "message");
            //e.Cancel = true;
        }

        private Dictionary<int, int> convertColumnIndex(Dictionary<int, int> weightRelation)
        {
            int selectColumnIndexChangeQuantity = transmitData.selectedColumn.Count;
            int insertColumnIndexChangeQuantity = weightRelation.Count;

            Dictionary<int, int> newWeightRelation = new Dictionary<int, int>();
            foreach (KeyValuePair<int, int> kvp in weightRelation)
            {
                //weightRelation.Add(kvp.Key - selectColumnIndexChangeQuantity, kvp.Value - insertColumnIndexChangeQuantity);
                //weightRelation.Remove(kvp.Key);
                newWeightRelation.Add(kvp.Key - selectColumnIndexChangeQuantity, kvp.Value + insertColumnIndexChangeQuantity);
            }

            //convertWeightAndColumnNameRelationIndex();

            return newWeightRelation;

        }

        private void convertWeightAndColumnNameRelationIndex()
        {
            int selectColumnIndexChangeQuantity = transmitData.selectedColumn.Count;
            Dictionary<int, string> newWeightAndColumnNameRelation = new Dictionary<int, string>();

            foreach (KeyValuePair<int, string> kvp in weightAndColumnNameRelation)
            {
                newWeightAndColumnNameRelation.Add(kvp.Key - selectColumnIndexChangeQuantity,kvp.Value);
            }

            this.weightAndColumnNameRelation = newWeightAndColumnNameRelation;
        }

        private void selectedColumnDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = this.selectedColumnDataGridView.CurrentCell.RowIndex;
            int col = this.selectedColumnDataGridView.CurrentCell.ColumnIndex;

            if (selectedColumnDataGridView.Rows[row].Cells[col].Value != null)
            {
                string context = selectedColumnDataGridView.Rows[row].Cells[col].Value.ToString();
                bool isNumber = Regex.IsMatch(context, PatternMatchingString.numberRegStr_1);

                if (!isNumber)
                {
                    DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["mustNumber"], "message");
                    //this.selectedColumnDataGridView.Rows[row].Cells[col].Selected = true;
                    //this.selectedColumnDataGridView.BeginEdit(true);
                    this.selectedColumnDataGridView.Rows[row].Cells[col].Value = "";
                }
            }
            
        }

        private void SetWeightButton_Click(object sender, EventArgs e)
        {
            this.allStringWeightList = new List<WeightDictionary>();
            Dictionary<int, int> weightRelation = convertColumnIndex(this.weightRelation);
            if (!weightAndColumnNameRelationIndexConverted)
            {
                convertWeightAndColumnNameRelationIndex();
                this.weightAndColumnNameRelationIndexConverted = true;
            }
            
            foreach (KeyValuePair<int, int> kvp in weightRelation)
            {
                WeightDictionary weightDict = new WeightDictionary();
                int weightValueColumn = kvp.Key;
                int weightNameColumn = kvp.Value;

                weightDict.columnName = weightAndColumnNameRelation[weightValueColumn];
                weightDict.variableName = selectedColumnVariableDict[weightAndColumnNameRelation[weightValueColumn]].ToString();

                for (int i = 0; i < this.selectedColumnDataGridView.Rows.Count; i++)
                {
                    if (!selectedColumnDataGridView.Rows[i].Cells[weightNameColumn].Value.ToString().Equals("") && selectedColumnDataGridView.Rows[i].Cells[weightValueColumn].Value == null)
                    {
                        DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["error_1"] + "," + weightAndColumnNameRelation[weightValueColumn] + loadGlobalChineseCharacters.GlobalChineseCharactersDict["weight"] + ":" + (i + 1) + loadGlobalChineseCharacters.GlobalChineseCharactersDict["row"], "message");
                        return;
                    }
                    else if (selectedColumnDataGridView.Rows[i].Cells[weightNameColumn].Value.ToString().Equals("") && selectedColumnDataGridView.Rows[i].Cells[weightValueColumn].Value == null)
                    {
                        break;
                    }
                    else if (!selectedColumnDataGridView.Rows[i].Cells[weightNameColumn].Value.ToString().Equals("") && selectedColumnDataGridView.Rows[i].Cells[weightValueColumn].Value != null)
                    {
                        string valueStr = selectedColumnDataGridView.Rows[i].Cells[weightValueColumn].Value.ToString();
                        float value = Convert.ToSingle(valueStr);
                        string name = selectedColumnDataGridView.Rows[i].Cells[weightNameColumn].Value.ToString();
                        weightDict.Add(name, value);
                    }
                    
                    
                }
                allStringWeightList.Add(weightDict);
            }
            printAllWeightList();
            
        }

        private void printAllWeightList()
        {
            string str = "";
            foreach (WeightDictionary weightDict in allStringWeightList)
            {
                str += weightDict.columnName + "!" + weightDict.variableName + "!";

                foreach (KeyValuePair<string, float> kvp in weightDict)
                {
                    str += kvp.Key + ":" + kvp.Value+";";
                }
                str += "\n";
            }
            DialogResult dr1 = MessageBox.Show(str, "message");
        }

        private void SetDateTypeParameterButton_Click(object sender, EventArgs e)
        {
            SetDateTypeParameterForm setDateTypeParameterForm = new SetDateTypeParameterForm(transmitData);
            setDateTypeParameterForm.Show();
        }
    }
  
}
