using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam_task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 1000;
            long result = CalculateF(N);
            Console.WriteLine($"F({N}) = {result}");
            Console.ReadKey();
        }
        static bool HasThreeConsecutiveOnes(int n)
        {
            string binary = Convert.ToString(n, 2);

            return binary.Contains("111");
        }

        static long CalculateF(int N)
        {
            long sum = 0;
            int count = 0;

            for (int n = 1; n <= N; n++)
            {
                if (!HasThreeConsecutiveOnes(n))
                {
                    count++;

                    if (count % 2 != 0)
                    {
                        sum += (long)n * n;
                    }
                }
            }

            return sum;
        }
    }
}