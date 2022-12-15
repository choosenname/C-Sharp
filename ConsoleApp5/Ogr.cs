using System;

namespace ConsoleApp5
{
    [Serializable]
    public class Ogr : MythicalCreature
    {
        int weaponDamage;

        [NonSerialized]
        private readonly (int, int) weaponDamageRange = (0, 100);

        public Ogr(string name, int height, double weight, int age, SexEnum sex, int weaponDamage) : base(name, height, weight, age, sex)
        {
            WeaponDamage = weaponDamage;
        }

        public Ogr() : base() { }

        protected virtual (int, int) WeaponDamageRange => weaponDamageRange;
        public virtual int WeaponDamage
        {
            get => weaponDamage;
            set
            {
                try
                {
                    if (value < WeaponDamageRange.Item1 || value > WeaponDamageRange.Item2) { throw new ArgumentOutOfRangeException(WeaponDamageRange); }
                    else
                    {
                        weaponDamage = value;
                    }
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); weaponDamage = WeaponDamageRange.Item1; }
                catch (Exception ex) { ShowExeption(ex); }
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

        public override object Clone()
        {
            return new Ogr(Name, Height, Weight, Age, Sex, WeaponDamage);
        }
    }
}
