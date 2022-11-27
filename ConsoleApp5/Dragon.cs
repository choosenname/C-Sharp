using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Dragon : MythicalCreature
    {
        int fireDamage;
        public int FireDamage
        {
            get => fireDamage;
            protected set => fireDamage = value < 0 ? 0 : value;
        }
        public virtual void SetFireDamage() { FireDamage = Damage / 3 + Damage / 2; }
        public Dragon(string name, int weight, int height, int age, SexEnum sex) : base(name, weight, height, age, sex)
        { SetFireDamage(); }
        public override int Height
        {
            get => base.Height;
            set
            {
                try
                {
                    if (value > 5000)
                    { throw new Exception("Рост не может быть больше 50 м"); }
                    else
                    { base.Height = value; }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        public override double Weight
        {
            get => base.Weight;
            set
            {
                try
                {
                    if (value > 2000)
                    { throw new Exception("Вес не может быть больше 2 тонн"); }
                    else
                    { base.Weight = value; }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        public override int Age
        {
            get => base.Age;
            set
            {
                try
                {
                    if (value > 1000)
                    { throw new Exception("Возраст не может быть больше 1000 лет"); }
                    else
                    { base.Age = value; }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        public override int Attack()
        {
            switch (random.Next(0, 5))
            {
                case 0: return Damage / 2;
                case 1: return Damage - (Damage / 2);
                case 2: return Damage;
                case 3: return Damage + (Damage / 2);
                case 4: return Damage + SpecialAttack();
                default: return Damage;
            }
        }
        public override void TakeHit(int damage)
        {
            Health -= damage;
        }
        public override int SpecialAttack()
        {
            if (Age >= 200 || random.Next(0, 4) == 0)
                return FireDamage + 20;
            else if (Age <= 30)
                return FireDamage - 50 > 0 ? FireDamage - 50 : FireDamage;
            else
                return FireDamage;
        }
        public override string ToString()
        {
            return base.ToString() + $", огненный урон {FireDamage}";
        }
    }
}