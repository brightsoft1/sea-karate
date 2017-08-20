using System.Data.Entity;

namespace Adre.SEA.Database
{
    public class ASEAContext : DbContext
    {
        public ASEAContext() : base() { }

        public virtual DbSet<Athlete> Athletes { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<Match> Matches { get; set; }

        public virtual DbSet<Phase> Phases { get; set; }

        public virtual DbSet<Contingent> Contingents { get; set; }

        public virtual DbSet<MatchAthlete> MatchAthlete { get; set; }

        public virtual DbSet<Result> Result { get; set; }

        public virtual DbSet<MatchGroupType> MatchGroupType { get; set; }

        public virtual DbSet<Ranking> Rankings { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Match>()
                .HasOptional(m => m.Result)
                .WithRequired(m => m.Match);
                
                
        }
    }
}
