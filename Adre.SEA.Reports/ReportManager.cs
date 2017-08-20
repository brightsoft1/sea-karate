using System.Collections.Generic;
using System.Data;
using System.Linq;
using Adre.SEA.Database;
using Telerik.Reporting;

namespace Adre.SEA.Reports
{
    public static partial class ReportManager
    {
        public static InstanceReportSource GenerateMedalTallyReport()
        {
            using (var db = new ASEAContext())
            {
                var data = db.Rankings;
                var reportSource = LoadInstanceReportSourceFromFile("MedalTally.trdp");

                var dt = new DataTable();

                dt.Columns.Add("No");
                dt.Columns.Add("Contingent");
                dt.Columns.Add("Gold");
                dt.Columns.Add("Silver");
                dt.Columns.Add("Bronze");

                var rowData = new List<MedalTally>();

                foreach (var x in data)
                {
                    var d = rowData.FirstOrDefault(m => m.Contingent == x.Contingent.Name);

                    if (d == null)
                    {
                        d = new MedalTally();
                        d.Contingent = x.Contingent?.Name;
                        rowData.Add(d);
                    }

                    d.Gold += x.Medal != null && x.Medal.ToLower().Equals("gold") ? 1 : 0;
                    d.Silver += x.Medal != null && x.Medal.ToLower().Equals("silver") ? 1 : 0;
                    d.Bronze += x.Medal != null && x.Medal.ToLower().Equals("bronze") ? 1 : 0;
                }

                rowData = rowData.OrderByDescending(m => m.Gold)
                    .ThenByDescending(m => m.Silver)
                    .ThenByDescending(m => m.Bronze).ToList();

                var i = 1;
                foreach (var x in rowData)
                    dt.Rows.Add(i++, x.Contingent, x.Gold, x.Silver, x.Bronze);

                var ds = new DataSet();
                ds.Tables.Add(dt);

                var report = (Report) reportSource.ReportDocument;
                var table = (Table) report.Items.Find("tableMedalTally", true).FirstOrDefault();

                if (table != null)
                    table.DataSource = new ObjectDataSource {DataSource = ds};

                AddBasicReportParameters(reportSource);

                return reportSource;
            }
        }
    }
}