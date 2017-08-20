
using System;

namespace Adre.Controls.ResultList
{
    public interface IScoreItem
    {
        Guid Id { get; set; }

        int No { get; set; }

        int ScoreA { get; set; }

        int ScoreB { get; set; }

        string Remarks { get; set; }
    }
}
