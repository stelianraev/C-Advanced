using System.Collections.Generic;

namespace LinkedList
{
   public class ListNode<T>
    {       
        public T Value { get; set; }
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PreviousNode { get; set; }      
        
        public ListNode(T value)
        {
            this.Value = value;
        }
    }
}
