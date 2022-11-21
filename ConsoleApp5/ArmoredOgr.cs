using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class ArmoredOgr : Ogr
    {
        int protection;
        public int Protection
        {
            get => protection;
            set
            {
                try
                {
                    if (value < 0) { throw new Exception("Защита не может быть меньше 0"); }
                    else if (value > 50) { throw new Exception("Защита не может быть больше 50"); }
                    else { protection = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public ArmoredOgr(string name, int weight, int height, int age, SexEnum sex, int clubDamage, int ptotection) : base(name, weight, height, age, sex, clubDamage)
        {
            Protection = protection;
        }
        public override void TakeHit(int damage)
        {
            if (random.Next(0, 4) == 0) { damage -= protection / 2; }
            else { damage -= protection / 2; }
            base.TakeHit(damage);
        }
        public override void Heal(int HealHealth)
        {
            if (protection > HealHealth) { Health += protection; }
            else { Health += HealHealth; }
        }
    }
}