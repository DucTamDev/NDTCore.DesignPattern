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