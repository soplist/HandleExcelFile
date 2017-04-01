using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class TransmitData
    {
        private DataTable _dataTable;
        private List<string> _columnsNameList;
        private Dictionary<string, string> _columnTypeDict;
        private List<Column<string>> _noRepeatingColumnList;
        private List<string> _selectedColumn;
        private Dictionary<string, char> _selectedColumnVariableDict;
        private List<DateRelationDictionary> _dateRelationDictionaryList;

        private static string dataTableStr = "dataTable";
        private static string columnsNameListStr = "columnsNameList";
        private static string columnTypeDictStr = "columnTypeDict";
        private static string noRepeatingColumnListStr = "noRepeatingColumnList";
        private static string selectedColumnStr = "selectedColumn";

        public TransmitData() 
        { 
        }

        public TransmitData(DataTable _dataTable, List<string> _columnsNameList, Dictionary<string, string> _columnTypeDict, List<Column<string>> _noRepeatingColumnList)
        {
            this._dataTable = _dataTable;
            this._columnsNameList = _columnsNameList;
            this._columnTypeDict = _columnTypeDict;
            this._noRepeatingColumnList = _noRepeatingColumnList;
        }

        public DataTable dataTable
        {
            set { _dataTable = value; }
            get { return _dataTable; }
        }

        public List<string> columnsNameList
        {
            set { _columnsNameList = value; }
            get { return _columnsNameList; }
        }

        public Dictionary<string, string> columnTypeDict
        {
            set { _columnTypeDict = value; }
            get { return _columnTypeDict; }
        }

        public List<Column<string>> noRepeatingColumnList
        {
            set { _noRepeatingColumnList = value; }
            get { return _noRepeatingColumnList; }
        }

        public List<string> selectedColumn
        {
            set { _selectedColumn = value; }
            get { return _selectedColumn; }
        }

        public Dictionary<string, char> selectedColumnVariableDict
        {
            set { _selectedColumnVariableDict = value; }
            get { return _selectedColumnVariableDict; }
        }

        public List<DateRelationDictionary> dateRelationDictionaryList
        {
            set { _dateRelationDictionaryList = value; }
            get { return _dateRelationDictionaryList; }
        }

        public void setNull(string propertyName)
        {
            if (propertyName.Equals(dataTableStr)) 
            {
                _dataTable = null;
            }
            else if (propertyName.Equals(columnsNameListStr))
            {
                _columnsNameList = null;
            }
            else if (propertyName.Equals(columnTypeDictStr))
            {
                _columnTypeDict = null;
            }
            else if (propertyName.Equals(noRepeatingColumnListStr))
            {
                _noRepeatingColumnList = null;
            }
            else if (propertyName.Equals(selectedColumnStr))
            {
                _selectedColumn = null;
            }
        }
    }
}
