using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adre.SEA.Database;
using Telerik.Reporting;

namespace Adre.SEA.Reports
{
    public static partial class ReportManager
    {
        public static InstanceReportSource GenerateStartListOverall(Guid matchId)
        {
            using (var ctx = new ASEAContext())
            {
                var @match = ctx.Matches.FirstOrDefault(m => m.Id == matchId);
                var @event = @match?.Event;

                var reportSource = LoadInstanceReportSourceFromFile("StartList.Overall.trdp");

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
                    var athletesA = matchOnSameEvent.MatchAthletes.Where(ma => ma.Side == "A").Select(ma => ma.Athlete).OrderBy(a => a.PreferredName);
                    var athletesB = matchOnSameEvent.MatchAthletes.Where(ma => ma.Side == "B").Select(ma => ma.Athlete).OrderBy(a => a.PreferredName);

                    var athleteContingentA = athletesA.FirstOrDefault()?.Contingent.Code ?? "BYE";
                    var athleteContingentB = athletesB.FirstOrDefault()?.Contingent.Code ?? "BYE";

                    var athleteNamesA = string.Join("\r\n", athletesA.Select(a => a.PreferredName));
                    var athleteNamesB = string.Join("\r\n", athletesB.Select(a => a.PreferredName));

                    data.Add(new {
                        Date = matchOnSameEvent.DateTimeStart.ToString("dd/MM/yy"),
                        Time = matchOnSameEvent.DateTimeStart.ToString("HH:mm"),
                        Venue = matchOnSameEvent.Venue,
                        Group = matchOnSameEvent.Group.Name,
                        No = matchOnSameEvent.MatchNo,
                        ContA = athleteContingentA,
                        NameA = athleteNamesA,
                        ContB = athleteContingentB,
                        NameB = athleteNamesB,
                        Arena = matchOnSameEvent.Arena
                    });
                }

                var dataSet = GenerateDataSetFromDynamicObject(data);

                SetReportTableDataSource(reportSource, "tableStartList", new ObjectDataSource { DataSource = dataSet });

                return reportSource;
            }
        }

        public static InstanceReportSource GenerateStartListDetail(Guid matchId)
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

                var reportSource = LoadInstanceReportSourceFromFile("StartList.Detail.trdp");

                AddBasicReportParameters(reportSource);
                AddReportParameters(reportSource, new
                {
                    EventName = @event?.Name ?? "N/A",
                    MatchPhase = @match?.Phase?.Name ?? "N/A",
                    MatchVenue = @match?.Venue ?? "N/A",
                    MatchRemark = @match?.Remarks ?? "N/A",
                    MatchStart = @match?.DateTimeStart.ToString("hh:mm tt") ?? "N/A",
                    MatchEnd = @match?.DateTimeEnd?.ToString("hh:mm tt") ?? "N/A",
                    MatchNo = @match?.MatchNo.ToString() ?? "N/A",
                    MatchDate = @match?.DateTimeStart.ToString("dd/MM/yyyy"),
                    MatchGroup = @match?.Group?.Name ?? "N/A",
                });

                var data = new List<dynamic>
                {
                    new
                    {
                        ContingentA = @contingentA,
                        ContingentB = @contingentB,
                        PlayersA = @athletesA,
                        PlayersB = @athletesB
                    }
                };

                var dataSet = GenerateDataSetFromDynamicObject(data);

                SetReportTableDataSource(reportSource, "tablePlayers", new ObjectDataSource { DataSource = dataSet });

                return reportSource;
            }
        }
    }
}
