using System.IO;

namespace Gpio
{
    public class PwmPin : GpioPin
    {
        public int Frequency { get; private set; }

        public PwmPin(int frequency) : base(GpioPinNumber.Gpio11, Direction.Out)
        {
            Write(frequency);
        }

        public void Write(int frequency)
        {
            Frequency = frequency;
            File.WriteAllText(GpioPath + GpioPinNumber.ToString().ToLower() + "/value", frequency.ToString());
        }
    }

    public class OutputPin : GpioPin
    {
        public OutputPin(GpioPinNumber pin) : base(pin, Direction.Out)
        {
            Write(State.Low);
        }

        public OutputPin(GpioPinNumber pin, State state) : base(pin, Direction.Out)
        {
            Write(state);
        }

        public void Write(State state)
        {
            State = state;
            File.WriteAllText(GpioPath + GpioPinNumber.ToString().ToLower() + "/value", ((int)state).ToString());
        }

        public State State { get; private set; }
    }

    public class InputPin : GpioPin
    {
        public InputPin(GpioPinNumber pin)
            : base(pin, Direction.In)
        {

        }
    }

    public abstract class GpioPin
    {
        protected const string GpioPath = "/sys/class/gpio/";

        protected GpioPin(GpioPinNumber pin, Direction direction)
        {
            GpioPinNumber = pin;
            Direction = direction;

            File.WriteAllText(GpioPath + "export", ((int)pin).ToString());
            File.WriteAllText(GpioPath + pin.ToString().ToLower() + "/direction", direction.ToString().ToLower());
        }

        public GpioPinNumber GpioPinNumber { get; private set; }
        public Direction Direction { get; private set; }

        public string Read()
        {
            return File.ReadAllText(GpioPath + GpioPinNumber.ToString().ToLower() + "/value");
        }

        public void Cleanup()
        {
            File.WriteAllText(GpioPath + "unexport", ((int)GpioPinNumber).ToString());
        }
    }
}
