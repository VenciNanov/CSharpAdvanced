namespace FestivalManager.Core.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Contracts;
    using Entities.Contracts;
    using FestivalManager.Core.IO.Contracts;
    using FestivalManager.Entities.Factories.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";

        //private IWriter writer;
        private readonly IStage stage;
        private readonly ISetFactory setFactory;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISongFactory songFactory;

        public FestivalController(IStage stage, ISetFactory setFactory, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISongFactory songFactory)
        {
            this.stage = stage;
            this.setFactory = setFactory;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {$"{(int)totalFestivalLength.TotalMinutes:D2}:{totalFestivalLength.Seconds:D2}"}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                //result += ($"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):" + "\n");
                result += ($"--{set.Name} ({(int)set.ActualDuration.TotalMinutes:D2}:{set.ActualDuration.Seconds:d2}):"+"\n");

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString().Trim();
        }

        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var type = args[1];

            var set = setFactory.CreateSet(name, type);

            if (!stage.HasSet(name))
            {
                stage.AddSet(set);
                return $"Registered {type} set";
            }

            throw new InvalidOperationException("Invalid set provided");

        }

        public string RegisterSong(string[] args)
        {

            var songName = args[0];
            var duration = TimeSpan.ParseExact(args[1],TimeFormat,CultureInfo.CurrentCulture);

            var song = songFactory.CreateSong(songName, duration);

            stage.AddSong(song);
            return $"Registered song {songName} ({duration.ToString(TimeFormat)})";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentsList = args.Skip(2).ToArray();

            var instrumenti2 = instrumentsList
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in instrumenti2)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string SongRegistration(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song} to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];
            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }
            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var performer = stage.GetPerformer(performerName);
            var set = stage.GetSet(setName);

            //stage.AddPerformer(performer);
            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";


        }

        //public string PerformerRegistration(string[] args)
        //{
        //    var performerName = args[0];
        //    var setName = args[1];

        //    if (!this.stage.HasPerformer(performerName))
        //    {
        //        throw new InvalidOperationException("Invalid performer provided");
        //    }

        //    if (!this.stage.HasSet(setName))
        //    {
        //        throw new InvalidOperationException("Invalid set provided");
        //    }

        //    AddPerformerToSet(args);

        //    var performer = this.stage.GetPerformer(performerName);
        //    var set = this.stage.GetSet(setName);

        //    set.AddPerformer(performer);

        //    return $"Added {performer.Name} to {set.Name}";
        //}
      
        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }
            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var song = stage.GetSong(songName);
            var set = stage.GetSet(setName);

            //stage.AddSong(song);
            set.AddSong(song);

            return $"Added {songName} ({song.Duration.ToString(TimeFormat)}) to {setName}";
        }

        public string RepairInstruments(string[] args)

        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }

        //private static string ToCustomString(TimeSpan duration)
        //{
        //    return duration.("{0}//:{1}", duration.TotalMinutes, duration.TotalSeconds);
        //}

    }

   
}