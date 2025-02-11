
namespace NDTCore.DesignPattern.Structural.Decorator
{
    // The base Component interface defines operations that can be altered by decorators.
    public interface Notifier
    {
        public void Send(string message);
    }

    // Concrete Component - Basic Notifier (Default)
    class BasicNotifier : Notifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Basic Notification: {message}");
        }
    }

    // The base Decorator class follows the same interface as the other components.
    class NotifierDecorator : Notifier
    {
        protected Notifier _notifier;

        public NotifierDecorator(Notifier notifier)
        {
            this._notifier = notifier;
        }

        public void SetNotifier(Notifier notifier)
        {
            this._notifier = notifier;
        }

        // The Decorator delegates all work to the wrapped component.
        public virtual void Send(string message)
        {
            _notifier?.Send(message);
        }
    }

    // Concrete Decorator 1 - SMS Notifier
    class SMSNotifier : NotifierDecorator
    {
        public SMSNotifier(Notifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    // Concrete Decorator 2 - Email Notifier
    class EmailNotifier : NotifierDecorator
    {
        public EmailNotifier(Notifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    class PushNotifier : NotifierDecorator
    {
        public PushNotifier(Notifier notifier) : base(notifier)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending Push Notification: {message}");
        }
    }

    public class Client
    {
        public void ClientCode(Notifier notifier, string message)
        {
            notifier.Send(message);
        }

        // Cho phép chọn nhiều decorators một cách linh hoạt
        public Notifier CreateNotifier(Notifier baseNotifier, List<Type> decorators)
        {
            Notifier? notifier = baseNotifier;

            foreach (var decorator in decorators)
            {
                notifier = Activator.CreateInstance(decorator, notifier) as Notifier;
            }

            return notifier;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            var basicNotifier = new BasicNotifier();

            Console.WriteLine("Client: Sending a basic notification:");
            client.ClientCode(basicNotifier, "Hello!");

            Console.WriteLine("\nClient: Adding SMS and Email Notifiers dynamically:");
            var customNotifier = client.CreateNotifier(basicNotifier, new List<Type> { typeof(SMSNotifier), typeof(EmailNotifier) });
            client.ClientCode(customNotifier, "Hello!");

            Console.WriteLine("\nClient: Adding SMS, Email, and Push Notifiers dynamically:");
            var fullNotifier = client.CreateNotifier(basicNotifier, new List<Type> { typeof(SMSNotifier), typeof(EmailNotifier), typeof(PushNotifier) });
            client.ClientCode(fullNotifier, "Hello!");
        }
    }
}