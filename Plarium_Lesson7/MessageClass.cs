using System;
using System.Collections.Generic;
using System.Text;

namespace TaskA
{
    class MessageClass
    {
        //Обработчик события выводит сообщение и поступивший символ
        public void Message(object source, KeyEventArgs arg)
        {
            //Установка позиции курсора
            Console.SetCursorPosition(0, CountingClass.Count + 1);
            Console.WriteLine($"Получено сообщение о нажатии клавиши: {arg.ch}");
        }
    }
}
