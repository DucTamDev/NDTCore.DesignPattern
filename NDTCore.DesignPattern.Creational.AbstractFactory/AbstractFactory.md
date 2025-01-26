# **Abstract Factory Pattern**

---

## **1. Vấn đề cần giải quyết**

Khi xây dựng các ứng dụng hỗ trợ đa nền tảng, bạn cần đảm bảo giao diện (UI) và chức năng của ứng dụng phù hợp với từng hệ điều hành (Windows, MacOS, Linux). Ví dụ:

- Nút bấm (`Button`) trong Windows và MacOS cần hiển thị khác nhau.
- Checkbox trong Windows và MacOS cũng có giao diện khác biệt.

**Vấn đề**:  
Nếu bạn viết mã trực tiếp cho từng nền tảng, sẽ gây khó khăn trong việc mở rộng và bảo trì.

**Giải pháp**:  
Sử dụng **Abstract Factory Pattern** để tạo ra các nhóm sản phẩm liên quan (nút bấm, checkbox) cho từng nền tảng mà không làm thay đổi mã nguồn của ứng dụng.

---

## **2. Định nghĩa**

**Abstract Factory** là một **Creational Design Pattern** cung cấp một giao diện để tạo ra các nhóm đối tượng liên quan hoặc phụ thuộc nhau mà không cần chỉ rõ các lớp cụ thể của chúng.

Mẫu thiết kế này giúp xây dựng một hệ thống linh hoạt để tạo các đối tượng thuộc nhiều "gia đình sản phẩm" khác nhau.

---

## **3. Thành phần chính**

1. **Abstract Product**  
   Giao diện chung cho các loại sản phẩm trong một nhóm.

   - Ví dụ: `IButton`, `ICheckbox`.

2. **Concrete Product**  
   Cài đặt giao diện `Abstract Product` với các sản phẩm cụ thể.

   - Ví dụ: `WindowsButton`, `MacOSButton`, `WindowsCheckbox`, `MacOSCheckbox`.

3. **Abstract Factory**  
   Giao diện để tạo ra các sản phẩm trừu tượng.

   - Ví dụ: `IGUIFactory`.

4. **Concrete Factory**  
   Cài đặt giao diện `Abstract Factory` để tạo ra các sản phẩm cụ thể.

   - Ví dụ: `WindowsFactory`, `MacOSFactory`.

5. **Client**  
   Sử dụng Abstract Factory để tạo và sử dụng các sản phẩm mà không cần biết về lớp cụ thể của chúng.
   - Ví dụ: `Application`.

---

## **4. Sơ đồ UML**

![Abstract Factory UML](https://refactoring.guru/images/patterns/diagrams/abstract-factory/structure.png?id=a3112cdd98765406af94595a3c5e7762)

_Sơ đồ UML mô tả quan hệ giữa các thành phần trong mẫu thiết kế Abstract Factory._

---

## **5. Ưu điểm & nhược điểm**

### **Ưu điểm**

1. **Tăng tính mở rộng**:  
   Dễ dàng thêm nhóm sản phẩm mới mà không cần thay đổi mã nguồn của Client.
2. **Tách biệt logic tạo sản phẩm**:  
   Client không phụ thuộc vào các lớp sản phẩm cụ thể, giúp giảm sự phụ thuộc (loose coupling).
3. **Đảm bảo tính nhất quán**:  
   Đảm bảo rằng các sản phẩm trong cùng một nhóm luôn hoạt động tốt khi kết hợp với nhau.

### **Nhược điểm**

1. **Tăng độ phức tạp**:  
   Yêu cầu thêm nhiều lớp (nhà máy và sản phẩm) cho mỗi nhóm sản phẩm.
2. **Khó bảo trì hơn**:  
   Nếu số lượng nhóm sản phẩm tăng, số lượng lớp sẽ tăng đáng kể, làm mã nguồn khó quản lý.

---

## **6. Ví Dụ Code**

```csharp

namespace NDTCore.DesignPattern.Creational.AbstractFactory
{
    public interface IButton
    {
        void Render();
    }

    public interface ICheckbox
    {
        void Render();
    }

    // 2. Concrete Products
    public class WindowsButton : IButton
    {
        public void Render() => Console.WriteLine("Windows Button Rendered");
    }

    public class MacOSButton : IButton
    {
        public void Render() => Console.WriteLine("MacOS Button Rendered");
    }

    public class WindowsCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("Windows Checkbox Rendered");
    }

    public class MacOSCheckbox : ICheckbox
    {
        public void Render() => Console.WriteLine("MacOS Checkbox Rendered");
    }

    // 3. Abstract Factory
    public interface IGUIFactory
    {
        IButton CreateButton();
        ICheckbox CreateCheckbox();
    }

    // 4. Concrete Factories
    public class WindowsFactory : IGUIFactory
    {
        public IButton CreateButton() => new WindowsButton();
        public ICheckbox CreateCheckbox() => new WindowsCheckbox();
    }

    public class MacOSFactory : IGUIFactory
    {
        public IButton CreateButton() => new MacOSButton();
        public ICheckbox CreateCheckbox() => new MacOSCheckbox();
    }

    // 5. Client
    public class Application
    {
        private readonly IButton _button;
        private readonly ICheckbox _checkbox;

        public Application(IGUIFactory factory)
        {
            _button = factory.CreateButton();
            _checkbox = factory.CreateCheckbox();
        }

        public void RenderUI()
        {
            _button.Render();
            _checkbox.Render();
        }
    }

    // Usage
    static class Program
    {
        static void Main()
        {
            string os = "Windows";
            IGUIFactory? factory = null;
            if (os == "Windows")
            {
                factory = new WindowsFactory();
            }
            else
            {
                factory = new MacOSFactory();
            }

            Application app = new Application(factory);
            app.RenderUI();
        }
    }
}

```

## **7. Tài liệu**

- [Design Patterns - Refactoring Guru](https://refactoring.guru/design-patterns)
