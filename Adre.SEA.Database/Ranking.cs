using Adre.Controls;
using System;
using System.ComponentModel.DataAnnotations;

namespace Adre.SEA.Database
{
    public class Ranking : IRanking
    {

        [Key]
        public Guid Id { get; set; }

        public virtual Event Event { get; set; }

        public virtual Contingent Contingent { get; set; }

        public string Medal { get; set; }

        public int Point { get; set; }

        public int Order { get; set; }

        public IEvent IEvent { get; set; }

        public IContingent IContingent { get; set; }

        public string Group { get; set; }
    }
}
