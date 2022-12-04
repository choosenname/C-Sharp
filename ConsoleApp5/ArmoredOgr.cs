using System;

namespace ConsoleApp5
{
    internal class ArmoredOgr : Ogr
    {
        int armorProtection;

        public ArmoredOgr(string name, int height, double weight, int age, SexEnum sex, int weaponDamage, int armorProtection) : base(name, height, weight, age, sex, weaponDamage)
        {
            ArmorProtection = armorProtection;
        }

        protected virtual (int, int) ArmorProtectionRange { get; } = (0, 50);

        public virtual int ArmorProtection
        {
            get => armorProtection;
            set
            {
                try
                {
                    if (value < ArmorProtectionRange.Item1 || value > ArmorProtectionRange.Item2) throw new ArgumentOutOfRangeException(ArmorProtectionRange);
                    else
                    {
                        armorProtection = value;
                    }
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); armorProtection = ArmorProtectionRange.Item1; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        protected override (int, int) WeightRange { get; } = (1, 350);

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