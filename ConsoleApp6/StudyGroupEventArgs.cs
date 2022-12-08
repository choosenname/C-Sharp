namespace ConsoleApp6
{
    class StudyGroupEventArgs
    {
        public string Message { get; }


        public int Boys { get; } = 0;

        public int Girls { get; } = 0;

        public StudyGroupEventArgs(string mes, int boys)
        {

            Message = mes;
            Boys = boys;
        }

        public StudyGroupEventArgs(string mes, int boys, int girls)
        {

            Message = mes;
            Boys = boys;
            Girls = girls;
        }
    }

    delegate void StudyGroupHandler(object obj, StudyGroupEventArgs sg);
}
