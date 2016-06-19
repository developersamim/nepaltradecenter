using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.DAL;

namespace NepalTradeCenter.ViewModels
{
    public class CategoryBasedProductViewModel : ViewModelBase
    {
        private ProductDAL productDAL;
        private List<NepalTradeCenterServiceReference.Product> productList;

        public CategoryBasedProductViewModel()
        {
            productDAL = new ProductDAL();
            productList = new List<NepalTradeCenterServiceReference.Product>();
        }

        public void setProductList(int categoryId)
        {
            productList = productDAL.getProductListByCategoryId(categoryId);
        }

        public List<NepalTradeCenterServiceReference.Product> getProductList()
        {
            return productList;
        }
    }
}