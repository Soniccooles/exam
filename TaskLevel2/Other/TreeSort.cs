using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms.TaskLevel2.Other
{
    public class TreeSort : ISortAlgorithm
    {
        public static string Name => "TreeSort";
        public static void Sort(int[] array)
        {
            TreeNode root = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                root.Insert(array[i]);
            }
            List<int> sortedList = new List<int>();
            root.InOrderTraversal(sortedList);
            sortedList.CopyTo(array);
            Console.WriteLine(string.Join(", ", array));
        }
    }

    public class TreeNode
    {
        private TreeNode Left, Right;
        public int Value;

        public TreeNode(int value)
        {
            Value = value;
        }

        public void Insert(int value)
        {
            if (value < Value)
            {
                if (Left == null)
                    Left = new TreeNode(value);
                else
                    Left.Insert(value);
            }
            else
            {
                if (Right == null)
                    Right = new TreeNode(value);
                else
                    Right.Insert(value);
            }
        }

        public void InOrderTraversal(List<int> list)
        {
            Left?.InOrderTraversal(list);
            list.Add(Value);
            Right?.InOrderTraversal(list);
        }
    }
}
