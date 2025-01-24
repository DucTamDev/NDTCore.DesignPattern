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