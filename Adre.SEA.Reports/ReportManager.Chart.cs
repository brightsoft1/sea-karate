using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Reporting;

namespace Adre.SEA.Reports
{
    public static partial class ReportManager
    {
        public static InstanceReportSource GenerateBracket(string filename, string resultFileName)
        {
            var chartReport = new ReportChart(filename, resultFileName);
            var reportSource = LoadInstanceReportSourceFromClass(chartReport);
            AddBasicReportParameters(reportSource);
            return reportSource;
        }
    }
}
