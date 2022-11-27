using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class ArrayMythicalCreature
    {
        public MythicalCreature[] ArrayOfMC { get; set; }
        internal ArrayMythicalCreature()
        {
            ArrayOfMC = new MythicalCreature[0];
        }
        public ArrayMythicalCreature(MythicalCreature[] MythicalCreature)
        {
            ArrayOfMC = MythicalCreature;
        }
        public void Add(MythicalCreature mythicalCreature)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrayOfMC.Length + 1];
            for (int i = 0; i < ArrayOfMC.Length; i++)
                NewMythicalCreatures[i] = ArrayOfMC[i];

            NewMythicalCreatures[ArrayOfMC.Length] = mythicalCreature;
            ArrayOfMC = NewMythicalCreatures;
        }
        public void Add(MythicalCreature[] value)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[value.Length + ArrayOfMC.Length];

            for (int i = 0; i < ArrayOfMC.Length; i++)
            {
                NewMythicalCreatures[i] = ArrayOfMC[i];
            }
            for (int i = ArrayOfMC.Length, j = 0; i < NewMythicalCreatures.Length; i++, j++)
            {
                NewMythicalCreatures[i] = value[j];
            }
            ArrayOfMC = NewMythicalCreatures;
        }
        public void Remove(MythicalCreature obj)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrayOfMC.Length - 1];
            for (int i = 0, j = 0; i < ArrayOfMC.Length && j < NewMythicalCreatures.Length; i++)
            {
                if (ArrayOfMC[i].CompareTo(obj) != 0)
                {
                    NewMythicalCreatures[j] = ArrayOfMC[i];
                    j++;
                }
            }
            ArrayOfMC = NewMythicalCreatures;
        }
        public void Remove(int index)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrayOfMC.Length - 1];
            for (int i = 0, j = 0; i < ArrayOfMC.Length && j < NewMythicalCreatures.Length; i++)
            {
                if (i != index)
                {
                    NewMythicalCreatures[j] = ArrayOfMC[i];
                    j++;
                }
            }
            ArrayOfMC = NewMythicalCreatures;
        }
        public override string ToString()
        {
            string str = null;
            for (int i = 0; i < ArrayOfMC.Length; i++)
                str += ArrayOfMC[i] + "\n";
            return str;
        }
        public MythicalCreature MaxDamage()
        {
            if (ArrayOfMC.Length > 1)
            {
                MythicalCreature max = ArrayOfMC[0];
                for (int i = 1; i < ArrayOfMC.Length; i++)
                {
                    if (max.Damage < ArrayOfMC[i].Damage)
                        max = ArrayOfMC[i];
                }
                return max;
            }
            else return null;
        }
        public MythicalCreature MinHealth()
        {
            if (ArrayOfMC.Length > 1)
            {
                MythicalCreature min = ArrayOfMC[0];
                for (int i = 1; i < ArrayOfMC.Length; i++)
                {
                    if (min.Health > ArrayOfMC[i].Health)
                        min = ArrayOfMC[i];
                }
                return min;
            }
            else return null;
        }
        public void SortByName()
        {
            for (int write = 0; write < ArrayOfMC.Length; write++)
            {
                for (int sort = 0; sort < ArrayOfMC.Length - 1; sort++)
                {
                    if (ArrayOfMC[sort].Name.CompareTo(ArrayOfMC[sort + 1].Name) > 0)
                    {
                        (ArrayOfMC[sort], ArrayOfMC[sort + 1]) = (ArrayOfMC[sort + 1], ArrayOfMC[sort]);
                    }
                }
            }
        }
        public int Figth(ArrayMythicalCreature obj)
        {
            while (ArrayOfMC.Length > 0 && obj.ArrayOfMC.Length > 0)
            {
                int flag = ArrayOfMC[0].Figth(obj.ArrayOfMC[0]);
                if (flag > 0)
                {
                    Console.WriteLine("Победитель " + ArrayOfMC[0]);
                    Console.WriteLine(obj.ArrayOfMC[0] + " выбывает");
                    obj.Remove(0);
                }
                else if (flag < 0)
                {
                    Console.WriteLine("Победитель " + obj.ArrayOfMC[0]);
                    Console.WriteLine(ArrayOfMC[0] + " выбывает");
                    Remove(0);
                }
                else
                {
                    Console.WriteLine("Оба выбывают");
                    Remove(0);
                    obj.Remove(0);
                }
            }
            return ArrayOfMC.Length - obj.ArrayOfMC.Length;
        }
    }
}
