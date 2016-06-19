using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.NepalTradeCenterServiceReference;
using NepalTradeCenter.DAL;

namespace NepalTradeCenter.ViewModels
{
    public abstract class ViewModelBase
    {
        private CategoryDAL categoryDAL = new CategoryDAL();

        public void setCategoryList()
        {
            categoryDAL.setCategoryList();
        }

        public List<NepalTradeCenterServiceReference.Category> getCategoryList()
        {
            return categoryDAL.getCategoryList();
        }
    }
}