using Adre.SEA.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using Adre.Controls.RankingList;
using System.Data.Entity.Migrations;
using System.Configuration;

namespace Adre.SEA.Service
{
    public class RankService
    {
        ASEAContext _dbContext;
        IDataContext _rankContext;
        
        public RankService() { _dbContext = new ASEAContext(); }

        public void Register(IDataContext context) { _rankContext = context; }

        public void Load()
        {
            var matches = _dbContext.Matches;
            var results = matches.Where(m => m.DateTimeEnd.HasValue).Select(m => m.Result);
            var contingents = _dbContext.MatchAthlete.Where(m => matches.Contains(m.Match)).Select(m => new { m.Group, m.Athlete.Contingent.Code }).Distinct();

            var totalScores = new List<IItemViewModel>();

            //Normalize
            foreach (var result  in results)
            {
                var rA = _rankContext.Create();
                var rB = _rankContext.Create();
                var resultA = result.ScoreA;
                var resultB = result.ScoreB;

                rA.Event = rB.Event = result.Match.Event;
                var athleteA = result?.Match.MatchAthletes?.Where(m => m.Side == "A").FirstOrDefault();
                var athleteB = result?.Match.MatchAthletes?.Where(m => m.Side == "B").FirstOrDefault();
                rA.Contingent = athleteA?.Athlete?.IContingent;
                rB.Contingent = athleteB?.Athlete?.IContingent;

                rA.Group = athleteA.Match.Group.Name;
                rB.Group = athleteB.Match.Group.Name;

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

            var container = new List<IItemViewModel>();

            //Aggregate
            foreach (var evnt in totalScores.Select(m => new { m.Event, m.Group }).Distinct())
                foreach (var cont in totalScores.Where(m => m.Event == evnt.Event && m.Group == evnt.Group).Select(m => m.Contingent).Distinct())
                {
                    var item = _rankContext.Create();
                    var ts = totalScores.Where(m => m.Contingent.Id == cont.Id);
                    item.Contingent = cont;

                    item.Play = ts.Sum(m => m.Play);
                    item.Win = ts.Sum(m => m.Win);
                    item.Lose = ts.Sum(m => m.Lose);
                    item.GA = ts.Sum(m => m.GA);
                    item.GD = ts.Sum(m => m.GD);
                    item.GF = ts.Sum(m => m.GF);
                    item.Tie = ts.Sum(m => m.Tie);
                    item.Event = evnt.Event;
                    item.Group = evnt.Group;
                    item.Point = (item.Win) * int.Parse(ConfigurationManager.AppSettings["ScoreWin"]) +
                        item.Tie * int.Parse(ConfigurationManager.AppSettings["ScoreTie"]) +
                        item.Lose * int.Parse(ConfigurationManager.AppSettings["ScoreLose"]);

                    var dbData = _dbContext.Rankings.Where(x => x.Event.Id == evnt.Event.Id &&
                                x.Contingent.Id == cont.Id).FirstOrDefault();

                    if (dbData != null)
                    {
                        item.No = dbData.Order;
                        item.SelectedMedal = dbData.Medal;
                    }
                    container.Add(item);
                }

            container = container
                .OrderByDescending(m => m.Play)
                .ThenByDescending(m => m.Point)
                .ThenByDescending(m => m.GF)
                .ThenBy(m => m.GA).ToList();

            _rankContext.Items = new System.Collections.ObjectModel.ObservableCollection<IItemViewModel>(container);

        }

        public void Save()
        {
            foreach (var i in _rankContext.Items)
            {
                var ranking = _dbContext.Rankings.Where(x => x.Contingent.Id == i.Contingent.Id &&
                    i.Event.Id == x.Event.Id &&
                    i.Group == x.Group).FirstOrDefault();

                if (ranking == null)
                {
                    ranking = new Ranking();
                    ranking.Id = Guid.NewGuid();
                }

                ranking.Event = (Event)i.Event;
                ranking.Contingent = (Contingent)i.Contingent;
                ranking.Point = i.Point;
                ranking.Group = i.Group;
                ranking.Order = i.No;
                ranking.Medal = i.SelectedMedal;
                _dbContext.Rankings.AddOrUpdate(ranking);
            }

            _dbContext.SaveChanges();
        }

        public void Refresh()
        {
            _dbContext.Dispose();
            _dbContext = new ASEAContext();
            Load();
        }
    }
}
