using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class Column<T> : List<T>
    {
        private string _columnName;
        public Column(string columnName)
        {
            this._columnName = columnName;
        }
        public string columnName
        {
            get { return _columnName; }
        }
    }
}
