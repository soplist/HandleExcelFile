using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool;

namespace UI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //convertStringToFormulaCalculate();
            //regularExpression();
            //IsNumeric();
            //voidShowASC2();
            //testStringLength();
            dayInterval();
            
        }

        private void testStringLength()
        {
            LoadGlobalChineseCharacters loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show(loadGlobalChineseCharacters.GlobalChineseCharactersDict["testStringLength"].Length+"", "ASCII", messButton);
        }

        private void testloopAndException()
        {
            try
            {
                loopAndException();
            }
            catch (Exception ex)
            {
                MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show(ex.Message, "Exception", messButton);
            }
        }

        private void loopAndException()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 3)
                {
                    throw new Exception("oops");
                }
                if (i == 4)
                {
                    throw new Exception("oops4");
                }
            }
        }

        private void dayInterval()
        {
            DateTimeFormatInfo dtFormat = new System.Globalization.DateTimeFormatInfo();
            dtFormat.ShortDatePattern = "yyyy-MM-dd";
            DateTime d1 = Convert.ToDateTime("2017-4-29", dtFormat);
            DateTime d2 = Convert.ToDateTime("2017-3-20", dtFormat);
            int days = ((TimeSpan)(d2 - d1)).Days;
            DialogResult dr1 = MessageBox.Show(days + "", "message");
        }

        private void voidShowASC2()
        {
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show(""+(char)97, "ASCII", messButton);
        }

        private void IsNumeric()
        {
            string str1 = "1234567";
            string str2 = "0.125";
            string str3 = "-10.1";
            string str4 = "    ";
            string str5 = "sdfg";
            bool result1 = Regex.IsMatch(str1, @"(^[+-]?\d*[.]?\d*$)|\s*");
            bool result2 = Regex.IsMatch(str2, @"(^[+-]?\d*[.]?\d*$)|\s*");
            bool result3 = Regex.IsMatch(str3, @"(^[+-]?\d*[.]?\d*$)|\s*");
            bool result4 = Regex.IsMatch(str4, @"(^[+-]?\d*[.]?\d*$)|\s*");
            bool result5 = Regex.IsMatch(str5, @"(^[+-]?\d*[.]?\d*$)");
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("str1:" + result1 + ";str2:" + result2 + ";str3:" + result3 + ";str4:" + result4 + ";str5:" + result5, "regular expression result", messButton);
        }

        private void regularExpression()
        {
            string str1 = "2017-3-21";
            string str2 = "2017-03-21";
            string str3 = "2017-12-01";
            string str4 = "2017/3/21";
            string str5 = "2017/03/21";
            string str6 = "2017/12/01";
            string str7 = "20170321";
            string str8 = "fdgdfgdfg";
            string str9 = "    ";
            string str10 = "62001XXXXXXXXXXXXXXX";
            string str11 = "6199979Q11308330356344";
            string str12 = "";
            //Regex reg = new Regex(@"([1-2]\d{3}\-\d|\d\d\-\d|\d\d)|([1-2]\d{3}\/\d|\d\d\/\d|\d\d)|(\d{8})|\s");
            Regex reg = new Regex(@"^(([1-2]\d{3})[-/](\d|\d\d)[-/](\d|\d\d))$|^(\d{8})$|\s|^$");
            Regex reg1 = new Regex(@"\s");
            bool result1 = reg.IsMatch(str1);
            bool result2 = reg.IsMatch(str2);
            bool result3 = reg.IsMatch(str3);
            bool result4 = reg.IsMatch(str4);
            bool result5 = reg.IsMatch(str5);
            bool result6 = reg.IsMatch(str6);
            bool result7 = reg.IsMatch(str7);
            bool result8 = reg.IsMatch(str8);
            bool result9 = reg.IsMatch(str9);
            bool result10 = reg.IsMatch(str10);
            bool result11 = reg.IsMatch(str11);
            bool result12 = reg.IsMatch(str12);
            /*bool result1 = reg1.IsMatch(str1);
            bool result2 = reg1.IsMatch(str2);
            bool result3 = reg1.IsMatch(str3);
            bool result4 = reg1.IsMatch(str4);
            bool result5 = reg1.IsMatch(str5);
            bool result6 = reg1.IsMatch(str6);
            bool result7 = reg1.IsMatch(str7);
            bool result8 = reg1.IsMatch(str8);
            bool result9 = reg1.IsMatch(str9);*/
            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show("str1:" + result1 + ";str2:" + result2 + ";str3:" + result3 + "str4:" + result4 + ";str5:" + result5 + ";str6:" + result6 + ";str7:" + result7 + ";str8:" + result8 + ";str9:" + result9 + ";str10:" + result10 + ";str11:" + result11 + ";str12:" + result12, "regular expression result", messButton);
        }

        private void convertStringToFormulaCalculate() 
        {
            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControlClass();
            sc.Language = "JavaScript";

            MessageBoxButtons messButton = MessageBoxButtons.OKCancel;
            DialogResult dr = MessageBox.Show(sc.Eval("((2*3)-5+(3*4))+6/2").ToString(), "formula result", messButton);
            if (dr == DialogResult.OK)
            {

            }
            else
            {

            }
        }
    }
}
