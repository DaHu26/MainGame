using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_game
{
    internal abstract class Fighter
    {
        public string Name;
        public int Power;
        public int Health;
        public int Armor;
        public int Stamina;
        public int AddStaminaPerRound;
        public int TemporaryArmor;

        public Fighter(string name, int health, int power, int armor)
        {
            Name = name;
            Power = power;
            Health = health;
            var basicStamina = 8;
            Stamina = basicStamina;
            var basicAddStaminaPerRound = 4;
            AddStaminaPerRound = basicAddStaminaPerRound;
            Armor = armor;
        }

        public abstract void Punch(Fighter attacking, Fighter enemy);

        public abstract void Relax(Fighter fighter);

        public abstract void Defence(Fighter fighter);
    }
}
