using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrFixIt.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MrFixIt.Controllers
{
    public class JobsController : Controller
    {
        private MrFixItContext db = new MrFixItContext();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(db.Jobs.Include(i => i.Worker).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Job job)
        {
            db.Jobs.Add(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(job => job.JobId == id);

            return View(thisJob);
        }
        public IActionResult Edit(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisJob);
        }

        [HttpPost]
        public IActionResult Edit(Job job)
        {
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisJob);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisJob = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);

            db.Jobs.Remove(thisJob);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Claim(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisItem);
        }

        [HttpPost]
        //alter parameters
        //public IActionResult Claim(string JobId)
        //{
        //    Job thisItem = db.Jobs.FirstOrDefault(jobs => jobs.JobId == int.Parse(JobId));
        //    thisItem.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
        //    db.Entry(thisItem).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        public IActionResult Claim(Job job)
        {
            job.Worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return Content("Claimed by " + job.Worker.FirstName + " " + job.Worker.LastName, "text/plain");
        }

    }
}
