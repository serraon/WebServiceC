using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using InventoryManagement.Models.Database;
using Examples.SmptExamples.Async;
using System.Net;
using System.Net.Mail;

namespace InventoryManagement.Controllers
{
    public class QuoteController : Controller
    {
        private InventoryDBEntities db = new InventoryDBEntities();

        // GET: Quote
        public ActionResult Index()
        {

            

            var quotes = db.Quotes.Include(q => q.Order).Include(q => q.Product).Include(q => q.Vendor);
            return View(quotes.ToList());
        }

        // GET: Quote/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // GET: Quote/Create
        public ActionResult Create()
        {
            // Add Today's Date
            ViewBag.DateToday = DateTime.Now.Date.ToString("dd/MMM/yyyy"); ;

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            ViewBag.CompanyName = new SelectList(db.Vendors, "VendorID", "CompanyName");
            return View();
        }
        
        // POST: Quote/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuoteID,Date,VendorID,ProductID,TotalCost,OrderID,QuoteName")] Quote quote, string vendorid, string qty)
        {
            if (ModelState.IsValid)
            {
                int quantity = int.Parse(qty);
                quote.VendorID = int.Parse(vendorid);
                QuoteService.AddQuote(quote);

                // Create and Send Quote
                // need to make Quote name unique in db
                Product product = ProductService.GetProductById(quote.ProductID.GetValueOrDefault());

                Quote existQuote = QuoteService.GetQuoteByName(quote.QuoteName);
                Vendor assignedVendor = QuoteService.GetVendorByQuoteId(existQuote.QuoteID);
                Contact assignedContact = QuoteService.GetContactByVendorId(assignedVendor.VendorID);
                string message = EmailVendorService.Body(assignedContact.FirstName, product.Name, qty);
                EmailVendorService.sendMail(assignedContact.EmailAddress, assignedContact.FirstName, assignedContact.LastName, message);

                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", quote.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Type", quote.ProductID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorType", quote.VendorID);



            return View(quote);
        }
     /*   */
        // GET: Quote/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", quote.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Type", quote.ProductID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorType", quote.VendorID);
            return View(quote);
        }

        // POST: Quote/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuoteID,Date,VendorID,ProductID,TotalCost,OrderID,QuoteName")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "OrderID", quote.OrderID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Type", quote.ProductID);
            ViewBag.VendorID = new SelectList(db.Vendors, "VendorID", "VendorType", quote.VendorID);
            return View(quote);
        }

        // GET: Quote/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quote quote = db.Quotes.Find(id);
            if (quote == null)
            {
                return HttpNotFound();
            }
            return View(quote);
        }

        // POST: Quote/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quote quote = db.Quotes.Find(id);
            db.Quotes.Remove(quote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
