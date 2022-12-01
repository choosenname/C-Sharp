using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class ArrayMythicalCreature : IList<MythicalCreature>, IComparable<ArrayMythicalCreature>, ICloneable
    {
        public MythicalCreature[] ArrayOfMC { get; set; }

        public int Count => ArrayOfMC.Length;

        public bool IsReadOnly => false;

        public MythicalCreature this[int index] { get => ArrayOfMC[index]; set => ArrayOfMC[index] = value; }

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
            for (int i = 0; i < Count; i++)
                str += ArrayOfMC[i] + "\n";
            return str;
        }
        public void Show()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine(i + ". " + ArrayOfMC[i]);
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
            Array.Sort(ArrayOfMC);
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

        public int IndexOf(MythicalCreature item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (ArrayOfMC[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, MythicalCreature item)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrayOfMC.Length + 1];

            if (index > 0 && index < Count)
            {
                for (int i = 0; i < index; i++)
                {
                    NewMythicalCreatures[i] = ArrayOfMC[i];
                }

                NewMythicalCreatures[index] = item;

                for (int i = Count; i > index; i--)
                {
                    NewMythicalCreatures[i] = ArrayOfMC[i - 1];
                }
            }
            ArrayOfMC = NewMythicalCreatures;
        }

        public void RemoveAt(int index)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[Count - 1 - index];

            if ((index >= 0) && (index < Count))
            {
                for (int i = index, j = 0; i < Count - 1; i++, j++)
                {
                    NewMythicalCreatures[j] = ArrayOfMC[i + 1];
                }
            }
            ArrayOfMC = NewMythicalCreatures;
        }

        public void Clear()
        {
            ArrayOfMC = new MythicalCreature[0];
        }

        public bool Contains(MythicalCreature item)
        {
            if (item == null) return false;

            foreach (MythicalCreature mc in ArrayOfMC)
                if (mc == item) return true;

            return false;
        }

        public void CopyTo(MythicalCreature[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(ArrayOfMC[i], arrayIndex++);
            }
        }

        public bool Remove(MythicalCreature item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (ArrayOfMC[i].CompareTo(item) == 0)
                {
                    Remove(i);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<MythicalCreature> GetEnumerator() => new ArrayMythicalCreatureEnum(ArrayOfMC);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int CompareTo(ArrayMythicalCreature other)
        {
            return ArrayOfMC.Length - other.ArrayOfMC.Length;
        }

        public object Clone()
        {
            return new ArrayMythicalCreature(ArrayOfMC);
        }
    }

    class ArrayMythicalCreatureEnum : IEnumerator<MythicalCreature>
    {
        public MythicalCreature[] mythicalCreatures;

        int position = -1;

        public ArrayMythicalCreatureEnum(MythicalCreature[] mythicalCreatures)
        {
            this.mythicalCreatures = mythicalCreatures;
        }

        public object Current
        {
            get
            {
                try
                {
                    if (position == -1 || position >= mythicalCreatures.Length)
                        throw new IndexOutOfRangeException();
                    return mythicalCreatures[position];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return null;
            }
        }

        MythicalCreature IEnumerator<MythicalCreature>.Current
        {
            get
            {
                try
                {
                    if (position == -1 || position >= mythicalCreatures.Length)
                        throw new IndexOutOfRangeException();
                    return mythicalCreatures[position];
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return null;
            }
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            position++;
            return position < mythicalCreatures.Length;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}