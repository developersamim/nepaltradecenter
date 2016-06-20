using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NepalTradeCenterWebAPI.Models;
using System.Data.Entity.Infrastructure;
using System.Text;

namespace NepalTradeCenterWebAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        public ProductController() { }

        public IEnumerable<Product> Get()
        {



            return null;
        }

        // GET api/poduct/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/product
        public void Post([FromBody]string value)
        {
            DummyValues dummyData = new DummyValues();
            List<Product> productList = dummyData.dummyproduct();


            // insert product starts here
            try
            {
                MyContext myContext = new MyContext();
                productList.ForEach(s => myContext.Products.Add(s));
                myContext.SaveChanges();
                //return productList;
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e.ToString());
               // return null;
            }

            // insert product ends here

        }

        // PUT api/product/5
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/product/5
        public void Delete(int id)
        {
        }
    }
}
