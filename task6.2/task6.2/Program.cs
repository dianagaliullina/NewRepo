using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task6._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var s = "клоун";
            var word1 = s.Substring(0, 1);
            word1 += s.Substring(3, 1);
            word1 += s.Substring(1, 2);
            word1 += s.Substring(4, 1);

            Console.WriteLine(word1);

            var word2 = s.Substring(0, 1);
            word2 += s.Substring(2, 1);
            word2 += s.Substring(1, 1);
            word2 += s.Substring(3, 1);
            word2 += s.Substring(4, 1);

            Console.WriteLine(word2);
            Console.ReadKey();
        
        }
    }
}
