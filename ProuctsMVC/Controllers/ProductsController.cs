using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProuctsMVC.DAL;
using ProuctsMVC.Models;


namespace ProuctsMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsDbContext db;

        public ProductsController()
        {
            db = new ProductsDbContext();
        }

        public ActionResult Index()
        {
            var list = new List<Products>();
            list = db.Product.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var categories = db.Categories.ToList();
            var selectList2 = new SelectList(categories, "Id", "Name");
            ViewBag.Categories = selectList2;
            var companies= db.Companies.ToList();
            var selectList = new SelectList(companies, "Id", "Name");
            ViewBag.Companies = selectList;
            
            var countries = db.Countries.ToList();
            var selectList1 = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = selectList1;

           

            return View();
        }

        [HttpPost]
        public ActionResult Create(Products entity)
        {

            var categories = db.Categories.ToList();
            var selectList2 = new SelectList(categories, "Id", "Name");
            ViewBag.Categories = selectList2;

            var companies = db.Companies.ToList();
            var selectList = new SelectList(companies, "Id", "Name");
            ViewBag.Companies = selectList;

            var countries = db.Countries.ToList();
            var selectList1 = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = selectList1;
           

           
            if (ModelState.IsValid)
            {

            }

            if (db.Product.Any(x => x.Id == entity.Id))
            {
                ViewBag.Message = "این محصول درج شده است.!";
                return View(entity);
            }
            

            if (entity.BrandName == null)
            {
                ViewBag.Message = "لطفا نام برند را وارد نمایید.";
                return View(entity);
            }

            if(db.Product.Any(x => x.BrandName==entity.BrandName))
            {
                ViewBag.Message = " نام برند  نمی تواند تکراری باشد..";
                return View(entity);
            }

            if (entity.ModelNo == null)
            {
                ViewBag.Message = "لطفا شماره محصول را وارد نمایید.";
                return View(entity);
            }
            if (entity.CategoryId == null)
            {
                ViewBag.Message = "لطفا نوع دسته را انتخاب نمایید.";
                return View(entity);
            }
            if (entity.CompanyId == null)
            {
                ViewBag.Message = "لطفا شرکت سازنده را انتخاب نمایید";
                return View(entity);
            }
            if (entity.CountryId == null)
            {
                ViewBag.Message = "لطفا کشورمورد نظررا انتخاب نمایید";
                return View(entity);
            }

            db.Product.Add(entity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            

            var entity = db.Product.Find(Id);

            if (entity == null)
            {
                ViewBag.Message = "این محصول وجود ندارد.";
                return RedirectToAction("Index");
            }
          

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Companies = new SelectList(db.Companies, "Id", "Name");
            ViewBag.Countries = new SelectList(db.Countries, "Id", "Name");
           
            return View(entity);
        }

        [HttpPost]
        public ActionResult Edit(Products entity)
        {

            var categories = db.Categories.ToList();
            var selectList2 = new SelectList(categories, "Id", "Name");
            ViewBag.Categories = selectList2;

            var companies = db.Companies.ToList();
            var selectList = new SelectList(companies, "Id", "Name");
            ViewBag.Companies = selectList;

            var countries = db.Countries.ToList();
            var selectList1 = new SelectList(countries, "Id", "Name");
            ViewBag.Countries = selectList1;

            if (ModelState.IsValid)
            {

            }

          


            if (entity.BrandName == null)
            {
                ViewBag.Message = "لطفا نام برند را وارد نمایید.";
                return View(entity);
            }

          

            if (entity.ModelNo == null)
            {
                ViewBag.Message = "لطفا شماره محصول را وارد نمایید.";
                return View(entity);
            }


            if (entity.CategoryId == null)
            {
                ViewBag.Message = "لطفا نوع دسته را انتخاب نمایید.";
                return View(entity);
            }
            if (entity.CompanyId == null)
            {
                ViewBag.Message = "لطفا شرکت سازنده را انتخاب نمایید";
                return View(entity);
            }
            if (entity.CountryId == null)
            {
                ViewBag.Message = "لطفا کشورمورد نظررا انتخاب نمایید";
                return View(entity);
            }
            
           

            db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int Id)
        {
            var entity = db.Product.FirstOrDefault(x => x.Id == Id);

            if (entity == null)
            {
                ViewBag.Message = "Not Found!";
                return RedirectToAction("Index");
            }

            db.Product.Remove(entity);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}