using System;

namespace ИниСП_Лаб._3
{
    public class Person
    {
        private int _age;
        private int _height;
        private int _weight;
        
        public string Name { get; set; }
        public int Age { 
            get { return _age; }
            set
            {
                if (value >= 0 || value <= 130) _age = value;
                else _age = 0;
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                if (value >= 0 || value <= 250) _height = value;
                else _height = 0;
            }
        }
        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value >= 0 || value <= 200) _weight = value;
                else _weight = 0;
            }
        }
    }
}
