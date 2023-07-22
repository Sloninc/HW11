using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    public class Stack
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
        public void Show()
        {
            Console.Write("Элементы стека: ");
            foreach (var item in _list)
                Console.Write(item + "  ");
        }
        public static Stack Concat(params Stack[] stacks)
        {
            var stk = new Stack();
            foreach (var item in stacks)
            {
                var size=item.Size;
                for (int i = 0; i < size; i++)
                    stk.Add(item.Pop());
            }
            return stk;
        }
    }
}
