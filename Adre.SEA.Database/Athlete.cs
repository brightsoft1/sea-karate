using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Adre.Controls;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Adre.SEA.Database
{
    public class Athlete : IAthlete
    {
        public Athlete()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string GivenName { get; set; }

        public string PreferredName { get; set; }

        public string Gender { get; set; }

        public DateTime? DOB { get; set; }

        public List<IMatch> IMatches { get => new List<IMatch>(MatcheAthletes.Select(m => m.Match)); }

        public virtual List<MatchAthlete> MatcheAthletes { get; set; }

        public virtual List<Event> Events { get; set; }

        public virtual List<IEvent> IEvents { get => new List<IEvent>(Events); }

        public virtual Contingent Contingent { get; set; }

        public virtual IContingent IContingent { get => Contingent; }

        public override bool Equals(object other)
        {
            var obj = other as Athlete;
            return (obj != null) && Id == obj.Id;
        }

        public override string ToString()
        {
            return FullName;
        }

        public int WslId { get; set; }
    }
}
