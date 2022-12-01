using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Parallelogram
    {
        double square = 1;
        double aSide = 1;

        public delegate void ExceptionHandler(Exception ex);
        public static event ExceptionHandler ExceptionNotify;
        public double Square
        {
            get => square;
            set
            {
                try
                {
                    if (value <= 0) throw new ArgumentZeroOrLessException("Значение не может ровняться или быть меньше нуля");
                    square = value;
                }
                catch (ArgumentZeroOrLessException ex)
                {
                    ExceptionNotify?.Invoke(ex);
                }
                catch (Exception ex)
                {
                    ExceptionNotify?.Invoke(ex);
                }
            }
        }

        public double ASide
        {
            get => aSide;
            set
            {
                try
                {
                    if (value <= 0) throw new ArgumentZeroOrLessException("Значение не может ровняться или быть меньше нуля");
                    aSide = value;
                }
                catch (ArgumentZeroOrLessException ex)
                {
                    ExceptionNotify?.Invoke(ex);
                }
                catch (Exception ex)
                {
                    ExceptionNotify?.Invoke(ex);
                }
            }
        }

        public double GetHeight
        {
            get
            {
                try
                {
                    if (aSide == 0) throw new DivideByZeroException();
                    return square / aSide;
                }
                catch (DivideByZeroException ex)
                {
                    ExceptionNotify?.Invoke(ex);
                    aSide = 1;
                }
                catch (Exception ex)
                {
                    ExceptionNotify?.Invoke(ex);
                }
                return 0;
            }
        }
    }
}
