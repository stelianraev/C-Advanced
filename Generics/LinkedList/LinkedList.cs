using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;


        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);                
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                ListNode<T> oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if(this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                ListNode<T> oldTail = this.tail;

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }
            this.Count++;
        }

        public T RemoveFirst()
        {           
            if(this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            T removedEl = this.head.Value;

           if(this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newHead = this.head.NextNode;
                newHead.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;

            return removedEl;
        }

        public T RemoveLast()
        {
            if(this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            T removedEl = this.tail.Value;

            if(this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;
            }

            this.Count--;

            return removedEl;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currEl = this.head;

            while (currEl != null)
            {
                action(currEl.Value);
                currEl = currEl.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];

            int cnt = 0;

            ListNode<T> currentEl = this.head;
            while(currentEl != null)
            {
                arr[cnt++] = currentEl.Value;
                currentEl = currentEl.NextNode;
            }

            return arr;
        }
    }

} 
