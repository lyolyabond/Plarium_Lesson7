using System;

namespace TaskA
{
    class Program
    {
        //Делегат для события
        public delegate void KeyHandler(object source, KeyEventArgs arg);
        //Класс, который хранит код клавиши
        public class KeyEventArgs : EventArgs
        {
            public char symbol;
        }
        //Метод для вызова события
        static void EventCall(KeyEventArgs keyEventArgs, KeyEvent keyEvent)
        {
            //Установка курсора для ввода символа
            Console.SetCursorPosition(CountingClass.Count, 1);
            //Получает символ, соответствующий заданной клавише
            keyEventArgs.symbol = Console.ReadKey().KeyChar;
            //Вызов события в методе, передача введённого символа
            keyEvent.OnKeyPress(keyEventArgs.symbol);
        }



        static void Main(string[] args)
        {
            KeyEvent keyEvent = new KeyEvent();
            KeyEventArgs keyEventArgs = new KeyEventArgs();
            MessageClass messageClass = new MessageClass();
            
            //Добавление обработчиков событий
            keyEvent.KeyPress += CountingClass.Counting;
            keyEvent.KeyPress += messageClass.Message;
            Console.WriteLine("Введите несколько символов. Для останова введите точку.");
        
            //Работа цикла до ввода точки
            do
            {
                EventCall(keyEventArgs, keyEvent);
            } while (keyEventArgs.symbol != '.');

            Console.WriteLine($"Было нажато {CountingClass.Count} клавиш.");

        }
    }
}
