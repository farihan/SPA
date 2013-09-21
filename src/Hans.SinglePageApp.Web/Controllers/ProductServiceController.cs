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
    public class ProductServiceController : ApiController
    {
        public IRepository<Product> ProductRepository { get; set; }

        public HttpResponseMessage Get()
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

            var response = Request.CreateResponse(HttpStatusCode.OK, list);
            var uri = Url.Route(null, null);
            response.Headers.Location = new Uri(Request.RequestUri, uri);

            return response;
        }
    }
}
