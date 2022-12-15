using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp5
{
    [Serializable]
    public class ArrayMythicalCreature : IList<MythicalCreature>, IComparable<ArrayMythicalCreature>, ICloneable
    {
        public MythicalCreature[] ArrayMC { get; set; }

        public static event ArrayMythicalCreatureHandler Event;

        public int Count => ArrayMC.Length;

        public bool IsReadOnly => false;

        public MythicalCreature this[int index] { get => ArrayMC[index]; set => ArrayMC[index] = value; }

        internal ArrayMythicalCreature()
        {
            ArrayMC = new MythicalCreature[0];
        }

        public ArrayMythicalCreature(MythicalCreature[] MythicalCreature)
        {
            ArrayMC = MythicalCreature;
        }

        public void Add(MythicalCreature mythicalCreature)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrayMC.Length + 1];
            for (int i = 0; i < ArrayMC.Length; i++)
                NewMythicalCreatures[i] = ArrayMC[i];

            NewMythicalCreatures[ArrayMC.Length] = mythicalCreature;

            Event?.Invoke(this, new ArrayMythicalCreatureEventArgs("Добавлен объект", mythicalCreature));

            ArrayMC = NewMythicalCreatures;
        }

        public void Add(MythicalCreature[] value)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[value.Length + ArrayMC.Length];

            for (int i = 0; i < ArrayMC.Length; i++)
            {
                NewMythicalCreatures[i] = ArrayMC[i];
            }
            for (int i = ArrayMC.Length, j = 0; i < NewMythicalCreatures.Length; i++, j++)
            {
                NewMythicalCreatures[i] = value[j];
            }
            ArrayMC = NewMythicalCreatures;
        }

        public void Remove(int index)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrayMC.Length - 1];
            for (int i = 0, j = 0; i < ArrayMC.Length && j < NewMythicalCreatures.Length; i++)
            {
                if (i != index)
                {
                    NewMythicalCreatures[j] = ArrayMC[i];
                    j++;
                }
            }

            Event?.Invoke(this, new ArrayMythicalCreatureEventArgs("Удален объект", ArrayMC[index]));

            ArrayMC = NewMythicalCreatures;
        }

        public override string ToString()
        {
            string str = null;
            for (int i = 0; i < Count; i++)
                str += ArrayMC[i] + "\n";
            return str;
        }

        public delegate void ShowFunc(object[] arr);
        public static ShowFunc Func;

        public delegate void ArrayFunc(int index, MythicalCreature item);

        public void Show(ArrayFunc func)
        {
            for (int i = 0; i < Count; i++)
                func(i, ArrayMC[i]);
        }

        public void Show()
        {
            for (int i = 0; i < Count; i++)
                Console.WriteLine(i + ". " + ArrayMC[i]);
        }

        public delegate bool Compare(MythicalCreature obj1, MythicalCreature obj2);

        public MythicalCreature FindMax(Compare func)
        {
            if (ArrayMC.Length < 1) return null;

            MythicalCreature max = ArrayMC[0];
            for (int i = 1; i < ArrayMC.Length; i++)
            {
                if (func(max, ArrayMC[i]))
                    max = ArrayMC[i];
            }
            return max;
        }

        public MythicalCreature MaxDamage()
        {
            if (ArrayMC.Length > 0)
            {
                MythicalCreature max = ArrayMC[0];
                for (int i = 1; i < ArrayMC.Length; i++)
                {
                    if (max.Damage < ArrayMC[i].Damage)
                        max = ArrayMC[i];
                }
                return max;
            }
            else return null;
        }

        public MythicalCreature MinHealth()
        {
            if (ArrayMC.Length > 0)
            {
                MythicalCreature min = ArrayMC[0];
                for (int i = 1; i < ArrayMC.Length; i++)
                {
                    if (min.Health > ArrayMC[i].Health)
                        min = ArrayMC[i];
                }
                return min;
            }
            else return null;
        }

        public void SortByName()
        {
            Array.Sort(ArrayMC);
        }
        public int Figth(ArrayMythicalCreature obj)
        {
            while (ArrayMC.Length > 0 && obj.ArrayMC.Length > 0)
            {
                int flag = ArrayMC[0].Figth(obj.ArrayMC[0]);
                if (flag > 0)
                {
                    Console.WriteLine("Победитель " + ArrayMC[0]);
                    Console.WriteLine(obj.ArrayMC[0] + " выбывает");
                    obj.Remove(0);
                }
                else if (flag < 0)
                {
                    Console.WriteLine("Победитель " + obj.ArrayMC[0]);
                    Console.WriteLine(ArrayMC[0] + " выбывает");
                    Remove(0);
                }
                else
                {
                    Console.WriteLine("Оба выбывают");
                    Remove(0);
                    obj.Remove(0);
                }
            }
            return ArrayMC.Length - obj.ArrayMC.Length;
        }

        public int IndexOf(MythicalCreature item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (ArrayMC[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, MythicalCreature item)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[ArrayMC.Length + 1];

            if (index > 0 && index < Count)
            {
                for (int i = 0; i < index; i++)
                {
                    NewMythicalCreatures[i] = ArrayMC[i];
                }

                NewMythicalCreatures[index] = item;

                for (int i = Count; i > index; i--)
                {
                    NewMythicalCreatures[i] = ArrayMC[i - 1];
                }
            }
            ArrayMC = NewMythicalCreatures;
        }

        public void RemoveAt(int index)
        {
            MythicalCreature[] NewMythicalCreatures = new MythicalCreature[Count - 1 - index];

            if ((index >= 0) && (index < Count))
            {
                for (int i = index, j = 0; i < Count - 1; i++, j++)
                {
                    NewMythicalCreatures[j] = ArrayMC[i + 1];
                }
            }
            ArrayMC = NewMythicalCreatures;
        }

        public void Clear()
        {
            ArrayMC = new MythicalCreature[0];

            Event?.Invoke(this, new ArrayMythicalCreatureEventArgs("Массив очищен", null));
        }

        public bool Contains(MythicalCreature item)
        {
            if (item == null) return false;

            foreach (MythicalCreature mc in ArrayMC)
                if (mc == item) return true;

            return false;
        }

        public void CopyTo(MythicalCreature[] array, int arrayIndex)
        {
            for (int i = 0; i < Count; i++)
            {
                array.SetValue(ArrayMC[i], arrayIndex++);
            }
        }

        public bool Remove(MythicalCreature item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (ArrayMC[i].CompareTo(item) == 0)
                {
                    Remove(i);
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<MythicalCreature> GetEnumerator() => new ArrayMythicalCreatureEnum(ArrayMC);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int CompareTo(ArrayMythicalCreature other)
        {
            return ArrayMC.Length - other.ArrayMC.Length;
        }

        public object Clone()
        {
            return new ArrayMythicalCreature(ArrayMC);
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
                catch (Exception ex)
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