using System;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        // Ініціалізація масиву з 24 випадкових цілих чисел у діапазоні [0, 15]
        Random random = new Random();
        int[] array = new int[24];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(0, 16);
        }

        // Вивід масиву для перевірки
        Console.WriteLine("Масив:");
        Console.WriteLine(string.Join(", ", array));

        // Потік T0: знайти суму елементів масиву
        Thread t0 = new Thread(() =>
        {
            int sum = array.Sum();
            Console.WriteLine($"Сума елементів масиву: {sum}");
        });

        // Потік T1: знайти кількість парних чисел у масиві
        Thread t1 = new Thread(() =>
        {
            int evenCount = array.Count(n => n % 2 == 0);
            Console.WriteLine($"Кількість парних чисел: {evenCount}");
        });

        // Запуск потоків
        t0.Start();
        t1.Start();

        // Очікування завершення роботи потоків
        t0.Join();
        t1.Join();
    }
}
