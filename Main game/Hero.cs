using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_game
{
    internal class Hero : Fighter
    {
        public int Money;
        public int FullHealth;
        public int BasicStamina = 8;
        public Hero(string name, int health, int power, int armor) : base(name, health, power, armor)
        {
            int fullHealth = 20;
            FullHealth = fullHealth;
            int baseMoney = 0;
            Money = baseMoney;
        }

        public override void Defence(Fighter fighter)
        {
            if (fighter.Stamina >= 2)
            {
                TemporaryArmor += 2;
                fighter.Stamina -= 2;
                Console.WriteLine($"{fighter.Name} усилил свою броню.");
            }
            else
                Console.WriteLine($"{fighter.Name} не смог поднять показатель армора потому что устал.");
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
            Console.WriteLine($"{fighter.Name} перевел дух, теперь его стамина составляет: {fighter.Stamina}");
        }

        public override string ToString()
        {
            return $"{Name}, {Health}";
        }
    }
}
