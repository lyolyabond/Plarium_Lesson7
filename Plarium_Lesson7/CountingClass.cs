using System;
using System.Collections.Generic;
using System.Text;

namespace TaskA
{

    class CountingClass
    {
        public static int Count = 0;
        //Обработчик события считает количество нажатий
        public static void Counting(object source, Program.KeyEventArgs arg) => Count++;
    }
}
