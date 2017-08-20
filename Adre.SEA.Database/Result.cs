using System;
using System.ComponentModel.DataAnnotations;
using Adre.Controls;

namespace Adre.SEA.Database
{
    public class Result: IResult
    {
        public Result() { Id = Guid.NewGuid(); }

        [Key]
        public Guid Id { get; set; }
        
        public int No { get; set; }
        
        public int ScoreA { get; set; }

        public int ScoreB { get; set; }

        public string Remarks { get; set; }

        public virtual Match Match { get; set; }

        public virtual IMatch IMatch => Match;
    }
}
