using System;

namespace NDTCore.DesignPattern.Structural.Composite
{
    class Person : ICloneable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Person person1 = new Person { Name = "Alice", Age = 25 };

            // Clone object
            Person person2 = (Person)person1.Clone();
            person2.Name = "Bob"; 

            Console.WriteLine($"Person1: {person1.Name}, {person1.Age} tuổi");
            Console.WriteLine($"Person2: {person2.Name}, {person2.Age} tuổi");
        }
    }
}