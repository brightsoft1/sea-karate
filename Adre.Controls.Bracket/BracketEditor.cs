using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Adre.Controls.Bracket.Service;
using Adre.SEA.Database;
using Adre.SEA.Reports;
using Newtonsoft.Json;

// NOTICE: BETTER NOT TO CHANGE ANYTHING HERE.
//         BETTER TO CHANGE INDIVIDUAL SERVICE IN Adre.Controls.Bracket.Service->BracketService.cs

namespace Adre.Controls.Bracket
{
    public static class BracketEditor
    {
        public static string StringToHexString(string s)
        {
            byte[] ba = Encoding.Default.GetBytes(s);
            var hexString = BitConverter.ToString(ba);
            return hexString.Replace("-", "");
        }

        public static string SanitizeJson(object obj)
        {
            return StringToHexString(JsonConvert.SerializeObject(obj));
        }

        public static void Open(Guid matchId)
        {
            using (var ctx = new ASEAContext())
            {
                var match = ctx.Matches.First(m => m.Id == matchId);
                var phases = ctx.Phases.OrderBy(p => p.Order).ToList();
                var matchesDetails = BracketService.GetMatchesDetails(ctx, match.Event, match);
                var matchesResults = BracketService.GetMatchesResults(ctx, match.Event, match);
                var eventId = match.Event.Id.ToString();
                var bracketEditorPath = ConfigurationManager.AppSettings["BracketEditorPath"];
                var saveTo = GetBracketSavePath(match.Event.Id);

                var objectToSave = new
                {
                    phases,
                    matches = matchesDetails,
                    results = matchesResults,
                    eventId,
                    saveTo
                };

                try
                {
                    Directory.CreateDirectory("BracketEditorData");
                    File.WriteAllText(Path.Combine("BracketEditorData", "input.json"), JsonConvert.SerializeObject(objectToSave));
                    var process = new Process
                    {
                        StartInfo =
                        {
                            FileName = bracketEditorPath,
                            ErrorDialog = true,
                            WindowStyle = ProcessWindowStyle.Maximized
                        }
                    };
                    process.Start();
                    process.WaitForExit();
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }

        public static string GetBracketSavePath(Guid eventId)
        {
            return Path.Combine("BracketEditorData", $"{ConfigurationManager.AppSettings["AppName"].ToLowerInvariant()}-{eventId}.json");
        }

        public static string GetBracketMedalPath(Guid eventId)
        {
            return GetBracketSavePath(eventId).Replace(".json", "-medal.json");
        }

        public static List<List<BracketExportMedalDto>> GetBracketMedalExportData(Guid eventId)
        {
            var path = GetBracketMedalPath(eventId);
            var data = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<List<BracketExportMedalDto>>>(data);
        }

        public static void OpenReport(Guid matchId)
        {
            using (var ctx = new ASEAContext())
            {
                var match = ctx.Matches.First(m => m.Id == matchId);
                var exportPath = GetBracketSavePath(match.Event.Id).Replace(".json", ".png");
                var exportResultPath = exportPath.Replace(".png", "-medal.png");
                new ReportWindow(ReportManager.GenerateBracket(exportPath, exportResultPath)).ShowDialog();
            }
        }
    }

    public class BracketExportMedalDto
    {
        public Guid AthleteId { get; set; }
        public string AthleteName { get; set; }
        public Guid ContingentId { get; set; }
        public string ContingentName { get; set; }
        public string ContingentGroup { get; set; }
    }
}
