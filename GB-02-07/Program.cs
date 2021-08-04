using System;
using System.Collections.Generic;

namespace GB_02_07
{
    class Program
    {
        const int N = 3;
        const int M = 3;

        static void Print2(int n, int m, int[,] a)
        {
            int i, j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                    Console.Write(a[i, j]);
                Console.Write("\r\n");
            }
        }


        static void Main(string[] args)
        {

            Console.WriteLine(lcsLength2(  //нахождение наибольшей общей подпоследовательности
                "11528974",
                "15921697"
                ));


            //Way1();

            //Way2();
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

        static void Way2()
        {
            int[,] A = new int[N, M];
            int i, j;
            for (j = 0; j < M; j++)
                A[0, j] = 1; // Первая строка заполнена единицами
            for (i = 1; i < N; i++)
            {
                A[i, 0] = 1;
                for (j = 1; j < M; j++)
                    A[i, j] = A[i, j - 1] + A[i - 1, j];
            }

            Print2(N, M, A);

        }

        static int lcsLength(string a, string b)
        {
            if (a.Length == 0 || b.Length == 0)
                return 0;
            else if (a[0] == b[0])
                return 1 + lcsLength(a.Substring(1), b.Substring(1));
            else
                return Math.Max(lcsLength(a.Substring(1), b), lcsLength(a, b.Substring(1)));
        }

        static int lcsLength2(string a, string b,int i=0, int j=0)
        {
            if (a.Length == 0 || b.Length == 0
                || i>=a.Length||j>=b.Length)
                return 0;
            else if (a[i] == b[j])
                return 1 + lcsLength2(a, b,i+1,j+1) ;
            else
                return Math.Max(lcsLength2(a, b,i+1,j), lcsLength2(a, b, i,j+1));
        }


    }
}
