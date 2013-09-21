using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hans.SinglePageApp.Core.Domains;
using Hans.SinglePageApp.Core.Repositories;
using Hans.SinglePageApp.Web.Models;

namespace Hans.SinglePageApp.Web.Controllers
{
    public class ProductController : Controller
    {
        public IRepository<Supplier> SupplierRepository { get; set; }
        public IRepository<Category> CategoryRepository { get; set; }
        //
        // GET: /Product/

        public ActionResult Index()
        {
            var model = new ProductModel();
            model.AvailableSuppliers = SupplierRepository.FindAll()
                .Select(x => new SelectListItem
                {
                    Value = x.SupplierID.ToString(),
                    Text = x.CompanyName
                })
                .ToList();
            model.AvailableCategories = CategoryRepository.FindAll()
                .Select(x => new SelectListItem
                {
                    Value = x.CategoryID.ToString(),
                    Text = x.CategoryName
                })
                .ToList();

            return View(model);
        }

    }
}
