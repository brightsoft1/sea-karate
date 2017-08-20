using System.Collections.ObjectModel;

namespace Adre.Controls.ResultList
{
    public interface IItemViewModel
    {
        StartList.IItemViewModel StartListItem { get; }

        ObservableCollection<IScoreItem> IItems { get; set; }

        string ContingentA { get; }

        string ContingentB { get; }

        int PointA { get; set; }

        int PointB { get; set; }
        
        string AthletesA { get; }

        string AthletesB { get; }

        IScoreItem CreateScoreItem();
    }
}
