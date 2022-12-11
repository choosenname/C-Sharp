using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;

namespace ConsoleApp5
{
    internal class MainMythicalCreature
    {
        static string path = @"C:\Users\admin\Desktop\Labsы\ПП16\";

        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            dirInfo.Create();

            Dragon dragon = new Dragon("draconchik", 1500, 1500, 10, SexEnum.None);
            FormattingAll(dragon);

        }

        static void FormattingAll(object obj)
        {
            Formatting(new BinaryFormatter(), obj.GetType() + ".dat", obj);

            Formatting(new SoapFormatter(), obj.GetType() + ".soap", obj);

            Formatting(new XmlSerializer(obj.GetType()), obj.GetType() + ".xml", obj);
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
