using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adre.SEA.Database;
using Telerik.Reporting;

namespace Adre.SEA.Reports
{
    public static partial class ReportManager
    {
        public static InstanceReportSource GenerateResultListOverall(Guid matchId)
        {
            using (var ctx = new ASEAContext())
            {
                var @match = ctx.Matches.FirstOrDefault(m => m.Id == matchId);
                var @event = @match?.Event;

                var reportSource = LoadInstanceReportSourceFromFile("ResultList.Overall.trdp");

                AddBasicReportParameters(reportSource);
                AddReportParameters(reportSource, new
                {
                    EventName = @event?.Name ?? "N/A",
                    MatchPhase = @match?.Phase?.Name ?? "N/A",
                    MatchVenue = @match?.Venue ?? "N/A",
                    MatchRemark = @match?.Remarks ?? "N/A",
                    MatchDate = @match?.DateTimeStart.ToString("dd/MM/yyyy") ?? "N/A",
                    MatchStart = @match?.DateTimeStart.ToString("hh:mm tt") ?? "N/A"
                });

                var data = new List<dynamic>();

                var matchesOnSameEvent = ctx.Matches.Where(m => m.Event.Id == @event.Id).OrderBy(m => m.MatchNo);

                foreach (var matchOnSameEvent in matchesOnSameEvent)
                {
                    var results = matchOnSameEvent.Result;

                    var athletesA = matchOnSameEvent.MatchAthletes.Where(ma => ma.Side == "A").Select(ma => ma.Athlete).OrderBy(a => a.PreferredName);
                    var athletesB = matchOnSameEvent.MatchAthletes.Where(ma => ma.Side == "B").Select(ma => ma.Athlete).OrderBy(a => a.PreferredName);

                    var athleteContingentA = athletesA.FirstOrDefault()?.Contingent.Code ?? "BYE";
                    var athleteContingentB = athletesB.FirstOrDefault()?.Contingent.Code ?? "BYE";

                    var athleteNamesA = string.Join("\r\n", athletesA.Select(a => a.PreferredName));
                    var athleteNamesB = string.Join("\r\n", athletesB.Select(a => a.PreferredName));

                    var totalScoreA = results.ScoreA;
                    var totalScoreB = results.ScoreB;

                    var winA = totalScoreA > totalScoreB ? "a" : "";
                    var winB = totalScoreB > totalScoreA ? "a" : "";

                    var duration = matchOnSameEvent.DateTimeEnd - matchOnSameEvent.DateTimeStart;

                    data.Add(new
                    {
                        Date = matchOnSameEvent.DateTimeStart.ToString("dd/MM/yy"),
                        Time = matchOnSameEvent.DateTimeStart.ToString("HH:mm"),
                        Venue = matchOnSameEvent.Venue,
                        Group = matchOnSameEvent.Group.Name,
                        No = matchOnSameEvent.MatchNo,
                        ContA = athleteContingentA,
                        NameA = athleteNamesA,
                        ContB = athleteContingentB,
                        NameB = athleteNamesB,
                        ScoreA = totalScoreA,
                        ScoreB = totalScoreB,
                        WinA = winA,
                        WinB = winB,
                        Duration = duration?.ToString(@"hh\:mm\:ss") ?? "N/A",
                        Arena = matchOnSameEvent.Arena,
                        Rmk = matchOnSameEvent.Result.Remarks
                    });
                }

                var dataSet = GenerateDataSetFromDynamicObject(data);

                SetReportTableDataSource(reportSource, "tableResultList", new ObjectDataSource { DataSource = dataSet });

                return reportSource;
            }
        }

