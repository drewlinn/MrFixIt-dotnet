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
    public class WorkersController : Controller
    {
        private MrFixItContext db = new MrFixItContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            var thisWorker = db.Workers.Include(i =>i.Jobs).FirstOrDefault(i => i.UserName == User.Identity.Name);
            if (thisWorker != null)
            {
                return View(thisWorker);
            }
            else
            {
                return View("Index");
            }
        }
        [HttpPost]
        public IActionResult Create(Worker worker)
        {
            worker.UserName = User.Identity.Name;
            db.Workers.Add(worker); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var thisWorker = db.Workers.FirstOrDefault(worker => worker.WorkerId == id);

            return View(thisWorker);
        }
        public IActionResult Edit(int id)
        {
            var thisWorker = db.Workers.FirstOrDefault(items => items.WorkerId == id);
            return View(thisWorker);
        }
        [HttpPost]
        public IActionResult Edit(Worker worker)
        {
            db.Entry(worker).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var thisWorker = db.Workers.FirstOrDefault(items => items.WorkerId == id);
            return View(thisWorker);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisWorker = db.Workers.FirstOrDefault(items => items.WorkerId == id);
            db.Workers.Remove(thisWorker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            return View();
        }
        
        //Possible need for refactor


        //public IActionResult Pending(int id)
        //{
        //    var thisItem = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
        //    return View(thisItem);
        //}
        //[HttpPost]
        //public IActionResult Pending(Job job)
        //{
        //    Worker worker = job.Worker;
        //    job.Pending = true;
        //    db.Entry(job).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //public IActionResult Complete(int id)
        //{
        //    var thisItem = db.Jobs.FirstOrDefault(jobs => jobs.JobId == id);
        //    return View(thisItem);
        //}
        //[HttpPost]
        //public IActionResult Complete(Job job)
        //{
        //    job.Completed = true;
        //    db.Entry(job).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

    }
}
