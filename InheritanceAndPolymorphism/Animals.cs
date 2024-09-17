using System;

namespace InheritancePolyMorphism
{
    public class Animal
    {
        public int age { get; set; }

        public Animal()
        {
            age = 0;
        }
        public void speak(string sound)
        {
            Console.WriteLine(sound);
        }
        public virtual int Age(int growthRate){return 0;}

    }


    public class Dog : Animal
    {
        public override int Age(int growthRate)
        {
            age = (growthRate * 7) + age;
            return age;
        }
    }

    public class Human : Animal
    {
        public override int Age(int growthRate)
        {
            age += growthRate;
            return age;
        }
    }

}