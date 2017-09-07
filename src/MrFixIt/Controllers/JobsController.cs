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
            var thisJob = db.Jobs.Include(job => job.Worker).FirstOrDefault(job => job.JobId == id);
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
            Worker worker = thisJob.Worker;
            if (worker != null)
            { 
                worker.Available = true;
            }
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
        public IActionResult Claim(Job job)
        {
            Worker worker = db.Workers.FirstOrDefault(i => i.UserName == User.Identity.Name);
                job.Worker = worker;
                job.Worker.Available = false;
                db.Entry(job).State = EntityState.Modified;
                db.Entry(worker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");  
        }
        public IActionResult Pending(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisItem);
        }
        [HttpPost]
        public IActionResult Pending(Job job)
        {
            Worker worker = job.Worker;
            job.Pending = true;
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Workers");
        }
        public IActionResult Complete(int id)
        {
            var thisItem = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
            return View(thisItem);
        }
        [HttpPost]
        public IActionResult Complete(Job job)
        {
            job.Completed = true;
            db.Entry(job).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index", "Workers");
        }
    }
}
