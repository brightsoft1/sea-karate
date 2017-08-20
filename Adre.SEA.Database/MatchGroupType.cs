using Adre.Controls;
using System;
using System.ComponentModel.DataAnnotations;

namespace Adre.SEA.Database
{
    public class MatchGroupType: IMatchGroupType
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
