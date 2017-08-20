using System;
using System.Data;
using System.Linq;
using Adre.SEA.Database;
using Adre.SEA.Database.SukmaSarawak;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace Adre.SEA.Importer
{
    public class ImportManager
    {
        public delegate void EventChangedHandler(string label, float progress);

        public event EventChangedHandler OnEventChanged;

        int _sportId { get; set; }

        public ImportManager() { }

        public ImportManager(int SportId)
        {
            _sportId = SportId;
        }

        public async Task Execute()
        {
            OnEventChanged?.Invoke("Preparing data...", 0);

            await Task.Run(() =>
            {
                using (ASEAContext ctx = new ASEAContext())
                {
                    using (WSLSSContext ctx2 = new WSLSSContext())
                    {

                        var wslContingents = ctx2.Contingents;
                        var contingents = ctx.Contingents;
                        int i = 0;

                        foreach (var wslContingent in wslContingents)
                        {
                            OnEventChanged?.Invoke($"Importing contingent data.. {i} / {wslContingents.Count()}", i / (float)wslContingents.Count());
                            i++;
                            var newContingent = new Adre.SEA.Database.Contingent
                            {
                                Id = Guid.NewGuid(),
                                WslId = wslContingent.ContingentID,
                                Code = wslContingent.ContingentCode,
                                Name = wslContingent.ContingentName
                            };

                            var existingContingent = contingents.FirstOrDefault(athlete => athlete.WslId == wslContingent.ContingentID);

                            if ((existingContingent != null))
                            {
                                newContingent.Id = existingContingent.Id;
                            }

                            contingents.AddOrUpdate(newContingent);

                        }

                        ctx.SaveChanges();

                        var wslAthletes = ctx2.Athletes.Where(athlete => athlete.SportID == _sportId & athlete.Status == 2);
                        var athletes = ctx.Athletes;

                        i = 0;
                        foreach (var wslAthlete in wslAthletes)
                        {
                            OnEventChanged?.Invoke($"Importing athletes data.. {i} / {wslAthletes.Count()}", i / (float)wslAthletes.Count());
                            i++;
                            var wslContingent = wslAthlete.Contingent;

                            var newAthlete = new Adre.SEA.Database.Athlete
                            {
                                Id = Guid.NewGuid(),
                                WslId = wslAthlete.AthleteID,
                                FullName = wslAthlete.FullName,
                                PreferredName = wslAthlete.PreferredName,
                                DOB = wslAthlete.DOB,
                                Gender = wslAthlete.Gender,
                                Contingent = contingents.First(contingent => contingent.WslId == wslContingent.ContingentID)
                            };

                            var existingAthlete = athletes.FirstOrDefault(athlete => athlete.WslId == wslAthlete.AthleteID);

                            if ((existingAthlete != null))
                            {
                                newAthlete.Id = existingAthlete.Id;
                            }

                            athletes.AddOrUpdate(newAthlete);
                        }

                        ctx.SaveChanges();

                        var wslEvents = ctx2.SportEvents.Where(sportEvent => sportEvent.SportID == _sportId);
                        var events = ctx.Events;

                        i = 0;
                        foreach (var wslEvent in wslEvents)
                        {

                            var aa = ctx2.AthleteEvents.Where(ae => ae.EventID == wslEvent.EventID).Select(ae => ae.AthleteID).ToList();

                            OnEventChanged?.Invoke($"Adding athletes to event.. {i} / {wslEvents.Count()}", i / (float)wslEvents.Count());
                            i++;

                            var newEvent = new Adre.SEA.Database.Event
                            {
                                Id = Guid.NewGuid(),
                                WslId = wslEvent.EventID,
                                Name = wslEvent.EventName.Trim(),
                                Code = wslEvent.EventCode.Trim(),
                                Gender = wslEvent.EventGender.Trim(),
                                Athlete = ctx.Athletes.Where(ath => aa.Contains(ath.WslId)).ToList()
                            };

                            var existingEvent = events.FirstOrDefault(ev => ev.WslId == wslEvent.EventID);

                            if ((existingEvent != null))
                            {
                                newEvent.Id = existingEvent.Id;
                            }

                            events.AddOrUpdate(newEvent);
                        }

                        ctx.SaveChanges();

                    }

                    OnEventChanged?.Invoke($"Import completed", 100f);

                }
            });
        }

        public async Task Clear()
        {
            OnEventChanged?.Invoke("Preparing cleaning", 0);

            await Task.Run(() =>
            {
                using (ASEAContext c = new ASEAContext())
                {
                    OnEventChanged?.Invoke("Cleaning rankings table", 20);
                    c.Rankings.RemoveRange(c.Rankings);
                    c.SaveChanges();

                    OnEventChanged?.Invoke("Cleaning results table", 40);
                    c.Result.RemoveRange(c.Result);
                    c.SaveChanges();
                    
                    OnEventChanged?.Invoke("Cleaning matches table", 60);
                    c.Matches.RemoveRange(c.Matches);
                    c.SaveChanges();

                    OnEventChanged?.Invoke("Cleaning athletes table", 80);
                    c.Athletes.RemoveRange(c.Athletes);
                    c.SaveChanges();

                    OnEventChanged?.Invoke("Cleaning contingent table", 90);
                    c.Contingents.RemoveRange(c.Contingents);
                    c.SaveChanges();

                    OnEventChanged?.Invoke("Cleaning events table", 95);
                    c.Events.RemoveRange(c.Events);
                    c.SaveChanges();

                }
            });
        }
    }
}