using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NepalTradeCenterWebAPI.Models;

namespace NepalTradeCenterWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        public IEnumerable<Product> Get()
        {
            List<Product> productList = new List<Product>();
            Product product1 = new Product();
            product1.productId = 1;
            product1.productCode = "product 1";

            Product product2 = new Product();
            product2.productId = 2;
            product2.productCode = "product 2";

            productList.Add(product1);
            productList.Add(product2);

            return productList;
        }
    }
}
