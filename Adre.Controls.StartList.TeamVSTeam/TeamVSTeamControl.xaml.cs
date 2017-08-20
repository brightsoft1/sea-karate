using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using System;
using Adre.SEA.Reports;

namespace Adre.Controls.StartList.TeamVSTeam
{
    /// <summary>
    /// Interaction logic for TeamVSTeamControl.xaml
    /// </summary>
    public partial class TeamVSTeamControl : UserControl, IStartListButtonHandler
    {
        public event NewItemAddedHandler OnNewItemAdded;
        public event ItemDeletedHandler OnItemDeleted;
        public event DataContextBindingHandler OnDataContextBinded;
        public event DataSavedHandler OnDataSaved;
        public event OnDataRefreshedHandler OnDataRefreshed;

        DataContext _dataContext;
        
        public TeamVSTeamControl()
        {
            _dataContext = new DataContext();
            DataContext = _dataContext;
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            OnDataContextBinded?.Invoke(_dataContext);
        }

        public void OnAddClick(object sender, RoutedEventArgs e) {
            ItemViewModel model = null;
            if (_dataContext.Items.Count == 0)
                model = _dataContext.CreateAndAdd();
            else
            {
                model = (ItemViewModel)(_dataContext.SelectedItem != null ? 
                    _dataContext.SelectedItem.Clone(): 
                    _dataContext.Items.Last().Clone());

                model.No = _dataContext.Items.Max(m => m.No) + 1;
                model.Id = Guid.NewGuid();
                _dataContext.Items.Add(model);
            }

            if (model != null)
                OnNewItemAdded?.Invoke(model);
        }

        public void ButtonDeleteClick(object sender, RoutedEventArgs e) {
            var item = _dataContext.SelectedItem;
            
            var b = OnItemDeleted?.Invoke(item);

            if (b != null && b == true)
            {
                _dataContext.RemoveSelected();
            }
        }

        public void OnSaveClick(object sender, RoutedEventArgs e)
        {
            OnDataSaved?.Invoke(_dataContext);
        }

        public void OnRefresh(object sender, RoutedEventArgs e)
        {
            OnDataRefreshed?.Invoke(_dataContext);
        }

        public void BtnReport_Click(object sender, RoutedEventArgs e) { }
        
        public void LstAllMatchesReport_OnPreviewMouseDown(object sender, RoutedEventArgs e) { }

        public void LstMatchReport_OnPreviewMouseDown(object sender, MouseButtonEventArgs e) { }

        private void ButtonDetailReport(object sender, RoutedEventArgs e)
        {
            var selectedMatchId = _dataContext.SelectedItem.Id;
            var reportWindow = new ReportWindow(ReportManager.GenerateStartListDetail(selectedMatchId));
            reportWindow.ShowDialog();
        }

        private void ButtonEventReport(object sender, RoutedEventArgs e)
        {
            var selectedMatchId = _dataContext.SelectedItem.Id;
            var reportWindow = new ReportWindow(ReportManager.GenerateStartListOverall(selectedMatchId));
            reportWindow.ShowDialog();
        }
    }
}
