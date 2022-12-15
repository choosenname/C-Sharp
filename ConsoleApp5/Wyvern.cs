using System;

namespace ConsoleApp5
{
    [Serializable]
    public class Wyvern : Dragon
    {
        int diveDamage;
        [NonSerialized] private readonly (int, int) diveDamageRange = (1, 100);

        public override void SetFireDamage() { FireDamage = Damage / 3 + Damage / 2 + DiveDamage; }

        public Wyvern(string name, double weight, int height, int age, SexEnum sex, int diveDamage) : base(name, height, weight, age, sex)
        {
            DiveDamage = diveDamage;
            SetFireDamage();
        }

        public Wyvern() : base() { }

        protected virtual (int, int) DiveDamageRange => diveDamageRange;
        public int DiveDamage
        {
            get => diveDamage;
            set
            {
                try
                {
                    if (value < DiveDamageRange.Item1 || value > DiveDamageRange.Item2) throw new ArgumentOutOfRangeException(DiveDamageRange);
                    else
                    {
                        diveDamage = value;
                    }
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); diveDamage = DiveDamageRange.Item1; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        public override void TakeHit(int damage)
        {
            damage -= DiveDamage / 2;
            base.TakeHit(damage);
        }

        public override string ToString()
        {
            return base.ToString() + $", урон при пикировании {DiveDamage}";
        }

        public override object Clone()
        {
            return new Wyvern(Name, Weight, Height, Age, Sex, DiveDamage);
        }
    }
}