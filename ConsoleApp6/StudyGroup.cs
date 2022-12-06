using System;

namespace ConsoleApp6
{
    internal class StudyGroup
    {
        int girlsQuantity;
        int boysQuantity;


        public static event StudyGroupHandler Event;
        public static event StudyGroupHandler Adding;
        public static event StudyGroupHandler Deducting;

        public StudyGroup(int girlsQuantity, int boysQuantity)
        {
            GirlsQuantity = girlsQuantity;
            BoysQuantity = boysQuantity;

            Event?.Invoke(this, new StudyGroupEventArgs("Создана группа", GirlsQuantity, BoysQuantity));
        }

        public int GirlsQuantity
        {
            get => girlsQuantity;
            set
            {
                try
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("Количество девушек не может быть меньше 0");
                    else girlsQuantity = value;
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); girlsQuantity = 0; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        public int BoysQuantity
        {
            get => boysQuantity;
            set
            {
                try
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException("Количество юношей не может быть меньше 0");
                    else boysQuantity = value;
                }
                catch (ArgumentOutOfRangeException ex) { ShowExeption(ex); boysQuantity = 0; }
                catch (Exception ex) { ShowExeption(ex); }
            }
        }

        public void AddBoys(int boysQuantity)
        {
            try
            {
                boysQuantity = boysQuantity < 0 ? Math.Abs(boysQuantity) : boysQuantity;
                BoysQuantity += boysQuantity;
                Adding?.Invoke(this, new StudyGroupEventArgs("В группу добавлены юноши ", boysQuantity));
            }
            catch (ArgumentException ex) { ShowExeption(ex); }
            catch (Exception ex) { ShowExeption(ex); }
        }

        public void Deduct(int girlsQuantity, int boysQuantity)
        {
            try
            {
                boysQuantity = boysQuantity < 0 ? Math.Abs(boysQuantity) : boysQuantity;
                girlsQuantity = girlsQuantity < 0 ? Math.Abs(girlsQuantity) : girlsQuantity;

                double BDiff = BoysQuantity - boysQuantity, GDiff = GirlsQuantity - girlsQuantity;
                if (GDiff < 0 || BDiff < 0)
                    Deducting?.Invoke(this, new StudyGroupEventArgs("Нельзя отчислить больше чем есть студентов", girlsQuantity, boysQuantity));
                else
                {
                    double diff;
                    if (BDiff == 0)
                        diff = BDiff / GDiff;
                    else diff = GDiff / BDiff;

                    if (diff < 0.9 || diff > 1.12)
                        throw new Exception("Количество девушек и юношей должно быть примерно равно");

                    GirlsQuantity -= girlsQuantity;
                    BoysQuantity -= boysQuantity;

                    Deducting?.Invoke(this, new StudyGroupEventArgs("Отчислены", girlsQuantity, boysQuantity));
                }

            }
            catch (Exception ex) { ShowExeption(ex); }
        }

        public override string ToString()
        {
            return String.Format("В группе {0} девушек и {1} юношей", GirlsQuantity, BoysQuantity);
        }

        public void ShowExeption(System.Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
