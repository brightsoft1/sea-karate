using Adre.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Adre.SEA.Database
{
    public class Event : IEvent
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Gender { get; set; }

        public virtual List<IAthlete> IAthletes { get => new List<IAthlete>(Athlete); }
        
        public virtual List<Athlete> Athlete { get; set; }

        public Event ()
        {
            Id = Guid.NewGuid();
        }

        public override bool Equals(object other)
        {
            var obj = other as Event;
            return (obj != null) && Id == obj.Id;
        }
        
        public override string ToString()
        {
            return Name.Trim() + " (" + Gender + ")";
        }

        public int WslId { get; set; }
        
    }
}
