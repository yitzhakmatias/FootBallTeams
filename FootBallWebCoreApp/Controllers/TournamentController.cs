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
    public class TournamentController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<dynamic> GetTournaments()
        {
            var teams = IoCContainerHelper.Resolve<ITournamentRepository>();
            var data = teams.GetAll().ToList();

            var objectList = new List<Object>();
            foreach (var item in data)
            {
                dynamic obj = new System.Dynamic.ExpandoObject();
                obj.name = item.Name;
                obj.tournamentId = item.TournamentId;
                objectList.Add(obj);
            }
            return objectList;
           
        }
       
    }
}