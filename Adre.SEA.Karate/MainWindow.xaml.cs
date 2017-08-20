using System.Windows;
using Adre.Controls;
using System;
using System.Linq;
using System.Net;
using System.Collections.Specialized;
using System.Configuration;
using System.Threading.Tasks;
using Adre.SEA.Service;
using System.Windows.Threading;

namespace Adre.SEA.Karate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MatchService _service;
        RankService _rankService;
        DataContext _dataContext;

        public MainWindow()
        {
            _service = new MatchService();
            _rankService = new RankService();

            _dataContext = new DataContext();
            DataContext = _dataContext;
            InitializeComponent();

            new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                _dataContext.Time = DateTime.Now.ToString("HH:mm:ss");
            }, this.Dispatcher);
        }

        public void OnNewItemAdded(Controls.StartList.IItemViewModel item)
        {
            _service.Add(item);
        }

        public void OnStartListDataBinded(Controls.StartList.IDataContext context)
        {
            _service.Register(context);
        }

        public void OnResultListDataBinded(Controls.ResultList.IDataContext context)
        {
            _service.Register(context);
        }
        
        void OnStartListSaved(Controls.StartList.IDataContext context) {
            _service.SaveMatch();
            MessageBox.Show("Save Completed!", "Status");
        }

        void OnResultListSaved(Controls.ResultList.IDataContext context)
        {
            _service.SaveResult();
            _rankService.Save();
            MessageBox.Show("Save Completed!", "Status");
        }

        void OnRankingListSave(Controls.RankingList.IDataContext context) {
            _rankService.Save();
            MessageBox.Show("Save Completed!", "Status");
        }

        void LoadAll()
        {
            _service.Refresh();
            _rankService.Load();
        }
        
        void OnResultListRowDoubleClicked(Controls.ResultList.IItemViewModel item)
        {
            if (item != null) SendtMatchDetailsToScoring(item.StartListItem);
        }

        void SendtMatchDetailsToScoring(Controls.StartList.IItemViewModel item)
        {
            MessageBoxResult result = MessageBox.Show("Send info of Match No " + item.No + " to RealTime?", "Confirmation", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes) return;

            var t = Task.Run(() =>
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        var athAList = item.SelectedAthleteA.Select(m => (IAthlete)m).ToList();
                        var athBList = item.SelectedAthleteB.Select(m => (IAthlete)m).ToList();

                        var athA1 = athAList[0];
                        var athA2 = athAList.Count > 1 ? athAList[1] : null;
                        var athB1 = athBList[0];
                        var athB2 = athBList.Count > 1 ? athBList[1] : null;

                        byte[] response =
                        
                        client.UploadValues(ConfigurationManager.AppSettings["RealtimeServerTerminal"] + "/" + item.Id, new NameValueCollection()
                        {   
                            { "SportName",  ConfigurationManager.AppSettings["SportName"] },
                            { "EventName", item.SelectedEvent.ToString() },
                            { "MatchNo", item.No.ToString() },
                            { "TableNo", item.Arena },
                            { "ContingentACode", item.SelectedContingentA.Code },
                            { "ContingentAGroup", item.SelectedGroupA },
                            { "ContingentAName", item.SelectedContingentA.Name },
                            { "ContingentBCode", item.SelectedContingentB.Code },
                            { "ContingentBGroup", item.SelectedGroupB },
                            { "ContingentBName", item.SelectedContingentB.Name },
                            { "Series", item.SelectedPhase.ToString() },
                            { "StartTime", item.DateTimeStart.ToString("HH:mm") },
                            { "Date", item.DateTimeStart.ToString("dd/MM/yyyy") },
                            { "AthleteA1Name", athA1?.PreferredName },
                            { "AthleteA1Photo", athA1?.Id + ".jpg" },
                            { "AthleteA2Name", athA2?.PreferredName },
                            { "AthleteA2Photo", athA2?.Id + ".jpg" },
                            { "AthleteB1Name", athB1?.PreferredName },
                            { "AthleteB1Photo", athB1?.Id + ".jpg" },
                            { "AthleteB2Name", athB2?.PreferredName },
                            { "AthleteB2Photo", athB2?.Id + ".jpg" },
                        });

                        Console.WriteLine(System.Text.Encoding.UTF8.GetString(response));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            });
        }

         bool? OnStartListItemDeleted(Controls.StartList.IItemViewModel item)
         {
              
            if (item == null) return false;

            MessageBoxResult result = MessageBox.Show("Are you sure to delete Match No " + item.No + "?", "Delete Confirmation", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                _service.Remove(item);
                return true;
            }

            return false;
        }

        void OnStartListDataRefreshed(Controls.StartList.IDataContext dataContext) {
            LoadAll();
            MessageBox.Show("Data Refreshed!", "Status");

        }

        void OnResultListDataRefreshed(Controls.ResultList.IDataContext dataContext) {
            LoadAll();
            MessageBox.Show("Data Refreshed!", "Status");
        }

        void OnRankingDataContextBinded(Controls.RankingList.IDataContext context)
        {
            _rankService.Register(context);
            LoadAll();
        }

        void OnImporterStatusChanged(string status, float value)
        {
            _dataContext.Visibility = "Collapsed";
            _dataContext.Status = status;

            new DispatcherTimer(new TimeSpan(0, 0, 3), DispatcherPriority.Normal, (object sender, EventArgs e) =>
            {
                _dataContext.Status = "";
                ((DispatcherTimer)sender).Stop();
            }, this.Dispatcher);
        }

        void OnImporterStatusChanging(string status, float value)
        {
            _dataContext.Visibility = "Visible";
            _dataContext.Status = status;
            _dataContext.Value = value * 100;
        }
    }
}
