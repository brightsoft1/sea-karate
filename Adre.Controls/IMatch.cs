using System;

namespace Adre.Controls
{
    public interface IMatch
    {
        Guid Id { get; }

        DateTime DateTimeStart { get; set; }

        DateTime? DateTimeEnd { get; set; }

        int MatchNo { get; set; }

        string Arena { get; set; }

        string Round { get; set; }

        string Venue { get; set; }

        IMatchGroupType IGroup { get; set; }

        string Remarks { get; set; }
    }
}
