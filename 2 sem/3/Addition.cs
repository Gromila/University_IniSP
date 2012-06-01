using System;

namespace ИниСП_Лаб._3
{
    public static class Addition
    {
        public static void PrintListFromHead (this LinkedListItem current)
        {
            while (current != null)
            {
                Console.WriteLine("{0}, возраст: {1}, рост: {2}, вес: {3}", current.Data.Name, current.Data.Age.ToString(), current.Data.Height.ToString(), current.Data.Weight.ToString());
                current = current.Next;
            }
        }
    }
}