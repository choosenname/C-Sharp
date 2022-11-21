using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Dragon : MythicalCreature
    {
        int FireDamage;
        protected virtual void SetFireDamage() { FireDamage = Damage / 3 + Damage / 2; }
        public int GetFireDamege { get => FireDamage; }
        public override void UpdateParameters()
        {
            base.UpdateParameters();
            SetFireDamage();
        }
        public Dragon(string name, int weight, int height, int age, SexEnum sex) : base(name, weight, height, age, sex) { }
        public override int Attack()
        {
            switch (random.Next(0, 5))
            {
                case 0: return Damage / 2;
                case 1: return Damage - (Damage / 2);
                case 2: return Damage;
                case 3: return Damage + (Damage / 2);
                case 4: return Damage + SpecialAttack();
                default: return Damage;
            }
        }
        public override int SpecialAttack()
        {
            if (Age >= 200 || random.Next(0, 4) == 0)
                return FireDamage + 20;
            else if (Age <= 30)
                return FireDamage - 50 > 0 ? FireDamage - 50 : FireDamage;
            else
                return FireDamage;
        }
        public override void TakeHit(int damage)
        {
            Health -= damage;
        }
        public override string ToString()
        {
            return base.ToString() + $", огненный урон {FireDamage}";
        }
    }
}