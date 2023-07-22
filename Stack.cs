using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    internal class Stack
    {
        private List<string> _list = new();
        public Stack(params string[] str)
        {
            _list=str.ToList();
        }

        public void Add(string str)
        {
            _list.Add(str); 
        }

        public string Pop()
        {
            if (_list.Count == 0)
                throw new Exception("Стек пустой");
            var s=_list.Last();
            _list.RemoveAt(_list.Count - 1);
            return s;
        }

        public int Size
        {
            get { return _list.Count; }
        }

        public string Top
        {
            get 
            {
                if (_list.Count != 0)
                    return _list[_list.Count - 1];
                else return null;
            }    
        }
    }
}
