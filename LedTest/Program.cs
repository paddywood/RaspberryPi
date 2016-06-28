using System;
using System.Threading;
using Gpio;

namespace LedTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pin = new OutputPin(GpioPinNumber.Gpio11, State.High);

            Console.WriteLine("Press ESC to stop");

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                Thread.Sleep(1000);
                pin.Write(State.Low);
                Thread.Sleep(1000);
                pin.Write(State.High);
            }

            pin.Cleanup();
                        
        }
    }
}