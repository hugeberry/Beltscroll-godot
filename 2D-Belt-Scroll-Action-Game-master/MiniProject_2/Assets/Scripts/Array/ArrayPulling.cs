using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//자료구조 
namespace ArrayPulling
{
    public class ArrayObject<T>
    {
        private T[] arr;
        public int arrMin;
        public int current;
        public int length;

        public ArrayObject()
        {
            arrMin = 0;
            current = 0;
            length = 0;
            arr = new T[length];
        }


        public bool CheackPosition(int position)
        {
            if (position > length || position < 0)
            {
                return false;
            }
            return true;
        }

        public T get(int position)
        {
            return arr[position];
        }

        public T get(T position)
        {
            for (int i = 0; i < length; i++)
            {
                if (position.Equals(arr[i]))
                {
                    return arr[i];
                }
            }
            return default;
        }

        public void add(T item)
        {
            Array.Resize(ref arr, ++length);
            arr[current++] = item;
        }

        public void set(T item, int position)
        {
            arr[position] = item;
        }

        public void remove(int position)
        {
            for (int i = position; i < length; i++)
            {
                arr[position] = arr[position + 1];
            }
            Array.Resize(ref arr, (--length));
        }

        public int getPosition(T item)
        {
            for (int i = 0; i < length; i++)
            {
                if (item.Equals(arr[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}