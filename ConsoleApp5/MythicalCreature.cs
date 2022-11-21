using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ConsoleApp5
{
    abstract internal class MythicalCreature
    {
        string name;
        SexEnum sex;
        int weight;
        int height;
        int age;
        int health;
        int damage;
        public enum SexEnum
        {
            None,
            Male,
            Female
        }
        protected virtual int Health
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                health = value;
            }
        }
        protected virtual int Damage
        {
            get => damage;
            set
            {
                if (value < 0)
                {
                    damage = 0;
                }
                damage = value;
            }
        }
        public virtual void SetHealth() { Health = Weight + Height / Age; }
        public virtual int GetHealth { get => Health; }
        public virtual void SetDamage() { Damage = (Weight + Height / Age) / 12; }
        public virtual int GetDamage { get => Damage; }
        public virtual void UpdateParameters()
        {
            SetHealth();
            SetDamage();
        }
        public virtual string Name
        {
            get => name;
            set
            {
                Regex regex = new Regex(@"\w{2,150}");
                try
                {
                    if (!regex.IsMatch(value))
                    { throw new Exception("Введенное имя не подходит"); }
                    else
                        name = value;
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
                    else if (value > 5000)
                    { throw new Exception("Рост не может быть больше 50 метров"); }
                    else
                    {
                        height = value;
                    }
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }
            }
        }
        public virtual int Weight
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
                    {
                        weight = value;
                    }
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
                    {
                        age = value;
                    }
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
        public MythicalCreature(string name, int weight, int height, int age, SexEnum sex)
        {
            Name = name;
            Weight = weight;
            Height = height;
            Age = age;
            Sex = sex;
            UpdateParameters();
        }
        public override string ToString()
        {
            return $"Имя {Name}, вес {Weight}, рост {Height}, возраст {Age}, пол {Sex}, здоровье {Health}, урон {Damage}";
        }
        protected Random random = new Random();
        public abstract int Attack();
        public abstract void TakeHit(int damage);
        public abstract int SpecialAttack();
    }
}
