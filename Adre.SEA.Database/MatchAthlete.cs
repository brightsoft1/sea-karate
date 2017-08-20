using System;
using System.ComponentModel.DataAnnotations;

namespace Adre.SEA.Database
{
    public class MatchAthlete
    {
        [Key]
        public Guid Id { get; set; }

        public string Side { get; set; }

        public string Group { get; set; }

        public virtual Match Match { get;set; }

        public virtual Athlete Athlete { get; set; }

        public MatchAthlete()
        {
            Id = Guid.NewGuid();
        }
    }
}
