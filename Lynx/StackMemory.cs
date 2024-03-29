﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lynx
{
    public class StackMemory
    {
        private List<object> data = new List<object>();

        public int Count => data.Count;

        public object this[int index]
        {
            get
            {
                return data[ReverseIndex(index)];
            }
            set
            {
                data[ReverseIndex(index)] = value;
            }
        }

        public void Push(object value)
        {
            Debug.WriteLine($"Stack push: {value}");
            data.Add(value);
        }

        public object Pop()
        {
            var value = data.Last();

            data.RemoveAt(data.Count - 1);

            Debug.WriteLine($"Stack pop: {value}");

            return value;
        }

        public object[] Pop(int count)
        {
            if (count > Count)
            {
                throw new InvalidOperationException("Attempt to pop more values than available.");
            }

            var data = new object[count];

            for (int i = 0; i < count; i++)
            {
                data[i] = Pop();
            }

            return data;
        }

        public object[] PopAll()
        {
            return Pop(Count);
        }

        public object PopAt(int index)
        {
            // The index needs to be reversed because the pop 
            // operation indexes items from the end of the list.
            var reversedIndex = ReverseIndex(index);

            var value = data[reversedIndex];

            data.RemoveAt(reversedIndex);

            Debug.WriteLine($"Stack pop at {reversedIndex}: {value}");

            return value;
        }

        public object PeekAt(int index)
        {
            // The index needs to be reversed because the peek 
            // operation indexes items from the end of the list.
            var reversedIndex = ReverseIndex(index);

            return data[reversedIndex];
        }

        public object Peek()
        {
            return PeekAt(0);
        }

        public void Clear()
        {
            data.Clear();
        }

        private int ReverseIndex(int index)
        {
            return data.Count - 1 - index;
        }
    }
}
