using System;

namespace DataStructures42
{
    internal interface IStack<T>
    {
        void Push(T item);
        T Pop();
    }
}
