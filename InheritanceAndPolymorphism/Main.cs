using System;

namespace InheritancePolyMorphism
{
    class main
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            List<Human> ppl = new List<Human>();
            Human person = new();
            Dog nikki = new();

            animals.Add(person);
            animals.Add(nikki);

            foreach(var a in animals)
            {
                a.Age(1);
                a.speak("words");
                Console.WriteLine(a.age);
            }

            Console.WriteLine(animals.GetType() == ppl.GetType());
        }
    }
}