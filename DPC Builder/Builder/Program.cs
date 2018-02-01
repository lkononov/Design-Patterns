using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Water
    { }
    class Salt
    { }
    class Vegetables
    {
        public string Name { get; set; }
    }
    class Seasoning
    {
        public string Type { get; set; }
    }
    class Soup
    {
        public Water Water { get; set; }
        public Salt Salt { get; set; }
        public Vegetables Vegetables { get; set; }
        public Seasoning Seasoning { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (Water != null)
                sb.Append("Water \n");
            if (Salt != null)
                sb.Append("Salt \n");
            if (Vegetables != null)
                sb.Append("Vegetables: " + Vegetables.Name + " \n");
            if (Seasoning != null)
                sb.Append("Seasoning: " + Seasoning.Type + " \n");
            return sb.ToString();
        }
    }
    abstract class SoupBuilder
    {
        public Soup Soup { get; private set; }
        public void CreateSoup()
        {
            Soup = new Soup();
        }
        public abstract void SetWater();
        public abstract void SetSalt();
        public abstract void SetVegetables();
        public abstract void SetSeasoning();
    }
    class Cook
    {
        public Soup Cooks(SoupBuilder sb)
        {
            sb.CreateSoup();
            sb.SetWater();
            sb.SetSalt();
            sb.SetVegetables();
            sb.SetSeasoning();
            return sb.Soup;
        }
    }
    class ChineseSoupBiulder : SoupBuilder
    {
        public override void SetWater()
        {
            this.Soup.Water = new Water(); ;
        }

        public override void SetVegetables()
        {
            this.Soup.Vegetables = new Vegetables { Name = "Rice" };
        }

        public override void SetSalt()
        {
            this.Soup.Salt = new Salt();
        }

        public override void SetSeasoning()
        {
            this.Soup.Seasoning = new Seasoning { Type = "ground pepper" };
        }
    }
    class ScandinavianSoupBiulder : SoupBuilder
    {
        public override void SetWater()
        {
            this.Soup.Water = new Water(); ;
        }

        public override void SetVegetables()
        {
            this.Soup.Vegetables = new Vegetables { Name = "Potatoes" };
        }

        public override void SetSalt()
        {
            this.Soup.Salt = new Salt();
        }

        public override void SetSeasoning()
        {
            this.Soup.Seasoning = new Seasoning { Type = "Bay leaf" };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Cook cook = new Cook();

            SoupBuilder builder = new ChineseSoupBiulder();

            Soup chinese = cook.Cooks(builder);
            Console.WriteLine(chinese.ToString());
            
            builder = new ScandinavianSoupBiulder();
            Soup scand = cook.Cooks(builder);
            Console.WriteLine(scand.ToString());

            Console.Read();
        }
    }
}
