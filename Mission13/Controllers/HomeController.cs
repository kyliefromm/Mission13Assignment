using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private IBowlingRepository _repo { get; set; }

        public HomeController(IBowlingRepository temp)
        {
            _repo = temp;
        }

    public IActionResult Index(string NameTeams)
    {
            ViewBag.TeamName = NameTeams ?? "Home"; 

            var x = _repo.Bowlers
                    .Include(x => x.Team)
                    .Where(x => x.Team.TeamName == NameTeams || NameTeams == null)
                    .ToList();
    return View(x);
    }

    [HttpGet]
    public IActionResult Bowl()
    {
        Bowl b = new Bowl();
        ViewBag.Teams = _repo.Teams.ToList();
        return View(b);
    }

    [HttpPost]
    public IActionResult Bowl(Bowl b)
    {
        if (ModelState.IsValid)
        {
                if (b.BowlerID == 0)
                {
                    b.BowlerID = (_repo.Bowlers.Max(b => b.BowlerID)) + 1;
                    _repo.CreateBowl(b);

                }

                else
                {
                    _repo.SaveBowl(b);

                }

                 return RedirectToAction("Index");

            //context.Add(b);
            //context.SaveChanges();
            //return View("Confirmation", b);
        }
        else
        {
            ViewBag.Teams = _repo.Teams.ToList();
            ViewBag.Bowler = _repo.Bowlers.ToList();
            return View(b);
        }
    }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            ViewBag.Teams = _repo.Teams.ToList();


            var bowlers = _repo.Bowlers.SingleOrDefault(x => x.BowlerID == bowlerid);

            return View("Bowl", bowlers);
        }
        //[HttpPost]
        //public IActionResult Edit(bowl blah)
        //{
        //    _repo.Update(blah);
        //    _repo.SaveChanges();

        //    return RedirectToAction("Index");

        //}


        [HttpGet]
        public IActionResult Delete(int bowlerid)
        {
            var bowlers = _repo.Bowlers.SingleOrDefault(x => x.BowlerID == bowlerid);
            return View(bowlers);
        }

        [HttpPost]
        public IActionResult Delete(Bowl ar)
        {
            _repo.DeleteBowl(ar);
          
            return RedirectToAction("Index");
        }





    }

}
