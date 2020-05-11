using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyStack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private List<T> collection = new List<T>();

        public void Push(T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                collection.Insert(0, elements[i]);
            }
        }

        public void Pop()
        {
            collection.RemoveAt(0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
