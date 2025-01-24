# **Abstract Factory Pattern**

## **1. Định nghĩa**

**Abstract Factory** là một **Creational Design Pattern** cung cấp một giao diện để tạo ra các nhóm đối tượng liên quan hoặc phụ thuộc nhau mà không cần chỉ rõ các lớp cụ thể của chúng.  
Mẫu thiết kế này cho phép hệ thống dễ dàng mở rộng khi cần phải tạo các sản phẩm thuộc nhiều gia đình khác nhau mà không ảnh hưởng đến mã nguồn của ứng dụng.

---

## **2. Thành phần chính**

1. **Abstract Product**  
   Định nghĩa giao diện chung cho các loại sản phẩm trong một nhóm sản phẩm.

   - Ví dụ: `IButton`, `ICheckbox`.

2. **Concrete Product**  
   Cài đặt các giao diện từ Abstract Product. Đây là các đối tượng cụ thể được tạo ra bởi các nhà máy.

   - Ví dụ: `WindowsButton`, `MacOSButton`, `WindowsCheckbox`, `MacOSCheckbox`.

3. **Abstract Factory**  
   Định nghĩa giao diện để tạo ra các sản phẩm trừu tượng, mỗi phương thức tạo sản phẩm sẽ trả về một đối tượng thuộc giao diện `Abstract Product`.

   - Ví dụ: `IGUIFactory`.

4. **Concrete Factory**  
   Cài đặt các phương thức tạo ra các sản phẩm cụ thể cho một nhóm sản phẩm.

   - Ví dụ: `WindowsFactory`, `MacOSFactory`.

5. **Client**  
   Sử dụng các nhà máy trừu tượng để tạo ra các sản phẩm thông qua giao diện của chúng mà không cần biết các lớp cụ thể của sản phẩm.
   - Ví dụ: `Application`.

---

## **3. Sơ Đồ UML**

![Abstract Factory UML](https://refactoring.guru/images/patterns/diagrams/abstract-factory/structure.png?id=a3112cdd98765406af94595a3c5e7762)

_Sơ đồ UML mô tả quan hệ giữa các thành phần trong mẫu thiết kế Abstract Factory._

---

## **4. Ưu điểm**

- **Tăng tính mở rộng**: Dễ dàng thêm nhóm sản phẩm mới mà không cần thay đổi mã nguồn của khách hàng.
- **Tách biệt logic tạo sản phẩm**: Lớp khách hàng không cần phải biết các lớp cụ thể của sản phẩm, giảm sự phụ thuộc vào chúng.
- **Đảm bảo tính nhất quán**: Đảm bảo rằng các sản phẩm trong cùng một gia đình luôn hoạt động tốt khi kết hợp với nhau.

---

## **5. Nhược điểm**

- **Tăng độ phức tạp**: Số lượng lớp có thể tăng lên do phải tạo thêm các lớp nhà máy và sản phẩm cho mỗi nhóm sản phẩm.
- **Khó bảo trì hơn**: Khi có nhiều nhóm sản phẩm, số lượng lớp và sự phụ thuộc giữa chúng có thể làm mã nguồn trở nên khó bảo trì.

---

## **6. Ví Dụ Code**

```csharp
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
class Program
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

```

## **7. Tài liệu**

Design patterns [refactoring.guru](https://refactoring.guru/design-patterns)
