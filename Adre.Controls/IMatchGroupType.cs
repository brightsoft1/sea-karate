using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adre.Controls
{
    public interface IMatchGroupType
    {
        Guid Id { get; set; }

        string Name { get; set; }
    }
}
