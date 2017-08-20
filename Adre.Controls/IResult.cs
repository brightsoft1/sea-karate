using System;

namespace Adre.Controls
{
    public interface IResult
    {
        Guid Id { get; }

        int No { get; }

        int ScoreA { get; }

        int ScoreB { get; }

        string Remarks { get; }

        IMatch IMatch { get; }
    }
}
