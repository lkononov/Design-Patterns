using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            // new worker C++
            Programmer freelancer = new FreelanceProgrammer(new CPPLanguage());
            freelancer.DoWork();
            freelancer.EarnMoney();
            // need to use worker C#
            freelancer.Language = new CSharpLanguage();
            freelancer.DoWork();
            freelancer.EarnMoney();

            Console.Read();
        }
    }

    interface ILanguage
    {
        void Build();
        void Execute();
    }

    class CPPLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Using C ++ to compiling the program into binary code");
        }

        public void Execute()
        {
            Console.WriteLine("Run the executable file of the program");
        }
    }

    class CSharpLanguage : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Using the Roslyn to compiling the source code into an exe file");
        }

        public void Execute()
        {
            Console.WriteLine("JIT compiles program");
            Console.WriteLine("The CLR executes the compiled binary code");
        }
    }

    abstract class Programmer
    {
        protected ILanguage language;
        public ILanguage Language
        {
            set { language = value; }
        }
        public Programmer(ILanguage lang)
        {
            language = lang;
        }
        public virtual void DoWork()
        {
            language.Build();
            language.Execute();
        }
        public abstract void EarnMoney();
    }

    class FreelanceProgrammer : Programmer
    {
        public FreelanceProgrammer(ILanguage lang) : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Receive payment for the compleated order");
        }
    }
    class CorporateProgrammer : Programmer
    {
        public CorporateProgrammer(ILanguage lang)
            : base(lang)
        {
        }
        public override void EarnMoney()
        {
            Console.WriteLine("Get a salary at the end of the month");
        }
    }
}
