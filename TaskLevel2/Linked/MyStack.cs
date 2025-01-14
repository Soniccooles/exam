using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestsPrograms.TaskLevel2.Linked
{
    public class MyStack
    {
        private MyNode top;
        public int Count { get; set; }
        public void Push(int value)
        {
            MyNode newNode = new MyNode(value);
            newNode.Next = top;
            if (top != null)
                top.Prev = newNode;
            top = newNode;
            Count++;
        }

        public int Pop()
        {
            if (top == null)
                throw new InvalidOperationException("Стек пуст");
            int value = top.Data;
            top = top.Next;
            if (top != null)
                top.Prev = null;
            Count--;
            return value;
        }

        public int Peek()
        {
            if (top == null)
                throw new InvalidOperationException("Стек пуст");
            return top.Data;
        }

        public bool IsEmpty() => top == null;

        public void Print()
        {
            if (top == null)
            {
                Console.WriteLine("Стек пуст.");
                return;
            }

            Console.WriteLine("Элементы стека (LIFO):");
            MyNode current = top;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
            Console.WriteLine();
        }
    }
    public class MyStack2
    {
        public int Count { get; set; }
        private MyNode top;

        public void Push(int value)
        {
            MyNode node = new MyNode(value);
            node.Next = top;
            if (top != null)
                top.Prev = node;
            top = node;
            Count++;
        }
        
        public int Pop() 
        {
            if (top == null)
                return 0;
            int value = top.Data;
            top = top.Next;
            if (top != null)
                top.Prev = null;
            Count--;
            return value;
        }

        public int Peek()
        {
            if (top == null) return 0;
            return top.Data;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Print()
        {
            if (top == null)
                return;
            MyNode current = top;
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }
        }
    }
}
