using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.DAL;

namespace NepalTradeCenter.ViewModels
{
    public class ProductListViewModel
    {
        private ProductDAL productDAL;
        private CategoryDAL categoryDAL;
        private List<NepalTradeCenterServiceReference.Product> productList;
        private NepalTradeCenterServiceReference.Category category;
        private List<TemporaryObject> temporaryObjectList;

        public ProductListViewModel()
        {
            productDAL = new ProductDAL();
            categoryDAL = new CategoryDAL();
            productList = new List<NepalTradeCenterServiceReference.Product>();
            temporaryObjectList = new List<TemporaryObject>();
        }

        public void setProductList()
        {            
            productList = productDAL.getAllProductList();
            refactorProductList();
        }

        public List<TemporaryObject> getTemporaryObjectList()
        {
            return temporaryObjectList;
        }

        public List<NepalTradeCenterServiceReference.Product> getAProductList()
        {
            return productList;
        }

        public void refactorProductList()
        {
            foreach(var element in productList)
            {
                category = categoryDAL.getCategoryById(element.categoryId);
                TemporaryObject temporaryObject = new TemporaryObject();
                temporaryObject.product = element;
                temporaryObject.category = category;
                temporaryObjectList.Add(temporaryObject);
            }
        }
    }
    public class TemporaryObject
    {
        public NepalTradeCenterServiceReference.Product product { get; set; }
        public NepalTradeCenterServiceReference.Category category { get; set; }
    }
}