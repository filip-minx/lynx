using System;

namespace Lynx
{
    public class Arguments
    {
        private object[] data;

        public Arguments(object[] data)
        {
            this.data = data;
        }

        public T Get<T>(int index)
        {
            return (T)Convert.ChangeType(data[index], typeof(T));
        }
    }
}
