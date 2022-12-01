using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

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
        public MythicalCreature(string name, double weight, int height, int age, SexEnum sex)
        {
            Name = name;
            Weight = weight;
            Height = height;
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
                    Regex regex = new Regex(@"\w{2,150}");
                    if (!regex.IsMatch(value))
                    { throw new Exception("Введенное имя не подходит"); }
                    else
                    { name = value; }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        public virtual int Height
        {
            get => height;
            set
            {
                try
                {
                    if (value < 1)
                    { throw new Exception("Рост не может быть меньше 1"); }
                    else if (value > 50000)
                    { throw new Exception("Рост не может быть больше 5 км"); }
                    else
                    { height = value; }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        public virtual double Weight
        {
            get => weight;
            set
            {
                try
                {
                    if (value < 1)
                    { throw new Exception("Вес не может быть меньше 1"); }
                    else if (value > 50000)
                    { throw new Exception("Вес не может быть больше 50 тонн"); }
                    else
                    { weight = value; }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        public virtual int Age
        {
            get => age;
            set
            {
                try
                {
                    if (value < 1)
                    { throw new Exception("Возраст не может быть меньше 1"); }
                    else if (value > 10000)
                    { throw new Exception("Возраст не может быть больше 10000 лет"); }
                    else
                    { age = value; }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
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
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
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

        public abstract object Clone();
    }
}