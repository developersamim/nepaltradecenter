using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    public class DataInitializer
    {
        MyContext myContext;
        public DataInitializer()
        {
            myContext = new MyContext();
            insertUsers();
            insertRole();
            insertProduct();
            insertCategory();

        }

        public void insertUsers()
        {
            List<User> userList = new List<User>();
            User user1 = new User { username = "admin", email = "developersamim@gmail.com", password = "P@ssw0rd", status = 0, active = 0 };
            User user2 = new User { username = "samim", email = "developersamim@gmail.com", password = "P@ssw0rd", status = 0, active = 0 };
            userList.Add(user1);
            userList.Add(user2);

            userList.ForEach(s => myContext.Users.Add(s));
            myContext.SaveChanges();
        }

        public void insertRole()
        {
            List<Role> roleList = new List<Role>();
            Role role1 = new Role { name = "dba", userId = 1, status = 0, active = 0 };
            Role role2 = new Role { name = "employee", userId = 2, status = 0, active = 0 };
            roleList.Add(role1);
            roleList.Add(role2);

            roleList.ForEach(s => myContext.Roles.Add(s));
            myContext.SaveChanges();
        }

        public void insertProduct()
        {
            List<Product> productList = new List<Product>();
            Product product1 = new Product { name = "lily", productCode = "lily123", quantity = 18, cost = 100, sellingPrice = 150, productCreated = DateCreated, categoryId = 3, status = 0, active = 0, imageAddress = "~/Content/upload/product/1.jpg" };
            Product product2 = new Product { name = "gazal", productCode = "gazal123", quantity = 12, cost = 120, sellingPrice = 180, productCreated = DateCreated, categoryId = 3, status = 0, active = 0, imageAddress = "~/Content/upload/product/2.jpg" };
            Product product3 = new Product { name = "pinklady", productCode = "pinklady123", quantity = 18, cost = 180, sellingPrice = 220, productCreated = DateCreated, categoryId = 3, status = 0, active = 0, imageAddress = "~/Content/upload/product/3.jpg" };
            Product product4 = new Product { name = "kika", productCode = "kika123", quantity = 24, cost = 500, sellingPrice = 550, productCreated = DateCreated, categoryId = 3, status = 0, active = 0, imageAddress = null };
            Product product5 = new Product { name = "haki", productCode = "haki123", quantity = 18, cost = 550, sellingPrice = 600, productCreated = DateCreated, categoryId = 4, status = 0, active = 0, imageAddress = "~/Content/upload/product/5.jpg" };
            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);

            productList.ForEach(s => myContext.Products.Add(s));
            myContext.SaveChanges();
        }

        public void insertCategory()
        {
            List<Category> categoryList = new List<Category>();
            Category category1 = new Category { name = "pumps", parent = 0, created = DateCreated, status = 0, active = 0 };
            Category category2 = new Category { name = "platforms", parent = 0, created = DateCreated, status = 0, active = 0 };
            Category category3 = new Category { name = "sandals", parent = 0, created = DateCreated, status = 0, active = 0 };
            Category category4 = new Category { name = "sneakers", parent = 0, created = DateCreated, status = 0, active = 0 };
            Category category5 = new Category { name = "wedges", parent = 0, created = DateCreated, status = 0, active = 0 };
            Category category6 = new Category { name = "flats", parent = 0, created = DateCreated, status = 0, active = 0 };
            Category category7 = new Category { name = "ankle boots", parent = 0, created = DateCreated, status = 0, active = 0 };
            Category category8 = new Category { name = "high boots", parent = 0, created = DateCreated, status = 0, active = 0 };
            categoryList.Add(category1);
            categoryList.Add(category2);
            categoryList.Add(category3);
            categoryList.Add(category4);
            categoryList.Add(category5);
            categoryList.Add(category6);
            categoryList.Add(category7);
            categoryList.Add(category8);

            categoryList.ForEach(s => myContext.Categories.Add(s));
            myContext.SaveChanges();
        }

        private DateTime? dateCreated;
        public DateTime DateCreated
        {
            get { return dateCreated ?? DateTime.Now; }
            set { dateCreated = value; }
        }
    }
}