using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Tool
{
    public class ExcelHandle
    {
        private static string relationExcelFolderPath = System.Environment.CurrentDirectory + "\\..\\..\\..\\UI\\excel\\";
        public static string[] excelExtensions = new string[] { ".xlsx", ".xls" };
        private LoadGlobalChineseCharacters loadGlobalChineseCharacters;

        public ExcelHandle()
        {
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
        }
            

        public void CreateRelationExcelFile(string FileName)
        {
            //create  
            object Nothing = System.Reflection.Missing.Value;
            var app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook workBook = app.Workbooks.Add(Nothing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workBook.Sheets[1];
            worksheet.Name = loadGlobalChineseCharacters.GlobalChineseCharactersDict["relationContent"];
            //headline  
            worksheet.Cells[1, 1] = loadGlobalChineseCharacters.GlobalChineseCharactersDict["range"];
            worksheet.Cells[1, 2] = loadGlobalChineseCharacters.GlobalChineseCharactersDict["weight"];

            worksheet.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
            workBook.Close(false, Type.Missing, Type.Missing);
            app.Quit();
        }

        public List<TwoDateColumnRelationContainer<string>> getExistRelationFormExistExcel()
        {
            List<TwoDateColumnRelationContainer<string>> relationContainerList = new List<TwoDateColumnRelationContainer<string>>();
            DirectoryInfo TheFolder = new DirectoryInfo(relationExcelFolderPath);
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                if (NextFile.Extension.Equals(excelExtensions[0]) || NextFile.Extension.Equals(excelExtensions[1]))
                {
                    if (NextFile.Extension.Equals(excelExtensions[0]))
                    {
                        string nameWithoutExtension = NextFile.Name.Remove(NextFile.Name.Length - 5, 5);

                        TwoDateColumnRelationContainer<string> twoDateColumnRelationContainer = packageNameWithoutExtension(nameWithoutExtension);

                        relationContainerList.Add(twoDateColumnRelationContainer);
                    }
                    if (NextFile.Extension.Equals(excelExtensions[1]))
                    {
                        string nameWithoutExtension = NextFile.Name.Remove(NextFile.Name.Length - 4, 4);

                        TwoDateColumnRelationContainer<string> twoDateColumnRelationContainer = packageNameWithoutExtension(nameWithoutExtension);

                        relationContainerList.Add(twoDateColumnRelationContainer);
                    }
                }
            }
            return relationContainerList;    
        }

        private TwoDateColumnRelationContainer<string> packageNameWithoutExtension(string nameWithoutExtension)
        {
            string[] relationColumns = nameWithoutExtension.Split(new char[1] { '-' });
            TwoDateColumnRelationContainer<string> twoDateColumnRelationContainer = new TwoDateColumnRelationContainer<string>();
            twoDateColumnRelationContainer.Add(relationColumns[0]);
            twoDateColumnRelationContainer.Add(relationColumns[1]);
            
            return twoDateColumnRelationContainer;
        }

        
    }
}
