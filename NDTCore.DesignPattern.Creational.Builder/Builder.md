# **Builder Pattern**

## **1. Vấn đề cần giải quyết**

### **Khó khăn trong việc tạo đối tượng phức tạp**

Khi một đối tượng có quá nhiều thuộc tính hoặc cần một số bước cấu hình phức tạp để xây dựng, việc sử dụng constructor thông thường với nhiều tham số có thể trở nên rất phức tạp và dễ gây ra lỗi. Điều này thường xảy ra khi các đối tượng có quá nhiều thuộc tính tùy chọn hoặc bắt buộc, khiến cho việc tạo đối tượng trở nên khó hiểu và khó duy trì.

#### Ví dụ mà không sử dụng Builder:

Giả sử bạn có một đối tượng `Car` với nhiều thuộc tính như động cơ, số ghế, màu sắc, các tính năng phụ trợ, và các tùy chọn khác. Việc khởi tạo đối tượng này bằng cách truyền tất cả tham số vào một constructor có thể dẫn đến tình trạng code trở nên khó đọc và dễ gây nhầm lẫn.

```csharp
public class Car
{
    public string Engine { get; set; }
    public int Seats { get; set; }
    public string Color { get; set; }
    public bool HasGPS { get; set; }
    public bool HasSunroof { get; set; }

    public Car(string engine, int seats, string color, bool hasGPS, bool hasSunroof)
    {
        Engine = engine;
        Seats = seats;
        Color = color;
        HasGPS = hasGPS;
        HasSunroof = hasSunroof;
    }
}

// Khởi tạo đối tượng Car với nhiều tham số
var car1 = new Car("V8 Engine", 4, "Red", true, false);
var car2 = new Car("Electric Motor", 2, "Blue", false, true);

```

### **Khó khăn trong việc thay đổi cấu trúc đối tượng**

Khi cấu trúc của đối tượng thay đổi (thêm bớt thuộc tính, thay đổi logic tạo đối tượng), bạn sẽ phải sửa đổi lại tất cả những nơi mà đối tượng đó được tạo ra, điều này rất dễ dẫn đến việc không đồng bộ trong toàn bộ hệ thống.

### Trước khi thay đổi cấu trúc:

```csharp
public class Car
{
    public string Engine { get; set; }
    public int Seats { get; set; }
    public string Color { get; set; }

    public Car(string engine, int seats, string color)
    {
        Engine = engine;
        Seats = seats;
        Color = color;
    }
}

// Khởi tạo đối tượng Car
var car1 = new Car("V8 Engine", 4, "Red");
var car2 = new Car("Electric Motor", 2, "Blue");

```

Sau khi thay đổi cấu trúc:

Bây giờ bạn muốn thêm một thuộc tính AirConditioning mới vào đối tượng Car, vì vậy bạn cần thay đổi constructor và tất cả các nơi mà đối tượng Car được tạo ra:

```csharp
public class Car
{
    public string Engine { get; set; }
    public int Seats { get; set; }
    public string Color { get; set; }
    public bool AirConditioning { get; set; }

    public Car(string engine, int seats, string color, bool airConditioning)
    {
        Engine = engine;
        Seats = seats;
        Color = color;
        AirConditioning = airConditioning;
    }
}

// Khởi tạo đối tượng Car sau khi thay đổi cấu trúc
var car1 = new Car("V8 Engine", 4, "Red", true);
var car2 = new Car("Electric Motor", 2, "Blue", false);

```

## **2. Định nghĩa**

**Builder Design Pattern** là một mẫu thiết kế thuộc nhóm **Creational**, được sử dụng để xây dựng các đối tượng phức tạp theo từng bước. Mẫu thiết kế này tách biệt quá trình xây dựng đối tượng khỏi phần biểu diễn của nó, cho phép sử dụng cùng một quy trình xây dựng để tạo ra các biểu diễn khác nhau.

---

## **3. Thành phần chính**

1. **Product**
   Đối tượng phức tạp được xây dựng thông qua các bước cụ thể của Builder.

   - Ví dụ: `Car` (đại diện cho sản phẩm cần xây dựng).

2. **Builder Interface**
   Định nghĩa giao diện với các phương thức để xây dựng từng thành phần của đối tượng.

   - Ví dụ: `ICarBuilder` (giao diện xác định các bước để xây dựng `Car`).

3. **Concrete Builder**
   Cài đặt các phương thức trong `Builder Interface` để xây dựng và lắp ráp từng phần của `Product`.

   - Ví dụ: `SportsCarBuilder`, `SUVCarBuilder` (xây dựng các loại xe cụ thể).

4. **Director**
   Điều khiển quy trình xây dựng đối tượng, đảm bảo các thành phần được xây dựng theo đúng trình tự.

   - Ví dụ: `CarDirector` (chỉ đạo quy trình tạo xe).

5. **Client**
   Sử dụng `Director` và `Builder` để tạo ra sản phẩm mong muốn mà không cần quan tâm đến chi tiết xây dựng.
   - Ví dụ: `Program.Main` (sử dụng `Director` để tạo ra `Car`).

---

## **4. Sơ Đồ UML**

