using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Wyvern : Dragon
    {
        int diveDamage;
        public override void SetFireDamage() { FireDamage = Damage / 3 + Damage / 2 + DiveDamage; }
        public Wyvern(string name, int weight, int height, int age, SexEnum sex, int diveDamage) : base(name, weight, height, age, sex)
        {
            DiveDamage = diveDamage;
            SetFireDamage();
        }
        public int DiveDamage
        {
            get => diveDamage;
            set
            {
                try
                {
                    if (value < 1) { throw new Exception("Урон при пикировании не может быть меньше 1"); }
                    else if (value > 100) { throw new Exception("Урон при пикировании не может быть больше 50"); }
                    else { diveDamage = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public override double Weight
        {
            get => base.Weight;
            set
            {
                try
                {
                    if (value > 750) { throw new Exception("Вес не может быть больше 750 кг"); }
                    else { base.Weight = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public override int Height
        {
            get => base.Height;
            set
            {
                try
                {
                    if (value > 750) { throw new Exception("Рост не может быть больше 7,5 метров"); }
                    else { base.Height = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public override void TakeHit(int damage)
        {
            damage -= DiveDamage / 2;
            base.TakeHit(damage);
        }
        public override string ToString()
        {
            return base.ToString()+ $", урон при пикировании {DiveDamage}";
        }
    }
}