using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    public class CategoryOperation
    {
        MyContext myContext;

        public CategoryOperation()
        {
            myContext = new MyContext();
        }

        public void insertCategory(Category category)
        {
            using (myContext)
            {
                myContext.Categories.Add(category);
                myContext.SaveChanges();
            }
        }

        public List<Category> getAllCategory()
        {
            using (myContext)
            {
                return myContext.Categories.ToList();
            }
        }

        public bool checkTableExist()
        {
            using (myContext)
            {
                bool exists = myContext.Database
                     .SqlQuery<int?>(@"
                         SELECT 1 FROM sys.tables AS T
                         INNER JOIN sys.schemas AS S ON T.schema_id = S.schema_id
                         WHERE S.Name = 'SchemaName' AND T.Name = 'Category'")
                     .SingleOrDefault() != null;

                return exists;
            }            
        }


        public List<Product> getProductListByCategoryId(int categoryId)
        {
            using (myContext)
            {
                return myContext.Products.SqlQuery("SELECT TOP 3 * FROM Product where categoryId=" + categoryId).ToList();
            }
        }
    }
}