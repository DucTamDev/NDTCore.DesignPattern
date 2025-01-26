# NDTCore.DesignPattern

## Tổng Quan

Tài liệu này phác thảo blueprint cho dự án phần mềm của chúng ta, tập trung vào các design pattern, quyết định kiến trúc và cấu trúc hệ thống.

## Mục Lục

1. [Mục Tiêu Project](#mục-tiêu-project)
2. [Design Patterns](#design-patterns)
   - [Creational Design Patterns](#creational-design-patterns)
     - [Singleton](#singleton)
     - [Factory Method](#factory-method)
     - [Abstract Factory](#abstract-factory)
     - [Builder](#builder)
     - [Prototype](#prototype)
   - [Structural Design Patterns](#structural-design-patterns)
     - [Adapter](#adapter)
     - [Bridge](#bridge)
     - [Composite](#composite)
     - [Decorator](#decorator)
     - [Facade](#facade)
     - [Flyweight](#flyweight)
     - [Proxy](#proxy)
   - [Behavioral Design Patterns](#behavioral-design-patterns)
     - [Chain of Responsibility](#chain-of-responsibility)
     - [Command](#command)
     - [Interpreter](#interpreter)
     - [Iterator](#iterator)
     - [Mediator](#mediator)
     - [Memento](#memento)
     - [Observer](#observer)
     - [State](#state)
     - [Strategy](#strategy)
     - [Template Method](#template-method)
3. [Liên Kết](#liên-kết)
4. [Tài Liệu Tham Khảo](#tài-liệu-tham-khảo)

## Mục Tiêu Project

Mục tiêu chính của project này là xây dựng một hệ thống có thể mở rộng và bảo trì dễ dàng bằng cách áp dụng các best practices và design pattern. Chúng tôi nhắm đến việc đảm bảo hiệu suất cao, dễ sử dụng và khả năng mở rộng.

## Design Patterns

1. [Creational Design Patterns](#creational-design-patterns)
2. [Structural Design Patterns](#structural-design-patterns)
3. [Behavioral Design Patterns](#behavioral-design-patterns)

### Creational Design Patterns

Creational patterns liên quan đến việc tạo đối tượng trong hệ thống mà không cần phụ thuộc vào lớp cụ thể của đối tượng.

1. **[Singleton Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Creational.Singleton/Singleton.md)**

   - Đảm bảo rằng chỉ có một instance duy nhất của một class và cung cấp một điểm truy cập toàn cầu.

2. **[Factory Method Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Creational.FactoryMethod/FactoryMethod.md)**

   - Cung cấp một interface để tạo đối tượng, nhưng để các subclass quyết định loại đối tượng sẽ được tạo.

3. **[Abstract Factory Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Creational.AbstractFactory/AbstractFactory.md)**

   - Cung cấp một interface để tạo ra các nhóm đối tượng liên quan mà không cần phải xác định các lớp cụ thể của chúng.

4. **[Builder Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Creational.Builder/Builder.md)**

   - Tách việc xây dựng một đối tượng phức tạp thành các bước nhỏ và cho phép các bước này được thực hiện theo cách riêng.

5. **[Prototype Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Creational.Prototype/Prototype.md)**
   - Tạo các đối tượng mới bằng cách sao chép một đối tượng hiện có thay vì khởi tạo một đối tượng mới từ đầu.

---

### Structural Design Patterns

Structural patterns tập trung vào cách các lớp và đối tượng được tổ chức và kết nối với nhau.

6. **[Adapter Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Structural.Adapter/Adapter.md)**

   - Cung cấp một cách để làm cho các class không tương thích có thể làm việc với nhau bằng cách chuyển đổi interface của một class thành một interface mà client mong đợi.

7. **[Bridge Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Structural.Bridge/Bridge.md)**

   - Tách rời abstraction khỏi implementation, cho phép chúng thay đổi độc lập mà không ảnh hưởng đến nhau.

8. **[Composite Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Structural.Composite/Composite.md)**

   - Cho phép các đối tượng được tổ chức theo cấu trúc cây, giúp dễ dàng làm việc với các đối tượng đơn lẻ hoặc nhóm đối tượng như một.

9. **[Decorator Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Structural.Decorator/Decorator.md)**

   - Cung cấp cách để thêm các tính năng mới vào đối tượng mà không cần phải thay đổi mã gốc của class đó.

10. **[Facade Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Structural.Facade/Facade.md)**

    - Cung cấp một giao diện đơn giản, gọn gàng cho một hệ thống phức tạp, ẩn đi các chi tiết phức tạp của hệ thống.

11. **[Flyweight Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Structural.Flyweight/Flyweight.md)**

    - Chia sẻ các đối tượng giống nhau để giảm bớt bộ nhớ khi có nhiều đối tượng giống nhau được tạo ra trong hệ thống.

12. **[Proxy Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Structural.Proxy/Proxy.md)**
    - Cung cấp một đối tượng thay thế (proxy) để kiểm soát quyền truy cập đến đối tượng thực (real object).

---

### Behavioral Design Patterns

Behavioral patterns liên quan đến cách các đối tượng tương tác và giao tiếp với nhau.

13. **[Chain of Responsibility Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.ChainOfResponsibility/ChainOfResponsibility.md)**

    - Cho phép các đối tượng xử lý yêu cầu theo một chuỗi, mỗi đối tượng có thể xử lý hoặc chuyển tiếp yêu cầu cho đối tượng tiếp theo trong chuỗi.

14. **[Command Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.Command/Command.md)**

    - Biến đổi yêu cầu vào một đối tượng để có thể lưu trữ, truyền tải hoặc ghi lại yêu cầu đó.

15. **[Interpreter Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.Interpreter/Interpreter.md)**

    - Cung cấp cách để giải thích hoặc đánh giá các ngữ pháp hoặc cú pháp của một ngôn ngữ, ví dụ như parser cho ngôn ngữ lập trình.

16. **[Iterator Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.Iterator/Iterator.md)**

    - Cung cấp cách để truy cập từng phần tử trong một collection mà không cần phải lộ ra cấu trúc bên trong của collection đó.

17. **[Mediator Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.Mediator/Mediator.md)**

    - Giảm sự phụ thuộc giữa các đối tượng, cho phép các đối tượng giao tiếp thông qua một đối tượng trung gian (mediator).

18. **[Memento Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.Memento/Memento.md)**

    - Cho phép lưu trữ và khôi phục trạng thái của một đối tượng mà không làm lộ chi tiết bên trong của nó.

19. **[Observer Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.Observer/Observer.md)**

    - Cho phép một đối tượng (subject) thông báo cho các đối tượng khác (observers) về sự thay đổi của mình mà không cần biết trước các observers là ai.

20. **[State Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.State/State.md)**

    - Cho phép đối tượng thay đổi hành vi của mình khi trạng thái của nó thay đổi, giống như thể nó đã thay đổi lớp.

21. **[Strategy Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.Strategy/Strategy.md)**

    - Cung cấp một cách để chọn lựa thuật toán hoặc hành vi tại thời điểm chạy, thay vì gắn liền với một thuật toán cố định.

22. **[Template Method Pattern](https://github.com/DucTamDev/NDTCore.DesignPattern/blob/main/NDTCore.DesignPattern.Behavioral.TemplateMethod/TemplateMethod.md)**
    - Định nghĩa một phương thức trong class cha và để các subclass cung cấp các bước cụ thể của thuật toán mà không làm thay đổi cấu trúc tổng thể của nó.

---

## Liên Kết

Design patterns [refactoring.guru](https://refactoring.guru/design-patterns)

---

## Tài Liệu Tham Khảo

- [Design Patterns - Refactoring Guru](https://refactoring.guru/design-patterns)
