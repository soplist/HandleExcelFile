using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class DateRelationDictionary : Dictionary<float, float>
    {
        private string _name;
        private string _variableName;

        public string variableName
        {
            set { _variableName = value; }
            get { return _variableName; }
        }

        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
    }
}
