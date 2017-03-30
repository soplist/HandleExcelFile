using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Tool
{
    public class LoadGlobalChineseCharacters
    {
        private static LoadGlobalChineseCharacters instance;
        private static readonly object locker = new object();
        private static string GLOBAL_CHINESE_CHARACTERS_XML_FILE_PATH = "..\\..\\..\\Tool\\GlobalChineseCharacters.xml";
        private static string NODE_NAME = "/strings/string";
        private XmlDocument xml;
        private Dictionary<string, string> _GlobalChineseCharactersDict;
        private LoadGlobalChineseCharacters()
        {
           
        }

        private void init()
        {
            this.xml = new XmlDocument();
            this._GlobalChineseCharactersDict = new Dictionary<string, string>();
        }

        private void packageContent()
        {
            try
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
                if (File.Exists(GLOBAL_CHINESE_CHARACTERS_XML_FILE_PATH))
                {
                    xml.Load(GLOBAL_CHINESE_CHARACTERS_XML_FILE_PATH);
                    XmlNodeList nodelist = xml.SelectNodes(NODE_NAME);
                    if (nodelist != null)
                    {
                        foreach (XmlNode node in nodelist)
                        {
                            string key = node.Attributes["key"].Value;
                            string content = node.InnerText;

                            _GlobalChineseCharactersDict.Add(key, content);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public Dictionary<string, string> GlobalChineseCharactersDict
        {
            set { _GlobalChineseCharactersDict = value; }
            get { return _GlobalChineseCharactersDict; }
        }

        public static LoadGlobalChineseCharacters GetInstance()
        {
            if (instance == null)
　　　　     {
                 lock (locker)
　　　　　　      {
                     if (instance == null)
　　　　　　　　      {
                         instance = new LoadGlobalChineseCharacters();
                         instance.init();
                         instance.packageContent();
　　　　　　　　      }
　　　　　　      }
　　　　     }
            return instance;
        }
    }
}
