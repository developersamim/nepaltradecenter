﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NepalTradeCenterWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    public class ProductService : IProductService
    {
        public void DoWork()
        {
        }
        public bool insertProduct()
        {
            ProductOperation productOperation = new ProductOperation();
            return productOperation.insertProduct();
        }
        public List<Product> getAllProduct()
        {
            ProductOperation productOperation = new ProductOperation();
            return productOperation.getAllProduct();
        }
        public Product getProductById(int productId)
        {
            ProductOperation productOperation = new ProductOperation();
            return productOperation.getProductById(productId);
        }
    }
}
