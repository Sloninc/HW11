//#define isList
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW11
{

    public class Stack
    {

#if isList
        private List<string> _list = new();
#else
        private StackItem _stackItem;
        private int _stackItemCount = 0;
#endif
        public Stack(params string[] str)
        {
#if isList
            _list = str.ToList();
#else
            foreach (var item in str)
                Add(item);
#endif
        }

        public void Add(string str)
        {
#if isList
            _list.Add(str);
#else
            _stackItem = new StackItem(str,_stackItem);
            _stackItemCount++;  
#endif
        }

        public string Pop()
        {
#if isList
            if (_list.Count == 0)
                throw new Exception("Стек пустой");
            var s = _list.Last();
            _list.RemoveAt(_list.Count - 1);
            return s;
#else
            if (_stackItemCount == 0)
                throw new Exception("Стек пустой");
            var s = _stackItem.Str;
            _stackItem = _stackItem.PreviousStackItem;
            _stackItemCount--;
            return s;
#endif
        }

        public int Size
        {
#if isList
            get { return _list.Count; }
#else
            get { return _stackItemCount; }
#endif
        }

        public string Top
        {
            get 
            {
#if isList
                if (_list.Count != 0)
                    return _list[_list.Count - 1];
                else return null;
#else
                if (_stackItemCount != 0)
                    return _stackItem.Str;
                else return null;
#endif
            }
        }
        public void Show()
        {
            Console.Write("Элементы стека: ");
#if isList
            foreach (var item in _list)
                Console.Write(item + "  ");
            System.Console.WriteLine("   реализация с помощью коллекции List<string>");
#else
            ShowStackItem(_stackItem);
            System.Console.WriteLine("   реализация с помощью nested класса StackItem");
#endif
        }
        private void ShowStackItem(StackItem stackItem)
        {
            if(stackItem?.PreviousStackItem != null)
                ShowStackItem(stackItem.PreviousStackItem);
            Console.Write(stackItem?.Str+"  ");
        }
        public static Stack Concat(params Stack[] stacks)
        {
            var stk = new Stack();
            foreach (var item in stacks)
            {
                var size = item.Size;
                for (int i = 0; i < size; i++)
                    stk.Add(item.Pop());
            }
            return stk;
        }
        private class StackItem
        {
            StackItem _previousStackItem;
            string _str;
            public StackItem(string str, StackItem previousStackItem)
            {
                _str = str;
                _previousStackItem = previousStackItem;
            }
            public string Str
            {
                get
                {
                    return _str;
                }
            }
            public StackItem PreviousStackItem
            {
                get
                {
                    return _previousStackItem;
                }
            }
        }
    }
}
