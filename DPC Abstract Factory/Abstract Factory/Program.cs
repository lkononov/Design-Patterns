using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
   
    abstract class Weapon
    {
        public abstract void Hit();
    }
    abstract class Armor
    {
        public abstract void Protect();
    }
   
    abstract class Movement
    {
        public abstract void Move();
    }
    
    class Bow : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("shoots");
        }
    }
    
    class Sword : Weapon
    {
        public override void Hit()
        {
            Console.WriteLine("sword strike");
        }
    }
    
    class LightArmor : Armor
    {
        public override void Protect()
        {
            Console.WriteLine("defend one hit");
            Console.WriteLine("feeling light fatigue");
        }
    }

    class HeavyArmor : Armor
    {
        public override void Protect()
        {
            Console.WriteLine("defend three hits");
            Console.WriteLine("feeling exhausted");
        }
    }

    class EvasionMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("evasion");
        }
    }
    
    class RunMovement : Movement
    {
        public override void Move()
        {
            Console.WriteLine("tumble");
        }
    }
    
    abstract class HeroFactory
    {
        public abstract Movement CreateMovement();
        public abstract Weapon CreateWeapon();
        public abstract Armor CreateArmor();
    }
    
    class ArcherFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new EvasionMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Bow();
        }

        public override Armor CreateArmor()
        {
            return new LightArmor();
        }
    }
    
    class WarriorFactory : HeroFactory
    {
        public override Movement CreateMovement()
        {
            return new RunMovement();
        }

        public override Weapon CreateWeapon()
        {
            return new Sword();
        }

        public override Armor CreateArmor()
        {
            return new HeavyArmor();
        }
    }
   
    class Hero
    {
        private Weapon weapon;
        private Movement movement;
        private Armor armor;
        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
            armor = factory.CreateArmor();
        }
        public void Run()
        {
            movement.Move();
        }
        public void Hit()
        {
            weapon.Hit();
        }
        public void Defend()
        {
            armor.Protect();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hero archer = new Hero(new ArcherFactory());
            Hero bowman = new Hero(new ArcherFactory());
            Hero warrior = new Hero(new WarriorFactory());

            archer.Hit();
            bowman.Hit();
            warrior.Run();
            warrior.Hit();
            archer.Run();
            warrior.Defend();
            bowman.Defend();

            Console.ReadLine();
        }
    }
}
