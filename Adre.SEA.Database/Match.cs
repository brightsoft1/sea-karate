using Adre.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Adre.SEA.Database
{
    public class Match : IMatch
    {
        public Match()
        {
            Id = Guid.NewGuid();
            MatchAthletes = new List<MatchAthlete>();
            DateTimeStart = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }

        public DateTime DateTimeStart { get; set; }

        public DateTime? DateTimeEnd { get; set; }

        public int MatchNo { get; set; }

        public string Arena { get; set; }

        public string Round { get; set; }

        public string Venue { get; set; }
        
        public string Remarks { get; set; }

        public virtual Event Event { get; set; }

        public virtual Phase Phase { get; set; }

        public virtual MatchGroupType Group { get; set; }

        public virtual IMatchGroupType IGroup { get => Group; set => Group = (MatchGroupType)value; }

        public virtual List<MatchAthlete> MatchAthletes { get; set; }

        public virtual Result Result { get; set; }

    }
}
