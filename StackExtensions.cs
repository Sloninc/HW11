using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW11
{
    public static class StackExtensions
    {
        public static void Merge(this Stack stack1, Stack stack2)
        {
            var size=stack2.Size;
            for(int i = 0; i < size; i++)
            {
                stack1.Add(stack2.Pop());
            }
            //return stack1;  
        }
    }
}
