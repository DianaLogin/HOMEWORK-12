using System;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace HOMEWORK_12
{
    internal class Program
    {
        /// <summary>
        /// Метод для вывода на консоль чисел от 1 до 10
        /// </summary>
        static void Print_Numbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i);
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// Метод вычисления квадрата введённого числа
        /// </summary>
        /// <param name="x></param>
        /// <returns></returns>
        static int Calculate_Square(int x)
        {
            return x * x;
        }

        /// <summary>
        /// Метод вычисления факториала введённого числа
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static int Calculate_Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        /// <summary>
        /// Метод асинхронного вычисления факториала введённого числа
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static async Task<int> Async_Calculate_Factorial(int x)
        {
            int factorial = await Task.Run(() => Calculate_Factorial(x));//метод Task.Run() запускает асинхронно выполнение Calculate_Factorial(x) в новом потоке
            Thread.Sleep(8000);// Задержка потокa на 8 секунд 

            return factorial;
        }

        static async Task Main(string[] args)
        {   //-----------------------------------------------------------------
            Console.WriteLine("=========== Задача 1 ===========\n");

            //Создание трёх потоков
            Thread thread_1 = new Thread(Print_Numbers);
            thread_1.Start();
            thread_1.Join(); // эксперименты с методом Join()

            Thread thread_2 = new Thread(Print_Numbers);
            thread_2.Start();

            Thread thread_3 = new Thread(Print_Numbers);
            thread_3.Start();
            thread_3.Join(); 
            

            Console.WriteLine("\n");

            //-----------------------------------------------------------------
            Console.WriteLine("=========== Задача 2 ===========\n");

            Console.Write("Введите число: ");
            int number = int.Parse(Console.ReadLine());

            // Синхронное вычисление
            int square = Calculate_Square(number);
            Console.WriteLine($"Квадрат введённого вами числа: {square}");

            // Асинхронное вычисление
            int factorial = await Async_Calculate_Factorial(number);
            Console.WriteLine($"Факториал введённого вами числа: {factorial}\n");

            //-----------------------------------------------------------------
            Console.WriteLine("=========== Задача 3 ===========\n");

            Refl obj = new Refl();

            Console.WriteLine(Refl.Output());
            Console.WriteLine(Refl.AddInts(1, 2));

            MethodInfo[] methods = obj.GetType().GetMethods();

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine("Метод " + method.Name + "\n");
            }
        }
    }
}

       

     


