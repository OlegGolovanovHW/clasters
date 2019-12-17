using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Кластеры
{
    class Program
    {
        static bool[,] Visited;
        static int summ = 0;
        static void Claster(int I, int J, int N, int M, int value, int[,] Matrix)
        {
            Visited[I, J] = true;
            summ++;
            if (J - 1 >= 0)
            {
                if (Visited[I, J - 1] == false && Matrix[I, J - 1] == value)
                {
                    Claster(I, J - 1, N, M, value, Matrix);
                }
            }
            if (J + 1 < M)
            {
                if (Visited[I, J + 1] == false && Matrix[I, J + 1] == value)
                {
                    Claster(I, J + 1, N, M, value, Matrix);
                }
            }
            if (I - 1 >= 0)
            {
                if (Visited[I - 1, J] == false && Matrix[I - 1, J] == value)
                {
                    Claster(I - 1, J, N, M, value, Matrix);
                }
            }
            if (I + 1 < N)
            {
                if (Visited[I + 1, J] == false && Matrix[I + 1, J] == value)
                {
                    Claster(I + 1, J, N, M, value, Matrix);
                }
            }
        }
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int M = int.Parse(Console.ReadLine());
            int[,] Matrix = new int[N,M];
            Visited = new bool[N, M];
            Random rnd = new Random();
            for (int i = 0; i<N; i++)
            {
                //int[] mas = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j<M; j++)
                {
                    Matrix[i, j] = rnd.Next(1, 5);
                    //Matrix[i, j] = mas[j];
                    Visited[i, j] = false;
                }
            }

            int[] Unique = new int[N*M];
            Unique[0] = Matrix[0, 0];
            int k = 1;
            int cnt = 0;
            for (int i = 0; i<N; i++)
            {
                for (int j = 0; j<M; j++)
                {
                    for (int m = 0; m<k; m++)
                    {
                        if (Matrix[i,j] != Unique[m])
                        {
                            cnt++;
                        } 
                    }
                    if (cnt == k)
                    {
                        Unique[k] = Matrix[i, j];
                        k++;
                    }
                    cnt = 0;
                }
            }
            for (int i = 0; i<N; i++)
            {
                for (int j = 0; j<M; j++)
                {
                    Console.Write("{0} ", Matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //for (int i = 0; i < k; i++)
            //{
            //    Console.Write("{0} ", Unique[i]);
            //}
            //Console.WriteLine
            Console.Write("Введите значение элемента: ");
            int value  = int.Parse(Console.ReadLine());
            for (int i = 0; i<N; i++)
            {
                for (int j = 0; j<M; j++)
                {
                    if (Matrix[i, j] == value && Visited[i, j] == false)
                    {
                        summ = 0;
                        Claster(i, j, N, M, value,Matrix);
                        Console.Write("{0} ", summ);
                    }
                }
            }

        }
    }
}
