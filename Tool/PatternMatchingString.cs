using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class PatternMatchingString
    {
        public static string emptyString = "";
        public static string dateRegStr = @"^(([1-2]\d{3})[-/](\d|\d\d)[-/](\d|\d\d))$|^(\d{8})$|\s|^$";
        public static string numberRegStr = @"(^[+-]?\d*[.]?\d*$)|\s|^$";
        public static string numberRegStr_1 = @"(^[+-]?\d*[.]?\d*$)";
    }
}
