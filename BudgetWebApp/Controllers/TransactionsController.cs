using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetWebApp;
using BudgetWebApp.Models;

namespace BudgetWebApp.Controllers
{
    public class TransactionsController : Controller
    {
        private BudgetEntities db = new BudgetEntities();

        // GET: TransactionsModel
        public ActionResult Index()
        {
            List<Transactions> listtransactions = new List<Transactions>();

            var trans = (from t in db.Transactions
                         join p in db.PaymentTypes on t.PaymentType equals p.ID
                         where t.Active == true
                         select new
                         {
                             t.ID,
                             t.Name,
                             t.Amount,
                             p.PaymentName,
                             t.PaymentDate
                         }).ToList();

            foreach (var trandata in trans)
            {
                var model = new Transactions();

                model.ID = trandata.ID;
                model.Name = trandata.Name;
                model.Amount = trandata.Amount;
                model.PaymentName = trandata.PaymentName;
                model.PaymentDate = trandata.PaymentDate;

                listtransactions.Add(model);
            }

            return View(listtransactions);
        }

        // GET: TransactionsModel/Details/5
        public ActionResult Details(int id)
        {


            return View();
        }

        // GET: TransactionsModel/Create
        public ActionResult Create()
        {
            var model = new Models.Transactions();

            var paymentType = from p in db.PaymentTypes orderby p.PaymentName select p;

            var t = new SelectList(paymentType, "ID", "PaymentName");

            model.PaymentTypeList = t;

            return View(model);
        }

        // POST: TransactionsModel/Create
        [HttpPost]
        public ActionResult Create(Models.Transactions model)//FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var t = new Transaction();
                //var payment =  collection.Keys               

                t.Name = model.Name;
                t.Amount = model.Amount;
                t.PaymentDate = model.PaymentDate;
                t.PaymentType = model.ID;
                t.Active = true;


                db.Transactions.Add(t);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionsModel/Edit/5
        public ActionResult Edit(int id)
        {
            List<Transactions> listtransactions = new List<Transactions>();

            var trans = (from t in db.Transactions
                         join p in db.PaymentTypes on t.PaymentType equals p.ID
                         where t.ID == id
                         select new
                         {
                             t.ID,
                             t.Name,
                             t.Amount,
                             p.PaymentName,
                             t.PaymentDate
                         }).ToList().FirstOrDefault() ;

            var model = new Transactions();

            model.ID = trans.ID;
            model.Name = trans.Name;
            model.Amount = trans.Amount;
            model.PaymentName = trans.PaymentName;
            model.PaymentDate = trans.PaymentDate;

            return View(model);
        }

        // POST: TransactionsModel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionsModel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionsModel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
