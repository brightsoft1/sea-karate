using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Adre.SEA.Importer
{
    public delegate void StatusChangedHandler(string status, float progress);

    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    public partial class MainControl : UserControl
    {
        DataContext _dataContext;
        ImportManager _importManager;

        public event StatusChangedHandler OnStatusChanged, OnStatusChanging;

        public MainControl()
        {
            InitializeComponent();
            _dataContext = new DataContext();
            _importManager = new ImportManager(int.Parse(ConfigurationManager.AppSettings["SportId"]));

            _importManager.OnEventChanged += (string label, float progress) => {
                OnStatusChanging?.Invoke(label, progress);
            };

            DataContext = _dataContext;
        }

        private async void ButtonImportClick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            await _importManager.Execute();
            ((Button)sender).IsEnabled = true;

            OnStatusChanged?.Invoke("Import complete", 100);
        }

        private async void ButtonClearClick(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false;
            await _importManager.Clear();
            ((Button)sender).IsEnabled = true;

            OnStatusChanged?.Invoke("Database cleared", 100);
        }
    }
}
