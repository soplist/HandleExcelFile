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
    public partial class EditFormulaForm : Form
    {
        private TransmitData transmitData;
        private LoadGlobalChineseCharacters loadGlobalChineseCharacters;

        public EditFormulaForm(TransmitData transmitData)
        {
            InitializeComponent();
            this.transmitData = transmitData;
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            initUI();
        }
        public EditFormulaForm()
        {
            InitializeComponent();
        }

        private void initUI()
        {
            calculateButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["calculate"];
            CalculateDependentVariablesGroupBox.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["calculateDependentVariables"];
            initCalculateDependentVariablesUI();
        }

        private void initCalculateDependentVariablesUI()
        {
            string labelStr = "";
            foreach(string column in transmitData.selectedColumn)
            {
                if (!transmitData.columnTypeDict[column].Equals(ColumnType.dateTypeString))
                {
                    labelStr += column + ":" + transmitData.selectedColumnVariableDict[column]+",";
                }
            }

            foreach (DateRelationDictionary dic in transmitData.dateRelationDictionaryList)
            {
                labelStr += dic.name + ":" + dic.variableName;
            }

            variablesLabel.Text = labelStr;
            
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
