using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chummer.Backend.Data.Infrastructure;

namespace Chummer.Backend.Data.Sources
{
    class DataList<T> : IChummerDataSource<T>
    {
        public Dictionary<Guid, T> Items { get; set; }

        public DataList(Dictionary<Guid, T> items)
        {
            Items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (KeyValuePair<Guid, T> keyValuePair in Items)
            {
                yield return keyValuePair.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T this[Guid key]
        {
            get
            {
                T o;
                return Items.TryGetValue(key, out o) ? o : default(T);
            }
        }
    }

    
}
