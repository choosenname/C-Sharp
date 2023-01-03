using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public int GroupNumber { get; set; }

        public int[] Evaluations { get; set; }

        public Student()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Patronymic = string.Empty;

            GroupNumber = 0;
            Evaluations = new int[0];
        }

        public Student(Random random)
        {
            Name = GenName(random);
            Surname = GenName(random);
            Patronymic = GenName(random);

            GroupNumber = random.Next(1, 100);
            Evaluations = new int[3];
            for (int i = 0; i < Evaluations.Length; i++)
            {
                Evaluations[i] = random.Next(1, 6);
            }
        }

        private string GenName(Random random)
        {
            string str = null;
            str += (char)random.Next('А', 'Я');
            for (int i = 0; i < random.Next(2, 16); i++)
            {
                str += (char)random.Next('а', 'я');
            }
            return str;
        }

        public bool SuccStud()
        {
            foreach (var i in Evaluations)
            {
                if(i < 4) return false;
            }
            return true;
        }

        public override string ToString()
        {
            string str = null;
            foreach(var i in Evaluations)
            {
                if(str != null) { str += ", "; }
                str += i.ToString();
            }
            return $"{Name} {Surname} {Patronymic} учиться в группе {GroupNumber} на оценки: {str}";
        }
    }
}
