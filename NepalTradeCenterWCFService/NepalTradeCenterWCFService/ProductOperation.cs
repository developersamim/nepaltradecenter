using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    public class ProductOperation
    {
        private DateTime? dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
        }
        MyContext myContext;

        public ProductOperation()
        {
            myContext = new MyContext();
        }

        public List<Product> getAllProduct()
        {
            using (myContext)
            {
                return myContext.Products.ToList();
            }
        }

        public Product getProductById(int productId)
        {
            using (myContext)
            {
                return myContext.Products.Find(productId);
            }
        }

        public bool insertProduct()
        {
            using (myContext)
            {
                Product product = new Product();
                product.productCode = "C123";
                product.name = "Car";
                product.quantity = 10;
                product.cost = 10000;
                product.sellingPrice = 14000;
                product.productCreated = DateCreated;
                product.categoryId = 1;
                product.status = 1;
                product.active = 1;
                product.imageAddress = "this is where am I ?";


                myContext.Products.Add(product);
                myContext.SaveChanges();
                return true;
            }
            
        }
    }
}