
using System;
using System.Collections.ObjectModel;

namespace Adre.Controls.RankingList
{
    public interface IItemViewModel
    {
        Guid Id { get; set; }

        int No { get; set; }

        int Point { get; set; }

        IContingent Contingent { get; set; }

        IEvent Event { get; set; }

        string SelectedMedal { get; set; }

        string Group { get; set; }

        string ContingentName { get; }

        ObservableCollection<string> MedalList { get; }

        int Play { get; set; }

        int Win { get; set; }

        int Tie { get; set; }
        
        int Lose { get; set; }

        int GF { get; set; }

        int GA { get; set; }

        int GD { get; set; }
    }
}
