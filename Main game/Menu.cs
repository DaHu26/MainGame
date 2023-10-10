using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Main_game
{
    internal class Menu
    {
        public int Day = 0;
        public void Start(Hero hero)
        {
            Tutorial(hero);
            AddDay(hero);
            LiveDay(hero);
        }
        public void Tutorial(Hero hero)
        {
            bool whiteSpace = true;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Вас приветствует игра «Soul of Thrall»\r\n" +
                "Введите имя персонажа");
            hero.Name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(hero.Name))
            {
                Console.WriteLine("Имя персонажа не может быть пустым, заполните его.");
                hero.Name = Console.ReadLine();
            }
            Console.WriteLine("Вы просыпаетесь ночью, в незнакомом вам строении, похожем на амбар.\r\n" +
                $"Не знаете кто вы и что здесь делаете, помните только ваше имя, “{hero.Name}”\r\n" +
                "Здесь очень темно и лишь пара маленьких свечных фонарей немного освещает местность.\r\n" +
                "Осматриваетесь и замечаете здесь несколько человек греющихся о фонарь.\r\n" +
                "Вы думаете, стоит ли выходить из тени и подойти к ним?\r\n" +
                "1-\tДа \r\n2-\tНет");

            int choose = 0;
            while (whiteSpace == true)
            {
                choose = Convert.ToInt32(Console.ReadLine());
                if (string.IsNullOrWhiteSpace(choose.ToString()))
                    Console.WriteLine("Введите данные которые вас просят.");
                else if (choose < 0 || choose > 2)
                {
                    Console.ResetColor();
                    Console.WriteLine("Неизвестный выбор.");
                    choose = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }
                else
                    whiteSpace = false;
            }

            if (choose == 1)
            {
                Console.WriteLine("Вы решаете подойти к ним. Узнаете имя одного из них, Каргат.\r\n" +
                    "Он выглядит приветливым, хоть и уставшим, весь в рваных обносках.\r\n" +
                    "Начинаете расспрашивать его о том что это за место и что они тут делают.\r\n" +
                    "На что получаете ответ, что вас продали в рабство и теперь ваша единственная задача,\r\n" +
                    "это сражаться на потеху публике, а единственный способ стать свободным – победить чемпиона.\r\n" +
                    "Он показывает вам место где вы можете поспать и говорит, что завтра с утра покажет все что необходимо знать.\r\n" +
                    "Вы засыпаете.\r\n");
                Console.ResetColor();
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else if (choose == 2)
            {
                Console.WriteLine("Вы решаете сидеть тихо и смотреть что будет дальше.\r\n" +
                    "Вас замечает один из них и начинает идти в вашу сторону.\r\n" +
                    "Он просит вас не нервничать и называет свое имя “Каргат”.\r\n" +
                    "Каргат выглядит приветливым, хоть и уставшим, весь в рваных обносках.\r\n" +
                    "Вы начинаете расспрашивать его о том что это за место и что они тут делают.\r\n" +
                    "На что получаете ответ, что вас продали в рабство и теперь ваша единственная задача,\r\n" +
                    "это сражаться на потеху публике, а единственный способ стать свободным – победить чемпиона.\r\n" +
                    "Он показывает вам место где вы можете поспать и говорит, что завтра с утра покажет все что необходимо знать.\r\n" +
                    "Вы засыпаете.\r\n");
                Console.ResetColor();
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }

            Console.WriteLine("Ранним утром вас будит Каргат и начинает экскурсию.\r\n" +
                "Из основных зданий здесь магазин, арена и казарма, если ее можно так назвать, где вы живете.\r\n" +
                "В магазине вы можете улучшить снаряжение за деньги заработанные в боях.\r\n" +
                "В казарме после боя вы можете отдохнуть, тем самым восстановив здоровье.\r\n" +
                "В арене выбрать соперника, за победу вам дается 5 монет, поражение может лишить вас жизни.\r\n" +
                "Вместе вы заходите в магазин, там вас встречает продавец с именем Вано.\r\n" +
                "Вы узнаете что в магазине можно улучшить оружие, броню, здоровье и выносливость.\r\n" +
                "Для каждого улучшение потребуется заплатить 3 монеты.\r\n" +
                "Каргат дает вам несколько монет по доброте душевной, этого хватает на покупку самого простого меча и усиленной мантии.\r\n" +
                "Желает вам удачи и перед уходом говорит \"Прошел слух, чемпион приедет через 4 дня на арену, это твой шанс.\".\r\n" +
                "Время начинать свой собственный путь в трудной жизни раба.\r\n" +
                "Вы только и думаете как победите чемпиона и будете свободным.\r\n");
            Console.ResetColor();
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadLine();
        }
        public void LiveDay(Hero hero)
        {
            var life = true;
            while (life)
            {
                var choose = 0;
                var whiteSpace = true;
                hero.Stamina = hero.BasicStamina;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Вы начинаете думать куда сходить");
                Console.WriteLine("1 - Арена.");
                Console.WriteLine("2 - Магазин");
                Console.WriteLine("3 - Пойти отдыхать в казарму.");
                while (whiteSpace == true)
                {
                    choose = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if (string.IsNullOrEmpty(choose.ToString()))
                        Console.WriteLine("Введите данные которые вас просят.");
                    else if (choose < 0 || choose > 3)
                        Console.WriteLine("Неизвестный выбор, повторите ввод.");
                    else
                        whiteSpace = false;
                }
                switch (choose)
                {
                    case 1:
                        life = goArena(hero);
                        break;
                    case 2:
                        goShop(hero);
                        break;
                    case 3:
                        AddDay(hero);
                        Console.WriteLine("Ваше здоровье восстановлено.");
                        break;

                }
            }
        }
        public void goShop(Hero hero)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Вы приходите в магазин. В карманах у вас {hero.Money}");
            Console.WriteLine("1 - Улучшить оружие.");
            Console.WriteLine("2 - Улучшить броню.");
            Console.WriteLine("3 - Увеличить здоровье.");
            Console.WriteLine("4 - Увеличить выносливость.");
            Console.WriteLine("5 - Уйти.");
            var whiteSpace = true;
            var choose = 0;
            while (whiteSpace)
            {
                choose = Convert.ToInt32(Console.ReadLine());
                if (string.IsNullOrEmpty(choose.ToString()))
                    Console.WriteLine("Введите данные которые вас просят.");
                else if (choose < 0 || choose > 5)
                    Console.WriteLine("Неизвестный выбор, повторите ввод.");
                else
                    whiteSpace = false;
            }
            if (hero.Money < 3 && choose <= 4)
            {
                Console.WriteLine($"У вас нехватает денег, нужно 3 монеты, у вас {hero.Money}");
                Console.WriteLine("Вано выгоняет вас из магазина.");
            }
            if (hero.Money > 2)
            {
                switch (choose)
                {
                    case 1:
                        Shop.addPower(hero);
                        Console.WriteLine($"Вы улучшили оружие, теперь ваша атака равна {hero.Power}");
                        break;
                    case 2:
                        Shop.addArmor(hero);
                        Console.WriteLine($"Вы улучшили броню, теперь она составляет {hero.Armor} единиц");
                        break;
                    case 3:
                        Shop.addHealth(hero);
                        Console.WriteLine($"Вы улучшили показатели здоровья, теперь оно равно {hero.FullHealth}");
                        break;
                    case 4:
                        Shop.addStamina(hero);
                        Console.WriteLine($"Вы улучшили выносливость, теперь она равна {hero.BasicStamina}");
                        break;
                }
            }
        }
        public bool goArena(Hero hero)
        {
            if (Day > 4)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Этот день настал.");
                Thread.Sleep(2000);
                Console.WriteLine("Вы заходите на арену и видите лишь одного человека, он не отрывает с вас взгляд.");
                Thread.Sleep(2000);
                Console.WriteLine("Осматривая его вы понимаете, что никогда не видели подобной брони и оружия.");
                Thread.Sleep(2000);
                Console.WriteLine("Несомненно, это чемпион и именно вы станете его следующим соперником.");
                Thread.Sleep(2000);
                var enemy = Arena.CreateChampion();
                var endOfGame = Arena.Fight(hero, enemy);
                if (endOfGame)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Thread.Sleep(2000);
                    Console.Clear();
                    Console.WriteLine("Точным и невероятно сильным ударом вы отрубаете голову чемпиону!");
                    Console.WriteLine($"Голова чемпиона в ваших руках, {hero.Name} заслужил свою награду!");
                    Thread.Sleep(2000);
                    Console.WriteLine("Как и все чемпионы до него.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Погребенные под ареной.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Обещание свободы было ложью.");
                    Thread.Sleep(2000);
                    Console.WriteLine("Спасибо что играли и прошли игру!");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Thread.Sleep(2000);
                    Console.WriteLine("Вы были так близки к своей цели...");
                    Thread.Sleep(3000);
                    Death(enemy);
                    return false;
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Вы пришли на арену и замечаете трех других бойцов ищущих соперника.");
            var enemies = new List<Enemy>();
            for (int i = 0; i < 3; i++)
            {
                var enemy = Arena.CreateRandomEnemy();
                enemies.Add(enemy);
                Console.WriteLine($"{i + 1} - {enemy}");
            }
            Console.WriteLine($"Кого вы хотите выбрать для сражения?\r\n" +
                $"Напоминаю, что победа над любым из них даст 5 монет.");
            Console.WriteLine("Введите \"4\" чтобы выйти из арены.");
            var whiteSpace = true;
            var choose = 0;
            while (whiteSpace)
            {
                choose = Convert.ToInt32(Console.ReadLine());
                if (string.IsNullOrEmpty(choose.ToString()))
                    Console.WriteLine("Введите данные которые вас просят.");
                else if (choose < 0 || choose > 4)
                    Console.WriteLine("Неизвестный выбор, выберите от 1 до 4.");
                else
                    whiteSpace = false;
            }

            Enemy chooseEnemy = enemies[0];
            if (choose == 1)
                chooseEnemy = enemies[0];
            if (choose == 2)
                chooseEnemy = enemies[1];
            if (choose == 3)
                chooseEnemy = enemies[2];

            bool resultFight;

            if (choose > 0 && choose < 4)
                resultFight = Arena.Fight(hero, chooseEnemy);
            else
                return true;

            if (resultFight)
            {
                Console.WriteLine("Вы одерживаете победу! В награду вы получаете 5 монет.");
                Console.WriteLine("Не забудьте отдохнуть в казарме чтобы залечить раны.");
                hero.Money += 5;
                return true;
            }
            else
            {
                Console.WriteLine("Вы проигрываете. Все ваше тело в ранениях, вы боретесь за свою жизнь.");

                if (Arena.GetLucky())
                {
                    Console.WriteLine("В борьбе со смертью вы одерживаете верх!");
                    Console.WriteLine("На следующий день будете чувствовать себя отлично.");
                    return true;
                }
                else
                {
                    return Death(chooseEnemy);
                }
            }

        }
        public void AddDay(Hero hero)
        {
            Day++;
            Console.WriteLine($"ДЕНЬ {Day}");
            hero.Health = hero.FullHealth;
        }
        public bool Death(Enemy enemy)
        {
            Thread.Sleep(1500);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Весь ваш взгляд застилает свет, вы чувствуете что умираете.");
            Thread.Sleep(1000);
            Console.WriteLine("Стоило ли бороться за свою жизнь в рабстве?");
            Thread.Sleep(1000);
            Console.WriteLine($"Количество прожитых дней: {Day}");
            Console.WriteLine($"Имя убившего вас персонажа: {enemy.Name}");
            Console.WriteLine("Запомните его и отомстите в следующей жизни.");
            return false;
        }
    }
}
