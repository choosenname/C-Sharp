using System;

namespace ConsoleApp5
{
    [Serializable]
    public class ArmoredOgr : Ogr
    {
        int armorProtection;

        public ArmoredOgr(string name, int height, double weight, int age, SexEnum sex, int weaponDamage, int armorProtection) : base(name, height, weight, age, sex, weaponDamage)
        {
            ArmorProtection = armorProtection;
        }

        public ArmoredOgr() : base() { }

        public virtual int ArmorProtection
        {
            get => armorProtection;
            set
            {
                try
                {
                    if (value < 0) { throw new Exception("Защита не может быть меньше 0"); }
                    else if (value > 50) { throw new Exception("Защита не может быть больше 50"); }
                    else { armorProtection = value; }
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
                    if (value > 350) { throw new Exception("Вес не может быть больше 350 кг"); }
                    else { base.Weight = value; }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
        public override void TakeHit(int damage)
        {
            if (random.Next(0, 2) == 0) { damage -= armorProtection; }
            else { damage -= armorProtection / 2; }
            base.TakeHit(damage);
        }
        public override void Heal(int HealHealth)
        {
            if (armorProtection > HealHealth) { Health += armorProtection; }
            else { Health += HealHealth; }
        }
        public override string ToString()
        {
            return base.ToString() + $", защита брони {armorProtection}";
        }

        public override object Clone()
        {
            return new ArmoredOgr(Name, Height, Weight, Age, Sex, WeaponDamage, ArmorProtection);
        }
    }
}