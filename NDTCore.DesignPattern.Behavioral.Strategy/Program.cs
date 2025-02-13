namespace NDTCore.DesignPattern.Behavioral.Strategy
{
    // Interface định nghĩa các thuật toán có thể thay thế nhau
    public interface IStrategy
    {
        void Execute();
    }

    public class ConcreteStrategyA : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Executing Strategy A");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("Executing Strategy B");
        }
    }

    public class Context
    {
        private IStrategy _strategy;

        public Context(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public void ExecuteStrategy()
        {
            _strategy.Execute();
        }
    }

    class Program
    {
        static void Main()
        {
            Context context = new Context(new ConcreteStrategyA());
            context.ExecuteStrategy();

            context.SetStrategy(new ConcreteStrategyB());
            context.ExecuteStrategy();
        }
    }
}