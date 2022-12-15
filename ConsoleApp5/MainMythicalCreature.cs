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
            Wyvern wyvern = new Wyvern("Дребр", 500, 250, 45, SexEnum.Female, 28);

            FormattingAll(dragon);
            FormattingAll(wyvern);
            FormattingAll(new Ogr("лешка", 250, 300, 30, SexEnum.Male, 50));
            FormattingAll(new ArmoredOgr("cursed", 300, 200, 25, SexEnum.Female, 100, 30));

        }

        static void FormattingAll(object obj)
        {
            Formatting(new BinaryFormatter(), obj.GetType().Name + ".dat", obj);

            Formatting(new SoapFormatter(), obj.GetType().Name + ".soap", obj);

            XmlIncludeAttribute attribute = new XmlIncludeAttribute(obj.GetType()); 
            Formatting(new XmlSerializer(attribute.Type), obj.GetType().Name + ".xml", obj);
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
