﻿namespace NDTCore.DesignPattern.Creational.Singleton
{
    // Basic Singleton
    public class SingletonBasic
    {
        private static SingletonBasic? _instance;

        private SingletonBasic()
        {
            Console.WriteLine("SingletonBasic instance is created.");
        }

        public static SingletonBasic Instance
        {
            get
            {
                if (_instance == null)
                {
                    Console.WriteLine("Creating a new SingletonBasic instance...");
                    _instance = new SingletonBasic();
                }

                Console.WriteLine("Returning SingletonBasic instance.");
                return _instance;
            }
        }
    }


    // Thread-Safe Singleton
    public class SingletonThreadSafe
    {
        private static SingletonThreadSafe? _instance;
        private static readonly object _lock = new object();

        private SingletonThreadSafe()
        {
            Console.WriteLine("SingletonThreadSafe instance is created.");
        }

        public static SingletonThreadSafe Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        Console.WriteLine("Creating a new SingletonThreadSafe instance...");
                        _instance = new SingletonThreadSafe();
                    }

                    Console.WriteLine("Returning SingletonThreadSafe instance.");
                    return _instance;
                }
            }
        }
    }

    public class SingletonLazy
    {
        private static readonly Lazy<SingletonLazy> _instance = new Lazy<SingletonLazy>(() =>
        {
            Console.WriteLine("Creating a new SingletonLazy instance...");
            return new SingletonLazy();
        });

        private SingletonLazy()
        {
            Console.WriteLine("SingletonLazy instance is created.");
        }

        public static SingletonLazy Instance
        {
            get
            {
                Console.WriteLine("Returning SingletonLazy instance.");
                return _instance.Value;
            }
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            var basicInstance = SingletonBasic.Instance;
            var basicInstance2 = SingletonBasic.Instance;
            Console.WriteLine("\n\n");

            var threadSafeInstance = SingletonThreadSafe.Instance;
            var threadSafeInstance2 = SingletonThreadSafe.Instance;
            Console.WriteLine("\n\n");

            var lazyInstance = SingletonLazy.Instance;
            var lazyInstance2 = SingletonLazy.Instance;
            Console.WriteLine("\n\n");

            Console.WriteLine("Singletons are working properly!");
        }
    }
}
