using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adre.Controls
{
    public interface IAthlete
    {
        Guid Id { get; }
        string ToString();

        IContingent IContingent { get;  }

        List<IEvent> IEvents { get; }

        string PreferredName { get; }

        string Gender { get; }
    }
}
