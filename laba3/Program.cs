using System;

namespace laba3
{
    class Program
    {
        public static void Main(string[] args)
        {
            var intList = new List<int>();
            var stringList = new List<string>();
            var random = new Random();

            // Рандомно добавляем числа в диапозоне от -100 до 100
            for (var i = 0; i < 10; i++) intList.Add(random.Next(-100, 100));

            stringList.Add("Good");
            stringList.Add("Job");
            stringList.Add("Юрий");
            stringList.Add("Викторович");
            stringList.Add("BruhMoment");

            // Выводим список чисел
            Console.WriteLine("Список чисел:");

            for (var i = 0; i < intList.Length; i++) Console.Write($"{intList[i]} ");

            Console.WriteLine("");
            Console.WriteLine("Список строк:");

            // Выводим список строк
            for (var i = 0; i < stringList.Length; i++) Console.Write($"{stringList[i]} ");

            Console.WriteLine("");

            // Рандомно удаляем элементы
            try
            {
                intList.RemoveAt(random.Next(-1, 12));
                stringList.RemoveAt(random.Next(-1, 6));

                // Printing again
                Console.WriteLine("Список чисел:");

                for (var i = 0; i < intList.Length; i++) Console.Write($"{intList[i]} ");

                Console.WriteLine("");
                Console.WriteLine("Список строк:");

                for (var i = 0; i < stringList.Length; i++) Console.Write($"{stringList[i]} ");

                Console.WriteLine("");
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

            Console.ReadKey();
        }
    }
}
