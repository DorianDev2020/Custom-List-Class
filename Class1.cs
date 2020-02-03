using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListProj
{
    class Class1
    {
        public class CustomList<T> : IEnumerable where T : IComparable
        {
            T[] genericarray;
            int capacityAdd;

            public int Count { get; private set; }

            public int Capacity { get; set; }

            public T this[int i]
            {
                get
                {
                    if (i < 0 || i >= Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    return genericarray[i];
                }
                set
                {
                    if (i < 0 || i >= Count)
                    {
                        throw new IndexOutOfRangeException();
                    }
                    genericarray[i] = value;
                }
            }


            public CustomList()
            {
                Capacity = 0;
                capacityAdd = 4;
                Count = 0;
                genericarray = new T[Capacity];
            }

            public void Add(T item)
            {
                if (Count == Capacity)
                {
                    Capacity += capacityAdd;
                    T[] temporary = genericarray;
                    genericarray = new T[Capacity];
                    for (int i = 0; i < Count; i++)
                    {
                        genericarray[i] = temporary[i];
                    }
                }
                genericarray[Count++] = item;
            }
            public bool Remove(T item)
            {
                bool foundItem = false;
                int counter = 0;
                do
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (genericarray[i].Equals(item))
                        {
                            foundItem = true;
                            break;
                        }
                        counter++;
                    }
                } while (foundItem == false && counter <= Count);
                if (foundItem)
                {
                    Count--;
                    for (int i = counter; i < Count; i++)
                    {
                        genericarray[i] = genericarray[i + 1];
                    }
                    SubtractCapacity();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public void SubtractCapacity()
            {

                if (Count <= (Capacity - capacityAdd))
                {
                    Capacity -= capacityAdd;
                    T[] temporary = genericarray;
                    genericarray = new T[Capacity];
                    for (int i = 0; i < Count; i++)
                    {
                        genericarray[i] = temporary[i];
                    }
                }
            }
            public override string ToString()
            {
                string value = string.Empty;
                for (int i = 0; i < Count; i++)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        value += genericarray[i].ToString();
                    }
                    else
                    {
                        value += string.Format(", {0}", genericarray[i]);
                    }
                }
                return value;
            }
            public static CustomList<T> operator +(CustomList<T> firstList, CustomList<T> secondList)
            {
                CustomList<T> temporary = firstList;
                foreach (T item in secondList)
                {
                    temporary.Add(item);
                }
                return temporary;
            }
            public static CustomList<T> operator -(CustomList<T> firstList, CustomList<T> secondList)
            {
                CustomList<T> temporary = firstList;
                foreach (T item in secondList)
                {
                    temporary.Remove(item);
                }
                return temporary;
            }
            public CustomList<T> Zip(CustomList<T> firstList, CustomList<T> secondList)
            {
                CustomList<T> temporary = new CustomList<T>();
                if (firstList.Count <= secondList.Count)
                {
                    for (int i = 0; i < firstList.Count; i++)
                    {
                        temporary.Add(firstList[i]);
                        temporary.Add(secondList[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < secondList.Count; i++)
                    {
                        temporary.Add(firstList[i]);
                        temporary.Add(secondList[i]);
                    }
                }
                return temporary;
            }
            public T[] Sort()
            {

                if (Count == 1)
                {
                    return genericarray;
                }
                bool swapItem = false;
                for (int i = 0; i < (Count - 1); i++)
                {
                    if (genericarray[i].CompareTo(genericarray[i + 1]) > 0)
                    {
                        T temporary = genericarray[i];
                        genericarray[i] = genericarray[i + 1];
                        genericarray[i + 1] = temporary;
                        swapItem = true;
                    }
                }
                if (swapItem)
                {
                    Sort();
                }
                return genericarray;
            }
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < Count; i++)
                {
                    yield return genericarray[i];
                }
            }
        }
    }
}
