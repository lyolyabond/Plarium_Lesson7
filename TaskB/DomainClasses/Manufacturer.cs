using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    //Класс производителя сувениров
    class Manufacturer
    {
        public event EventHandler <EventDelegate.KeyEventArgs> ManufacturerRemoved;
        //Инициализирующий конструктор
        public Manufacturer(string manufacturerName, string manufacturerCountry)
        {
            ManufacturerName = manufacturerName;
            ManufacturerCountry = manufacturerCountry;
        }
        //Конструктор по умолчанию
        public Manufacturer()
        { }
        public string ManufacturerName { get; }
        public string ManufacturerCountry { get; }
        public void DisplayInformationManufacturer()
        {
            Console.WriteLine($"Название производителя: {ManufacturerName}");
            Console.WriteLine($"Страна производителя: {ManufacturerCountry}");
            Console.WriteLine("--------------------------\n");
        }

        //Метод вызывает событие
        protected virtual void OnManufacturerRemoved(EventDelegate.KeyEventArgs e)
        {
            var temp = ManufacturerRemoved;
            //Вызов события, проверка на null перед вызовом
            temp?.Invoke(this, e);
        }
        public void RemoveManufacturer(int key)
        {
            var e = new EventDelegate.KeyEventArgs(key);
            OnManufacturerRemoved(e);
        }

    }
}
