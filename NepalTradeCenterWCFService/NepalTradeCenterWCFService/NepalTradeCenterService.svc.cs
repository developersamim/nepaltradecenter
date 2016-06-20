using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NepalTradeCenterWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ProductService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ProductService.svc or ProductService.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ProductService : INepalTradeCenterService
    {
        // start shopcart
        private ShopCart shopCart;

        public ShopCart newCart()
        {
            shopCart = new ShopCart();
            return shopCart;
        }

        public bool addItem(Item item)
        {
            shopCart.addItem(item);
            return true;
        }
        public Item getItem(int itemId)
        {
            Item item = null;
            foreach (Item element in getItemList())
            {
                if (element.itemId == itemId)
                {
                    item = element;
                }

            }
            return item;
        }
        public void setQuantityofItem(Item item, int quantity)
        {
            item.quantity = quantity;
        }
        public bool deleteItem(int itemID)
        {
            return shopCart.deleteItem(itemID);
            //itemList.Remove(item);
        }
        public Item findItem(string productId)
        {
            Item item = null;
            foreach (var element in getItemList())
            {
                if (element.itemId.Equals(productId))
                    item = element;
            }
            return item;
        }

        public List<Item> getItemList()
        {
            return shopCart.getItemList();
        }
        public ShopCart getCart()
        {
            if (shopCart == null)
                shopCart = new ShopCart();
            return shopCart;
        }
        // end shopcart

        // start DataInitializer
        public void RunDataInitializer()
        {
            DataInitializer dataInitializer = new DataInitializer();
        }
        // end DataInitializer

        // start product
        public int insertProduct(Product product)
        {
            ProductOperation productOperation = new ProductOperation();
            return productOperation.insertProduct(product);
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

        public int updateProduct(int productId, string imageAddress)
        {
            ProductOperation productOperation = new ProductOperation();
            return productOperation.updateProduct(productId, imageAddress);
        }

        public List<Product> getLastNProduct()
        {
            ProductOperation productOperation = new ProductOperation();
            return productOperation.getLastNProduct();
        }
        // end product

        // start category
        public List<Category> getAllCategory()
        {
            CategoryOperation categoryOperation = new CategoryOperation();
            return categoryOperation.getAllCategory();
        }

        public bool checkTableExist()
        {
            CategoryOperation categoryOperation = new CategoryOperation();
            return categoryOperation.checkTableExist();
        }

        public void insertCategory(Category category)
        {
            CategoryOperation categoryOperation = new CategoryOperation();
            categoryOperation.insertCategory(category);
        }

        public List<Product> getProductListByCategoryId(int categoryId)
        {
            CategoryOperation categoryOperation = new CategoryOperation();
            return categoryOperation.getProductListByCategoryId(categoryId);
        }
        public Category getCategoryById(int categoryId)
        {
            CategoryOperation categoryOperation = new CategoryOperation();
            return categoryOperation.getCategoryById(categoryId);
        }
        // end category


        // start user
        public User authentiateUser(string username, string password)
        {
            UserOperation userOperation = new UserOperation();
            return userOperation.authentiateUser(username, password);
        }
        // end user
    }
}
