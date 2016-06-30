using System;
using System.Threading;
using Gpio;

namespace LedTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pin11 = new OutputPin(GpioPinNumber.Gpio11);
            var pin2 = new OutputPin(GpioPinNumber.Gpio17);

            Console.WriteLine("Press ESC to stop");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                pin11.Write(State.Low);
                pin2.Write(State.High);
                Thread.Sleep(750);
                pin11.Write(State.High);
                pin2.Write(State.Low);
                Thread.Sleep(750);
            }

            pin11.Cleanup();
            pin2.Cleanup();              
        }
    }
}