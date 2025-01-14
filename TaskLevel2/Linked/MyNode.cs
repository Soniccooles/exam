using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestsPrograms.TaskLevel2.Linked
{
    public class MyNode
    {
        public int Data;
        public MyNode Next;
        public MyNode Prev;
        public MyNode(int data)
        {
            Data = data;
        }
    }
}
