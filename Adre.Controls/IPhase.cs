
using System;

namespace Adre.Controls
{
    public interface IPhase
    {
        Guid Id { get; }
        string Name { get; }
        string ToString();
    }
}
