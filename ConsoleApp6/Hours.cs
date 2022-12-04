using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception;

namespace ConsoleApp6
{
    public enum HourTypeEnum
    {
        HourForSleep,
        HourForEat,
        HourForStudy,
        HourForLife,
        None
    }

    internal class Hours : IComparable<Hours>
    {
        int countOfHours;

        public HourTypeEnum HourType { get; set; }

        public static ShowExeptionFunc ShowExeption;

        public Hours()
        {
            countOfHours = 0;
            HourType = HourTypeEnum.None;
        }

        public Hours(int countOfHours, HourTypeEnum hourType)
        {
            CountOfHours = countOfHours;
            HourType = hourType;
        }

        public int CountOfHours
        {
            get => countOfHours;
            set
            {
                try
                {
                    if (value < 0) throw new LessThenZeroException();
                    else if (value > 24) throw new MoreThen24HourException();
                    countOfHours = value;
                }
                catch (LessThenZeroException ex)
                {
                    ShowExeption(ex);
                }
                catch (MoreThen24HourException ex)
                {
                    ShowExeption(ex);
                }
                catch (System.Exception ex)
                {
                    ShowExeption(ex);
                }
            }
        }

        public override string ToString()
        {
            return String.Format("{0} часов, тип {1}", countOfHours, HourType.ToString());
        }

        public int CompareTo(Hours other)
        {
            return CountOfHours - other.CountOfHours;
        }

        public static bool operator <(Hours left, Hours right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Hours left, Hours right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >(Hours left, Hours right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator >=(Hours left, Hours right)
        {
            return left.CompareTo(right) >= 0;
        }
    }
}
