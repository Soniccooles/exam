using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsPrograms
{
    public interface ISortAlgorithm
    {
        public static string Name { get; }
        public static void Sort() { }
    }
}
