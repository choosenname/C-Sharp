using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception;

namespace ConsoleApp6
{
    internal class Student
    {
        int hoursForSleep = 0;
        int hoursForEat = 0;
        int hoursForStudy = 0;
        int hoursForLife = 0;
        int averageScore;

        public int AvailableHours { get; private set; } = 24;

        public static ShowExeptionFunc ShowExeption;

        public Student()
        {
            Enter();
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
        }

        public int HourForSleep
        {
            get => hoursForSleep;
            set
            {
                try
                {
                    if (value < 0) throw new LessThenZeroException();
                    else if (value > 24) throw new SumIsMoreThen24HourException();
                    hoursForSleep = value;
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (SumIsMoreThen24HourException ex)
                {
                    ShowExeption(ex);
                }
                catch (StudentException ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public int HourForEat
        {
            get => hoursForEat;
            set
            {
                try
                {
                    if (value < 0) throw new LessThenZeroException();
                    else if (AvailableHours - value < 0) throw new SumIsMoreThen24HourException();
                    else
                    {
                        hoursForEat = value;
                        AvailableHours -= value;
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
                catch (StudentException ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public int HourForStudy
        {
            get => hoursForStudy;
            set
            {
                try
                {
                    if (value < 0) throw new LessThenZeroException();
                    else if (AvailableHours - value < 0) throw new SumIsMoreThen24HourException();
                    else
                    {
                        hoursForStudy = value;
                        AvailableHours -= value;
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
                catch (StudentException ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public int HourForLife
        {
            get => hoursForLife;
            set
            {
                try
                {
                    if (value < 0) throw new LessThenZeroException();
                    else if (AvailableHours - value < 0) throw new SumIsMoreThen24HourException();
                    else hoursForLife = value;
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (SumIsMoreThen24HourException ex)
                {
                    ShowExeption(ex);
                }
                catch (StudentException ex)
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
                catch (StudentException ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public void Enter()
        {
            try
            {
                HourForSleep = Convert.ToInt32(Console.ReadLine());
                HourForEat = Convert.ToInt32(Console.ReadLine());
                HourForStudy = Convert.ToInt32(Console.ReadLine());
                HourForLife = Convert.ToInt32(Console.ReadLine());
                if (AvailableHours != 0) throw new SumIsNot24HourException();

                AverageScore = Convert.ToInt32(Console.ReadLine());
            }
            catch (SumIsNot24HourException ex)
            {
                ShowExeption(ex);
            }
            catch (StudentException ex)
            {
                ShowExeption(ex);
            }
        }

        public override string ToString()
        {
            return String.Format("Студент спит {0} часов, ест {1} часов, учится {2} часов, ну и личная жизнь {3} часов, средний балл {4}", HourForSleep, HourForEat, HourForStudy, HourForLife, AverageScore);
        }

        public void PriorityOccupation()
        {
        }
    }
}
