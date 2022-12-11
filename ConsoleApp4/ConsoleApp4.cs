using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace ConsoleApp4
{
    internal class A
    {
        static string path = @"C:\Users\admin\Desktop\Labsы\КПиЯП17\";
        static void Main()
        {
            Random random = new Random();
            Motherboard motherboard = new Motherboard(random);

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            dirInfo.Create();

            Formatting(new BinaryFormatter(), "Binary.dat", motherboard);

            Formatting(new SoapFormatter(), "Soap.soap", motherboard);

            Formatting(new XmlSerializer(typeof(Motherboard)), "xml.xml", motherboard);
        }

        static void Formatting(IFormatter formatter, string filePath, object obj)
        {
            using (FileStream fs = new FileStream(path + filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }

        static void Formatting(XmlSerializer formatter, string filePath, object obj)
        {
            using (FileStream fs = new FileStream(path + filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
    }
}