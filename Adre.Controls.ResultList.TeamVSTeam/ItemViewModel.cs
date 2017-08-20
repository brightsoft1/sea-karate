using System;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Adre.Controls.ResultList.TeamVSTeam
{
    class ItemViewModel : BindableBase, IItemViewModel
    {
        StartList.IItemViewModel _startListItem;

        ObservableCollection<ScoreItem> _items;

        TimeSpan? _duration;

        int _pointA, _pointB;

        public ItemViewModel()
        {
            Items = new ObservableCollection<ScoreItem>();
        }

        public StartList.IItemViewModel StartListItem
        {
            get => _startListItem;
            set
            {
                if(_startListItem != null)
                    ((BindableBase)_startListItem).PropertyChanged -= OnStartListPropertyChanged;//unregister old listener
                                
                ((BindableBase)value).PropertyChanged += OnStartListPropertyChanged; //register new listener
                value.OnAthleteAChanged += OnAthletesAChanged;
                value.OnAthleteBChanged += OnAthletesBChanged;
                value.OnContingentAChanged += OnContingentAChanged;
                value.OnContingentBChanged += OnContingentBChanged;
                SetProperty(ref _startListItem, value);
            }
        }
                
        string _contingentA, _contingentB, _athletesA, _athletesB;

        public string ContingentA { get => _contingentA; set => SetProperty(ref _contingentA, value); }

        public string ContingentB { get => _contingentB; set => SetProperty(ref _contingentB, value); }

        public string AthletesA { get => _athletesA; set => SetProperty(ref _athletesA, value); }

        public string AthletesB { get => _athletesB; set => SetProperty(ref _athletesB, value); }

        public TimeSpan? Duration { get => _duration; set => SetProperty(ref _duration, value); }

        public ObservableCollection<ScoreItem> Items
        {
            get => _items;
            set
            {
                if (_items != null && _items.Count() > 0)
                    foreach (var item in _items) item.OnScoresChanged -= OnScoreItemsScoreChanged;

                foreach (var item in value) item.OnScoresChanged += OnScoreItemsScoreChanged;

                SetProperty(ref _items, value);

                OnScoreItemsScoreChanged(0, 0);
            }
        }

        public ObservableCollection<IScoreItem> IItems
        {
            get => new ObservableCollection<IScoreItem>(Items);
            set { Items = new ObservableCollection<ScoreItem>(value.Select(m => (ScoreItem)m)); }
        }

        public void OnAthletesAChanged(ICollection<IAthlete> item)
        {
            AthletesA = (item != null) ? String.Join("\n", item) : "";
        }
        
        public void OnAthletesBChanged(ICollection<IAthlete> item)
        {
            AthletesB = (item != null) ? String.Join("\n", item): "";
        }
        
        public void OnContingentAChanged(IContingent item)
        {
            ContingentA = item?.Code;
        }

        public void OnContingentBChanged(IContingent item)
        {
            ContingentB = item?.Code;   
        }

        public void OnStartListPropertyChanged(object sender, EventArgs e)
        {
            var d = (dynamic)sender;
            if (d.DateTimeEnd != null)
                Duration = d.DateTimeEnd - d.DateTimeStart;
        }
        
        public int PointA { get => _pointA; set => SetProperty(ref _pointA, value); }

        public int PointB { get => _pointB; set => SetProperty(ref _pointB, value); }

        public IScoreItem CreateScoreItem() { return new ScoreItem(); }

        public void OnScoreItemsScoreChanged(int scoreA, int scoreB)
        {
            PointA = scoreA;
            PointB = scoreB;
        }
    }
}
