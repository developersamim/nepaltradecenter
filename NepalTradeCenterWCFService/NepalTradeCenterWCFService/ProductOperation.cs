using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

        public int insertProduct(Product product)
        {
            using (myContext)
            {
                myContext.Products.Add(product);
                myContext.SaveChanges();
                return product.productId;
            }            
        }

        public int updateProduct(int productId, string imageAddress)
        {
            Product myProduct = getProductById(productId);
            myProduct.imageAddress = imageAddress;
            using (var context = new MyContext())
            {
                // the next step implicitly attaches the entity
                context.Entry(myProduct).State = EntityState.Modified;

                return context.SaveChanges();
            }
        }

        public List<Product> getLastNProduct()
        {
            using (myContext)
            {
                return myContext.Products.SqlQuery("SELECT TOP 3 * FROM Product ORDER BY productId DESC").ToList();
            }
        }

        
    }
}