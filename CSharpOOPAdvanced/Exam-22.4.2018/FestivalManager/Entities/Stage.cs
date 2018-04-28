namespace FestivalManager.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class Stage : IStage
    {
        // да си вкарват през полетата бе
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public IPerformer GetPerformer(string name)
        {
            return performers.FirstOrDefault(x => x.Name == name);
        }

        public ISet GetSet(string name)
        {
            return sets.FirstOrDefault(x => x.Name == name);
        }

        public ISong GetSong(string name)
        {
            return songs.FirstOrDefault(x => x.Name == name);
        }

        public bool HasPerformer(string name)
        {
            return performers.Any(x => x.Name == name);
        }

        public bool HasSet(string name)
        {
            return sets.Any(x => x.Name == name);
        }

        public bool HasSong(string name)
        {
            return songs.Any(x => x.Name == name);
        }
    }
}
