﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Zoo
{
    class Dog : Animal, ISound
    {
        public Dog(int age, string name, bool isMale)
            : base(age, name, isMale) { }

        public void ProduceSound()
        {
            Console.WriteLine("Woof Woof!");
        }
    }
}
