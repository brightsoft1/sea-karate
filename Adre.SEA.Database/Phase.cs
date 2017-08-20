using Adre.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Adre.SEA.Database
{
    public class Phase : IPhase
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public Phase()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return Name;
        }

        public int Order { get; set; }
    }

}
