using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Adre.SEA.Database;
using Telerik.Reporting;
using System.Configuration;

namespace Adre.SEA.Reports
{
    public static partial class ReportManager
    {
        public static InstanceReportSource GenerateTableStanding(Guid selectedEventId, Guid matchGroupTypeId)
        {
            using (var ctx = new ASEAContext())
            {
                var eventName = ctx.Events.First(e => e.Id == selectedEventId).Name;
                var groupName = ctx.MatchGroupType.First(mgt => mgt.Id == matchGroupTypeId).Name;
                var matches = ctx.Matches.Where(m => m.Event.Id == selectedEventId && m.Group.Id == matchGroupTypeId && m.DateTimeEnd.HasValue);
                var results = matches.Select(m => m.Result);
                var contingents = ctx.MatchAthlete.Where(m => matches.Contains(m.Match)).Select(m => new { m.Group, m.Athlete.Contingent.Code }).Distinct();
                                
                var totalScores = new List<ReportRoundRobinModel>();
                var dt = new DataTable("tableResults");

                dt.Columns.Add("Cont");
                dt.Columns.Add("Play");
                dt.Columns.Add("Win");
                dt.Columns.Add("Lose");
                dt.Columns.Add("Tie");
                dt.Columns.Add("GF");
                dt.Columns.Add("GA");
                dt.Columns.Add("GD");
                dt.Columns.Add("PT");

                //Normalize
                foreach (var result in results)
                {
                    var rA = new ReportRoundRobinModel();
                    var rB = new ReportRoundRobinModel();

                    var resultA = result.ScoreA;
                    var resultB = result.ScoreB;
                    
                    rA.Cont = result.Match.MatchAthletes?.Where(m => m.Side == "A").FirstOrDefault().Athlete.Contingent.Code;
                    rB.Cont = result.Match.MatchAthletes?.Where(m => m.Side == "B").FirstOrDefault().Athlete.Contingent.Code;

                    rA.Play = 1;
                    rB.Play = 1;
                    rA.Win = 0;
                    rA.Lose = 0;
                    rA.Tie = 0;

                    rB.Win = 0;
                    rB.Lose = 0;
                    rB.Tie = 0;

                    if (resultA == resultB)
                    {
                        rA.Tie = 1;
                        rB.Tie = 1;
                    }
                    else if (resultA > resultB)
                    {
                        rA.Win = 1;
                        rB.Lose = 1;

                    }
                    else if (resultA < resultB)
                    {
                        rA.Lose = 1;
                        rB.Win = 1;
                    }

                    rA.GF = resultA;
                    rB.GF = resultB;

                    rA.GA = rB.GF;
                    rB.GA = rA.GF;

                    rA.GD = rA.GF - rA.GA;
                    rB.GD = rB.GF - rB.GA;

                    totalScores.Add(rA);
                    totalScores.Add(rB);
                }

                var container = new List<ReportRoundRobinModel>();

                //Aggregate
                foreach(var cont in totalScores.Select(m => m.Cont).Distinct())
                {
                    var item = new ReportRoundRobinModel();
                    var ts = totalScores.Where(m => m.Cont == cont);
                    item.Cont = cont;

                    item.Play = ts.Sum(m => m.Play);
                    item.Win = ts.Sum(m => m.Win);
                    item.Lose = ts.Sum(m => m.Lose);
                    item.Tie = ts.Sum(m => m.Tie);
                    item.GA = ts.Sum(m => m.GA);
                    item.GD = ts.Sum(m => m.GD);
                    item.GF = ts.Sum(m => m.GF);

                    item.PT = (item.Win) * int.Parse(ConfigurationManager.AppSettings["ScoreWin"]) + 
                        item.Lose * int.Parse(ConfigurationManager.AppSettings["ScoreLose"]) + 
                        item.Tie * int.Parse(ConfigurationManager.AppSettings["ScoreTie"]);

                    container.Add(item);
                }

                container = container
                    .OrderByDescending(m => m.Play)
                    .ThenByDescending(m => m.PT)
                    .ThenByDescending(m => m.GF)
                    .ThenBy(m => m.GA).ToList();

                var dataSet = new DataSet();

                foreach (var item in container)
                    dt.Rows.Add(item.Cont, item.Play, item.Win, 
                        item.Lose, item.Tie, item.GF, 
                        item.GA, item.GD, item.PT);

                dataSet.Tables.Add(dt);

                var reportSource = LoadInstanceReportSourceFromFile("RoundRobin.trdp");

                AddBasicReportParameters(reportSource);

                reportSource.Parameters.Add("EventName", eventName);
                reportSource.Parameters.Add("MatchGroup", groupName);

                ((Table)((Report)reportSource.ReportDocument).Items.Find("tableResults", true).First()).DataSource = new ObjectDataSource(dataSet, "tableResults");
                                
                return reportSource;
            }
        }

    }
}
