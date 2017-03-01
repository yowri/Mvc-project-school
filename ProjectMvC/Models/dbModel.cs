using ProjectMvC.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProjectMvC.Models
{
    public class dbModel
    {
        public spelerModel f1 = new spelerModel();

        public List<SerializedModelSpeler> smsList = new List<SerializedModelSpeler>();

        public dbModel() { }

        public void makeModel(){

            foreach (var speler in f1.Spelers.ToList())
            {
                SerializedModelSpeler sms = new SerializedModelSpeler();

                sms.Id = speler.Id;
                sms.naam = speler.naam;
                sms.score = speler.score;
                sms.platform = speler.platform;
                sms.flag = speler.flag;

                smsList.Add(sms);
            }            
        }

        public void addSpeler(string naam, string vlag, int score, string platform)
        {
            Speler speler = new Speler();

            speler.naam = naam;
            speler.flag = vlag;
            speler.score = score;
            speler.platform = platform;
            
            f1.Spelers.Add(speler);

            f1.SaveChanges();
        }

        public void addSpelerStats(int spelerId,float goalsPerGame, float goalsAgainstPerGame, float goalRatio, string favTeam, string scoredMostWith, string mostHatedPlayer, string mostPlayedAgainst, int seasonsPlayed, int seasonsPlayedCurrent, int highestDivision, int relegations)
        {
            StatsTeam ts = new StatsTeam();

            ts.speler_id = spelerId;
            ts.goals_per_game = goalsPerGame;
            ts.goals_against_per_game = goalsAgainstPerGame;
            ts.goal_ratio = goalRatio;
            ts.favorit_team = favTeam;
            ts.scored_most_with = scoredMostWith;
            ts.most_played_against = mostPlayedAgainst;
            ts.seasons_played = seasonsPlayed;
            ts.seasons_played_current_division = seasonsPlayedCurrent;
            ts.highest_division = highestDivision;
            ts.relegations = relegations;
  
            f1.StatsTeams.Add(ts);

            f1.SaveChanges();
        }
        public void addStatsTeamExtendeds(int spelerId, int division, int WinsTeam, int LosesTeam, int DrawsTeam, int points)
        {
            StatsTeamExtended ste = new StatsTeamExtended();

            ste.spelerId = spelerId;
            // stats season moet eigenlijk division heten
            ste.SeasonTeam = division;
            ste.WinsTeam = WinsTeam;
            ste.LosesTeam = LosesTeam;
            ste.DrawsTeam = DrawsTeam;
            ste.points = points;

            f1.StatsTeamExtendeds.Add(ste);

            f1.SaveChanges();
        }

        public static class JavaScriptConvert
        {
            public static IHtmlString SerializeObject(object value)
            {
                using (var stringWriter = new StringWriter())
                using (var jsonWriter = new JsonTextWriter(stringWriter))
                {
                    var serializer = new JsonSerializer
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    };

                    jsonWriter.QuoteName = false;
                    serializer.Serialize(jsonWriter, value);

                    return new HtmlString(stringWriter.ToString());
                }
            }

        }





    }
}