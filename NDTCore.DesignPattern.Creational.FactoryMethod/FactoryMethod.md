# **Factory Method Pattern**

## **1. Định nghĩa**

**Factory Method** là một **Creational Design Pattern** cung cấp một giao diện (interface) để tạo các đối tượng, nhưng cho phép các lớp con quyết định loại đối tượng nào sẽ được tạo.  
Thay vì sử dụng trực tiếp từ khóa `new` để khởi tạo đối tượng, Factory Method chuyển trách nhiệm tạo đối tượng này sang các lớp con cụ thể.

---

## **2. Thành phần chính**

Factory Method hoạt động dựa trên hai thành phần chính:

- **Creator**: Lớp cơ sở định nghĩa một phương thức factory trừu tượng (`FactoryMethod`), được các lớp con kế thừa và triển khai.
- **Concrete Product**: Các lớp cụ thể được tạo ra thông qua Factory Method.

---

## **3. Cấu trúc UML**

![Abstract Factory UML](https://refactoring.guru/images/patterns/diagrams/factory-method/structure.png)

_Sơ đồ UML mô tả quan hệ giữa các thành phần trong mẫu thiết kế Factory Method._

---

## **4. Ưu điểm**

- **Đảm bảo tính mở rộng**: Dễ dàng thêm loại sản phẩm mới mà không sửa đổi mã nguồn của lớp Creator.
- **Loại bỏ sự phụ thuộc trực tiếp vào các lớp cụ thể**: Giảm sự phụ thuộc vào việc khởi tạo các đối tượng cụ thể (tăng tính linh hoạt).

---

## **5. Nhược điểm**

- **Phức tạp hơn**: Yêu cầu các lớp con phải triển khai Factory Method.
- **Thêm lớp mới**: Việc thêm nhiều Concrete Product có thể làm tăng số lượng lớp trong ứng dụng.

---

## **6. Ví dụ minh họa**

### **C# Code**

```csharp
// Abstract Product
public interface IButton
{
    void Render();
}

// Concrete Product
public class WindowsButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Render Windows Button");
    }
}

public class MacOSButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Render macOS Button");
    }
}

// Abstract Creator
public abstract class Dialog
{
    public abstract IButton CreateButton();

    public void RenderButton()
    {
        IButton button = CreateButton();
        button.Render();
    }
}

// Concrete Creator
public class WindowsDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new WindowsButton();
    }
}

public class MacOSDialog : Dialog
{
    public override IButton CreateButton()
    {
        return new MacOSButton();
    }
}

// Client
class Program
{
    static void Main(string[] args)
    {
        Dialog dialog;

        string os = "Windows";
        if (os == "Windows")
            dialog = new WindowsDialog();
        else
            dialog = new MacOSDialog();

        dialog.RenderButton();
    }
}
```

---

## **7. Khi nào nên dùng Factory Method**

- Khi một lớp không biết trước về loại đối tượng cụ thể cần được tạo.
- Khi muốn giảm sự phụ thuộc vào các lớp cụ thể, tăng tính linh hoạt và mở rộng.
- Khi ứng dụng cần tuân theo **Open/Closed Principle** (mở rộng mà không sửa đổi mã hiện tại).

---

## **8. Ví dụ thực tế**

- **Logger System**: Tạo các Logger khác nhau (`FileLogger`, `DatabaseLogger`) dựa trên môi trường.

---

## **9. Tài liệu**

Design patterns [refactoring.guru](https://refactoring.guru/design-patterns)

---
