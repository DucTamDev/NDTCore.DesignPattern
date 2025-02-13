namespace NDTCore.DesignPattern.Behavioral.Observer
{
    // Subject
    // Giao diện Subject (Observable)
    interface IStockMarket
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify(string stock, double price);
    }

    // Subject cụ thể
    class StockMarket : IStockMarket
    {
        private List<IObserver> _observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string stock, double price)
        {
            foreach (var observer in _observers)
            {
                observer.Update(stock, price);
            }
        }

        // Giả lập thay đổi giá cổ phiếu
        public void SetStockPrice(string stock, double price)
        {
            Console.WriteLine($"\n📈 Giá cổ phiếu {stock} thay đổi: {price}$");
            Notify(stock, price);
        }
    }


    // Observer
    public interface IObserver
    {
        void Update(string stock, double price);
    }

    // Concrete Observer
    class Investor : IObserver
    {
        private string _name;

        public Investor(string name)
        {
            _name = name;
        }

        public void Update(string stock, double price)
        {
            Console.WriteLine($"🔔 {_name} nhận thông báo: Giá cổ phiếu {stock} là {price}$");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Tạo Subject
            StockMarket stockMarket = new StockMarket();

            // Tạo Observer
            Investor investorA = new Investor("Alice");
            Investor investorB = new Investor("Bob");

            // Đăng ký Observer
            stockMarket.Attach(investorA);
            stockMarket.Attach(investorB);

            // Thay đổi giá cổ phiếu
            stockMarket.SetStockPrice("AAPL", 150.5);
            stockMarket.SetStockPrice("GOOGL", 2800.75);

            // Hủy đăng ký một Observer
            stockMarket.Detach(investorA);

            // Thay đổi giá tiếp theo chỉ thông báo đến Bob
            stockMarket.SetStockPrice("MSFT", 330.2);
        }
    }

}