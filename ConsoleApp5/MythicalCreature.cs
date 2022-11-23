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
    internal abstract class MythicalCreature
    {
        protected string name;
        SexEnum sex;
        protected double weight;
        protected int height;
        protected int age;
        protected int health;
        protected int damage;
        protected Random random = new Random();
        protected Regex regex = new Regex(@"\w{2,150}");
        public enum SexEnum
        {
            None,
            Male,
            Female
        }
        public virtual string Name
        {
            get => name;
            set
            {
                try
                {
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
        public virtual void SetHealth() => Health = (int)Math.Round(Weight) + (Height / Age);
        public virtual void SetDamage() => Damage = ((int)Math.Round(Weight) + (Height / Age)) / 12;
        public MythicalCreature(string name, int weight, int height, int age, SexEnum sex)
        {
            Name = name;
            Weight = weight;
            Height = height;
            Age = age;
            Sex = sex;
            SetHealth();
            SetDamage();
        }
        public override string ToString()
        {
            return $"Класс {this.GetType()}: Имя {Name}, вес {Weight}, рост {Height}, возраст {Age}, пол {Sex}, здоровье {Health}, урон {Damage}";
        }
        public abstract int Attack();
        public abstract void TakeHit(int damage);
        public abstract int SpecialAttack();

        public virtual MythicalCreature Figth(MythicalCreature obj)
        {
            while (obj.Health > 0 && Health > 0)
            {
                if (random.Next(0, 4) != 0)
                {
                    TakeHit(obj.Attack());
                    obj.TakeHit(Attack());
                }
                else
                {
                    TakeHit(obj.SpecialAttack());
                    obj.TakeHit(SpecialAttack());
                }
            }
            return Health < 1 ? obj : this;
        }
    }
}
