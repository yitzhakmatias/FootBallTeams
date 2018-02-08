using System;
using System.Collections.Generic;
using System.Linq;
using BL.Services.IoC;
using BL.Services.Repositories;
using DL.DataContext.Model;
using Microsoft.AspNetCore.Mvc;

namespace FootBallWebCoreApp.Controllers
{
    
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<dynamic> GetTeams()
        {
            var teams = IoCContainerHelper.Resolve<ITeamRepository>();
            var data = teams.GetAll().ToList();

            var objectList = new List<Object>();
            foreach (var item in data)
            {
                dynamic obj = new System.Dynamic.ExpandoObject();
                obj.name = item.Name;
                obj.score = item.Score;
                obj.tournamentId = item.TournamentId;
                objectList.Add(obj);
            }
            return objectList;
        }
        [HttpGet("[action]")]
        public IEnumerable<Team> GetTeamsByTournament(int id)
        {
            var teams = IoCContainerHelper.Resolve<ITeamRepository>();
            var data = teams.GetMany(p => p.TournamentId == id).ToList();

            return data;
        }
        [HttpGet("[action]")]
        public IEnumerable<dynamic> GetTeamsScores()
        {
            var teams = IoCContainerHelper.Resolve<ITeamRepository>();
            var data = teams.GetAll().GroupBy(p=>p.Score).Select(x=>x.First()).Select(y=>y.Score).ToList();
            return data;
        }
    }
}