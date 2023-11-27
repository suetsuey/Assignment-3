using Assignment3.ProblemDomain;
using System;

namespace Assignment3.Utility
{
    /// <summary>
    /// My implementation of a singly linked list.
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    public class SinglyLinkedList : ILinkedListADT
    {
        private Node head;
        private int size;

        public SinglyLinkedList()
        {
            head = null;
            size = 0;
        }


        public bool IsEmpty()
        {
            return size == 0;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public void AddLast(User value)
        {
            Add(value, size);
        }

        public void AddFirst(User value)
        {
            Add(value, 0);
        }

        public void Add(User value, int index)
        {
            // ...
            // 1. Create new node

            Node newNode = new Node(value);

            if (index <0 || index > size)
            {
                throw new IndexOutOfRangeException("Index is out of Range");
            }

            if (index == 0)
            {
                // 2. Assign new node to the head
                newNode.Next = head; 
                head = newNode;

                // 3. Increment the size by 1
            }
            else
            {
                Node current = head;
                // 2. Loop until node at index -1
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                // 3. Set the next of node at index -1 to new node
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            // Increment the size by 1
            size++;
        }

        public void Prepend(User value)
        {
            Node newNode = new Node(value);

            newNode.Next = head;

            head = newNode;
        }
        
        public void Append(User value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public void RemoveFirst()
        {
            Remove(0);
        }

        public void RemoveLast()
        {
            Remove(size - 1);
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
            if (index == 0)
            {
                head = head.Next;
            }
            else
            {
                Node current = head;
               
                for (int i = 0; i < index - 1 ; i++)
                {
                    current = current.Next.Next;
                }
            }

            // Decrement the size by 1
            size--;
        }

        public int IndexOf(User value)
        {
            Node current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return index;
                }
                current = current.Next;
                index++;
            }

            return -1;
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Value = value;
        }

        public int Count()
        {
            return size;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }

        

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        public void Reverse()
        {
            Node previous = null;
            Node current = head;
            Node next = null;

            while (current != null)
            {
                next = current.Next;
                current.Next = previous;

                previous = current;
                current = next;
            }
            head = previous;
        }
    }
}
