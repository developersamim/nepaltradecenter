
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWebAPI.Models
{
    public class DummyValues
    {
        public List<Product> dummyproduct()
        {
            List<Product> productList = new List<Product>();
            Product product1 = new Product();
            Product product2 = new Product();
            /*Size size1 = new Size();
            size1.sizeID = 100;
            size1.sizeName = "XXL";
            using (var dbCtx = new MyContext())
            {
                //Add Student object into Students DBset
                dbCtx.Sizes.Add(size1);

                // call SaveChanges method to save student into database
                dbCtx.SaveChanges();
            }*/



          
            product1.productName = "Adidas 9001";
            product1.sizeID = 1;
            product1.productCode = "A12";
            product1.quantity = 13;
            product1.initialCost = 200.50;
            product1.sellingPrice = 321.30;
            product1.profitPercentage = 20;
            product1.color = "red";
            product1.createdDate = DateTime.Now;
            product1.modifiedDate = DateTime.Now;
            product1.modifier = "-by sunit";
            product1.staus = false;
            product1.isAvailabe = true;
            product1.categoryID = 1221312;
            product1.testfield = "nth";
            // P
            
            product2.productName = "Adidas fs2001";
            product2.sizeID = 2;
            product2.productCode = "2cd3";
            product2.quantity = 13;
            product2.initialCost = 200.50;
            product2.sellingPrice = 321.30;
            product2.profitPercentage = 20;
            product2.color = "red";
            product2.createdDate = DateTime.Now;
            product2.modifiedDate = DateTime.Now;
            product2.modifier = "-by sunit";
            product2.staus = false;
            product2.isAvailabe = true;
            product2.categoryID = 1221312;
            product2.testfield = "nth";

            productList.Add(product1);
            productList.Add(product2);

            return productList;

        }
       
    }
}