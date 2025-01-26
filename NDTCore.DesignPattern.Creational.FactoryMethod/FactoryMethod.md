# **Factory Method Pattern**

## **1. Vấn đề cần giải quyết**

Trong một hệ thống có nhiều loại đối tượng cần được khởi tạo (ví dụ: thông báo, tài liệu, hoặc giao diện người dùng), nếu bạn sử dụng trực tiếp từ khóa `new` để tạo đối tượng, mã nguồn sẽ trở nên khó mở rộng khi cần thêm loại đối tượng mới.

**Vấn đề**:

- Làm thế nào để tách biệt logic khởi tạo đối tượng khỏi mã nguồn chính?
- Làm thế nào để mở rộng các loại đối tượng mà không sửa đổi mã hiện tại?

**Giải pháp**:  
Sử dụng **Factory Method Pattern** để di chuyển logic khởi tạo đối tượng sang các lớp con cụ thể, giúp mã dễ bảo trì và mở rộng hơn.

---

## **2. Định nghĩa**

**Factory Method** là một **Creational Design Pattern** cung cấp một giao diện để tạo các đối tượng, nhưng cho phép các lớp con quyết định loại đối tượng cụ thể nào sẽ được tạo.

Thay vì sử dụng trực tiếp từ khóa `new`, phương pháp này sử dụng một phương thức "Factory" để tạo ra các đối tượng.

---

## **3. Thành phần chính**

1. **Product**  
   Giao diện hoặc lớp trừu tượng đại diện cho các đối tượng được tạo ra bởi Factory Method.

   - Ví dụ: `IProduct`.

2. **Concrete Product**  
   Cài đặt cụ thể của `Product` được tạo ra bởi các Factory Method.

   - Ví dụ: `ConcreteProductA`, `ConcreteProductB`.

3. **Creator**  
   Lớp cơ sở định nghĩa một Factory Method trừu tượng để các lớp con triển khai. Creator có thể chứa logic chung để sử dụng đối tượng được tạo ra.

   - Ví dụ: `Creator`.

4. **Concrete Creator**  
   Lớp con cụ thể cài đặt phương thức Factory Method để trả về các đối tượng cụ thể (`Concrete Product`).
   - Ví dụ: `ConcreteCreatorA`, `ConcreteCreatorB`.

---

## **3. Cấu trúc UML**

![Abstract Factory UML](https://refactoring.guru/images/patterns/diagrams/factory-method/structure.png)

_Sơ đồ UML mô tả quan hệ giữa các thành phần trong mẫu thiết kế Factory Method._

---

## **5. Ưu điểm & nhược điểm**

### **Ưu điểm**

1. **Đảm bảo tính mở rộng**  
   Dễ dàng thêm loại sản phẩm mới mà không cần sửa đổi mã nguồn của Creator.
2. **Giảm sự phụ thuộc**  
   Loại bỏ sự phụ thuộc trực tiếp vào các lớp cụ thể.
3. **Tính linh hoạt**  
   Cho phép thay đổi các lớp cụ thể được sử dụng trong ứng dụng mà không cần thay đổi mã nguồn của Client.

### **Nhược điểm**

1. **Tăng độ phức tạp**  
   Việc yêu cầu các lớp con triển khai Factory Method có thể làm tăng số lượng lớp trong hệ thống.
2. **Phải tạo thêm lớp mới**  
   Khi thêm sản phẩm mới, cần tạo thêm lớp Factory mới, có thể làm mã nguồn trở nên nặng nề.

---

## **6. Ví dụ minh họa**

### **C# Code**

```csharp

namespace NDTCore.DesignPattern.Creational.FactoryMethod
{
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
    static class Program
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
}

```

---

## **7. Tài liệu**

- [Design Patterns - Refactoring Guru](https://refactoring.guru/design-patterns)
