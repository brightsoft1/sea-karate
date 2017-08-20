using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adre.Controls
{
    public interface IContingent
    {
        Guid Id { get; }

        string Code { get; }

        string ToString();

        string Name { get; }
    }
}
