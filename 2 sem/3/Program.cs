using System;

namespace ИниСП_Лаб._3
{
    class Program
    {
        private static LinkedList myList = new LinkedList();
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                MainMenu();
                char ch = Console.ReadLine()[0];
                Console.Clear();
                switch (ch)
                {
                    case '1':
                        AddMenu();
                        break;
                    case '2':
                        FindMenu();
                        break;
                    case '3':
                        SortMenu();
                        break;
                    case '4':
                        PrintMenu();
                        break;
                    case '5':
                        ArrayMenu();
                        break;
                    case '0':
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод");
                        break;
                }
            }
            myList.Head.PrintListFromHead();
        }

        public static void MainMenu()
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1. Добавить");
            Console.WriteLine("2. Найти элемент по...");
            Console.WriteLine("3. Отсортировать");
            Console.WriteLine("4. Вывести...");
            Console.WriteLine("5. Перегнать в массив");
            Console.WriteLine("0. Выход");
        }

        public static void AddMenu()
        {
            var a = new Person();
            Console.WriteLine("Введите имя");
            a.Name = Console.ReadLine();
            Console.WriteLine("Возраст:");
            a.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Рост:");
            a.Height = int.Parse(Console.ReadLine());
            Console.WriteLine("Вес:");
            a.Weight = int.Parse(Console.ReadLine());
            bool menu = true;
            int age;
            while (menu)
            {
                Console.WriteLine("Добавить в \n1. Начало\n2.Конец\n3.После элемента...\n4.До элемента...");
                char ch = Console.ReadLine()[0];
                switch (ch)
                {
                    case '1':
                        myList.AddFirst(a);
                        menu = false;
                        break;
                    case '2':
                        myList.AddLast(a);
                        menu = false;
                        break;
                    case '3':
                        Console.WriteLine("Введите возраст человека, после которого вы хотите добавить элемент");
                        age = int.Parse(Console.ReadLine());
                        myList.AddAfter(a, myList.FindInt("age", age));
                        menu = false;
                        break;
                    case '4':
                        Console.WriteLine("Введите возраст человека, перед которым вы хотите добавить элемент");
                        age = int.Parse(Console.ReadLine());
                        myList.AddBefore(a, myList.FindInt("age",age));
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод, попробуйте ещё раз");
                        break;
                }
            }
        }

        public static void FindMenu()
        {
            Console.WriteLine("Введи тип поиска (age, height, weight, name)");
            string type = Console.ReadLine();
            Console.WriteLine("Введи ключ");
            string key = Console.ReadLine();
            var temp = new LinkedListItem();
            if (type == "name")
                temp = myList.FindString(key);
            else
                temp = myList.FindInt(type, int.Parse(key));
            if (temp != null) 
                Console.WriteLine("Имя: {0}, возраст: {1}, рост: {2}, вес: {3}", temp.Data.Name, temp.Data.Age.ToString(),
                              temp.Data.Height.ToString(), temp.Data.Weight.ToString());
            else FindMenu();
        }
        
        public static void SortMenu()
        {
            Console.WriteLine("Отсортировать по: age, height, weight, name");
            string temp = Console.ReadLine();
            myList.QuickSort(temp, myList.Head, myList.Tail);
        }

        public static void PrintMenu()
        {
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("1. Вывести первый с удалением\n2.Вывести последний с удалением\n3. Вывести весь список");
                char ch = Console.ReadLine()[0];
                switch (ch)
                {
                    case '1':
                        myList.PickFirst();
                        menu = false;
                        break;
                    case '2':
                        myList.PickLast();
                        menu = false;
                        break;
                    case '3':
                        for (LinkedListItem i = myList.Head; i != null; i = i.Next)
                            Console.WriteLine("{0}, возраст: {1}, рост: {2}, вес: {3}", i.Data.Name, i.Data.Age.ToString(), i.Data.Height.ToString(), i.Data.Weight.ToString());
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод");
                        menu = true;
                        break;
                }
            }
        }

        public static void ArrayMenu()
        {
            Person[] arr = myList.ToArray();
            foreach (Person x in arr)
                Console.WriteLine("{0}, возраст: {1}, рост: {2}, вес: {3}", x.Name, x.Age, x.Height, x.Weight);
        }
    }
}
