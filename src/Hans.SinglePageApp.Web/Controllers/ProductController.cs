using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hans.SinglePageApp.Core.Domains;
using Hans.SinglePageApp.Core.Repositories;
using Hans.SinglePageApp.Web.Models;

namespace Hans.SinglePageApp.Web.Controllers
{
    public class ProductController : ApiController
    {
        public IRepository<Product> ProductRepository { get; set; }

        public IQueryable<ProductModel> GetProducts()
        {
            var list = ProductRepository.FindAll().Select(x => new ProductModel{
                ProductID = x.ProductID,
                ProductName = x.ProductName,
                SupplierId = x.Supplier.SupplierID,
                CategoryId = x.Category.CategoryID,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued
            });

            return list;
        }
    }
}
