namespace ConsoleApp5
{
    internal class Dragon : MythicalCreature
    {
        int fireDamage;

        public int FireDamage
        {
            get => fireDamage;
            protected set
            {
                fireDamage = value < 0 ? 0 : value;
            }
        }

        public virtual void SetFireDamage() { FireDamage = Damage / 3 + Damage / 2; }

        public Dragon(string name, int height, double weight, int age, SexEnum sex) : base(name, height, weight, age, sex)
        { SetFireDamage(); }

        protected override (int, int) HeightRange { get; } = (1, 5000);

        protected override (int, int) WeightRange { get; } = (1, 2000);

        protected override (int, int) AgeRange { get; } = (1, 1000);

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

        public override void TakeHit(int damage)
        {
            Health -= damage;
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

        public override string ToString()
        {
            return base.ToString() + $", огненный урон {FireDamage}";
        }

        public override object Clone()
        {
            return new Dragon(Name, Height, Weight, Age, Sex);
        }
    }
}