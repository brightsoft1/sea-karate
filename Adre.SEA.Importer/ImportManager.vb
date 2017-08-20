Imports System.Data.Entity.Migrations
Imports Adre.SEA.Database
Imports Adre.SEA.Database.SukmaSarawak

Public Module ImportManager
    Public Sub Import()
        using ctx As New ASEAContext
            using ctx2 As New WSLSSContext

                Dim wslContingents = ctx2.Contingents
                Dim contingents = ctx.Contingents

                For Each wslContingent In wslContingents
                    Dim newContingent = New Database.Contingent With {
                        .Id = Guid.NewGuid(),
                        .WslId = wslContingent.ContingentID,
                        .Code = wslContingent.ContingentCode,
                        .Name = wslContingent.ContingentName
                    }

                    Dim existingContingent = contingents.FirstOrDefault(function(athlete) athlete.WslId = wslContingent.ContingentID)

                    If Not existingContingent Is Nothing
                        newContingent.Id = existingContingent.Id
                    End If

                    contingents.AddOrUpdate(function(contingent) contingent.WslId, newContingent)
                Next

                ctx.SaveChanges()

                Dim wslEvents = ctx2.SportEvents.Where(function(sportEvent) sportEvent.SportID = 14)
                Dim events = ctx.Events

                For Each wslEvent In wslEvents
                    Dim newEvent = New Database.Event With {
                        .Id = Guid.NewGuid(),
                        .WslId = wslEvent.EventID,
                        .Name = wslEvent.EventName,
                        .Code = wslEvent.EventCode,
                        .Gender = wslEvent.EventGender
                    }

                    Dim existingEvent = events.FirstOrDefault(Function(ev) ev.WslId = wslEvent.EventID)

                    If Not existingEvent Is Nothing
                        newEvent.Id = existingEvent.Id
                    End If

                    events.AddOrUpdate(Function([event]) [event].WslId, newEvent)
                Next

                ctx.SaveChanges()

                Dim wslAthletes = ctx2.Athletes.Where(function(athlete) athlete.SportID = 14 And athlete.Status = 2)
                Dim athletes = ctx.Athletes

                For Each wslAthlete in wslAthletes
                    Dim wslContingent = wslAthlete.Contingent

                    Dim newAthlete = New Database.Athlete With {
                        .Id = Guid.NewGuid(),
                        .WslId = wslAthlete.AthleteID,
                        .FullName = wslAthlete.FullName,
                        .PreferredName = wslAthlete.PreferredName,
                        .Gender = wslAthlete.Gender,
                        .Contingent = contingents.First(Function(contingent) contingent.WslId = wslContingent.ContingentID)
                    }

                    Dim existingAthlete = athletes.FirstOrDefault(function(athlete) athlete.WslId = wslAthlete.AthleteID)

                    If Not existingAthlete Is Nothing
                        newAthlete.Id = existingAthlete.Id
                    End If

                    athletes.AddOrUpdate(Function(athlete) athlete.WslId, newAthlete)
                Next

                ctx.SaveChanges()

                Dim wslAthleteIds = wslAthletes.Select(Function(athlete) athlete.AthleteID)
                Dim wslAthleteEvents = ctx2.AthleteEvents.Where(Function(athleteEvent) wslAthleteIds.Contains(athleteEvent.AthleteID))
                'Dim eventAthletes = ctx.EventAthlete

                'For Each wslAthleteEvent In wslAthleteEvents
                '    Dim athlete = athletes.FirstOrDefault(Function(a) a.WslId = wslAthleteEvent.AthleteID)
                '    Dim [event] = events.FirstOrDefault(Function(e) e.WslId = wslAthleteEvent.EventID)

                '    If athlete Is nothing Or [event] Is Nothing
                '        Continue For
                '    End If

                '    Dim newEventAthlete = New Database.EventAthlete With {
                '        .Id = Guid.NewGuid(),
                '        .Athlete = athlete,
                '        .Event = [event]
                '    }

                '    Dim existingEventAthlete = eventAthletes.FirstOrDefault(Function(eventAthlete) eventAthlete.Athlete.Id = athlete.Id And eventAthlete.Event.Id = [event].Id)

                '    If existingEventAthlete Is nothing
                '        eventAthletes.Add(newEventAthlete)
                '    End If
                'Next

                ctx.SaveChanges()
            End Using
        End Using

        MessageBox.Show("All data has been successfully imported.")
    End Sub
End Module
