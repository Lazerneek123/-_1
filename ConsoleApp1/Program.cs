using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int i_Array = 5;
            int j_Array = 5;

            int[,] array_A = new int[i_Array, j_Array];
            int[,] array_B = new int[i_Array, j_Array];

            Console.WriteLine("Генерація масивів рандомним сособом!");
            array_A = Fill_The_ArrayA_Random(i_Array, j_Array);
            array_B = Fill_The_ArrayB_Random(i_Array, j_Array);

            Console.WriteLine("Ваш масив A: ");
            Print_Arrays(array_A);

            Console.WriteLine("Ваш масив B: ");
            Print_Arrays(array_B);

            Console.WriteLine("Ваша матриця R:");

            int[] array_R = Create_Array_R(array_A, array_B);
            Print_Array_R(array_R);

            bool switch_0 = true;
            int s = 0;            

            while (switch_0)
            {
                Console.WriteLine("Введіть число, яке знаходеться в масиві R!");
                s = Int32.Parse(Console.ReadLine());

                for (int i = 0; i < array_R.Length; i++)
                {
                    if (array_R[i] == s)
                    {
                        switch_0 = false;

                    }
                }
            }

            int N = i_Array;

            array_A = Replaced_Arrays(array_A, array_B, array_R, N, s);

            Print_Arrays(array_A);

            Console.ReadKey();

        }

        static int[,] Fill_The_ArrayA_Random(int i_A, int j_A)
        {
            Random random = new Random();

            int[,] array_A = new int[i_A, j_A];


            for (int i = 0; i < i_A; i++)
            {

                for (int j = 0; j < j_A; j++)
                {
                    array_A[i, j] = random.Next(-4, 4);                    
                }                
            }

            return array_A;
        }


        static int[,] Fill_The_ArrayB_Random(int i_Array, int j_Array)
        {
            Random random = new Random();

            int[,] array_B = new int[i_Array, j_Array];


            for (int i = 0; i < i_Array; i++)
            {

                for (int j = 0; j < j_Array; j++)
                {
                    array_B[i, j] = random.Next(-6, 6);
                }

            }

            return array_B;
        }

        static int[] Create_Array_R(int[,] array_A, int[,] array_B)
        {

            int n = 0;
            int[] array_R = new int[0];

            for (int i = 0; i < array_A.GetLength(0); i++)
            {

                for (int j = 0; j < array_A.GetLength(1); j++)
                {
                    if (array_A[i, j] == array_B[i, j])
                    {
                        Array.Resize(ref array_R, array_R.Length + 1);

                        array_R[n] = array_A[i, j];
                        n++;

                    }

                }

            }

            return array_R;
        }


        static int[,] Replaced_Arrays(int[,] array_A, int[,] array_B, int[] array_R, int N, int s)
        {

            int a = 0;
            int b = 0;
            int n = 0;

            for (int i = 0; i < array_R.Length; i++)
            {
                if (s == array_R[i])
                {
                    n++;

                    if (n == 1)
                    {
                        a = i;
                        b = i;
                    }
                    else
                    {
                        b = i;
                    }


                }

            }

            a = a % N;
            b = b % N;

            if (n > 1)
            {
                Console.WriteLine("Ваша матриця A: ");
                array_A[a, b] = s;
                return array_A;
            }
            else
            {
                Console.WriteLine("Ваша матриця B: ");
                array_B[b, a] = s;
                return array_B;
            }

        }

        static void Print_Arrays(int[,] array_A)
        {
            for (int i = 0; i < array_A.GetLength(0); i++)
            {

                for (int j = 0; j < array_A.GetLength(1); j++)
                {

                    Console.Write("{0, 4}", array_A[i, j]);

                }

                Console.WriteLine();
            }

        }

        static void Print_Array_R(int[] array_R)
        {
            for (int i = 0; i < array_R.Length; i++)
            {
                Console.Write("{0, 4}", array_R[i]);

            }
            Console.WriteLine();
        }

    }
}