        public static InstanceReportSource GenerateResultListDetail(Guid matchId)
        {
            using (var ctx = new ASEAContext())
            {
                var @match = ctx.Matches.FirstOrDefault(m => m.Id == matchId);
                var @event = @match?.Event;
                var @contingentA = @match?.MatchAthletes.FirstOrDefault(m => m.Side == "A")?.Athlete?.Contingent?.Name +
                                   (!string.IsNullOrEmpty(@match?.MatchAthletes.FirstOrDefault(m => m.Side == "A")?.Group) ? " " + (@match?.MatchAthletes.FirstOrDefault(m => m.Side == "A")?.Group) : "") ?? "N/A";
                var @contingentB = @match?.MatchAthletes.FirstOrDefault(m => m.Side == "B")?.Athlete?.Contingent?.Name +
                                   (!string.IsNullOrEmpty(@match?.MatchAthletes.FirstOrDefault(m => m.Side == "B")?.Group) ? " " + (@match?.MatchAthletes.FirstOrDefault(m => m.Side == "B")?.Group) : "") ?? "N/A";
                var @athletesA = string.Join("\r\n", @match?.MatchAthletes.Where(m => m.Side == "A").Select(m => m.Athlete.PreferredName) ?? new List<string>());
                var @athletesB = string.Join("\r\n", @match?.MatchAthletes.Where(m => m.Side == "B").Select(m => m.Athlete.PreferredName) ?? new List<string>());

                var eventName = @event?.Name ?? "N/A";
                var matchPhase = @match?.Phase?.Name ?? "N/A";
                var matchVenue = @match?.Venue ?? "N/A";
                var matchRemark = @match?.Remarks ?? "N/A";
                var matchStart = @match?.DateTimeStart.ToString("hh:mm tt") ?? "N/A";
                var matchEnd = @match?.DateTimeEnd?.ToString("hh:mm tt") ?? "N/A";
                var matchNo = @match?.MatchNo.ToString() ?? "N/A";
                var matchDate = @match?.DateTimeStart.ToString("dd/MM/yyyy");
                var matchGroup = @match?.Group.Name;

                var totalScoreA = match.Result.ScoreA;
                var totalScoreB = match.Result.ScoreB;
                var teamWin = "";
                var teamLose = "";

                var reportSource = LoadInstanceReportSourceFromFile("ResultList.Detail.trdp");

                AddBasicReportParameters(reportSource);

                reportSource.Parameters.Add("EventName", eventName);
                reportSource.Parameters.Add("MatchPhase", matchPhase);
                reportSource.Parameters.Add("MatchVenue", matchVenue);
                reportSource.Parameters.Add("MatchRemark", matchRemark);
                reportSource.Parameters.Add("MatchStart", matchStart);
                reportSource.Parameters.Add("MatchEnd", matchEnd);
                reportSource.Parameters.Add("MatchNo", matchNo);
                reportSource.Parameters.Add("MatchGroup", matchGroup);
                reportSource.Parameters.Add("MatchDate", matchDate);

                var dataSet = new DataSet();

                var dataTable = new DataTable("tablePlayers");

                dataTable.Columns.Add("ContingentA");
                dataTable.Columns.Add("ContingentB");
                dataTable.Columns.Add("PlayersA");
                dataTable.Columns.Add("PlayersB");

                dataTable.Rows.Add(
                    @contingentA,
                    @contingentB,
                    @athletesA,
                    @athletesB
                );

                dataSet.Tables.Add(dataTable);

                dataTable = new DataTable("tableScores");

                dataTable.Columns.Add("FrameNo");
                dataTable.Columns.Add("ScoreA");
                dataTable.Columns.Add("ScoreB");

                if (match != null && match.Result != null)
                {

                    dataTable.Rows.Add(
                        match.Result.No,
                        match.Result.ScoreA,
                        match.Result.ScoreB
                    );
                }            

                dataSet.Tables.Add(dataTable);

                dataTable = new DataTable("tableFinalResult");

                dataTable.Columns.Add("TeamWin");
                dataTable.Columns.Add("TeamLose");

                teamWin = totalScoreA > totalScoreB ? contingentA : contingentB;
                teamLose = totalScoreB > totalScoreA ? contingentA : contingentB;

                dataTable.Rows.Add(
                    teamWin,
                    teamLose
                );

                dataSet.Tables.Add(dataTable);

                ((Table)((Report)reportSource.ReportDocument).Items.Find("tablePlayers", true).First()).DataSource = new ObjectDataSource(dataSet, "tablePlayers");
                ((Table)((Report)reportSource.ReportDocument).Items.Find("tableScores", true).First()).DataSource = new ObjectDataSource(dataSet, "tableScores");
                ((Table)((Report)reportSource.ReportDocument).Items.Find("tableFinalResult", true).First()).DataSource = new ObjectDataSource(dataSet, "tableFinalResult");
                SetTextBoxValue(reportSource, "FinalResultA", totalScoreA.ToString());
                SetTextBoxValue(reportSource, "FinalResultB", totalScoreB.ToString());
                return reportSource;
            }
        }

