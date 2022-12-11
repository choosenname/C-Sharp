using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\admin\Desktop\Labsы\09090.9090";
            FileStream file = File.Create(path);

            WriteFile(file);

            //Console.WriteLine(LetterOfEndWord(file));

            FindAllWords(file, LetterOfEndWord(file));

            file.Close();
        }

        static void WriteFile(FileStream file)
        {
            Random random = new Random();
            int wordsCount = 14;
            for (int i = 0; i < wordsCount; i++)
            {
                byte[] arr = null;
                arr = new byte[random.Next(3, 17)];
                for (int j = 0; j < arr.Length; j++)
                {
                    arr[j] = (byte)random.Next('a', 'z');
                }
                file.Write(arr, 0, arr.Length);
                if (i != wordsCount - 1) file.WriteByte((byte)' ');
            }
        }

        static char LetterOfEndWord(FileStream file)
        {
            file.Seek(0, SeekOrigin.End);
            while (' ' != file.ReadByte())
            {
                file.Position -= 2;
            }

            return (char)file.ReadByte();
        }

        static void FindAllWords(FileStream file, char Letter)
        {
            file.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[file.Length];
            file.Read(buffer, 0, buffer.Length);
            string str = Encoding.Default.GetString(buffer);

            foreach (Match match in new Regex(@"\b" + Letter + @"\w+\b").Matches(str))
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}