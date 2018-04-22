
using System;
using System.Linq;
namespace FestivalManager.Core
{
    using System.IO;
    using System.Reflection;
    using Contracts;
    using Controllers;
    using Controllers.Contracts;
    using FestivalManager.Core.IO;
    using IO.Contracts;

    /// <summary>
    /// by g0shk0
    /// </summary>
    class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private readonly IFestivalController festivalController;
        private readonly ISetController setController;

        public Engine(IFestivalController festivalController, ISetController setController, IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
        }


        //public IFestivalController festivalCоntroller = new FestivalController();
        //public ISetController setCоntroller = new SetController();

        // дайгаз
        public void Run()
        {
            while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) // for job security
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                //try
                //{
                string.Intern(input);

                var result = this.ProcessCommand(input);
                this.writer.WriteLine(result);
                //}
                //catch (InsufficientMemoryException ex) // in case we run out of memory
                //{
                //    this.writer.WriteLine("ERROR: " + ex.Message);
                //}
            }

            var end = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var tokens = input.Split(" ".ToCharArray().First());

            var cmd = tokens.First();
            var ctorParams = tokens.Skip(1).ToArray();

            if (cmd == "LetsRock")
            {
                var sets = this.setController.PerformSets();
                return sets;
            }

            var festivalcontrolfunction = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == cmd);

            string a;

            try
            {
                a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { ctorParams });
            }
            catch (TargetInvocationException up)
            {
                a = "ERROR: " + up.InnerException.Message;
            }

            return a;
        }


    }
}