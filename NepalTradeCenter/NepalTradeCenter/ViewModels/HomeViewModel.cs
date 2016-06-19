using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.DAL;

namespace NepalTradeCenter.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private ProductDAL productDAL;

        public HomeViewModel()
        {
            productDAL = new ProductDAL();
        }

        public void setProductList()
        {
            productDAL.setProductList();
        }

        public List<NepalTradeCenterServiceReference.Product> getProductList()
        {
            return productDAL.getProductList();
        }


    }
}