using System;

namespace NDTCore.DesignPattern.Structural.Proxy
{
    // The Subject interface declares common operations for both RealSubject and the Proxy.
    public interface ISubject
    {
        void Request();
    }

    // The RealSubject contains some core business logic. Usually, RealSubjects are capable of doing some useful work which may also be very slow or sensitive - e.g. correcting input data.
    public class RealSubject : ISubject
    {
        public void Request()
        {
            Console.WriteLine("RealSubject: Handling Request.");
        }
    }

    // The Proxy class has an interface identical to the RealSubject.
    public class Proxy : ISubject
    {
        private readonly RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            _realSubject = realSubject;
        }

        public void Request()
        {
            if (CheckAccess())
            {
                _realSubject.Request();
                LogAccess();
            }
        }

        private bool CheckAccess()
        {
            Console.WriteLine("Proxy: Checking access prior to firing a real request.");
            return true;
        }

        private void LogAccess()
        {
            Console.WriteLine("Proxy: Logging the time of request.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Client: Executing the client code with a real subject:");
            ClientCode(new RealSubject());

            Console.WriteLine();

            Console.WriteLine("Client: Executing the same client code with a proxy:");
            ClientCode(new Proxy(new RealSubject()));
        }

        public static void ClientCode(ISubject subject)
        {
            // ...

            subject.Request();

            // ...
        }
    }
}