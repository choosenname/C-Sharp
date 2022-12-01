using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    public enum TypeOfHoursEnum
    {
        HourForSleep,
        HourForEat,
        HourForStudy,
        HourForLife
    }

    internal class Hours
    {
        int countOfHours;
        int hourType;

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
                catch (Exception ex)
                {
                    ShowExeption(ex);
                }
            }
        }
    }
}
