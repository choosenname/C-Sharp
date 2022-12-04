using System;
using System.Text.RegularExpressions;

namespace ConsoleApp5
{
    public enum SexEnum
    {
        None,
        Male,
        Female
    }
    internal abstract class MythicalCreature : IComparable<MythicalCreature>, ICloneable
    {
        string name;
        SexEnum sex;
        double weight;
        int height;
        int age;
        int health;
        int damage;

        protected Regex regex = new Regex(@"\w{2,150}");
        protected Random random = new Random();

        public abstract int Attack();

        public abstract void TakeHit(int damage);

        public abstract int SpecialAttack();

        public virtual void SetHealth() => health = (int)Math.Round(weight) + (height / age);

        public virtual void SetDamage() => damage = ((int)Math.Round(weight) + (height / age)) / 12;

        public virtual int Health
        {
            get => health;
            protected set => health = value < 0 ? 0 : value;
        }

        public virtual int Damage
        {
            get => damage;
            protected set => damage = value < 0 ? 0 : value;
        }

        public MythicalCreature(string name, int height, double weight, int age, SexEnum sex)
        {
            Name = name;
            Height = height;
            Weight = weight;
            Age = age;
            Sex = sex;
            SetHealth();
            SetDamage();
        }

        public virtual string Name
        {
            get => name;
            set
            {
                try
                {
                    if (!regex.IsMatch(value)) throw new InvalidNameException();
                    else
                    {
                        name = value;
                    }
                }
                catch (InvalidNameException ex) { ShowExeption(ex); name = "none"; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        protected virtual (int, int) HeightRange { get; } = (1, 50000);

        public virtual int Height
        {
            get => height;
            set
            {
                try
                {
                    if (value < HeightRange.Item1 || value > HeightRange.Item2) throw new ArgumentOutOfRangeException(HeightRange);
                    else
                    {
                        height = value;
                    }
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); height = HeightRange.Item1; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        protected virtual (int, int) WeightRange { get; } = (1, 50000);

        public virtual double Weight
        {
            get => weight;
            set
            {
                try
                {
                    if (value < WeightRange.Item1 || value > WeightRange.Item2) throw new ArgumentOutOfRangeException(WeightRange);
                    else
                    {
                        weight = value;
                    }
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); weight = WeightRange.Item1; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        protected virtual (int, int) AgeRange { get; } = (1, 10000);

        public virtual int Age
        {
            get => age;
            set
            {
                try
                {
                    if (value < AgeRange.Item1 || value > AgeRange.Item2) throw new ArgumentOutOfRangeException(AgeRange);
                    else
                    {
                        age = value;
                    }
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); age = AgeRange.Item1; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        public virtual SexEnum Sex
        {
            get => sex;
            set
            {
                try
                {
                    sex = value;
                }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        public override string ToString()
        {
            return $"Класс {this.GetType()}: Имя {Name}, вес {Weight}, рост {Height}" +
                $", возраст {Age}, пол {Sex}, здоровье {Health}, урон {Damage}";
        }

        public virtual int Figth(MythicalCreature obj)
        {
            Console.WriteLine($"-------{Name} VS {obj.Name}-------");
            while (obj.health > 0 && health > 0)
            {
                if (random.Next(0, 4) != 0)
                {
                    int damage = obj.Attack(), damage1 = Attack();
                    TakeHit(damage);
                    obj.TakeHit(damage1);
                    Console.WriteLine($"{Name} наносит урон {damage1}, {obj.Name} наносит урон {damage}");
                }
                else
                {
                    int damage = obj.SpecialAttack(), damage1 = SpecialAttack();
                    TakeHit(damage);
                    obj.TakeHit(damage1);
                    Console.WriteLine($"(крит) {Name} наносит урон {damage1}, {obj.Name} наносит урон {damage}");
                }
            }
            return Health - obj.Health;
        }

        public int CompareTo(MythicalCreature other)
        {
            return name.CompareTo(other.name);
        }

        protected virtual void ShowExeption(Exception ex)
        {
            Console.WriteLine($"Исключение: {ex.Message}");
            Console.WriteLine($"Название приложения: {ex.Source}");
            Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            Console.WriteLine($"Метод: {ex.TargetSite}");
        }

        public abstract object Clone();
    }
}