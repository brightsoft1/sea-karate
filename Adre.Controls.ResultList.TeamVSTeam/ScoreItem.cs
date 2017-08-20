using Prism.Mvvm;
using System;
using System.ComponentModel;

namespace Adre.Controls.ResultList.TeamVSTeam
{
    public class ScoreItem: BindableBase, IScoreItem
    {
        public event ScoreItemScoresChangedHandler OnScoresChanged;

        Guid _id;

        string _remarks;

        int _scoreA, _scoreB, _no;

        public Guid Id { get => _id; set => SetProperty(ref _id, value); }

        public int No { get => _no; set => SetProperty(ref _no, value); }
        
        public int ScoreA { get => _scoreA; set => SetProperty(ref _scoreA, value); }

        public int ScoreB { get => _scoreB; set => SetProperty(ref _scoreB, value); }
        
        public string Remarks { get => _remarks; set => SetProperty(ref _remarks, value); }

        protected override void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == "ScoreA" || args.PropertyName == "ScoreB") OnScoresChanged?.Invoke(ScoreA, ScoreB);

            base.OnPropertyChanged(args);
        }
    }
}
