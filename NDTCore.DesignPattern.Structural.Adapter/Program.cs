
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