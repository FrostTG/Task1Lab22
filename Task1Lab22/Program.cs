using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1Lab22
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Write("Введите кол-во чисел в массиве: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0, n);
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
            Func<object, int> func = new Func<object, int>(Summa);
            Task<int> task = new Task<int>(func,array);
            //int s = task.Result;            
            Func<object, int> func1 = new Func<object, int>(MaxArray);
            Task<int> task1 = new Task<int>(func1, array);
            //Task task2 = task.ContinueWith(func1);
            task.Start();
            task1.Start();            
            Console.ReadKey();
        }
        static int Summa(object array_)
        {
            int[] array = (int[])array_;
            int S = 0;
            for (int i = 0; i < array.Length; i++)
            {
                S += array[i];
            }
            Console.WriteLine($"Сумма чисел: {S}");
            return S;
        }
        static int MaxArray(object array_)
        {
            int[] array = (int[])array_;
            int max = array[0];
            foreach (int a in array)
            {
                if (a > max)
                {
                    max = a;
                }
            }
            Console.WriteLine($"Максимальное число: { max}");
            return max;
        }
    }
}
