using System;

namespace CommandPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Testing Command Pattern--------\n");

            WiproSmartBulb livingRoomBulb = new WiproSmartBulb();

            ICommand turnOn = new TurnOnBulbCommand(livingRoomBulb);
            ICommand turnOff = new TurnOffBulbCommand(livingRoomBulb);

            SmartRemote remote = new SmartRemote();

            remote.SetCommand(turnOn);
            remote.PressButton();

            remote.SetCommand(turnOff);
            remote.PressButton();
        }
    }
}