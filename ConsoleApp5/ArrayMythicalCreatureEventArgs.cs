namespace ConsoleApp5
{
    public class ArrayMythicalCreatureEventArgs
    {
        public string Message { get; } = null;

        public MythicalCreature Object { get; } = null;

        public ArrayMythicalCreatureEventArgs(string message, MythicalCreature obj)
        {
            Message = message;
            Object = obj;
        }
    }

    public delegate void ArrayMythicalCreatureHandler(object obj, ArrayMythicalCreatureEventArgs args);
}
