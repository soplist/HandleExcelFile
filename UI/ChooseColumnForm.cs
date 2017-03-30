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
    public partial class ChooseColumnForm : Form
    {
        private LoadGlobalChineseCharacters loadGlobalChineseCharacters;
        private TransmitData transmitData;

        public ChooseColumnForm()
        {
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            InitializeComponent();
            initUI();
        }

        public ChooseColumnForm(TransmitData transmitData)
        {
            this.transmitData = transmitData;
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            InitializeComponent();
            initUI();
            addColumnCheckBox(transmitData.columnsNameList, transmitData.columnTypeDict);
            clearNotNeedData(transmitData);
        }

        public void clearNotNeedData(TransmitData transmitData)
        {
            transmitData.dataTable = null;
        }

        private void initUI()
        {
            OKbutton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["ok"];
            cancelButton.Text = loadGlobalChineseCharacters.GlobalChineseCharactersDict["cancel"];
        }

        private void addColumnCheckBox(List<string> columnsNameList, Dictionary<string, string> columnTypeDict) 
        {
            // 
            // checkBox1
            // 
            int loopMark = 1;
            foreach (string columnName in columnsNameList)
            {
                System.Windows.Forms.CheckBox checkBox = new System.Windows.Forms.CheckBox();;
                checkBox.AutoSize = true;
                checkBox.Location = new System.Drawing.Point(28, 17 * loopMark);
                checkBox.Name = columnName;
                checkBox.Size = new System.Drawing.Size(78, 16);
                checkBox.TabIndex = 0;
                checkBox.Text = columnName + "(" + columnTypeDict[columnName] + ")";
                checkBox.UseVisualStyleBackColor = true;
                loopMark++;
                this.columnListPanel.Controls.Add(checkBox);
            }
            
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            List<string> selected = searchCheckedCheckBox();
            this.transmitData.selectedColumn = selected;
            AssignmentForm assignmentForm = new AssignmentForm(transmitData);
            assignmentForm.Show();
        }

        private List<string> searchCheckedCheckBox()
        {
            List<string> selected = new List<string>();
            foreach (Control cl in columnListPanel.Controls)
            {
                if (cl is CheckBox)
                {
                    CheckBox ck = cl as CheckBox;
                    if (ck.Checked)
                    {
                        selected.Add(ck.Name);
                    }
                }
            }
            return selected;
        }

        private void showMessage(List<string> list)
        {
            string str = "";
            foreach(string cell in list)
            {
                str += cell + ",";
            }
            DialogResult dr1 = MessageBox.Show(str, "message");
        }

        private void showMessage(string message)
        {
            DialogResult dr1 = MessageBox.Show(message, "message");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void columnListPanel_ControlAdded(object sender, ControlEventArgs e)
        {
            columnListPanel.VerticalScroll.Enabled = true;
            columnListPanel.VerticalScroll.Visible = true;
            columnListPanel.Scroll += new ScrollEventHandler(columnListPanel_Scroll);
        }

        private void columnListPanel_Scroll(object sender, ScrollEventArgs e)
        {
            columnListPanel.VerticalScroll.Value = e.NewValue;
        }


    }
}
