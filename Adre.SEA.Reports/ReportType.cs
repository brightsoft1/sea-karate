using Telerik.Reporting;

namespace Adre.SEA.Reports
{
    public class ReportType
    {
        public string Name { get; set; }
        public ReportSource Source { get; set; }

        public EReportType Type { get; set; }

        public ReportType(string name, Report report, EReportType type)
        {
            Name = name;
            Source = new InstanceReportSource() {ReportDocument = report};
            Type = type;
        }

        public ReportType(string name, Report report)
        {
            Name = name;
            Source = new InstanceReportSource() {ReportDocument = report};
        }

        public ReportType(string name, ReportSource reportSource)
        {
            Name = name;
            Source = reportSource;
        }
    }

    public enum EReportType
    {
        Undefined = 0,
        StartList = 1
    }
}
