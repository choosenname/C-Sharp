using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program3
    {
        static string dir = @"C:\Users\admin\Desktop\Labsы";

        static void Main(string[] args)
        {
            DirectoryInfo dirInfoK1 = CreateDir("K1");

            FileInfo fileInfoT1 = CreateFolder(dirInfoK1, "t1.txt", "Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            FileInfo fileInfoT2 = CreateFolder(dirInfoK1, "t2.txt", "Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");

            DirectoryInfo dirInfoK2 = CreateDir("K2");

            StreamReader reader = new StreamReader(fileInfoT1.OpenRead());
            FileInfo fileInfoT3 = CreateFolder(dirInfoK2, "t3.txt", reader.ReadToEnd());
            reader.Close();

            reader = new StreamReader(fileInfoT2.OpenRead());
            WriteText(fileInfoT3.OpenWrite(), reader.ReadToEnd());
            reader.Close();

            ShowInfo(fileInfoT1);
            ShowInfo(fileInfoT2);
            ShowInfo(fileInfoT3);

            if (!File.Exists(dirInfoK2 + "\\t2.txt")) fileInfoT2.MoveTo(dirInfoK2 + "\\t2.txt");
            if (!File.Exists(dirInfoK2 + "\\t1.txt")) fileInfoT1.CopyTo(dirInfoK2 + "\\t1.txt");


            dirInfoK1.Delete(true);
            if (Directory.Exists(dir + "\\ALL")) Directory.Delete(dir + "\\ALL", true);
            dirInfoK2.MoveTo(dir + "\\ALL");

            Console.WriteLine("------------------------Информация о файлах из папки ALL------------------------");
            ShowInfoFromDir(dirInfoK2);
        }

        static DirectoryInfo CreateDir(string folderName)
        {
            string path = dir + "\\" + folderName;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            dirInfo.Create();
            return dirInfo;
        }

        static FileInfo CreateFolder(DirectoryInfo directoryInfo, string fileName, string text)
        {
            FileInfo fileInfo = new FileInfo(directoryInfo + "\\" + fileName);
            WriteText(fileInfo.Create(), text);

            return fileInfo;
        }

        static void WriteText(FileStream fstream, string text)
        {
            fstream.Seek(0, SeekOrigin.End);
            StreamWriter writer = new StreamWriter(fstream);
            writer.Write(text);

            writer.Close();
            fstream.Close();
        }

        static void ShowInfo(FileInfo fileInfo)
        {
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
            Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
            Console.WriteLine($"Размер: {fileInfo.Length}");
        }

        static void ShowInfoFromDir(DirectoryInfo directoryInfo)
        {
            Console.WriteLine($"Название каталога: {directoryInfo.Name}");
            Console.WriteLine($"Полное название каталога: {directoryInfo.FullName}");
            Console.WriteLine($"Время создания каталога: {directoryInfo.CreationTime}");
            Console.WriteLine($"Корневой каталог: {directoryInfo.Root}");

            foreach(FileInfo fileInfo in directoryInfo.GetFiles())
            {
                ShowInfo(fileInfo);
            }
        }
    }
}
