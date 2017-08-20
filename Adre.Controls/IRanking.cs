using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adre.Controls
{
    public interface IRanking
    {
        Guid Id { get; set; }

        IEvent IEvent { get; set; }

        IContingent IContingent { get; set; }

        string Medal { get; set; }

        int Point { get; set; }
    }
}
