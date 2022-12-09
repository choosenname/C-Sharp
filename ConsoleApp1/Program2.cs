using System.IO;

namespace ConsoleApp1
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\admin\Desktop\Labsы\09090.9090";
            string path1 = @"C:\Users\admin\Desktop\Labsы\15.15.1";

            StreamReader reader = new StreamReader(path);
            string str = reader.ReadToEnd();
            reader.Close();

            StreamWriter writer = new StreamWriter(path1, false);
            writer.Write(DelEvenIdex(str));
            writer.Close();
        }

        static string DelEvenIdex(string str)
        {
            string text = null;
            for (int i = 0; i < str.Length; i++)
                if (i % 2 != 0) text += str[i];
            return text;
        }
    }
}