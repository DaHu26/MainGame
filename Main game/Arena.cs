using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Main_game
{
    internal static class Arena
    {
        public static bool Fight(Hero hero, Enemy enemy)
        {
            bool turn;
            bool valid = true;
            int choose1 = 0;
            int choose2 = 0;
            var rand = Static.Rand;
            Console.WriteLine("Напоминаю правила. Удар - 3 выносливости, Блок - 2 выносливости, Отдых +4 выносливости.");
            if (rand.Next(1, 100) > 49)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Первый ход за вами.");
                Console.ResetColor();
                turn = true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Первым ходит ваш соперник.");
                Console.ResetColor();
                turn = false;
            }

            while (hero.Health > 0 && enemy.Health > 0)
            {
                if (turn == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Ваши нынешние показатели ЗДОРОВЬЯ: {hero.Health}, ВЫНОСЛИВОСТЬ: {hero.Stamina}");
                    Console.WriteLine("Выберите первое ваше действие.");
                    Console.WriteLine("1 - Атака 2 - Защита 3 - Отдых.");
                    while (valid == true)
                    {
                        bool tryParse = int.TryParse(Console.ReadLine(), out choose1);
                        if (tryParse)
                        {
                            if (choose1 < 1 || choose1 > 3)
                                Console.WriteLine("Выбрана неизвестная команда, повторите ввод.");
                            else
                                valid = false;
                        }
                        else
                            Console.WriteLine("Неизвестная операция.");
                    }

                    Console.WriteLine("Выберите второе действие.");
                    while (valid == false)
                    {
                        bool tryParse = int.TryParse(Console.ReadLine(), out choose2);
                        if (tryParse)
                        {
                            if (choose2 < 1 || choose2 > 3)
                                Console.WriteLine("Выбрана неизвестная команда, повторите ввод.");
                            else
                                valid = true;
                        }
                        else
                            Console.WriteLine("Неизвестная операция.");
                    }

                    switch (choose1)
                    {
                        case 1:
                            hero.Punch(hero, enemy);
                            break;
                        case 2:
                            hero.Defence(hero);
                            break;
                        case 3:
                            hero.Relax(hero);
                            break;
                    }

                    switch (choose2)
                    {
                        case 1:
                            hero.Punch(hero, enemy);
                            break;
                        case 2:
                            hero.Defence(hero);
                            break;
                        case 3:
                            hero.Relax(hero);
                            break;
                    }

                    Console.WriteLine("Конец вашего хода.");
                    enemy.TemporaryArmor = 0;
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    turn = false;
                }

                else
                {
                    enemy.TurnEnemy(hero);
                    Console.ResetColor();
                    hero.TemporaryArmor = 0;
                    Console.WriteLine($"Начало вашего хода! ЗДОРОВЬЕ СОПЕРНИКА {enemy.Health}");

                    turn = true;
                }
            }

            if (hero.Health > 0)
                return true;

            return false;
        }

        public static bool GetLucky()
        {
            var rand = Static.Rand;
            var lucky = rand.Next(0, 101);
            if (lucky > 50)
                return true;

            return false;
        }
        public static Enemy CreateRandomEnemy()
        {
            var rand = Static.Rand;
            var names = new [] { "Saidor", "Gavin", "Vigore", "Delathis", "Mezigore", "Kelace", "Bonis", "Kigalar", "Fedred", "Grige", "Matilar", "Zatus", "Dofym", "Bogrinn" };
            var enemy = new Enemy(names[rand.Next(0, names.Length)], rand.Next(15, 25), rand.Next(1, 6), rand.Next(1, 4));
            return enemy;
        }
        public static Enemy CreateChampion()
        {
            var champion = new Enemy("Maximus", 25, 6, 4);
            return champion;
        }
    }
}
