using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class HandleData
    {
        public List<Column<string>> filterRepeatingData(DataTable dataTable)
        {
            List<Column<string>> columnList = new List<Column<string>>();
            foreach (DataColumn dc in dataTable.Columns)
            {
                Column<string> column = new Column<string>(dc.ColumnName);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    bool cellExistInColumn = false;
                    string cell = dataTable.Rows[i][dc.ColumnName].ToString().Trim();
                    foreach (string cellValue in column) 
                    {
                        if (cellValue.Equals(cell))
                            cellExistInColumn = true;
                    }

                    if (!cellExistInColumn && !cell.Equals(PatternMatchingString.emptyString))
                        column.Add(cell);
                }
                columnList.Add(column);
            }
            return columnList;
        }

        public string getColumnListString(List<Column<string>> columnList)
        {
            string columnStr = "";
            foreach (Column<string> column in columnList)
            {
                columnStr += column.columnName + ":";
                foreach (string cell in column)
                {
                    columnStr += cell + ",";
                }
                columnStr += ";\n";
            }
            return columnStr;
        }
    }
}
