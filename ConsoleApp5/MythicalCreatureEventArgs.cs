namespace ConsoleApp5
{
    public class MythicalCreatureEventArgs
    {
        public string Message { get; }

        public MythicalCreatureEventArgs(string message)
        {
            Message = message;
        }
    }

    public delegate void MythicalCreatureHandler(object obj, MythicalCreatureEventArgs args);
}