using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_game
{
    internal class Enemy : Fighter
    {
        public Enemy(string name, int health, int power, int armor) : base(name, health, power, armor)
        {
        }

        public override void Defence(Fighter fighter)
        {
            if (fighter.Stamina >= 2)
            {
                TemporaryArmor += 2;
                fighter.Stamina -= 2;
                Console.WriteLine($"Ваш противник усилил свою БРОНЮ.");
            }
            else
                Console.WriteLine($"Противник не смог поднять показатель армора потому что устал.");
        }

        public override void Punch(Fighter attacking, Fighter enemy)
        {
            if (attacking.Stamina >= 3)
            {
                var damage = (attacking.Power - ((enemy.Armor + enemy.TemporaryArmor) / 2));
                if (damage <= 0)
                {
                    damage = 0;
                    enemy.Health -= damage;
                }
                else
                {
                    enemy.Health -= damage;
                }

                attacking.Stamina -= 3;
                Console.WriteLine($"{attacking.Name} нанес удар, здоровье {enemy.Name} сотавляет: {enemy.Health}");
            }
            else
            {
                Console.WriteLine($"{attacking.Name} не смог ударить потому что устал.");
            }
        }

        public override void Relax(Fighter fighter)
        {
            fighter.Stamina += AddStaminaPerRound;
            Console.WriteLine($"Противник ПЕРЕВЕЛ ДУХ, теперь его стамина составляет: {fighter.Stamina}");
        }
        public void TurnEnemy(Fighter enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            var rand = Static.Rand;
            var choose1 = rand.Next(1, 3);
            if (Stamina < 3)
                choose1 = 3;

            switch (choose1)
            {
                case 1:
                    Punch(this, enemy);
                    break;
                case 2:
                    Defence(this);
                    break;
                case 3:
                    Relax(this);
                    break;
            }

            var choose2 = rand.Next(1, 3);
            if (Stamina < 3)
                choose2 = 3;

            switch (choose2)
            {
                case 1:
                    Punch(this, enemy);
                    break;
                case 2:
                    Defence(this);
                    break;
                case 3:
                    Relax(this);
                    break;
            }

        }

        public override string ToString()
        {
            var list = new List<string>();
            list.Add(Name);
            if (Health < 17)
                list.Add(" выглядит хилым, ");
            if (Health >= 17 && Health < 21)
                list.Add(" выглядит подкаченным, ");
            if (Health >= 21)
                list.Add(" выглядит как настоящий боец, ");
            if (Power < 2)
                list.Add("с отвратительным оружием ");
            if (Power >= 2 && Power < 4)
                list.Add("с хорошим оружем ");
            if (Power >= 4)
                list.Add("с великолепным оружием ");
            if (Armor < 2)
                list.Add("в простой майке.");
            if (Armor >= 2 && Armor < 3)
                list.Add("в кожаной броне.");
            if (Armor >= 3)
                list.Add("в латном доспехе");
            return string.Join(string.Empty, list);
        }
    }
}
