using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestsPrograms.TaskLevel2.Linked
{
    public class MyQueue
    {
        private MyNode front;
        private MyNode rear;
        public int Count { get ; set; }

        public void Enqueue(int value)
        {
            MyNode newNode = new MyNode(value);
            if (rear != null)
                rear.Next = newNode;
            newNode.Prev = rear;
            rear = newNode;
            if (front == null)
                front = rear;
            Count++;
        }

        public int Dequeue()
        {
            if (front == null)
                throw new InvalidOperationException("Очередь пуста");
            int value = front.Data;
            front = front.Next;
            if (front != null)
                front.Prev = null;
            else
                rear = null;
            Count--;
            return value;
        }

        public int Peek()
        {
            if (front == null)
                throw new InvalidOperationException("Очередь пуста");
            return front.Data;
        }

        public bool IsEmpty() => front == null;

        public void Print()
        {
            if (front == null)
            {
                Console.WriteLine("Очередь пуста.");
                return;
            }

            Console.WriteLine("Элементы очереди (FIFO):");
            MyNode current = front;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
    public class MyQueue2
    {
        public int Count { get; set; }
        private MyNode rear;
        private MyNode front;
        
        public void Enqueue(int value)
        {
            MyNode node = new MyNode(value);
            if (rear != null)
                rear.Next = node;
            node.Prev = rear;
            rear = node;
            if (front == null)
                front = rear;
            Count++;
        }

        public int Dequeue()
        {
            if (front == null) 
                return 0;
            int value = front.Data;
            front = front.Next;
            if (front != null)
                front.Prev = null;
            else
                rear = null;
            Count--;
            return value;
        }

        public void Print()
        {
            if (front == null) 
                return;

            MyNode current = front;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
        }
    }
}
