using System;

namespace ИниСП_Лаб._3
{
    public class LinkedList
    {
        public LinkedListItem Head { get; private set; }
        public LinkedListItem Tail { get; private set; }
        public int Count { get; private set; }

        public void AddLast (Person value)
        {
            if (Head == null)
            {
                Head = new LinkedListItem {Data = value};
                Tail = Head;
            }
            else
            {
                Tail.Next = new LinkedListItem {Data = value, Prev = Tail};
                Tail = Tail.Next;
            }
            Count++;
        }

        public void AddFirst (Person value)
        {
            if (Head == null)
            {
                Head = new LinkedListItem { Data = value };
                Tail = Head;                
            }
            else
            {
                Head.Prev = new LinkedListItem {Data = value, Next = Head};
                Head = Head.Next;
            }
            Count++;
        }

        public void AddAfter (Person value, LinkedListItem point)
        {
            if (Head == null)
                AddFirst(value);
            else
            {
                var current = new LinkedListItem {Data = value};
                current.Next = point.Next;
                point.Next.Prev = current;
                current.Prev = point;
                point.Next = current;
            }
        }

        public void AddBefore (Person value, LinkedListItem point)
        {
            if (Head == null)
                AddFirst(value);
            else
            {
                var current = new LinkedListItem {Data = value};
                current.Prev = point.Prev;
                point.Prev.Next = current;
                current.Next = point;
                point.Prev = current;
            }
        }
       
        public LinkedListItem FindInt (string type, int key)
        {
            var current = Head;
            int element;
            while (current != null)
            {
                switch (type)
                {
                    case "age":
                        element = current.Data.Age;
                        break;
                    case "height":
                        element = current.Data.Height;
                        break;
                    case "weight":
                        element = current.Data.Weight;
                        break;
                    default:
                        element = current.Data.Age;
                        break;
                }
                if (element == key) return current;
                current = current.Next;
            }
            return null;
        }

        public LinkedListItem FindString (string key)
        {
            var current = Head;
            while (current != null)
            {
                if (current.Data.Name == key)
                    return current;
                current = current.Next;
            }
            return null;
        }

        public bool IsEqual (Person a, Person b)
        {
            return ((a.Age == b.Age) && (a.Height == b.Height) && (a.Weight == b.Weight) && (a.Name == b.Name))
                       ? true
                       : false;
        }

        public void QuickSort (string key, LinkedListItem left, LinkedListItem right)
        {
            LinkedListItem start, current;
            if (left == right) return;
            start = left;
            current = start.Next;
            while (true)
            {
                switch (key)
                {
                    case "age":
                        if (start.Data.Age < current.Data.Age)
                            Swap(start.Data, current.Data);
                        break;
                    case "height":
                        if (start.Data.Height < current.Data.Height)
                            Swap(start.Data, current.Data);
                        break;
                    case "weight":
                        if (start.Data.Weight < current.Data.Weight)
                            Swap(start.Data, current.Data);
                        break;
                    case "name":
                        if (start.Data.Name[0] < current.Data.Name[0])
                            Swap(start.Data, current.Data);
                        break;
                }
                if (current == right) break;
                current = current.Next;
            }
            Swap(left.Data, current.Data);
            LinkedListItem old = current;
            current = current.Prev;
            if (current != null)
                if ((left.Prev != current) && (current.Next != left))
                    QuickSort(key, left, current);
            current = old;
            current = current.Next;
            if (current != null)
                if ((current.Prev != right) && (right.Next != current))
                    QuickSort(key, current, right);
        }

        private void Swap (Person a, Person b)
        {
            Person copy = a;
            a = b;
            b = copy;
        }

        public Person PickLast()
        {
            if (Head != null)
            {
                Person value = Tail.Data;
                if (Tail != Head)
                {
                    Tail = Tail.Prev;
                    Tail.Next.Prev = null;
                    Tail.Next = null;
                }
                else
                {
                    Tail = null;
                }
                Count--;
                return value;
            }
            else return null;
        }

        public Person PickFirst()
        {
            if (Head != null)
            {
                Person value = Head.Data;
                if (Head != Tail)
                {
                    Head = Head.Next;
                    Head.Prev.Next = null;
                    Head.Prev = null;
                }
                else
                {
                    Head = null;
                }
                Count--;
                return value;
            }
            else return null;
        }

        public Person[] ToArray ()
        {
            Person[] arr = new Person[Count];
            LinkedListItem current = Head;
            int i = 0;
            while (current != null)
            {
                arr[i] = current.Data;
                current = current.Next;
                i++;
            }
            return arr;
        }

    }
}