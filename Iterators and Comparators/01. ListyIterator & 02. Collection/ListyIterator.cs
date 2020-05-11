using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._ListyIterator
{
   public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> list;
        private int index;
        public ListyIterator(List<T> list)
        {
            this.list = list;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext() == false)
            {
                return false;
            }

                index++;
                return true;
        }

        public bool HasNext()
        {
            if(index + 1 > this.list.Count - 1)
            {
                return false;
            }

            return true;
        }

        public T Print()
        {
            if(this.list.Count == 0)
            {
               throw new Exception("Invalid Operation!");
            }

            return this.list[index];
        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.list)
            {
                yield return item;
            }                 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
