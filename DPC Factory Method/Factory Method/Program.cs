using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
   
    abstract class Mechanic
    {
        public string Company { get; set; }

        public Mechanic(string name)
        {
            Company = name;
            Console.WriteLine(Company);
        }
        
        abstract public Engine Create();
    }
    
    class SportMechanic : Mechanic
    {
        public SportMechanic(string name) : base(name)
        { }

        public override Engine Create()
        {
            return new SportEngine();
        }
    }
    // строит деревянные дома
    class TruckMechanic : Mechanic
    {
        public TruckMechanic(string name) : base(name)
        { }

        public override Engine Create()
        {
            return new TruckEngine();
        }
    }

    abstract class Engine
    { }

    class SportEngine : Engine
    {
        public SportEngine()
        {
            Console.WriteLine("Sport engine created");
        }
    }

    class TruckEngine : Engine
    {
        public TruckEngine()
        {
            Console.WriteLine("Truck engine created");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Mechanic mech = new SportMechanic("Ferrary");
            Engine eng = mech.Create();

            mech = new TruckMechanic("Volvo");
            Engine treng = mech.Create();

            Console.ReadLine();
        }
    }
}
