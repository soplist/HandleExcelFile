using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool
{
    public class TwoDateColumnRelationContainer<T> : List<T>
    {
        private LoadGlobalChineseCharacters loadGlobalChineseCharacters;
        private int _count = 0;
        public static int sizeLimit = 2;

        public TwoDateColumnRelationContainer()
        {
            loadGlobalChineseCharacters = LoadGlobalChineseCharacters.GetInstance();
        }


        public int count
        {
            get { return _count; }
        }

        new public void Add(T t)
        {
            if (count < sizeLimit)
            {
                base.Add(t);
                _count++;
            }
            else
            {
                throw new Exception(loadGlobalChineseCharacters.GlobalChineseCharactersDict["exception9"]);
            }
        }

        new public void Remove(T t)
        {
            base.Remove(t);
            _count--;
        } 
    }
}
