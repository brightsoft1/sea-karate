using Adre.SEA.Database;
using System.Collections.ObjectModel;
using Adre.Controls;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity.Migrations;
using Adre.Controls.Bracket;
using System.IO;

namespace Adre.SEA.Service
{
    public class MatchService
    {
        ASEAContext _dbContext;
        Controls.StartList.IDataContext _startListContext;
        Controls.ResultList.IDataContext _resultListContext;

        public MatchService()
        {
            _dbContext = new ASEAContext();
        }

        public void Load()
        {
            _startListContext.Clear();
            _resultListContext.Clear();

            var matches = _dbContext.Matches.OrderBy(m => m.MatchNo);

            foreach (var m in matches)
            {
                var newMatch = _startListContext.NewItem();
                var newMr = _resultListContext.CreateAndAdd(newMatch);

                newMatch.Id = m.Id;
                newMatch.Arena = m.Arena;
                newMatch.DateTimeEnd = m.DateTimeEnd;
                newMatch.DateTimeStart = m.DateTimeStart;
                newMatch.No = m.MatchNo;
                newMatch.Remarks = m.Remarks;
                newMatch.IEventList = new ObservableCollection<IEvent>(_dbContext.Events.OrderBy(x => x.Name));
                newMatch.SelectedEvent = m.Event;
                newMatch.IPhaseList = new ObservableCollection<IPhase>(_dbContext.Phases.OrderBy(x => x.Order));
                newMatch.SelectedPhase = m.Phase;
                newMatch.MatchGroupList = new ObservableCollection<IMatchGroupType>(_dbContext.MatchGroupType.OrderBy(x => x.Order));
                newMatch.SelectedMatchGroup = m.Group;
                newMatch.Venue = m.Venue;
                newMatch.SelectedMatchGroup = m.IGroup;

                var playerA = m.MatchAthletes.Where(x => x.Side == "A");

                if (playerA.Count() > 0)
                {
                    newMatch.SelectedContingentA = playerA.Select(x => x.Athlete.IContingent).First();
                    newMatch.SelectedGroupA = playerA.Select(x => x.Group).First();
                    newMatch.SelectedAthleteA = new ObservableCollection<IAthlete>(playerA.Select(x => x.Athlete));
                    newMatch.AthleteListA = new ObservableCollection<IAthlete>(newMatch.AthleteListA.Except(newMatch.SelectedAthleteA));
                }

                var playerB = m.MatchAthletes.Where(x => x.Side == "B");

                if (playerB.Count() > 0)
                {
                    newMatch.SelectedContingentB = playerB.Select(x => x.Athlete.IContingent).First();
                    newMatch.SelectedGroupB = playerB.Select(x => x.Group).First();
                    newMatch.SelectedAthleteB = new ObservableCollection<IAthlete>(playerB.Select(x => x.Athlete));
                    newMatch.AthleteListB = new ObservableCollection<IAthlete>(newMatch.AthleteListB.Except(newMatch.SelectedAthleteB));
                }

                _startListContext.Items.Add(newMatch);

                if (m.Result != null)
                {
                    var container = new List<Controls.ResultList.IScoreItem>();
                    var r = m.Result;
                    var si = newMr.CreateScoreItem();

                    si.Id = r.Id;
                    si.No = r.No;
                    si.ScoreA = r.ScoreA;
                    si.ScoreB = r.ScoreB;
                    container.Add(si);
                    
                    newMr.IItems = new ObservableCollection<Controls.ResultList.IScoreItem>(container);
                }
            }
        }
        
        public void Add(Controls.StartList.IItemViewModel item)
        {
            item.ReservedEventList = new ObservableCollection<IEvent>(_dbContext.Events);
            item.GenderList = new ObservableCollection<string>(item.ReservedEventList.Select(m => m.Gender).Distinct().OrderBy(m => m));
            item.SelectedGender = item.GenderList.FirstOrDefault();
            item.IPhaseList = new ObservableCollection<IPhase>(_dbContext.Phases.OrderBy(m => m.Order));
            item.MatchGroupList = new ObservableCollection<IMatchGroupType>(_dbContext.MatchGroupType.OrderBy(m => m.Order));

            if (item.MatchGroupList != null)
                item.SelectedMatchGroup = item.MatchGroupList[0];

            item.SelectedGroupA = "";
            item.SelectedGroupB = "";
            _resultListContext.CreateAndAdd(item);
            _startListContext.SelectedItem = item;
        }

