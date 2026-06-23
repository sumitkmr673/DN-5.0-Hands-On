using System;

namespace CommandPatternExample
{
    public interface ICommand
    {
        void Execute();
    }

    public class WiproSmartBulb
    {
        public void TurnOn()
        {
            Console.WriteLine("Wipro Smart Bulb is now ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("Wipro Smart Bulb is now OFF.");
        }
    }

    public class TurnOnBulbCommand : ICommand
    {
        private readonly WiproSmartBulb _bulb;

        public TurnOnBulbCommand(WiproSmartBulb bulb)
        {
            _bulb = bulb;
        }

        public void Execute()
        {
            _bulb.TurnOn();
        }
    }

    public class TurnOffBulbCommand : ICommand
    {
        private readonly WiproSmartBulb _bulb;

        public TurnOffBulbCommand(WiproSmartBulb bulb)
        {
            _bulb = bulb;
        }

        public void Execute()
        {
            _bulb.TurnOff();
        }
    }

    public class SmartRemote
    {
        private ICommand? _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public void PressButton()
        {
            _command?.Execute();
        }
    }
}