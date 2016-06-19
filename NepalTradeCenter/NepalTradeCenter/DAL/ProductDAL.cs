using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NepalTradeCenter.NepalTradeCenterServiceReference;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.DAL
{
    public class ProductDAL
    {
        NepalTradeCenterServiceClient nepalTradeCenterServiceClient = new NepalTradeCenterServiceClient();

        private List<NepalTradeCenterServiceReference.Product> productList = new List<Product>();

        public void setProductList()
        {
            productList = nepalTradeCenterServiceClient.getLastNProduct();
        }

        public List<NepalTradeCenterServiceReference.Product> getProductList()
        {
            return productList = nepalTradeCenterServiceClient.getLastNProduct();
        }

        public List<NepalTradeCenterServiceReference.Product> getAllProductList()
        {
            return productList = nepalTradeCenterServiceClient.getAllProduct();
        }

        public List<NepalTradeCenterServiceReference.Product> getProductListByCategoryId(int categoryId)
        {
            return productList = nepalTradeCenterServiceClient.getProductListByCategoryId(categoryId);
        }

        public int insertProduct(NepalTradeCenterServiceReference.Product product)
        {
            return nepalTradeCenterServiceClient.insertProduct(product);
        }

        public int updateProduct(int productId, string imageAddress)
        {
            return nepalTradeCenterServiceClient.updateProduct(productId, imageAddress);
        }

        public NepalTradeCenterServiceReference.Product getProductById(int productId)
        {
            return nepalTradeCenterServiceClient.getProductById(productId);
        }
    }

    [TestClass]
    public class ProductDALTest
    {

        [TestMethod]
        public void getProductListByCategoryIdTest()
        {
            // Arrange
            NepalTradeCenterServiceClient client;
            List<NepalTradeCenterServiceReference.Product> productList;
            int categoryId1 = 1;

            // Act
            client = new NepalTradeCenterServiceClient();
            productList = new List<NepalTradeCenterServiceReference.Product>();
            productList = client.getProductListByCategoryId(categoryId1);

            //Assert
            Assert.IsTrue(productList.Count != 0);
        }

        [TestMethod]
        public void getProductByIdTest()
        {
            // Arrange
            NepalTradeCenterServiceClient client;
            NepalTradeCenterServiceReference.Product product;
            int productId1 = 1;

            // Act
            client = new NepalTradeCenterServiceClient();
            product = new NepalTradeCenterServiceReference.Product();
            product = client.getProductById(productId1);

            //Assert
            Assert.IsNotNull(product);
        }
        [TestMethod]
        public void getAllProductListTest()
        {
            // Arrange
            NepalTradeCenterServiceClient client;
            List<NepalTradeCenterServiceReference.Product> productList;

            // Act
            client = new NepalTradeCenterServiceClient();
            productList = new List<NepalTradeCenterServiceReference.Product>();
            productList = client.getAllProduct();

            //Assert
            Assert.IsTrue(productList.Count != 0);
        }

        [TestMethod]
        public void getLastNProductTest()
        {
            // Arrange
            NepalTradeCenterServiceClient client;
            List<NepalTradeCenterServiceReference.Product> productList;

            // Act
            client = new NepalTradeCenterServiceClient();
            productList = new List<NepalTradeCenterServiceReference.Product>();
            productList = client.getLastNProduct();

            //Assert
            Assert.IsTrue(productList.Count != 0);
        }

        
    }
}