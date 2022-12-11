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
        static void Main()
        {
            Random random = new Random();
            Motherboard motherboard = new Motherboard(random);

            Formattering(new BinaryFormatter(), "Binary.dat", motherboard);

            Formattering(new SoapFormatter(), "Soap.soap", motherboard);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Motherboard));
            using (FileStream fs = new FileStream(@"C:\Users\admin\Desktop\Labsы\КПиЯП17\xml.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, motherboard);
            }
        }

        static void Formattering(IFormatter formatter, string filePath, object obj)
        {
            using (FileStream fs = new FileStream(@"C:\Users\admin\Desktop\Labsы\КПиЯП17\" + filePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, obj);
            }
        }
    }
}