# Adapter Pattern

---

## **1. Vấn đề cần giải quyết**

Trong các ứng dụng phần mềm, đôi khi chúng ta phải làm việc với nhiều thư viện hoặc hệ thống có giao diện khác nhau. Khi các hệ thống này không tương thích với nhau, chúng ta cần một cách để làm việc với chúng mà không thay đổi mã nguồn của hệ thống. **Adapter Pattern** giúp giải quyết vấn đề này bằng cách chuyển đổi giữa các giao diện không tương thích.

### Ví dụ:

Giả sử bạn có một hệ thống cần xử lý dữ liệu từ hai nguồn khác nhau, một nguồn trả về dữ liệu dưới dạng **JSON** và một nguồn trả về dữ liệu dưới dạng **XML**. Tuy nhiên, hệ thống của bạn chỉ làm việc được với một kiểu dữ liệu nhất định. Nếu không có phương pháp chuyển đổi giữa chúng, bạn sẽ phải thay đổi mã nguồn trong cả hệ thống.

---

## **2. Định nghĩa**

**Adapter Pattern** là một mẫu thiết kế thuộc nhóm **Structural Pattern**, có tác dụng chuyển đổi giao diện của một lớp thành giao diện mà client mong muốn. Mẫu thiết kế này giúp các lớp không tương thích làm việc với nhau mà không phải thay đổi mã nguồn của chúng.

Thông qua Adapter Pattern, chúng ta có thể chuyển đổi một giao diện cũ hoặc không tương thích thành một giao diện mà client có thể sử dụng mà không cần thay đổi mã nguồn của hệ thống hiện tại.

---

## **3. Thành phần chính**

Adapter Pattern có các thành phần chính sau:

1. **Adaptee**:

   - Là lớp mà chúng ta cần chuyển đổi, tức là lớp có giao diện không phù hợp với yêu cầu của hệ thống.
   - Ví dụ: `JsonProcessor`, `XmlProcessor`.

2. **Adapter**:

   - Là lớp đóng vai trò cầu nối, chuyển đổi giao diện của Adaptee thành giao diện mà hệ thống mong muốn.
   - Ví dụ: `JsonToXmlAdapter`, `XmlToJsonAdapter`.

3. **Target**:
   - Là giao diện mà client mong muốn để tương tác với Adaptee.
   - Ví dụ: `IXmlAdapter`, `IJsonAdapter`.

---

## **4. Sơ đồ UML**

![Adapter UML Diagram](https://refactoring.guru/images/patterns/diagrams/adapter/structure-object-adapter.png)

_Sơ đồ UML mô tả mối quan hệ giữa các thành phần trong Adapter Pattern._

---

## **5. Ưu nhược điểm**

### **Ưu điểm**:

1. **Giảm sự phụ thuộc**: Adapter Pattern giúp giảm sự phụ thuộc giữa các lớp và giúp hệ thống dễ dàng mở rộng mà không cần thay đổi các lớp hiện tại.
2. **Tăng tính linh hoạt**: Bạn có thể sử dụng các thư viện hoặc hệ thống có giao diện khác nhau mà không cần thay đổi mã nguồn của chúng.

3. **Dễ dàng tích hợp**: Việc tích hợp các hệ thống hoặc thư viện bên ngoài sẽ trở nên dễ dàng hơn khi bạn có thể điều chỉnh giao diện mà không ảnh hưởng đến các phần còn lại của hệ thống.

### **Nhược điểm**:

1. **Tăng số lượng lớp**: Việc sử dụng Adapter Pattern có thể làm tăng số lượng lớp trong hệ thống, điều này có thể làm phức tạp mã nguồn.

2. **Không phù hợp khi thay đổi liên tục**: Nếu giao diện của Adaptee thay đổi quá thường xuyên, bạn sẽ phải cập nhật Adapter liên tục, điều này có thể gây tốn thời gian và công sức.

3. **Khó khăn khi mở rộng**: Nếu cần phải thay đổi logic chuyển đổi trong Adapter, việc mở rộng có thể trở nên phức tạp, đặc biệt khi có nhiều loại Adapter.

---

## **6. Ví Dụ Code**

```csharp

namespace NDTCore.DesignPattern.Structural.Adapter
{
    // Adaptee - Đối tượng cần chuyển đổi
    public class JsonProcessor
    {
        public string GetJsonData()
        {
            return "{\"name\": \"John\", \"age\": 30}";
        }
    }

    public class XmlProcessor
    {
        public string GetXmlData()
        {
            return "<person><name>John</name><age>30</age></person>";
        }
    }

    // Giao diện chuyển đổi từ JSON sang XML
    public interface IXmlAdapter
    {
        string GetXmlData();
    }

    // Giao diện chuyển đổi từ XML sang JSON
    public interface IJsonAdapter
    {
        string GetJsonData();
    }

    // Adapter chuyển JSON sang XML
    public class JsonToXmlAdapter : IXmlAdapter
    {
        private readonly JsonProcessor _jsonProcessor;

        public JsonToXmlAdapter(JsonProcessor jsonProcessor)
        {
            _jsonProcessor = jsonProcessor;
        }

        public string GetXmlData()
        {
            string json = _jsonProcessor.GetJsonData();
            return "<person><name>John</name><age>30</age></person>";
        }
    }

    // Adapter chuyển XML sang JSON
    public class XmlToJsonAdapter : IJsonAdapter
    {
        private readonly XmlProcessor _xmlProcessor;

        public XmlToJsonAdapter(XmlProcessor xmlProcessor)
        {
            _xmlProcessor = xmlProcessor;
        }

        public string GetJsonData()
        {
            string xml = _xmlProcessor.GetXmlData();
            return "{\"name\": \"John\", \"age\": 30}";
        }
    }

    public class ApplicationService
    {
        public void DisplayData()
        {
            // Giả sử client cần dữ liệu dưới dạng XML
            JsonProcessor jsonProcessor = new JsonProcessor();
            IXmlAdapter adapter = new JsonToXmlAdapter(jsonProcessor);
            string xml = adapter.GetXmlData();
            Console.WriteLine("Data with format XML: " + xml);

            // Giả sử client cần dữ liệu dưới dạng JSON
            XmlProcessor xmlProcessor = new XmlProcessor();
            IJsonAdapter adapter2 = new XmlToJsonAdapter(xmlProcessor);
            string json = adapter2.GetJsonData();
            Console.WriteLine("Data with format JSON: " + json);
        }
    }

    static class Program
    {
        static void Main(string[] args)
        {
            ApplicationService client = new ApplicationService();
            client.DisplayData();
        }
    }
}
```

## **7. Tài liệu**

- [Design Patterns - Refactoring Guru](https://refactoring.guru/design-patterns)
