using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Hero
    {
        private int ammo = 10;
        private int lives = 5;

        public void Shoot()
        {
            if (ammo > 0)
            {
                ammo--;
                Console.WriteLine("Shoot. {0} ammunition left", ammo);
            }
            else
                Console.WriteLine("No more ammunition");
        }
        
        public HeroMemento SaveState()
        {
            Console.WriteLine("Save. Param.: {0} ammunition left, {1} live", ammo, lives);
            return new HeroMemento(ammo, lives);
        }
     
        public void RestoreState(HeroMemento memento)
        {
            this.ammo = memento.Ammo;
            this.lives = memento.Lives;
            Console.WriteLine("Load. Param.: {0} ammunition left, {1} live", ammo, lives);
        }
    }
    
    class HeroMemento
    {
        public int Ammo { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int ammo, int lives)
        {
            this.Ammo = ammo;
            this.Lives = lives;
        }
    }

    class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<HeroMemento>();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            hero.Shoot();
            GameHistory game = new GameHistory();

            game.History.Push(hero.SaveState());

            hero.Shoot();

            hero.RestoreState(game.History.Pop());

            hero.Shoot();

            Console.Read();
        }
    }
}