![Builder UML](https://refactoring.guru/images/patterns/diagrams/builder/structure.png)

_Sơ đồ UML mô tả quan hệ giữa các thành phần trong mẫu thiết kế Builder._

---

## **5. Ưu điểm & nhược điểm**

### **Ưu điểm**

1. **Tách biệt xây dựng và biểu diễn đối tượng**:
   Builder cho phép tách biệt quá trình xây dựng đối tượng phức tạp khỏi mã nguồn sử dụng đối tượng. Điều này giúp mã nguồn của chúng ta dễ dàng bảo trì và mở rộng.

2. **Dễ dàng thay đổi các thành phần**:
   Với Builder, bạn có thể dễ dàng thay đổi các thành phần của đối tượng mà không ảnh hưởng đến các phần khác. Ví dụ, thay đổi động cơ hay màu sắc của xe mà không cần phải thay đổi logic xây dựng đối tượng.

3. **Hỗ trợ nhiều biểu diễn của đối tượng**:
   Mẫu thiết kế này cho phép tạo ra nhiều dạng đối tượng từ cùng một quy trình xây dựng. Chỉ cần thay đổi Builder là có thể tạo ra các loại đối tượng khác nhau (ví dụ: `SportsCar` và `SUVCar`).

4. **Xây dựng đối tượng phức tạp từng bước**:
   Builder rất thích hợp cho các đối tượng phức tạp với nhiều thuộc tính, giúp người dùng xây dựng đối tượng một cách tuần tự và có kiểm soát, thay vì phải truyền vào tất cả thuộc tính một lúc.

5. **Làm mã nguồn dễ đọc và dễ hiểu**:
   Việc xây dựng đối tượng thông qua các phương thức chainable (chạy theo chuỗi) giúp mã nguồn trở nên dễ đọc và dễ hiểu hơn.

---

### **Nhược điểm**

1. **Tăng số lượng lớp**:
   Sử dụng Builder dẫn đến việc phải tạo ra nhiều lớp (giao diện, Concrete Builder, Director), điều này có thể làm tăng độ phức tạp của hệ thống, đặc biệt khi đối tượng chỉ có một số lượng nhỏ thuộc tính.

2. **Không phù hợp với đối tượng đơn giản**:
   Nếu đối tượng của bạn không có quá nhiều thuộc tính phức tạp, việc sử dụng Builder có thể là một sự thừa thãi, vì bạn có thể tạo đối tượng trực tiếp mà không cần phải xây dựng từng bước.

3. **Khó kiểm soát các bước xây dựng**:
   Nếu có nhiều bước xây dựng phức tạp, bạn có thể gặp khó khăn trong việc quản lý trình tự các bước này hoặc trong việc thay đổi cấu trúc đối tượng trong Builder.

4. **Cần nhiều mã lặp lại**:
   Các Concrete Builders có thể có mã lặp lại trong quá trình xây dựng các thành phần của sản phẩm. Điều này có thể khiến việc bảo trì mã trở nên phức tạp nếu không có sự trừu tượng hóa đúng đắn.

5. **Khó khăn trong việc mở rộng đối tượng nếu có sự thay đổi lớn**:
   Nếu đối tượng thay đổi quá nhiều, Builder có thể cần phải cập nhật các phương thức và logic tương ứng trong các Concrete Builder, dẫn đến việc sửa đổi mã nguồn phức tạp.

---

## **6. Ví Dụ Code**

```csharp

namespace NDTCore.DesignPattern.Creational.Builder
{

    // Product
    public class Car
    {
        public string? Engine { get; set; }
        public int Seats { get; set; }
        public string? Color { get; set; }

        public override string ToString()
        {
            return $"Car [Engine: {Engine}, Seats: {Seats}, Color: {Color}]";
        }
    }

    // Builder Interface
    public interface ICarBuilder
    {
        ICarBuilder SetEngine(string engine);
        ICarBuilder SetSeats(int seats);
        ICarBuilder SetColor(string color);
        Car Build();
    }

    // Abstract Builder (Optional - for shared behavior)
    public abstract class CarBuilder : ICarBuilder
    {
        protected Car _car = new Car();

        public abstract ICarBuilder SetEngine(string engine);
        public abstract ICarBuilder SetSeats(int seats);
        public abstract ICarBuilder SetColor(string color);

        public Car Build()
        {
            return _car;
        }
    }

    // Concrete Builder for Sports Car
    public class SportsCarBuilder : CarBuilder
    {
        public override ICarBuilder SetEngine(string engine)
        {
            _car.Engine = engine;
            return this;
        }

        public override ICarBuilder SetSeats(int seats)
        {
            _car.Seats = seats;
            return this;
        }

        public override ICarBuilder SetColor(string color)
        {
            _car.Color = color;
            return this;
        }
    }

    // Concrete Builder for SUV
    public class SUVCarBuilder : CarBuilder
    {
        public override ICarBuilder SetEngine(string engine)
        {
            _car.Engine = engine;
            return this;
        }

        public override ICarBuilder SetSeats(int seats)
        {
            _car.Seats = seats;
            return this;
        }

        public override ICarBuilder SetColor(string color)
        {
            _car.Color = color;
            return this;
        }
    }


    // Director
    public class CarDirector
    {
        public Car ConstructSportsCar(ICarBuilder builder)
        {
            return builder.SetEngine("V8 Engine")
                    .SetSeats(2)
                    .SetColor("Black")
                    .Build();
        }

        public Car ConstructSUVCar(ICarBuilder builder)
        {
            return builder.SetEngine("Turbo Diesel")
                     .SetSeats(4)
                     .SetColor("Red")
                     .Build();
        }
    }

    // Usage
    static class Program
    {
        static void Main(string[] args)
        {
            CarDirector director = new CarDirector();

            ICarBuilder builderSportCar = new SportsCarBuilder();
            ICarBuilder builderSUVCar = new SUVCarBuilder();

            Car sportCar = director.ConstructSportsCar(builderSportCar);

            Car SUVCar = director.ConstructSUVCar(builderSUVCar);

            Console.WriteLine(sportCar);

            Console.WriteLine(SUVCar);
        }
    }
}
```

## **7. Tài liệu**

- [Design Patterns - Refactoring Guru](https://refactoring.guru/design-patterns)
