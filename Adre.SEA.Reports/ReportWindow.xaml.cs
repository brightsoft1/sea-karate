using System.Windows;
using Telerik.Reporting;

namespace Adre.SEA.Reports
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow(InstanceReportSource reportSource)
        {
            InitializeComponent();
            ReportViewer.ReportSource = reportSource;
        }
    }
}
