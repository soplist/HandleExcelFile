using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        public SetDateTypeParameterForm()
        {
            InitializeComponent();
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            initUI();
        }

        public SetDateTypeParameterForm(TransmitData transmitData)
        {
            InitializeComponent();
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            this.selectColumnList = transmitData.selectedColumn;
            this.columnTypeDict = transmitData.columnTypeDict;
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
            RelationColumnContentGroupBox.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationColumnContent"];
            initDateTypeCheckBox();
            initTwoColumnBeRelatedCheckedListBox();
            
        }

        private void initTwoColumnBeRelatedCheckedListBox()
        {
            for (int i = 0; i < relationContainerList.Count; i++)
            {
                CheckBox TwoDateColumnRelationCheckBox = new CheckBox();
                TwoDateColumnRelationCheckBox.Text = relationContainerList[i][0] + "-" + relationContainerList[i][1];
                TwoDateColumnRelationCheckBox.Width = 150;
                TwoDateColumnRelationCheckBox.Location = new Point(10, 10 + i * 30);
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
                TwoDateColumnRelationContainer<string> newTwoDateColumnRelationContainer = new TwoDateColumnRelationContainer<string>();
                newTwoDateColumnRelationContainer.Add(tmpTwoDateColumnRelationContainer[0]);
                newTwoDateColumnRelationContainer.Add(tmpTwoDateColumnRelationContainer[1]);
                relationContainerList.Add(newTwoDateColumnRelationContainer);
                addRelationExcelFile();
                setExcelDataToCurrentRelationContentDataGridView();
            }
            else
            {
                DialogResult dr1 = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception10"], "exception");
            }
                
        }

        private void setExcelDataToCurrentRelationContentDataGridView()
        {
            InputExcel inputExcel = new InputExcel(relationExcelFolderPath + tmpTwoDateColumnRelationContainer[0] + "-" + tmpTwoDateColumnRelationContainer[1] + ExcelHandle.excelExtensions[0]);
            DataTable dataTable = inputExcel.ExcelToDataTable(loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationContent"], isFirstRowColumn);
            this.currentRelationContentDataGridView.DataSource = dataTable;
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
            TwoColumnBeRelatedCheckedListBox.Controls.Add(TwoDateColumnRelationCheckBox);

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
    }
}
