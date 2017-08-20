using Adre.Controls;
using System;
using System.ComponentModel.DataAnnotations;

namespace Adre.SEA.Database
{
    public class Contingent: IContingent
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public Contingent ()
        {
            Id = Guid.NewGuid();
        }
        public override string ToString()
        {
            return this.Name + "( " + this.Code + " )";
        }
        public override bool Equals(object other)
        {
            var obj = other as Contingent;
            return (obj != null) && Id == obj.Id;
        }

        public int WslId { get; set; }
    }
}
