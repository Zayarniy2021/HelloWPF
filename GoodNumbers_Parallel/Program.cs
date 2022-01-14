using System;
using System.Threading.Tasks;

//Натуральное число будем называть хорошим, если оно делится на сумму цифр самого числа

/*
*Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. Хорошим называется число, которое делится на сумму своих цифр. Реализовать подсчет времени выполнения программы, используя структуру DateTime. 
Альтернативное решение. Использование параллельного программирования.
*/
namespace GoodNumbers_Parallel
{
    class Task6
    {
        static long SummCyfr(long n)
        {
            long s= 0;
            while (n != 0)
            {
                s = s + n % 10;
                n = n / 10;
            }
            return s;
        }

        static bool GoodNumber(long n)
        {
            return n % SummCyfr(n) == 0;
        }

        static int GoodNumberCounter(long a, long b)
        {
            int k = 0;
            for (long i = a; i <= b; i++)
                if (GoodNumber(i))
                {
                    k++;
                    //if (i % 1000000 == 0) Console.WriteLine("i={0} k={1}", i, k);                    
                }
            return k;
        }


        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;
            //Создаем задачи для выполнения в отдельном потоке
            Task<int> task1=new Task<int>(new Func<int>(delegate() 
            {
                return GoodNumberCounter(1, 200000000);
             }));
            Task<int> task2 = new Task<int>(new Func<int>(delegate ()
            {
                return GoodNumberCounter(200000001, 400000000);
            }));
            Task<int> task3 = new Task<int>(new Func<int>(delegate ()
            {
                return GoodNumberCounter(400000001,600000000);
            }));
            Task<int> task4 = new Task<int>(new Func<int>(delegate ()
            {
                return GoodNumberCounter(600000001,800000000);
            }));
            Task<int> task5 = new Task<int>(new Func<int>(delegate ()
            {
                return GoodNumberCounter(800000001, 1000000000);
            }));

            task1.Start();
            Console.WriteLine("Start task 1");
            task2.Start();
            Console.WriteLine("Start task 2");
            task3.Start();
            Console.WriteLine("Start task 3");
            task4.Start();
            Console.WriteLine("Start task 4");
            task5.Start();
            Console.WriteLine("Start task 5");
            Console.WriteLine(task1.Result+task2.Result+task3.Result+task4.Result+task5.Result);
            Console.WriteLine(DateTime.Now - start);
            Console.ReadKey();
        }
    }
}