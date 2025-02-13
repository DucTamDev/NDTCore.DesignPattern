namespace NDTCore.DesignPattern.Structural.Facade
{
    // The Facade class provides a simple interface to the complex logic of one or several subsystems.
    public class NotificationFacade
    {
        private readonly SMSNotifier _smsNotifier;
        private readonly EmailNotifier _emailNotifier;

        public NotificationFacade()
        {
            _smsNotifier = new SMSNotifier();
            _emailNotifier = new EmailNotifier();
        }

        public void SendSMS(string message)
        {
            _smsNotifier.Send(message);
        }

        public void SendEmail(string message)
        {
            _emailNotifier.Send(message);
        }

        public void SendAll(string message)
        {
            _smsNotifier.Send(message);
            _emailNotifier.Send(message);
        }
    }

    // Subsystem classes
    public class SMSNotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    public class EmailNotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    class Program
    {
        static void Main()
        {
            // The client code works with complex subsystems through a simple interface provided by the Facade.
            var notificationFacade = new NotificationFacade();
            notificationFacade.SendAll("Hello, World!");
        }
    }
}