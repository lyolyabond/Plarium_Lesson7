using System;

namespace TaskA
{
    class Program
    {
        //Метод для вызова события
        static void EventCall(out char ch, KeyEvent keyEvent)
        {
            //Установка курсора для ввода символа
            Console.SetCursorPosition(CountingClass.Count, 1);
            //Получает символ, соответствующий заданной клавише
            ch = Console.ReadKey().KeyChar;
            //Вызов события в методе, передача введённого символа
            keyEvent.NewKey(ch);
        }

        static void Main(string[] args)
        {
            KeyEvent keyEvent = new KeyEvent();
            MessageClass messageClass = new MessageClass();
            
            //Добавление обработчиков событий
            keyEvent.KeyPress += CountingClass.Counting;
            keyEvent.KeyPress += messageClass.Message;
            Console.WriteLine("Введите несколько символов. Для останова введите точку.");

            char ch;
            //Работа цикла до ввода точки
            do
            {
                EventCall(out ch, keyEvent);
            } while (ch != '.');

            Console.WriteLine($"Было нажато {CountingClass.Count} клавиш.");
        }
    }
}
