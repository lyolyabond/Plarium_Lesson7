using System;
using System.Collections.Generic;
using System.Text;

namespace TaskB
{
    class Menu
    {
        public static void ConsoleMenu()
        {
            var eventDelete = new Manufacturer();
            //Подписка на событие
            eventDelete.ManufacturerRemoved += AddDelete.collectionClass.DeleteObjectsByKey;

            bool flag = false;
            //Делегат, который указывает на метод изменение цены
            EventDelegate.PriceChangeDelegate priceChangeDelegate = Function.PriceChange;
            //Добавление метода в делегат
            priceChangeDelegate += Function.PriceChangeNotification;
            //Делегат, который будет указывать на метод сортировки
            EventDelegate.SortDelegate sortDelegate;
            
            int choice;
            do
            {
                Console.WriteLine("--Выберите, какое действие хотите совершить--");
                Console.WriteLine("0 - Добавить сувенир\n1 - Вывести информацию о сувенирах заданного производителя " +
                    " \n2 - Вывести информацию о сувенирах, произведенных в заданной стране " +
                    " \n3 - Вывести информацию о производителях, чьи цены на сувениры меньше заданной " +
                    "\n4 - Вывести информацию о производителях заданного сувенира, произведенного в заданном году " +
                    "\n5 - Удалить заданного производителя и его сувениры \n6 - Вывести информацию о сувенирах " +
                    "\n7 - Изменить цену сувенира по ID\n8 - Очистить все колекции" +
                    "\n9 - Отсортировать список сувениров по цене\n10 - Отсортировать список сувениров по названию" +
                    "\n11 - выйти\n");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 0:
                        Console.Clear();
                        Menu.EnterInformation();
                        break;
                    case 1:
                        Console.Clear();
                        Function.DisplayInformationByManufacturer();
                        break;
                    case 2:
                        Console.Clear();
                        Function.DisplayInformationByCountry();
                        break;
                    case 3:
                        Console.Clear();
                        Function.DisplayInformationByPrice();
                        break;
                    case 4:
                        Console.Clear();
                        Function.DisplayInformationByDate();
                        break;
                    case 5:
                        Console.Clear();
                        AddDelete.DeleteItemByManufacturer(eventDelete);
                        break;
                    case 6:
                        Console.Clear();
                        Function.DisplayAllInformation();
                        break;
                    case 7:
                        Console.Clear();
                        priceChangeDelegate(ref flag);
                        flag = false;
                        break;
                    case 8:
                        Console.Clear();
                        AddDelete.ClearCollections();
                        break;
                    case 9:
                       Console.Clear();
                        sortDelegate = AddDelete.collectionClass.SortByPrice;
                        Function.SortList(sortDelegate);
                        break;
                    case 10:
                        Console.Clear();
                        sortDelegate = AddDelete.collectionClass.SortBySouvenirName;
                        Function.SortList(sortDelegate);
                        break;

                    default: break;
                }
            } while (choice != 11);
        }

        //Метод для выбора типа сувенира
        public static Souvenir ChooseTypeOfSouvenir()
        {
            Console.WriteLine("Выберите вид сувенира: ");
            Console.WriteLine("1 - Бизнес-сувенир\n2 - Промосувенир\n3 - Тематический сувенир\n4 - VIP сувенир");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.Write("Введите число 1-4: ");
            }
            switch (choice)
            {
                case 1:
                    BusinessSouvenir souvenir1 = new BusinessSouvenir();
                    Console.Write("Введите название компании, в которой дарят сувениры: ");
                    souvenir1.CompanyName = Console.ReadLine();
                    return souvenir1;
                case 2:
                    PromotionalSouvenir souvenir2 = new PromotionalSouvenir();
                    Console.Write("Введите название компании, рекламная кампания которой проходит: ");
                    souvenir2.CompanyName = Console.ReadLine();
                    return souvenir2;
                case 3:
                    ThematicSouvenir souvenir3 = new ThematicSouvenir();
                    Console.Write("Введите название тематики сувенира: ");
                    souvenir3.SubjectMatter = Console.ReadLine();
                    return souvenir3;
                case 4:
                    VIPGift souvenir4 = new VIPGift();
                    Console.Write("Введите название повода для подарка: ");
                    souvenir4.Occasion = Console.ReadLine();
                    return souvenir4;
                default:
                    return null;
            }
        }
    

    //Метод ввода информации о сувенире
    public static void EnterInformation()
    {
        Souvenir souvenir = ChooseTypeOfSouvenir();
        if (souvenir != null)
        {
            souvenir.SouvenirName = Input.InputSouvenirName();
            souvenir.ReleaseDate = Input.InputReleaseDate();
            souvenir.Price = Input.InputPrice();

            //Добавление сувенира в список
           AddDelete.collectionClass.Add(souvenir);
           //Добавление производителя в словарь 
           AddDelete.AddManufacturer(new Manufacturer(Input.InputManufacturerName(), Input.InputManufacturerCountry()));
           Console.WriteLine("--------------------------");
           Console.Clear();
        }
    }
        
   }
}
