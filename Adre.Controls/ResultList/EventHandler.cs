
namespace Adre.Controls.ResultList.TeamVSTeam
{
    public delegate void DataContextBindingHandler(IDataContext context);
    public delegate void DataSavedHandler(IDataContext context);
    public delegate void SelectedItemChangedHandler(IItemViewModel item);
    public delegate void DataRefreshedHandler(IDataContext context);
    public delegate void RowDoubleClickedHandler(IItemViewModel item);
    public delegate void ScoreItemScoresChangedHandler(int ScoreA, int ScoreB);
}
