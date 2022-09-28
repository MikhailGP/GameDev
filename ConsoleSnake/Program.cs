using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Program
    {
        // Параметры еды
        static int food_x;
        static int food_y;
        static void SpawnFood() // Создаем функцию которая будет спавнить еду
        {
            Random rnd = new Random();

            food_x = rnd.Next(0, 120);
            if (food_x % 2 != 0) food_x += 1;

            food_y = rnd.Next(0, 40);
        }
        static void Main()
        {
            // Параметры программы
            Console.SetWindowSize(120, 40);
            Console.SetBufferSize(120, 40);
            Console.CursorVisible = false;

            // Параметры змейки
            int head_x = 20;
            int head_y = 10;
            int dir = 0;

            // Параметры еды


            // Стартовое заполнение змейки
            SpawnFood();

            // Стартовое значение еды



            // Игровой цикл

            while(true)
            {
                // 1. Очистка

                Console.SetCursorPosition(head_x, head_y);
                Console.Write("  ");

                Console.SetCursorPosition(food_x, food_y);
                Console.Write("  ");

                // 2. Расчет


                // Движение змейки

                if (Console.KeyAvailable == true) // Проверяем нажата ли какая-то клавиша
                {
                    ConsoleKeyInfo key;
                    Console.SetCursorPosition(0, 0); // Переносим курсор ввода управляющих воздуйствий клавиатуры
                    key = Console.ReadKey();
                    Console.SetCursorPosition(0, 0); // Возвращаем положение курсора обратно
                    Console.Write(" "); // Стираем буквы написанные от управляющих воздуйствий

                    if (key.Key == ConsoleKey.D) dir = 0;
                    if (key.Key == ConsoleKey.S) dir = 1;
                    if (key.Key == ConsoleKey.A) dir = 2;
                    if (key.Key == ConsoleKey.W) dir = 3;
                }

                if (dir == 0) head_x += 2;
                if (dir == 1) head_y += 1;
                if (dir == 2) head_x -= 2;
                if (dir == 3) head_y -= 1;

                // Бесконечное поле

                // Еда

                if (head_x == food_x && head_y == food_y) // Проверка на столкновение змейки и еды
                {
                    SpawnFood();
                }

                // 3. Отрисовка

                Console.SetCursorPosition(head_x, head_y);
                Console.Write("□");

                Console.SetCursorPosition(food_x, food_y);
                Console.Write("□");

                // 4. Ожидание


                System.Threading.Thread.Sleep(50);  // Команда задержки (50 миллисекунд)
            }
        }
    }
}
