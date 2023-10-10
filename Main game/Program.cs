using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hero = new Hero(string.Empty, 20, 3, 1);
            var menu = new Menu();
            menu.Start(hero);
        }
    }
}