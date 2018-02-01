using System;


namespace Adapter
{
    interface ITransport
    {
        void Drive();
    }
    
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("use car to road driving");
        }
    }
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    
    interface IAnimal
    {
        void Move();
    }
    
    class Camel : IAnimal
    {
        public void Move()
        {
            Console.WriteLine("use camel to off-road travel");
        }
    }
    
    class CamelToTransportAdapter : ITransport
    {
        Camel camel;
        public CamelToTransportAdapter(Camel c)
        {
            camel = c;
        }

        public void Drive()
        {
            camel.Move();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {           
            Driver driver = new Driver();           
            Auto auto = new Auto();           
            driver.Travel(auto);
            // adaptation of transport under conditions
            Camel camel = new Camel();           
            ITransport camelTransport = new CamelToTransportAdapter(camel);
            driver.Travel(camelTransport);

            Console.Read();
        }
    }

}
