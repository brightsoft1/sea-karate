using System;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Adre.Controls.RankingList
{
    class ItemViewModel : BindableBase, IItemViewModel
    {
        int _no, _point, _play, _win, _tie, _lose, _gf, _ga, _gd;

        string _medal, _group;

        IContingent _contingent;

        IEvent _event;

        Guid _Id;

        public Guid Id { get => _Id; set => SetProperty(ref _Id, value); }

        public int No { get => _no; set => SetProperty(ref _no, value); }

        public IContingent Contingent { get => _contingent; set => SetProperty(ref _contingent, value); }

        public int Point { get => _point; set => SetProperty(ref _point, value); }

        public IEvent Event { get => _event; set => SetProperty(ref _event, value); }

        public ObservableCollection<string> MedalList => new ObservableCollection<string> { "", "Gold", "Silver", "Bronze" };

        public string SelectedMedal {
            get => _medal;
            set => SetProperty(ref _medal, value);
        }

        public string Group {
            get => _group;
            set => SetProperty(ref _group, value);
        }

        public string ContingentName { get => _contingent.Name + "  " + _group; }
        
        public int Play { get => _play; set => SetProperty(ref _play, value); }

        public int Win { get => _win; set => SetProperty(ref _win, value); }

        public int Tie { get => _tie; set => SetProperty(ref _tie, value); }
        
        public int Lose { get => _lose; set => SetProperty(ref _lose, value); }

        public int GF { get => _gf; set => SetProperty(ref _gf, value); }

        public int GA { get => _ga; set => SetProperty(ref _ga, value); }

        public int GD { get => _gd; set => SetProperty(ref _gd, value); }

    }
}
