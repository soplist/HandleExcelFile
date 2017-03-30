using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ColumnType
    {
        private string _columnName;
        private string _columnType;

        public string columnName
        {
            set { _columnName = value; }
            get { return _columnName; }
        }

        public string columnType
        {
            set { _columnType = value; }
            get { return _columnType; }
        }
    }
}
