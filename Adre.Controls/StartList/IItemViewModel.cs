using Adre.Controls.StartList.TeamVSTeam;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adre.Controls.StartList
{
    public interface IItemViewModel
    {
        event ContingentChangedHandler
            OnContingentAChanged,
            OnContingentBChanged;

        event AthleteChangedHandler 
            OnAthleteAChanged,
            OnAthleteBChanged;

        Guid Id { get; set; }

        int No { get; set; }
        DateTime DateTimeStart { get; set; }

        DateTime? DateTimeEnd { get; set; }

        IEvent SelectedEvent { get; set; }

        string Arena { get; set; }

        string Venue { get; set; }

        string  Remarks { get; set; }

        IMatchGroupType SelectedMatchGroup { get; set; }

        ObservableCollection<IContingent> ContingentList { get; set; }

        IContingent SelectedContingentA { get; set; }

        IContingent SelectedContingentB { get; set; }

        ObservableCollection<IMatchGroupType> MatchGroupList { get; set; }
        
        List<string> GroupList { get; }

        string SelectedGroupA { get; set; }

        string SelectedGroupB { get; set; }

        ObservableCollection<IAthlete> AthleteListA { get; set; }

        ObservableCollection<IAthlete> SelectedAthleteA { get; set; }
        
        ObservableCollection<IAthlete> AthleteListB { get; set; }

        ObservableCollection<IAthlete> SelectedAthleteB { get; set; }
        
        IPhase SelectedPhase { get; set; }

        object Clone();

        ObservableCollection<IEvent> IEventList { get; set; }

        ObservableCollection<IPhase> IPhaseList { get; set; }

        ICollection<string> GenderList { get; set; }

        string SelectedGender { get; set; }

        ICollection<IEvent> ReservedEventList { get; set; }
    }
}
