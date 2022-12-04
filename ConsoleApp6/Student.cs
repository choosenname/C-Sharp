using Exception;
using System;

namespace ConsoleApp6
{
    internal class Student
    {
        Hours hoursForSleep = new Hours();
        Hours hourForEat = new Hours();
        Hours hourForStudy = new Hours();
        Hours hourForLife = new Hours();
        int averageScore;

        public int AvailableHours { get; private set; } = 24;

        public static ShowExeptionFunc ShowExeption;

        public Student()
        {
            Enter();
        }

        public Student(Random random)
        {
            Enter(random);
        }

        public Student(int HourForSleep, int HourForEat, int HourForStudy, int HourForLife, int AverageScore)
        {
            this.HourForSleep = HourForSleep;
            this.HourForEat = HourForEat;
            this.HourForStudy = HourForStudy;
            this.HourForLife = HourForLife;
            this.AverageScore = AverageScore;
            try
            {
                if (AvailableHours != 0) throw new StudentException("Сумма всех часов должна быть 24");
            }
            catch (StudentException ex)
            {
                ShowExeption(ex);
            }
            catch (ArgumentException ex)
            {
                ShowExeption(ex);
            }
            catch (System.Exception ex)
            {
                ShowExeption(ex);
            }
        }

        public int HourForSleep
        {
            get => hoursForSleep.CountOfHours;
            set
            {
                try
                {
                    int newHour = value - HourForSleep;
                    if (AvailableHours - newHour < 0) throw new SumIsMoreThen24HourException();
                    else
                    {
                        AvailableHours -= newHour;

                        hoursForSleep = new Hours(value, HourTypeEnum.HourForSleep);
                    }
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (SumIsMoreThen24HourException ex)
                {
                    Console.WriteLine(AvailableHours);
                    ShowExeption(ex);
                }
                catch (ArgumentException ex)
                {
                    ShowExeption(ex);
                }
                catch (System.Exception ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public int HourForEat
        {
            get => hourForEat.CountOfHours;
            set
            {
                try
                {
                    int newHour = value - HourForEat;
                    if (AvailableHours - newHour < 0) throw new SumIsMoreThen24HourException();
                    else
                    {
                        AvailableHours -= newHour;

                        hourForEat = new Hours(value, HourTypeEnum.HourForEat);
                    }
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (SumIsMoreThen24HourException ex)
                {
                    ShowExeption(ex);
                }
                catch (ArgumentException ex)
                {
                    ShowExeption(ex);
                }
                catch (System.Exception ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public int HourForStudy
        {
            get => hourForStudy.CountOfHours;
            set
            {
                try
                {
                    int newHour = value - HourForStudy;
                    if (AvailableHours - newHour < 0) throw new SumIsMoreThen24HourException();
                    else
                    {
                        AvailableHours -= newHour;

                        hourForStudy = new Hours(value, HourTypeEnum.HourForStudy);
                    }
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (SumIsMoreThen24HourException ex)
                {
                    ShowExeption(ex);
                }
                catch (ArgumentException ex)
                {
                    ShowExeption(ex);
                }
                catch (System.Exception ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public int HourForLife
        {
            get => hourForLife.CountOfHours;
            set
            {
                try
                {
                    int newHour = value - HourForLife;
                    if (AvailableHours - newHour < 0) throw new SumIsMoreThen24HourException();
                    else
                    {
                        AvailableHours -= newHour;

                        hourForLife = new Hours(value, HourTypeEnum.HourForStudy);
                    }
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (SumIsMoreThen24HourException ex)
                {
                    ShowExeption(ex);
                }
                catch (ArgumentException ex)
                {
                    ShowExeption(ex);
                }
                catch (System.Exception ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public int AverageScore
        {
            get => averageScore;
            set
            {
                try
                {
                    if (value < 0) throw new LessThenZeroException();
                    else if (value > 10) throw new ArgumentException("Оценка не может быть больше 10");
                    else averageScore = value;
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (ArgumentException ex)
                {
                    ShowExeption(ex);
                }
                catch (System.Exception ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public void Enter()
        {
            try
            {
                do
                {
                    Console.WriteLine("Сумма всех часов должна быть 24");
                    Console.WriteLine("Введите количество часов для сна");
                    HourForSleep = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите количество часов для покушат");
                    HourForEat = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите количество часов для учебы");
                    HourForStudy = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Введите количество часов для личной жизни");
                    HourForLife = Convert.ToInt32(Console.ReadLine());
                }
                while (AvailableHours != 0);

                Console.WriteLine("Введите средний балл");
                AverageScore = Convert.ToInt32(Console.ReadLine());
            }
            catch (StudentException ex)
            {
                ShowExeption(ex);
            }
        }

        public void Enter(Random random)
        {
            do
            {
                HourForSleep += random.Next(0, (AvailableHours + 1) / 2 + 1);

                HourForEat += random.Next(0, (AvailableHours + 1) / 2 + 1);

                HourForStudy += random.Next(0, (AvailableHours + 1) / 2 + 1);

                HourForLife += random.Next(0, (AvailableHours + 1) / 2 + 1);
            }
            while (AvailableHours != 0);
            AverageScore = random.Next(0, 11);
        }

        public override string ToString()
        {
            return String.Format("Студент спит {0} часов, ест {1} часов, учится {2} часов, ну и личная жизнь {3} часов, средний балл {4}", HourForSleep, HourForEat, HourForStudy, HourForLife, AverageScore);
        }

        Hours Max(Hours h1, Hours h2)
        {
            return h1 > h2 ? h1 : h2;
        }

        public Hours PriorityOccupation()
        {
            return Max(Max(hoursForSleep, hourForEat), Max(hourForStudy, hourForLife));
        }
    }
}
