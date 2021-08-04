using System;
using System.Collections.Generic;

namespace GB_02_07
{
    class Program
    {
        static void Main(string[] args)
        {


            Way1();
        }

        static void Way1()
        {
            int[] a = { 1,1, 5, 2, 8, 9, 7, 4 };
            int[] b = { 1, 5, 9, 2, 1, 6, 9, 7 };

            var result = new List<int> { };

            int lastIndexB = 0;

            for (int i = 0; i < a.Length; i++)
            {
                for (int j = lastIndexB; j < b.Length; j++)
                {
                    if (a[i] == b[j])
                    {
                        result.Add(b[j]);
                        lastIndexB = j + 1;
                        break;

                    }

                }

            }
            Console.WriteLine(string.Join(", ", result));

        }
    }
}
