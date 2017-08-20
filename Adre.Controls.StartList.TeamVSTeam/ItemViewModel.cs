using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Adre.Controls.StartList.TeamVSTeam
{
    public class ItemViewModel : BaseItemModel, IItemViewModel, ICloneable
    {
        public event ContingentChangedHandler
            OnContingentAChanged,
            OnContingentBChanged;

        public event AthleteChangedHandler
            OnAthleteAChanged,
            OnAthleteBChanged,
            OnReserveAChanged,
            OnReserveBChanged;

        ObservableCollection<IContingent> _contingentList;

        IContingent _selectedContingentA,
            _selectedContingentB;

        ObservableCollection<IMatchGroupType> _matchGroupList;

        IMatchGroupType _selectedMatchGroup;

        ObservableCollection<IAthlete> _selectedAthleteListA,
            _selectedAthleteListB,
            _athleteListA, _athleteListB,
            _selectedReserveListA, _selectedReserveListB;

        string _selectedGroupA, _selectedGroupB, _contingentA, _contingentB, _selectedGender;

        ICollection<string> _genderList;

        public ICollection<IEvent> ReservedEventList { get; set; }
        
        public string SelectedGroupA
        {
            get => _selectedGroupA;
            set
            {
                if (SelectedContingentA != null)
                    ContingentA = SelectedContingentA.Name + (!String.IsNullOrEmpty(value) ? " " + value : "");

                SetProperty(ref _selectedGroupA, value);
            }
        }

        public string SelectedGroupB
        {
            get => _selectedGroupB;
            set
            {
                if (SelectedContingentB != null)
                    ContingentB = SelectedContingentB.Name + (!String.IsNullOrEmpty(value) ? " " + value: "");
                SetProperty(ref _selectedGroupB, value);
            }
        }

        public List<string> GroupList { get => new List<string> { "", "A", "B", "C", "D", "E" }; }

        public ObservableCollection<IMatchGroupType> MatchGroupList { get => _matchGroupList; set => SetProperty(ref _matchGroupList, value); }
       
        public IMatchGroupType SelectedMatchGroup { get => _selectedMatchGroup; set => SetProperty(ref _selectedMatchGroup, value); }

        public ItemViewModel()
        {
            SelectedAthleteA = new ObservableCollection<IAthlete>();
            SelectedAthleteB = new ObservableCollection<IAthlete>();
            SelectedReserveA = new ObservableCollection<IAthlete>();
            SelectedReserveB = new ObservableCollection<IAthlete>();
            SelectedGroupA = "";
            SelectedGroupB = "";
        }

        public override IEvent SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                if (value == null) return;
                ContingentList = new ObservableCollection<IContingent>(value.IAthletes.Select(m => m.IContingent).Distinct());

                SelectedContingentA = null;
                SelectedContingentB = null;

                 SetProperty(ref _selectedEvent, value);
            }
        }

        public IContingent SelectedContingentA
        {
            get => _selectedContingentA;
            set {
                SetProperty(ref _selectedContingentA, value);

                if (value != null)
                {
                    AthleteListA = new ObservableCollection<IAthlete>(SelectedEvent.IAthletes.Where(m => m.IContingent.Id == value.Id));
                    SelectedAthleteA.Clear();
                    SelectedReserveA.Clear();
                    ContingentA = value.Name + (!String.IsNullOrEmpty(SelectedGroupA) ? " " + SelectedGroupA : "");

                    OnAthleteAChanged?.Invoke(SelectedAthleteA);
                    OnReserveAChanged?.Invoke(SelectedAthleteB);
                }

                OnContingentAChanged?.Invoke(value);
            }
        }

        public IContingent SelectedContingentB
        {
            get => _selectedContingentB;
            set {
                SetProperty(ref _selectedContingentB, value);
                if (value != null)
                {
                    AthleteListB = new ObservableCollection<IAthlete>(SelectedEvent.IAthletes.Where(m => m.IContingent.Id == value.Id));
                    SelectedAthleteB.Clear();
                    SelectedReserveB.Clear();
                    ContingentB = value.Name + (!String.IsNullOrEmpty(SelectedGroupB) ? " " + SelectedGroupB : "");

                    OnAthleteBChanged?.Invoke(null);
                    OnReserveBChanged?.Invoke(null);
                }
                OnContingentBChanged?.Invoke(value);
            }
        }

        public ObservableCollection<IContingent> ContingentList
        {
            get => _contingentList;
            set { SetProperty(ref _contingentList, value); }
        }

        public ObservableCollection<IAthlete> AthleteListA {
            get => _athleteListA;
            set => SetProperty(ref _athleteListA, value);
        }

        public ObservableCollection<IAthlete> AthleteListB
        {
            get => _athleteListB;
            set => SetProperty(ref _athleteListB, value); 
        }

        public ObservableCollection<IAthlete> SelectedAthleteA
        {
            get => _selectedAthleteListA;
            set { OnAthleteAChanged?.Invoke(value); SetProperty(ref _selectedAthleteListA, value); }
        }

        public ObservableCollection<IAthlete> SelectedReserveA
        {
            get => _selectedReserveListA;
            set { OnReserveAChanged?.Invoke(value); SetProperty(ref _selectedReserveListA, value); }
        }

        public ObservableCollection<IAthlete> SelectedAthleteB
        {
            get => _selectedAthleteListB;
            set { OnAthleteBChanged?.Invoke(value); SetProperty(ref _selectedAthleteListB, value); }
        }

        public ObservableCollection<IAthlete> SelectedReserveB
        {
            get => _selectedReserveListB;
            set { OnReserveBChanged?.Invoke(value); SetProperty(ref _selectedReserveListB, value); }
        }

        public ObservableCollection<IEvent> IEventList { get => EventList; set { EventList = value; } }

        public ObservableCollection<IPhase> IPhaseList { get => PhaseList; set { PhaseList = value; } }

        public object Clone()
        {
            var cloned = (ItemViewModel)this.MemberwiseClone();

            cloned.Id = Guid.NewGuid();

            cloned.SelectedAthleteA = new ObservableCollection<IAthlete>();
            cloned.SelectedAthleteB = new ObservableCollection<IAthlete>();
            cloned.SelectedReserveA = new ObservableCollection<IAthlete>();
            cloned.SelectedReserveB = new ObservableCollection<IAthlete>();
            cloned.SelectedGroupA = "";
            cloned.SelectedGroupB = "";
            cloned.AthleteListA = new ObservableCollection<IAthlete>();
            cloned.AthleteListB = new ObservableCollection<IAthlete>();
            cloned.SelectedContingentA = null;
            cloned.SelectedContingentB = null;
            cloned.ContingentA = null;
            cloned.ContingentB = null;
            cloned.DateTimeEnd = null;
            return cloned;
        }

        public string ContingentA
        {
            get => _contingentA;
            set => SetProperty(ref _contingentA, value);
        }

        public string ContingentB
        {
            get => _contingentB;
            set => SetProperty(ref _contingentB, value);
        }

        public ICollection<string> GenderList
        {
            get => _genderList;
            set => SetProperty(ref _genderList, value);
        }

        public string SelectedGender
        {
            get => _selectedGender;
            set
            {
                SetProperty(ref _selectedGender, value);

                if (value != null)
                {
                    EventList = new ObservableCollection<IEvent>(ReservedEventList.Where(m => m.Gender == value).OrderBy(m => m.Name));
                }
            }
        }
    }
}
