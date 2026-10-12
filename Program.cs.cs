using System;
using CatAndMouse.Services;
using CatAndMouse.Tests;

class Program
{
    static void Main(string[] args)
    {
        // Сначала запускаем тесты для проверки логики
        GameTests.RunAllTests();

        // Запуск симуляции игр
        for (int i = 1; i <= 3; i++)
        {
            Console.WriteLine($"================ ИГРА {i} ================");
            Game.InputFile = $"{i}.ChaseData.txt";
            Game.OutFile = $"{i}.PursuitLog.txt";

            Game game = new Game(10000);
            game.Run();
        }
    }
}