using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adre.SEA.Database;

namespace Adre.Controls.Bracket.Service
{
    public static class BracketService
    {
        public static object GetMatchesDetails(ASEAContext ctx, Event ev, Match match)
        {
            var results = ctx
                .Matches
                .Where(m => m.Event.Id == match.Event.Id)
                .Select(m => new
                {
                    MatchId = m.Id.ToString(),
                    MatchNo = m.MatchNo,
                    SideA = m.MatchAthletes.Where(ma => ma.Side == "A").Select(ma => new
                    {
                        AthleteId = ma.Athlete.Id,
                        AthleteName = ma.Athlete.PreferredName,
                        ContingentId = ma.Athlete.Contingent.Id,
                        ContingentCode = ma.Athlete.Contingent.Code,
                        ContingentName = ma.Athlete.Contingent.Name,
                        ContingentGroup = ma.Group,
                    }),
                    SideB = m.MatchAthletes.Where(ma => ma.Side == "B").Select(ma => new
                    {
                        AthleteId = ma.Athlete.Id,
                        AthleteName = ma.Athlete.PreferredName,
                        ContingentId = ma.Athlete.Contingent.Id,
                        ContingentCode = ma.Athlete.Contingent.Code,
                        ContingentName = ma.Athlete.Contingent.Name,
                        ContingentGroup = ma.Group,
                    }),
                    PhaseId = m.Phase.Id.ToString()
                })
                .ToList();

            return results;
        }

        public static object GetMatchesResults(ASEAContext ctx, Event ev, Match match)
        {
            var results = ctx
                .Matches
                .Where(m => m.Event.Id == match.Event.Id)
                .Select(m => new
                {
                    MatchId = m.Id.ToString(),
                    ScoreA = m.Result.ScoreA,
                    ScoreB = m.Result.ScoreB
                })
                .ToList();

            return results;
        }
    }
}
