using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission13.Models;

namespace Mission13.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlingRepository repo { get; set; }

        public TeamsViewComponent(IBowlingRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()

        {
            
            ViewBag.SelectedTeams = RouteData?.Values["NameTeams"];

            
            var teams = repo.Teams
                .Select(x => x.TeamName)
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            return View(teams);
        }
    }
}