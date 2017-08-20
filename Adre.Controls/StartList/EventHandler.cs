
using System.Collections.Generic;

namespace Adre.Controls.StartList.TeamVSTeam
{
    public delegate void NewItemAddedHandler(IItemViewModel item);
    public delegate bool? ItemDeletedHandler(IItemViewModel item);
    public delegate void ContingentChangedHandler(IContingent item);
    public delegate void AthleteChangedHandler(ICollection<IAthlete> item);
    public delegate void DataContextBindingHandler(IDataContext context);
    public delegate void DataSavedHandler(IDataContext item);
    public delegate void OnDataRefreshedHandler(IDataContext item);
}