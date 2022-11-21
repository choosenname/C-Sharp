using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Ogr : MythicalCreature
    {
        int clubDamage;
        public Ogr(string name, int weight, int height, int age, SexEnum sex, int clubDamage) : base(name, weight, height, age, sex)
        {
            ClubDamage = clubDamage;
        }
        public virtual int ClubDamage
        {
            get => clubDamage;
            set
            {
                try
                {
                    if (value < 0) { throw new Exception("Урон дубинкой не может быть меньше 0"); }
                    else if (value > 100) { throw new Exception("Урон дубинкой не может быть больше 100"); }
                    else { clubDamage = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public override int Weight
        {
            get => base.Weight;
            set
            {
                try
                {
                    if (value > 200) { throw new Exception("Вес не может быть больше 200 кг"); }
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
                    if (value > 500) { throw new Exception("Рост не может быть больше 5 метров"); }
                    else { base.Height = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public override int Age
        {
            get => base.Age;
            set
            {
                try
                {
                    if (value > 100) { throw new Exception("Возраст не может быть больше 100 лет"); }
                    else { base.Age = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public override int Attack()
        {
            if (random.Next(0, 5) == 0) { Heal(random.Next(0, 50)); }
            if (Height > 4000)
                return Damage + ClubDamage;
            return Damage;
        }
        public override void TakeHit(int damage)
        {
            switch (random.Next(0, 7))
            {
                case 0: Health -= damage - ClubDamage; break;
                case 1: Health -= damage / 2; break;
                default: Health -= damage; break;
            }
        }
        public override int SpecialAttack()
        {
            switch (random.Next(0, 5))
            {
                case 0: return Damage + ClubDamage;
                case 1: return ClubDamage * 2;
                case 2: Heal(random.Next(20, 100)); return 0;
                default: return ClubDamage;
            }
        }
        public virtual void Heal(int HealHealth)
        {
            Health += HealHealth;
        }
    }
}
