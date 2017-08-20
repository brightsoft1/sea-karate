using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adre.Controls
{
    public interface IEvent
    {
        Guid Id { get; set; }

        string Name { get; set; }

        string ToString();

        List<IAthlete> IAthletes { get; }

        string Gender { get; }
    }
}