# Singleton Pattern

## 1. Vấn đề cần giải quyết

Trong nhiều ứng dụng, có những tài nguyên chỉ nên tồn tại **một phiên bản duy nhất** trong toàn bộ vòng đời của ứng dụng. Ví dụ:

- **Logger**: Ghi log thông tin, không cần tạo nhiều đối tượng Logger.
- **Configuration Manager**: Lưu trữ và truy xuất cấu hình hệ thống.
- **Database Connection**: Quản lý kết nối cơ sở dữ liệu, tránh việc tạo kết nối mới mỗi lần sử dụng.

**Ví dụ vấn đề**:  
Giả sử bạn có một hệ thống log ghi lại thông tin lỗi. Nếu mỗi lần ghi log đều tạo một đối tượng mới, điều này dẫn đến lãng phí tài nguyên và thiếu tính đồng nhất.

**Giải pháp**:  
Sử dụng Singleton Pattern để đảm bảo rằng chỉ một đối tượng Logger được tạo và dùng chung trong toàn bộ ứng dụng.

---

## 2. Định nghĩa

**Singleton Pattern** là một **Creational Design Pattern** đảm bảo rằng:

1. Chỉ có một instance duy nhất của một class được tạo trong toàn bộ vòng đời của ứng dụng.
2. Cung cấp một điểm truy cập toàn cục đến instance đó.

---

## 3. Thành phần chính

Singleton Pattern bao gồm các thành phần chính sau:

1. **Private Constructor**: Ngăn việc tạo đối tượng mới từ bên ngoài class.
2. **Static Field**: Lưu trữ instance duy nhất của class.
3. **Public Static Method**: Cung cấp điểm truy cập toàn cục đến instance.

---

## 4. Sơ đồ UML

![Singleton Pattern UML](https://refactoring.guru/images/patterns/diagrams/singleton/structure-en.png)

_Sơ đồ UML mô tả cấu trúc của Singleton Pattern._

---

## 5. Ưu và Nhược điểm

### **Ưu điểm**

1. Đảm bảo chỉ có một instance duy nhất tồn tại.
2. Quản lý tài nguyên dùng chung một cách hiệu quả.
3. Hỗ trợ lazy initialization, tiết kiệm tài nguyên.
4. Dễ triển khai và sử dụng.

### **Nhược điểm**

1. Vi phạm nguyên tắc Single Responsibility Principle (SRP).
2. Gây khó khăn khi kiểm thử (Unit Test).
3. Dễ bị lạm dụng dẫn đến tight coupling (phụ thuộc chặt chẽ giữa các class).
4. Giảm hiệu suất trong môi trường đa luồng nếu không triển khai đúng cách.

---

## **6. Ví Dụ Code**

```csharp
namespace NDTCore.DesignPattern.Creational.Singleton
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

```

## **7. Tài liệu**

- [Design Patterns - Refactoring Guru](https://refactoring.guru/design-patterns)
