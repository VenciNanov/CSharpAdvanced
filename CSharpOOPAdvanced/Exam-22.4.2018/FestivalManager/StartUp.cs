namespace FestivalManager
{
	using System.IO;
	using System.Linq;
	using Core;
	using Core.Contracts;
	using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;
    using FestivalManager.Entities.Factories;
    using FestivalManager.Entities.Factories.Contracts;

    public static class StartUp
	{
		public static void Main(string[] args)
		{
            IWriter writer = new ConsoleWriter();
            IReader reader = new ConsoleReader();

			IStage stage = new Stage();
            ISetFactory setFactory = new SetFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISongFactory songFactory = new SongFactory();

            
			IFestivalController festivalController = new FestivalController(stage,setFactory,instrumentFactory,performerFactory,songFactory);
			ISetController setController = new SetController(stage);

			var engine = new Engine(festivalController, setController,reader,writer);

			engine.Run();
		}
	}
}