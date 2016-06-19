using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.NepalTradeCenterServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.DAL
{
    public class CategoryDAL
    {
        NepalTradeCenterServiceClient nepalTradeCenterServiceClient;

        private List<NepalTradeCenterServiceReference.Category> categoryList;

        public CategoryDAL()
        {
            nepalTradeCenterServiceClient = new NepalTradeCenterServiceClient();
            categoryList = new List<NepalTradeCenterServiceReference.Category>();
        }

        public void setCategoryList()
        {
            categoryList = nepalTradeCenterServiceClient.getAllCategory();
        }

        public List<NepalTradeCenterServiceReference.Category> getCategoryList()
        {
            return categoryList;
        }

        public NepalTradeCenterServiceReference.Category getCategoryById(int categoryId)
        {
            return nepalTradeCenterServiceClient.getCategoryById(categoryId);
        }

        public void insertCategory(NepalTradeCenterServiceReference.Category category)
        {
            nepalTradeCenterServiceClient.insertCategory(category);
        }

    }

    [TestClass]
    public class CategoeryDALTest
    {
        [TestMethod]
        public void getAllCategory()
        {
            // Arrange
            NepalTradeCenterServiceClient client;
            List<NepalTradeCenterServiceReference.Category> categoryList;

            // Act
            client = new NepalTradeCenterServiceClient();
            categoryList = new List<NepalTradeCenterServiceReference.Category>();
            categoryList = client.getAllCategory();

            // Assert
            Assert.IsTrue(categoryList.Count != 0);
        }
        [TestMethod]
        public void getCategoryById()
        {
            // Arrange
            NepalTradeCenterServiceClient client;
            NepalTradeCenterServiceReference.Category category;
            int categoryId1 = 1;

            // Act
            client = new NepalTradeCenterServiceClient();
            category = new NepalTradeCenterServiceReference.Category();
            category = client.getCategoryById(categoryId1);

            // Assert
            Assert.IsNotNull(category);
        }
    }
}