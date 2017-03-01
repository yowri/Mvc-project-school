using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectMvC.DataModels;
using ProjectMvC.Models;

namespace ProjectMvC.Controllers
{
    public class PlayerController : Controller
    {
        dbModel model = new dbModel();

        public ActionResult Stats(string speler, int id)
        {
            ViewBag.speler = speler;

            var newModel = model.f1.StatsTeams.ToList().Where(x => x.speler_id == id);

            return View(newModel);
        }
        [HttpGet]
        public ActionResult About()
        {
            var newModel = model.f1.Spelers.ToList();

            return View(newModel);
        }
        [HttpGet]
        public ActionResult leaderBoard(string platform)
        {
            if (Session["platformKey"] == null)
            {
                platform = "ps4";
            }
            else
            {
                platform = Session["platformKey"].ToString();
            }

            var newModel =  model.f1.Spelers.ToList().OrderByDescending(s => s.score).Where(w => w.platform == platform);

            return PartialView("leaderboardPartial",newModel);
        }

    //    public ActionResult runThis()
    //    {
    //        //spelers toevoegen
    //        Random rand = new Random();

    //        //int randomScore, randomFlag;

    //        //string spelerNaam;

    //        //string[] flags = { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Anguilla", "Antarctica", "Argentina", "Armenia", "ASEAN", "Australia", "Mongolia", "Montenegro", "Montserrat", "Netherlands", "Mexico", "Nigeria", "Scotland", "Suriname", "Turkey", "Ukraine", "Wales" };

    //        //string[] platforms = { "ps4", "ps3", "one", "360", "pc" };

    //        //int platformsNr = 0;

    //        //for (var i = 0; i < 500; i++)
    //        //{
    //        //    platformsNr++;

    //        //    if (platforms.Length == platformsNr)
    //        //    {
    //        //        platformsNr = 0;
    //        //    }

    //        //    randomScore = rand.Next(1200, 2501);

    //        //    randomFlag = rand.Next(0, 22);

    //        //    spelerNaam = "speler" + i;

    //        //    model.addSpeler(spelerNaam, flags[randomFlag], randomScore, platforms[platformsNr]);

    //        //}

    //         //teams toevoegen

    //        //float goals;
    //        //string[] Teams = {"Bayern Munchen","FC Barcelona","Real madrid","Manchester United","Tottenham hotspur", "Liverpool", "Borussia dortmunt", "Ajax", "Psv", "De graafschap"};
    //        //string[] Players = { "Messi", "Ronaldo", "Robben", "Suarez", "Benzema", "Bale", "Neymar", "Milik", "Fischer", "Klaassen", "Lewandowski", "Hazard", "Rooney"};
    //        //int seasonsPlayed, seasonsPlayedCurrentDivision, highestDivision, relegations,randomTeam,randomPlayer,division;

    //        //foreach (var item in model.namen)
    //        //{
    //        //    goals = rand.Next(2, 6);
    //        //    Math.Round(goals,1);

    //        //    randomTeam = rand.Next(0,Teams.Length);
    //        //    randomPlayer = rand.Next(0,Players.Length);

    //        //    seasonsPlayed = rand.Next(2, 40);
    //        //    seasonsPlayedCurrentDivision = rand.Next(1,10);
    //        //    highestDivision = rand.Next(1, 10);
    //        //    relegations = rand.Next(1,15);
    //        //    division = rand.Next(1,10);

    //        //    model.addSpelerStats(item.Id, goals, goals, goals, Teams[randomTeam], Players[randomPlayer], Players[randomPlayer], Teams[randomTeam], seasonsPlayed, seasonsPlayedCurrentDivision, highestDivision, relegations);

    //        //}

    //        //punten

    //        int division, wins, loses, draws, points;



    //        var newModel = model.f1.Spelers.ToList();

    //        foreach (var item in newModel)
    //        {
    //            division = rand.Next(1, 10);
    //            points = rand.Next(0, 20);
    //            wins = rand.Next(100, 300);
    //            loses = rand.Next(100, 300);
    //            draws = rand.Next(100, 300);

    //            model.addStatsTeamExtendeds(item.Id, division, wins, loses, draws,points);
    //        }

    //        return Json("Success");
    //    }


    }
}
