using System;
using System.Collections.Generic;
using System.Text;

namespace Modelirovanie
{

    class MyOwnStak
    {
        List<char> list = new List<char>();
        int count = 15;
        public MyOwnStak(int length)
        {
            count = length;
            int i = 0;
            while (i <= count)
            {
                list.Add('\0');
                i++;
            }
        }
        public void Push(int index,char data)
        {
            if (index + 1 < count)
            {
                list[count - 1 - index] = data;
            }
        }
        public char Peek(int index)
        {
            return list[count-1 - index];
        }
        public void clearStack()
        {
            int i = 0;
            while (i <= count)
            {
                list.Add('\0');
                i++;
            }
        }
    }
}
