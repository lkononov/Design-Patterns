using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State
{
    class Water
    {
        public IWaterState State { get; set; }

        public Water(IWaterState ws)
        {
            State = ws;
        }
        public void Heat()
        {
            State.Heat(this);
        }
        public void Frost()
        {
            State.Frost(this);
        }
    }

    interface IWaterState
    {
        void Heat(Water water);
        void Frost(Water water);
    }

    class SolidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Transforming ice into liquid state");
            water.State = new LiquidWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Continue freezing ice");
        }
    }

    class LiquidWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Transforming liquid state into vapor");
            water.State = new GasWaterState();
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Transforming liquid state into ice");
            water.State = new SolidWaterState();
        }
    }

    class GasWaterState : IWaterState
    {
        public void Heat(Water water)
        {
            Console.WriteLine("Increase the temperature of water vapor");
        }

        public void Frost(Water water)
        {
            Console.WriteLine("Transforming vapor to liquid state");
            water.State = new LiquidWaterState();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();

            Console.Read();
        }
    }

}
