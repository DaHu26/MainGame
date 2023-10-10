using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_game
{
    internal static class Shop
    {
        public static void addPower(Hero hero)
        {
            hero.Money -= 3;
            hero.Power += 2;
        }
        public static void addHealth(Hero hero)
        {
            hero.Money -= 3;
            hero.FullHealth += 3;
        }
        public static void addArmor(Hero hero)
        {
            hero.Money -= 3;
            hero.Armor += 1;
        }
        public static void addStamina(Hero hero)
        {
            hero.Money -= 3;
            hero.BasicStamina += 2;
        }
    }
}
