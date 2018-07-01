using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Lynx
{
    public class Memory
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
                data[index] = value;
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

        public object PopAt(int index)
        {
            // The index needs to be reversed because the pop 
            // operation takes a value from the end of the list.
            var reversedIndex = ReverseIndex(index);

            var value = data[reversedIndex];

            data.RemoveAt(reversedIndex);

            Debug.WriteLine($"Stack pop at {reversedIndex}: {value}");

            return value;
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
