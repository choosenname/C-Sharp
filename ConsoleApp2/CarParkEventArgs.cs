namespace КПиЯП
{
    internal class CarParkEventArgs
    {
        public string Message { get; }

        public Car Car { get; } = null;

        public CarParkEventArgs(string message)
        {
            Message = message;
        }

        public CarParkEventArgs(string message, Car car)
        {
            Message = message;
            Car = car;
        }
    }

    delegate void CarParkHandler(object obj, CarParkEventArgs args);
}
