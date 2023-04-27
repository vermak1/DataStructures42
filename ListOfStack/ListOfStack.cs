using System;
using System.Collections.Generic;

namespace DataStructures42
{
    internal class ListOfStack<T> : IStack<T> //task 2
    {
        private class MyStack2<K>
        {
            private readonly List<K> _internalCollection;
            public MyStack2(Int32 maxSize)
            {
                _internalCollection = new List<K>(maxSize);
            }

            public Boolean IsFull => _internalCollection.Count == _internalCollection.Capacity;

            public Boolean CurrentItemIsLast => _internalCollection.Count == 1;

            public K Pop()
            {
                if (_internalCollection.Count == 0)
                    throw new InvalidOperationException("Collection is empty");

                K item = _internalCollection[_internalCollection.Count - 1];
                _internalCollection.RemoveAt(_internalCollection.Count - 1);
                return item;
            }

            public void Push(K item)
            {
                if (item == null)
                    throw new ArgumentNullException("item");

                _internalCollection.Add(item);
            }
        }
        private readonly List<MyStack2<T>> _list;

        private Int32 _currentStack;

        private readonly Int32 _maxStackSize;
        public ListOfStack(int maxSize)
        {
            if (maxSize <= 0)
                throw new ArgumentException(nameof(maxSize));


            _maxStackSize = maxSize;
            _currentStack = 0;
            _list = new List<MyStack2<T>>
            {
                new MyStack2<T>(maxSize)
            };
        }

        public T Pop()
        {
            if (_list[_currentStack].CurrentItemIsLast)
            {
                return PopLastItemFromStack();
            }
            return _list[_currentStack].Pop();
        }

        private T PopLastItemFromStack()
        {
            T item = _list[_currentStack].Pop();
            _list.RemoveAt(_currentStack);
            _currentStack--;
            return item;
        }

        public void Push(T item)
        {
            if (!_list[_currentStack].IsFull)
            {
                _list[_currentStack].Push(item);
                return;
            }
            PushInNewStack(item);
        }

        private void PushInNewStack(T item)
        {
            _list.Add(new MyStack2<T>(_maxStackSize));
            _currentStack++;
            _list[_currentStack].Push(item);
        }
    }
}
