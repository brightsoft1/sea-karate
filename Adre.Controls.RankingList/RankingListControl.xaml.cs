using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Adre.SEA.Database;
using Adre.SEA.Reports;
using Prism.Mvvm;
using Telerik.Reporting;

namespace Adre.Controls.RankingList
{
    /// <summary>
    /// Interaction logic for RankingListControl.xaml
    /// </summary>
    public partial class RankingListControl : UserControl
    {
        public event DataContextBindedHandler OnDataContextBinded;
        public event DataSavedHandler OnDataSaved;

        private RankingListControlViewModel Dc => (RankingListControlViewModel) DataContext;

        public RankingListControl()
        {
            InitializeComponent();
            DataContext = new RankingListControlViewModel();
        }

        private void RankingListControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            Dc.Load();
            Dc.DataContext = new RankingList.DataContext();
            OnDataContextBinded?.Invoke(Dc.DataContext);
        }

        private void ButtonRoundRobinReportClick(object sender, RoutedEventArgs e)
        {
            InstanceReportSource reportSource = ReportManager.GenerateTableStanding(Dc.SelectedEvent.Id, Dc.SelectedMatchGroupType.Id);
            var reportWindow = new ReportWindow(reportSource);
            reportWindow.ShowDialog();
        }

        private void OnSaveButtonClick(object sender, RoutedEventArgs e)
        {
            OnDataSaved?.Invoke(Dc.DataContext);
        }

        private void OnMedalTallyReportClick(object sender, RoutedEventArgs e)
        {
            InstanceReportSource reportSource = ReportManager.GenerateMedalTallyReport();
            var reportWindow = new ReportWindow(reportSource);
            reportWindow.ShowDialog();
        }

        private void OnRecountClick(object sender, RoutedEventArgs e)
        {
            Dc.DataContext.Recount();
        }
    }

    public class RankingListControlViewModel : BindableBase
    {
        private ObservableCollection<Event> _events = new ObservableCollection<Event>();
        private ObservableCollection<MatchGroupType> _matchGroupTypes = new ObservableCollection<MatchGroupType>();

        private Event _selectedEvent;
        private MatchGroupType _selectedMatchGroupType;

        IDataContext _dataContext;

        public ObservableCollection<Event> Events
        {
            get => _events;
            set => SetProperty(ref _events, value);
        }

        public ObservableCollection<MatchGroupType> MatchGroupTypes
        {
            get => _matchGroupTypes;
            set => SetProperty(ref _matchGroupTypes, value);
        }

        public Event SelectedEvent
        {
            get => _selectedEvent;
            set => SetProperty(ref _selectedEvent, value);
        }

        public MatchGroupType SelectedMatchGroupType
        {
            get => _selectedMatchGroupType;
            set => SetProperty(ref _selectedMatchGroupType, value);
        }

        public IDataContext DataContext
        {
            get => _dataContext;
            set => SetProperty(ref _dataContext, value);
        }

        public void Load()
        {
            using (var ctx = new ASEAContext())
            {
                Events = new ObservableCollection<Event>(ctx.Events.OrderBy(m => m.Name));
                MatchGroupTypes = new ObservableCollection<MatchGroupType>(ctx.Matches.Select(m => m.Group).Distinct().OrderBy(m => m.Name));

                SelectedEvent = Events.FirstOrDefault();
                SelectedMatchGroupType = MatchGroupTypes.FirstOrDefault();
            }
        }
    }
}