        public void Register(Controls.StartList.IDataContext context)
        {
            if (_startListContext == null)
                _startListContext = context;
        }

        public void Register(Controls.ResultList.IDataContext context)
        {
            if (_resultListContext == null)
            {
                _resultListContext = context;
                Load();
            }
        }

        public void SaveMatch()
        {
            if (_startListContext.SelectedItem == null) return;
            var item = _startListContext.SelectedItem;

            var match = _dbContext.Matches.Find(item.Id);
            if (match == null)
            {
                match = new Match();
                match.Id = item.Id;
                var result = new Result();
                result.Id = Guid.NewGuid();
                result.Match = match;
                result.No = 1;
                result.Remarks = item.Remarks;
                _dbContext.Result.AddOrUpdate(result);
            }

            match.Arena = item.Arena;
            match.DateTimeEnd = item.DateTimeEnd;
            match.DateTimeStart = item.DateTimeStart;
            match.Event = (Event)item.SelectedEvent;
            match.MatchNo = item.No;
            match.Remarks = item.Remarks;
            match.Phase = (Phase)item.SelectedPhase;
            match.Venue = item.Venue;
            match.IGroup = item.SelectedMatchGroup;
            _dbContext.Matches.AddOrUpdate(match);

            var mas = _dbContext.MatchAthlete.Where(m => m.Match.Id == match.Id);
            _dbContext.MatchAthlete.RemoveRange(mas);

            foreach (var a in item.SelectedAthleteA)
            {
                var ma = new MatchAthlete();
                ma.Athlete = (Athlete)a;
                ma.Match = match;
                ma.Side = "A";
                ma.Group = item.SelectedGroupA;
                _dbContext.MatchAthlete.Add(ma);
            }

            foreach (var a in item.SelectedAthleteB)
            {
                var ma = new MatchAthlete();
                ma.Athlete = (Athlete)a;
                ma.Match = match;
                ma.Side = "B";
                ma.Group = item.SelectedGroupB;
                _dbContext.MatchAthlete.Add(ma);
            }

            _dbContext.SaveChanges();
        }

        public void SaveResult()
        {
            if (_resultListContext.SelectedItem == null) return;

            var items = _resultListContext.SelectedItem.IItems;
            var match = _dbContext.Matches.Find(_resultListContext.SelectedItem.StartListItem.Id);

            if (match == null) return;
            
            foreach (var item in items)
            {
                var result = (match.Result == null) ? new Result() : match.Result;
                result.Match = match;
                result.Match.DateTimeEnd = _resultListContext.SelectedItem.StartListItem.DateTimeEnd;
                result.No = item.No;
                result.ScoreA = item.ScoreA;
                result.ScoreB = item.ScoreB;
                _dbContext.Result.AddOrUpdate(result);
            }

            _dbContext.SaveChanges();
        }

        public void Remove(Controls.StartList.IItemViewModel item)
        {
            using (var d = new ASEAContext())
            {
                var match = d.Matches.Find(item.Id);

                if (match != null)
                {
                    d.Result.RemoveRange(d.Result.Where(m => m.Match.Id == match.Id));

                    if (match.Event != null)
                        d.Rankings.RemoveRange(d.Rankings.Where(m => m.Event.Id == match.Event.Id));

                    d.MatchAthlete.RemoveRange(match.MatchAthletes);
                    d.Matches.Remove(match);
                    d.SaveChanges();

                    try
                    {
                        var saveFile = BracketEditor.GetBracketSavePath(item.SelectedEvent.Id);
                        File.Delete(saveFile);
                        File.Delete(saveFile.Replace(".json", ".png"));

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            var results = _resultListContext.Items.Where(m => m.StartListItem.Id == item.Id).ToList();

            foreach (var r in results) _resultListContext.Items.Remove(r);

            _resultListContext.Items = _resultListContext.Items;
        }

        public void Refresh()
        {
            _dbContext.Dispose();
            _dbContext = new ASEAContext();

            var startItem = _startListContext.SelectedItem;
            var resultItem = _resultListContext.SelectedItem;

            Load();

            _startListContext.SelectedItem = _startListContext.Items.Where(m => m.Id == startItem?.Id).FirstOrDefault();
            _resultListContext.SelectedItem = _resultListContext.Items.Where(m => m.StartListItem.Id == resultItem?.StartListItem.Id).FirstOrDefault();
            
        }
    }
}
