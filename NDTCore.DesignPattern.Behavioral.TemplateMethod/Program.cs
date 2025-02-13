namespace NDTCore.DesignPattern.Behavioral.TemplateMethod
{
    using System;

    abstract class Beverage
    {
        // Template Method: định nghĩa thứ tự thực hiện các bước
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            if (CustomerWantsCondiments())
            {
                AddCondiments();
            }
        }

        private void BoilWater()
        {
            Console.WriteLine("Boiling water...");
        }

        private void PourInCup()
        {
            Console.WriteLine("Pouring into cup...");
        }

     
        protected abstract void Brew();
        protected abstract void AddCondiments();

        // Hook Method: Lớp con có thể ghi đè nếu muốn
        protected virtual bool CustomerWantsCondiments()
        {
            return true;
        }
    }

    class Tea : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Steeping the tea...");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding lemon...");
        }
    }

    class Coffee : Beverage
    {
        protected override void Brew()
        {
            Console.WriteLine("Dripping coffee through filter...");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding sugar and milk...");
        }

        protected override bool CustomerWantsCondiments()
        {
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Making tea:");
            Beverage tea = new Tea();
            tea.PrepareRecipe();

            Console.WriteLine("\nMaking coffee:");
            Beverage coffee = new Coffee();
            coffee.PrepareRecipe();
        }
    }
}

