using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataStructures42
{
    internal class MyStack<T> : IStack<T>, IEnumerable<T> where T : IComparable //task 1
    {
        private readonly List<T> _internalCollection;
        public MyStack()
        {
            _internalCollection = new List<T>();
        }

        public T MinValue => _internalCollection.Min();
       
        public T Pop()
        {
            if (_internalCollection.Count == 0)
                throw new InvalidOperationException("Collection is empty");

            T item = _internalCollection[_internalCollection.Count - 1];
            _internalCollection.RemoveAt(_internalCollection.Count - 1);
            return item;
        }

        public void Push(T item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            _internalCollection.Add(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _internalCollection.GetEnumerator();
        }
    }
}
