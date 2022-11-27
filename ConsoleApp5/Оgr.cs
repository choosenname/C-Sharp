using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Ogr : MythicalCreature
    {
        int weaponDamage;
        public Ogr(string name, int weight, int height, int age, SexEnum sex, int weaponDamage) : base(name, weight, height, age, sex)
        {
            WeaponDamage = weaponDamage;
        }
        public virtual int WeaponDamage
        {
            get => weaponDamage;
            set
            {
                try
                {
                    if (value < 0) { throw new Exception("Урон оружием не может быть меньше 0"); }
                    else if (value > 100) { throw new Exception("Урон оружием не может быть больше 100"); }
                    else { weaponDamage = value; }
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
                    if (value > 450)
                    { throw new Exception("Вес не может быть больше 450 кг"); }
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
                    if (value > 500)
                    { throw new Exception("Рост не может быть больше 5 метров"); }
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
            switch (random.Next(0, 3))
            {
                case 0:
                    return Damage + WeaponDamage;
                case 1:
                    return Damage;
                case 2:
                    return Damage + WeaponDamage / 2;
                default:
                    return Damage;

            }
        }
        public override void TakeHit(int damage)
        {
            switch (random.Next(0, 7))
            {
                case 0: Health -= damage - WeaponDamage; break;
                case 1: Health -= damage / 2; break;
                default: Health -= damage; break;
            }
        }
        public override int SpecialAttack()
        {
            switch (random.Next(0, 5))
            {
                case 0: return Damage + WeaponDamage;
                case 1: return WeaponDamage * 2;
                case 2: Heal(random.Next(20, 100)); return 0;
                default: return WeaponDamage;
            }
        }
        public virtual void Heal(int HealHealth)
        {
            Health += HealHealth;
        }
        public override string ToString()
        {
            return base.ToString() + $", урон дубинкой {weaponDamage}";
        }
    }
}