        public static InstanceReportSource GenerateResultListDetailTeam(Guid matchId)
        {
            using (var ctx = new ASEAContext())
            {
                var @match = ctx.Matches.FirstOrDefault(m => m.Id == matchId);
                var @event = @match?.Event;
                var @result = ctx.Result?.FirstOrDefault(m => m.Match.Id == match.Id);
                var @contingentA = @match?.MatchAthletes.FirstOrDefault(m => m.Side == "A")?.Athlete?.Contingent?.Name +
                                   (!String.IsNullOrEmpty(@match?.MatchAthletes.FirstOrDefault(m => m.Side == "A")?.Group) ? " " + (@match?.MatchAthletes.FirstOrDefault(m => m.Side == "A")?.Group) : "") ?? "N/A";
                var @contingentB = @match?.MatchAthletes.FirstOrDefault(m => m.Side == "B")?.Athlete?.Contingent?.Name +
                                   (!String.IsNullOrEmpty(@match?.MatchAthletes.FirstOrDefault(m => m.Side == "B")?.Group) ? " " + (@match?.MatchAthletes.FirstOrDefault(m => m.Side == "B")?.Group) : "") ?? "N/A";
                var @athletesA = string.Join("\r\n", @match?.MatchAthletes.Where(m => m.Side == "A").Select(m => m.Athlete.PreferredName) ?? new List<string>());
                var @athletesB = string.Join("\r\n", @match?.MatchAthletes.Where(m => m.Side == "B").Select(m => m.Athlete.PreferredName) ?? new List<string>());

                var eventName = @event?.Name ?? "N/A";
                var matchPhase = @match?.Phase?.Name ?? "N/A";
                var matchVenue = @match?.Venue ?? "N/A";
                var matchRemark = @match?.Remarks ?? "N/A";
                var matchStart = @match?.DateTimeStart.ToString("hh:mm tt") ?? "N/A";
                var matchEnd = @match?.DateTimeEnd?.ToString("hh:mm tt") ?? "N/A";
                var matchNo = @match?.MatchNo.ToString() ?? "N/A";
                var matchDate = @match?.DateTimeStart.ToString("dd/MM/yyyy");
                var matchGroup = @match?.Group.Name;
                var scoreA = @result.ScoreA;
                var scoreB = @result.ScoreB;

                var teamWin = "";
                var teamLose = "";

                if (scoreA > scoreB)
                {
                    teamWin = @contingentA;
                    teamLose = @contingentB;
                }
                else
                {
                    teamWin = @contingentB;
                    teamLose = @contingentA;
                }

                var reportSource = LoadInstanceReportSourceFromFile("ResultList.Detail.Team.trdp");

                AddBasicReportParameters(reportSource);
                reportSource.Parameters.Add("EventName", eventName);
                reportSource.Parameters.Add("MatchPhase", matchPhase);
                reportSource.Parameters.Add("MatchVenue", matchVenue);
                reportSource.Parameters.Add("MatchRemark", matchRemark);
                reportSource.Parameters.Add("MatchStart", matchStart);
                reportSource.Parameters.Add("MatchEnd", matchEnd);
                reportSource.Parameters.Add("MatchNo", matchNo);
                reportSource.Parameters.Add("ContingentA", contingentA);
                reportSource.Parameters.Add("ContingentB", contingentB);
                reportSource.Parameters.Add("MatchGroup", matchGroup);
                reportSource.Parameters.Add("MatchDate", matchDate);

                var dataTable = new DataTable();

                dataTable.Columns.Add("ContingentA");
                dataTable.Columns.Add("ContingentB");
                dataTable.Columns.Add("PlayersA");
                dataTable.Columns.Add("PlayersB");
                dataTable.Columns.Add("Reserve1A");
                dataTable.Columns.Add("Reserve2A");
                dataTable.Columns.Add("Reserve1B");
                dataTable.Columns.Add("Reserve2B");
                dataTable.Columns.Add("Point1A");
                dataTable.Columns.Add("Point2A");
                dataTable.Columns.Add("Point3A");
                dataTable.Columns.Add("Point1B");
                dataTable.Columns.Add("Point2B");
                dataTable.Columns.Add("Point3B");
                dataTable.Columns.Add("ScoreA");
                dataTable.Columns.Add("ScoreB");
                dataTable.Columns.Add("TeamWin");
                dataTable.Columns.Add("TeamLose");
                dataTable.Columns.Add("RoundDifference");
                dataTable.Columns.Add("TotalPointDifference");
                dataTable.Columns.Add("GameDuration");

                dataTable.Rows.Add(
                    @contingentA,
                    @contingentB,
                    @athletesA,
                    @athletesB,
                    @scoreA,
                    @scoreB,
                    teamWin,
                    teamLose,
                    $"{scoreA} : {scoreB}",
                    scoreA - scoreB
                );

                var dataSet = new DataSet();

                dataSet.Tables.Add(dataTable);
                var objectDataSource = new ObjectDataSource { DataSource = dataSet };

                return reportSource;
            }

        }
    }
}
