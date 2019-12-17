using NET.W._2019.Valuika._13;
using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueLib
{
    public class Queue<T> : IEnumerable<T>
    {
        Node<T> head; 
        Node<T> tail; 
        int count;
        
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> tempNode = tail;
            tail = node;
            if (count == 0)
                head = tail;
            else
                tempNode.Next = tail;
            count++;
        }
        
        public T Get()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }
        
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            Node<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class QueueEnumerator : IEnumerator<T>
        {
            private Node<T> current;
            private Queue<T> _queue;

            public QueueEnumerator(Queue<T> queue)
            {
                _queue = queue;
                current = new Node<T>();
                current.Next = _queue.head;
            }

            public T Current() 
            {
                return current.Data;
            }

            object IEnumerator.Current => throw new NotImplementedException();

            T IEnumerator<T>.Current => current.Data;

            public void Dispose()
            {
                current = null;
                _queue = null;
            }

            public bool MoveNext()
            {
                if (current.Next!=null)
                {
                    current = current.Next;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                current = _queue.head;
            }
        }
    }
}
