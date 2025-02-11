using System;

namespace NDTCore.DesignPattern.Structural.Bridge
{
    // Implementor: Device interface
    public interface IDevice
    {
        void TurnOn();
        void TurnOff();
        void SetVolume(int volume);
    }

    // Concrete Implementor 1: TV
    public class TV : IDevice
    {
        private int volume = 10;

        public void TurnOn()
        {
            Console.WriteLine("TV is turned ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV is turned OFF");
        }

        public void SetVolume(int volume)
        {
            this.volume = volume;
            Console.WriteLine($"TV volume set to {volume}");
        }
    }

    // Concrete Implementor 2: Radio
    public class Radio : IDevice
    {
        private int volume = 5;

        public void TurnOn()
        {
            Console.WriteLine("Radio is turned ON");
        }

        public void TurnOff()
        {
            Console.WriteLine("Radio is turned OFF");
        }

        public void SetVolume(int volume)
        {
            this.volume = volume;
            Console.WriteLine($"Radio volume set to {volume}");
        }
    }

    // Abstraction: Remote Control
    public class RemoteControl
    {
        protected IDevice device;

        public RemoteControl(IDevice device)
        {
            this.device = device;
        }

        public void TogglePower()
        {
            Console.WriteLine("Toggling power...");
            device.TurnOn();
        }

        public void VolumeUp()
        {
            Console.WriteLine("Increasing volume...");
            device.SetVolume(20);
        }
    }

    // Refined Abstraction: Advanced Remote Control
    public class AdvancedRemoteControl : RemoteControl
    {
        public AdvancedRemoteControl(IDevice device) : base(device) { }

        public void Mute()
        {
            Console.WriteLine("Muting device...");
            device.SetVolume(0);
        }
    }

    // Client Code
    class Program
    {
        protected void Main()
        {
            // Using a basic remote with a TV
            IDevice tv = new TV();
            RemoteControl basicRemote = new RemoteControl(tv);
            basicRemote.TogglePower();
            basicRemote.VolumeUp();

            Console.WriteLine();

            // Using an advanced remote with a Radio
            IDevice radio = new Radio();
            AdvancedRemoteControl advancedRemote = new AdvancedRemoteControl(radio);
            advancedRemote.TogglePower();
            advancedRemote.Mute();
        }
    }
}
