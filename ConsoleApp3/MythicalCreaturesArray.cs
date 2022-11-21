using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class MythicalCreaturesArray
    {
        public MythicalCreature[] ArrMythicalCreature { get; set; }
        internal MythicalCreaturesArray()
        {
            ArrMythicalCreature = new MythicalCreature[0];
        }
        internal MythicalCreaturesArray(MythicalCreature[] MythicalCreature)
        {
            ArrMythicalCreature = MythicalCreature;
        }
        ~MythicalCreaturesArray()
        {
            Console.WriteLine("Класс MythicalCreaturesArray удален");
        }
        public void Add(MythicalCreature mythicalCreature)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrMythicalCreature.Length + 1];
            for (int i = 0; i < ArrMythicalCreature.Length; i++)
                NewMythicalCreatures[i] = ArrMythicalCreature[i];

            NewMythicalCreatures[ArrMythicalCreature.Length] = mythicalCreature;
            ArrMythicalCreature = NewMythicalCreatures;
        }
        public void Add(MythicalCreature[] value)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[value.Length + ArrMythicalCreature.Length];

            for (int i = 0; i < ArrMythicalCreature.Length; i++)
            {
                NewMythicalCreatures[i] = ArrMythicalCreature[i];
            }
            for (int i = ArrMythicalCreature.Length, j = 0; i < NewMythicalCreatures.Length; i++, j++)
            {
                NewMythicalCreatures[i] = value[j];
            }
            ArrMythicalCreature = NewMythicalCreatures;
        }
        public void ShowMythicalCreatures()
        {
            for (int i = 0; i < ArrMythicalCreature.Length; i++)
                Console.WriteLine(ArrMythicalCreature[i]);
        }
        private int Choice(MythicalCreature mythicalCreature, int st)
        {
            switch (st)
            {
                case 0: return Convert.ToInt32(mythicalCreature.Name[0]);
                case 1: return mythicalCreature.Weight;
                case 2: return mythicalCreature.Height;
                case 3: return Convert.ToInt32(mythicalCreature.Sex);
                case 4: return mythicalCreature.Age;
                default: return 0;
            }
        }
        public void Sort(int st)
        {
            for (int write = 0; write < ArrMythicalCreature.Length; write++)
            {
                for (int sort = 0; sort < ArrMythicalCreature.Length - 1; sort++)
                {
                    if (Choice(ArrMythicalCreature[sort], st) > Choice(ArrMythicalCreature[sort + 1], st))
                    {
                        (ArrMythicalCreature[sort], ArrMythicalCreature[sort + 1]) = (ArrMythicalCreature[sort + 1], ArrMythicalCreature[sort]);
                    }
                }
            }
        }
        public MythicalCreature MinVal(int st)
        {
            MythicalCreature min = ArrMythicalCreature[0];
            for (int i = 1; i < ArrMythicalCreature.Length; i++)
            {
                int val = Choice(ArrMythicalCreature[i], st);
                if (val < Choice(min, st))
                {
                    min = ArrMythicalCreature[i];
                }
            }
            return min;
        }
        public MythicalCreature MaxVal(int st)
        {
            MythicalCreature max = ArrMythicalCreature[0];
            for (int i = 1; i < ArrMythicalCreature.Length; i++)
            {
                int val = Choice(ArrMythicalCreature[i], st);
                if (val > Choice(max, st))
                {
                    max = ArrMythicalCreature[i];
                }
            }
            return max;
        }

    }
}
