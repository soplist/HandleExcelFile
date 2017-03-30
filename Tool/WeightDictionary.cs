using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class WeightDictionary : Dictionary<string, float>
    {
        private string _columnName;
        private string _variableName;

        public string columnName
        {
            set { _columnName = value; }
            get { return _columnName; }
        }

        public string variableName
        {
            set { _variableName = value; }
            get { return _variableName; }
        }
    }
}
