using System.Threading;
using Gpio;

namespace LedTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pin = new OutputPin(GpioPinNumber.Gpio11, State.High);

            Thread.Sleep(3000);
            pin.Write(State.Low);
            Thread.Sleep(1000);
            pin.Write(State.High);
            Thread.Sleep(3000);
            pin.Cleanup();
        }
    }
}