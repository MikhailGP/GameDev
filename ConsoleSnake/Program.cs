using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Program
    {
        //проверка столкновений
        //невозможность двигаться в обратном направлении
        //телепорт по краям экрана +-
        //счет ++


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
            int score = 0;
            bool isGame = true;


            // Параметры змейки
            int head_x = 20;
            int head_y = 10;
            int dir = 0;
            int snakeLen = 10;
            int[] body_x = new int[100];
            int[] body_y = new int[100];


            // Стартовое заполнение змейки
            for (int i = 0; i < snakeLen; i++) //создаем хвост змейки
            {
                body_x[i] = head_x - (1 * 2);
                body_y[i] = 10;
            }

            // Стартовое заполнение еды
            SpawnFood();


            // Игровой цикл

            while (isGame == true)
            {
                // 1. Очистка

                for (int i = 0; i < snakeLen; i++)
                {
                    Console.SetCursorPosition(body_x[i], body_y[i]);
                    Console.Write("  ");
                }

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

                    if (key.Key == ConsoleKey.D && dir !=2) dir = 0;
                    if (key.Key == ConsoleKey.S && dir !=3) dir = 1;
                    if (key.Key == ConsoleKey.A && dir !=0) dir = 2;
                    if (key.Key == ConsoleKey.W && dir !=1) dir = 3;
                }

                if (dir == 0) head_x += 2;
                if (dir == 1) head_y += 1;
                if (dir == 2) head_x -= 2;
                if (dir == 3) head_y -= 1;



                for (int i = snakeLen; i > 0; i--)
                {
                    body_x[i] = body_x[i - 1];
                    body_y[i] = body_y[i - 1];
                }

                body_x[0] = head_x;
                body_y[0] = head_y;

                for(int i = 1; i < snakeLen; i++)
                {
                    if (body_x[i] == head_x && body_y[i] == head_y) isGame = false;
                }

                // Бесконечное поле
                if (head_x < 2) head_x = 116;

                if (head_x > 116) head_x = 1;

                if (head_y < 1) head_y = 38;

                if (head_y > 38) head_y = 1;


                // Еда

                if (head_x == food_x && head_y == food_y) // Проверка на столкновение змейки и еды
                {
                    SpawnFood();
                    score++;
                }

                // 3. Отрисовка

                for (int i = 0; i < snakeLen; i++) //Отрисовываем хвост змейки
                {
                     Console.SetCursorPosition(body_x[i], body_y[i]);
                     Console.Write("B");

                }

                Console.SetCursorPosition(head_x, head_y); //Отрисовываем голову змейки
                Console.Write("H");

                Console.SetCursorPosition(food_x, food_y); //Отрисовываем еду
                Console.Write("F");

                Console.SetCursorPosition(0, 0);
                Console.Write("Score: " + score);

                // 4. Ожидание

                System.Threading.Thread.Sleep(50);  // Команда задержки (50 миллисекунд)
            }

            Console.Write("Ты проиграл!");
            Console.ReadLine();
        }
    }
}
