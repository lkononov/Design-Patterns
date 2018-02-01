using System;
using System.Collections.Generic;
using System.Linq;

abstract class Wheels
{
    public Wheels(string name)
    {
        this.Name = name;
    }
    public string Name { get; protected set; }
    public abstract int GetCost();
}

class AspenWheels : Wheels
{
    public AspenWheels() : base("Aspen wheels")
    { }
    public override int GetCost()
    {
        return 450;
    }
}
class CortinaWheels : Wheels
{
    public CortinaWheels()
        : base("Cortina wheels")
    { }
    public override int GetCost()
    {
        return 350;
    }
}

abstract class WheelsDecorator : Wheels
{
    protected Wheels wheels;
    public WheelsDecorator(string name, Wheels wheels) : base(name)
    {
        this.wheels = wheels;
    }
}

class ChromeWheels : WheelsDecorator
{
    public ChromeWheels(Wheels p)
        : base(p.Name + ", with chrome layer", p)
    { }

    public override int GetCost()
    {
        return wheels.GetCost() + 150;
    }
}

class GraphiteWheels : WheelsDecorator
{
    public GraphiteWheels(Wheels p)
        : base(p.Name + ", with graphite layer", p)
    { }

    public override int GetCost()
    {
        return wheels.GetCost() + 20;
    }
}
class Program
{
    static void Main(string[] args)
    {
        Wheels wheels1 = new AspenWheels();
        wheels1 = new ChromeWheels(wheels1); // итальянская пицца с томатами
        Console.WriteLine("Name: {0}", wheels1.Name);
        Console.WriteLine("Cost: {0}", wheels1.GetCost() + "$");

        Wheels wheels2 = new AspenWheels();
        wheels2 = new GraphiteWheels(wheels2);// итальянская пиццы с сыром
        Console.WriteLine("Name: {0}", wheels2.Name);
        Console.WriteLine("Cost: {0}", wheels2.GetCost() + "$");

        Wheels wheels3 = new CortinaWheels();
        wheels3 = new ChromeWheels(wheels3);
        wheels3 = new GraphiteWheels(wheels3);
        Console.WriteLine("Name: {0}", wheels3.Name);
        Console.WriteLine("Cost: {0}", wheels3.GetCost() + "$");

        Console.ReadLine();
    }
}
