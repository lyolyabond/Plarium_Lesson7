using System;
using System.Collections.Generic;
using System.Text;

namespace TaskA
{
    class KeyEvent
    {
        //Определение события
        public event Program.KeyHandler KeyPress;
        public void OnKeyPress(char symbol)
        {
            Program.KeyEventArgs keyEventArgs = new Program.KeyEventArgs();
                keyEventArgs.symbol = symbol;
            //Вызов события, проверка на null перед вызовом
                KeyPress?.Invoke(this, keyEventArgs); 
        }
    }
}
