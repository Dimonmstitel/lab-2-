using System;
using System.Diagnostics;
using CatAndMouse.Models;
using CatAndMouse.Services;

namespace CatAndMouse.Tests
{
    public static class GameTests
    {
        public static void RunAllTests()
        {
            Console.WriteLine("Запуск юнит-тестов...");

            TestPlayerMovement();
            TestCircularWrapping();
            TestDistanceCalculation();

            Console.WriteLine("Все тесты успешно пройдены!\n");
        }

        private static void TestPlayerMovement()
        {
            Player player = new Player("Test");
            player.Move(3, 10);
            Debug.Assert(player.Location == 3, $"Ошибка входа в игру! Ожидалась 3, получена {player.Location}");
            Debug.Assert(player.State == State.Playing, "Ошибка состояния игрока!");

            player.Move(4, 10);
            Debug.Assert(player.Location == 7, $"Ошибка шага! Ожидалась 7, получена {player.Location}");
            Debug.Assert(player.DistanceTraveled == 4, "Ошибка подсчета пройденной дистанции!");

            Console.WriteLine("[PASS] Тесты базового перемещения пройдены.");
        }

        private static void TestCircularWrapping()
        {
            Player player = new Player("TestLoop");
            player.Move(10, 10); // Позиция 10

            // Шаг вперед через край поля
            player.Move(2, 10); // 10 + 2 = 2 (по кругу из 10)
            Debug.Assert(player.Location == 2, $"Ошибка закольцовывания вперед! Ожидалась 2, получена {player.Location}");

            // Шаг назад через край поля
            player.Move(-4, 10); // 2 - 4 = -2 -> должно вернуть 8
            Debug.Assert(player.Location == 8, $"Ошибка закольцовывания назад! Ожидалась 8, получена {player.Location}");

            Console.WriteLine("[PASS] Тесты закольцовывания пройдены.");
        }

        private static void TestDistanceCalculation()
        {
            Game game = new Game(10);
            game.Cat.Location = 2;
            game.Cat.State = State.Playing;

            game.Mouse.Location = 9;
            game.Mouse.State = State.Playing;

            // Расстояние напрямую: |2 - 9| = 7. Через край: 10 - 7 = 3. Минимум = 3.
            int dist = game.GetDistance();
            Debug.Assert(dist == 3, $"Ошибка расчета расстояния! Ожидалось 3, получено {dist}");

            Console.WriteLine("[PASS] Тесты расчета расстояния пройдены.");
        }
    }
}