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
    public class PaymentTypesController : Controller
    {
        private BudgetEntities db = new BudgetEntities();

        // GET: PaymentTypes
        public ActionResult Index()
        {
            List<Models.PaymentTypes> listpayments = new List<Models.PaymentTypes>();

            var payments = db.PaymentTypes.ToList();

            foreach (var paymentdata in payments)
            {
                var model = new Models.PaymentTypes();

                model.PaymentName = paymentdata.PaymentName;

                listpayments.Add(model);
            }

            return View(listpayments);
        }

        // GET: PaymentTypes/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: PaymentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaymentTypes model)
        {
            var t = new PaymentType();
            //var payment =  collection.Keys               
            
            t.PaymentName = model.PaymentName;
            t.Active = true;
            
            
            db.PaymentTypes.Add(t);
            db.SaveChanges();

            return RedirectToAction("../Transactions/Create");
        }

        // GET: PaymentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: PaymentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PaymentName,Active")] PaymentTypes paymentTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentTypes);
        }

        // GET: PaymentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }
    }
}
