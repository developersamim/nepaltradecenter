using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NepalTradeCenter.DAL;
using NepalTradeCenter.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NepalTradeCenter.Controllers
{
    public class MyCartController : Controller
    {
        public NepalTradeCenterServiceReference.NepalTradeCenterServiceClient client;
        NepalTradeCenterServiceReference.ShopCart myCart;
        public ProductDAL productDAL;

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {

            base.Initialize(requestContext);
            productDAL = new ProductDAL();

            if (Session["cart"] == null)
            {
                client = new NepalTradeCenterServiceReference.NepalTradeCenterServiceClient();
                myCart = client.newCart();
                Session["cart"] = client;
            }
            else
            {
                client = (NepalTradeCenterServiceReference.NepalTradeCenterServiceClient)Session["cart"];
                myCart = client.getCart();
            }
        }

        public ActionResult Index()
        {
            MyCartViewModel myCartViewModel = new MyCartViewModel();
            myCartViewModel.setCategoryList();
            ViewBag.itemList = client.getItemList();
            ViewBag.totalPrice = totalPrice(client.getItemList());
            return View(myCartViewModel);
        }

        public decimal totalPrice(List<NepalTradeCenterServiceReference.Item> itemList)
        {
            decimal totalPrice = 0;
            foreach (NepalTradeCenterServiceReference.Item item in itemList)
            {
                totalPrice += (item.quantity * item.product.sellingPrice);
            }
            return totalPrice;
        }
        public ActionResult addItem(int productId)
        {
            bool itemAdded = false;
            int quantity = 1;
            System.Diagnostics.Debug.WriteLine("ProductId: " + productId);


            NepalTradeCenterServiceReference.Product product = productDAL.getProductById(productId);

            // check item exists in shop cart, if true increment the count

            List<NepalTradeCenterServiceReference.Item> itemList = client.getItemList();
            if (itemList.Count > 0)
            {
                foreach (NepalTradeCenterServiceReference.Item item in itemList)
                {
                    if (item.itemId.Equals(productId))
                    {
                        int oldQuantity = item.quantity;
                        int currentQuantity = oldQuantity + quantity;
                        //client.setQuantityofItem(item, currentQuantity);
                        bool deleteStatus = client.deleteItem(item.itemId);

                        int size = client.getItemList().Count;

                        NepalTradeCenterServiceReference.Item newItem = new NepalTradeCenterServiceReference.Item();
                        newItem.itemId = productId;
                        newItem.product = product;
                        newItem.quantity = currentQuantity;
                        client.addItem(newItem);

                        itemAdded = true;
                        break;
                    }
                }
            }

            if (!itemAdded)
            {
                NepalTradeCenterServiceReference.Item item = new NepalTradeCenterServiceReference.Item();
                item.itemId = productId;
                item.product = product;
                item.quantity = quantity;
                client.addItem(item);
            }



            setSession();

            return RedirectToAction("Index", "Home");
        }
        //public ActionResult addItem()
        //{

        //    bool itemAdded = false;
        //    int productId = Convert.ToInt32(Request.Form["productId"].Trim());
        //    int quantity = Convert.ToInt32(Request.Form["quantity"]);

        //    System.Diagnostics.Debug.WriteLine("ProductId: " + productId);
        //    System.Diagnostics.Debug.WriteLine("Quantity: " + quantity);


        //    NepalTradeCenterServiceReference.Product product = productDAL.getProductById(productId);

        //    // check item exists in shop cart, if true increment the count

        //    List<NepalTradeCenterServiceReference.Item> itemList = client.getItemList();
        //    if (itemList.Count > 0)
        //    {
        //        foreach (NepalTradeCenterServiceReference.Item item in itemList)
        //        {
        //            if (item.itemId.Equals(productId))
        //            {
        //                int oldQuantity = item.quantity;
        //                int currentQuantity = oldQuantity + quantity;
        //                //client.setQuantityofItem(item, currentQuantity);
        //                bool deleteStatus = client.deleteItem(item.itemId);

        //                int size = client.getItemList().Count;

        //                NepalTradeCenterServiceReference.Item newItem = new NepalTradeCenterServiceReference.Item();
        //                newItem.itemId = productId;
        //                newItem.product = product;
        //                newItem.quantity = currentQuantity;
        //                client.addItem(newItem);

        //                itemAdded = true;
        //                break;
        //            }
        //        }
        //    }

        //    if (!itemAdded)
        //    {
        //        NepalTradeCenterServiceReference.Item item = new NepalTradeCenterServiceReference.Item();
        //        item.itemId = productId;
        //        item.product = product;
        //        item.quantity = quantity;
        //        client.addItem(item);
        //    }



        //    setSession();

        //    return RedirectToAction("Index", "Product");
        //}

        public void setSession()
        {
            //List<NepalTradeCenterServiceReference.Product> shopCartList = myCartDAO.getProductList();
            List<NepalTradeCenterServiceReference.Item> itemList = client.getItemList();
            if (itemList.Count > 0)
            {
                Session["itemList"] = itemList;
                Session["quantity"] = totalItem(itemList);
            }
            else
            {
                Session["itemList"] = null;
                Session["quantity"] = null;
            }
        }

        public int totalItem(List<NepalTradeCenterServiceReference.Item> itemList)
        {
            int total = 0;
            foreach (NepalTradeCenterServiceReference.Item element in itemList)
            {
                total += element.quantity;
            }
            return total;
        }

        public ActionResult deleteItem(int itemId)
        {
            //NepalTradeCenterServiceReference.Item myItem = null;
            //List<NepalTradeCenterServiceReference.Item> itemList = client.getItemList();
            //foreach(NepalTradeCenterServiceReference.Item item in itemList)
            //{
            //    if(item.itemId.Trim() == itemId)
            //    {
            //        myItem = item;
            //    }
            //}
            client.deleteItem(itemId);
            return RedirectToAction("Index", "MyCart");

            //System.Diagnostics.Debug.WriteLine("Item to be deleted: "+myItem.itemId);
        }
    }

    [TestClass]
    public class MyCartControllerTest
    {
        
        [TestMethod]
        public void deleteItemTest()
        {
            // Arrange
            NepalTradeCenterServiceReference.NepalTradeCenterServiceClient client;
            NepalTradeCenterServiceReference.ShopCart shopCart;
            List<NepalTradeCenterServiceReference.Item> itemList;

            // Act
            client = new NepalTradeCenterServiceReference.NepalTradeCenterServiceClient();
            shopCart = client.getCart();
            itemList = client.getItemList();

            // populate cart with two items starts here

            int product1Id = 1;
            int product2Id = 2;
            NepalTradeCenterServiceReference.Product product1 = client.getProductById(product1Id);
            NepalTradeCenterServiceReference.Product product2 = client.getProductById(product2Id);

            NepalTradeCenterServiceReference.Item item1 = new NepalTradeCenterServiceReference.Item();
            item1.itemId = product1.productId;
            item1.product = product1;
            item1.quantity = product1.quantity;
            client.addItem(item1);

            NepalTradeCenterServiceReference.Item item2 = new NepalTradeCenterServiceReference.Item();
            item2.itemId = product2.productId;
            item2.product = product2;
            item2.quantity = product2.quantity;
            client.addItem(item2);
            // populate cart with two items ends here

            // delete item starts here
            // total item in shopcart is 2
            itemList = client.getItemList();
            int totalItem1 = itemList.Count;

            client.deleteItem(item1.itemId);


            // Assert
            // after deleting one item
            // total item in cart should be 1
            itemList = client.getItemList();
            int totalItem = itemList.Count;
            Assert.AreEqual(totalItem, 1);

        }

        [TestMethod]
        public void addItemTest()
        {
            // Arrange
            NepalTradeCenterServiceReference.NepalTradeCenterServiceClient client;
            NepalTradeCenterServiceReference.ShopCart shopCart;
            List<NepalTradeCenterServiceReference.Item> itemList;
            NepalTradeCenterServiceReference.Product product;

            bool itemAdded = false;
            int productId = 1;
            int quantity = 2;
            int totalItem = 0;

            // Act
            client = new NepalTradeCenterServiceReference.NepalTradeCenterServiceClient();
            shopCart = client.getCart();
            itemList = client.getItemList();
            product = client.getProductById(productId);

            // populate cart with two items starts here

            int product1Id = 1;
            int product2Id = 2;
            NepalTradeCenterServiceReference.Product product1 = client.getProductById(product1Id);
            NepalTradeCenterServiceReference.Product product2 = client.getProductById(product2Id);

            NepalTradeCenterServiceReference.Item item1 = new NepalTradeCenterServiceReference.Item();
            item1.itemId = product1.productId;
            item1.product = product1;
            item1.quantity = product1.quantity;
            client.addItem(item1);

            NepalTradeCenterServiceReference.Item item2 = new NepalTradeCenterServiceReference.Item();
            item2.itemId = product2.productId;
            item2.product = product2;
            item2.quantity = product2.quantity;
            client.addItem(item2);
            // populate cart with two items ends here

            // add item to the cart starts here
            if (itemList.Count > 0)
            {
                foreach (NepalTradeCenterServiceReference.Item item in itemList)
                {
                    if (item.itemId.Equals(productId))
                    {
                        int oldQuantity = item.quantity;
                        int currentQuantity = oldQuantity + quantity;
                        //client.setQuantityofItem(item, currentQuantity);
                        bool deleteStatus = client.deleteItem(item.itemId);

                        int size = client.getItemList().Count;

                        NepalTradeCenterServiceReference.Item newItem = new NepalTradeCenterServiceReference.Item();
                        newItem.itemId = productId;
                        newItem.product = product;
                        newItem.quantity = currentQuantity;
                        client.addItem(newItem);

                        itemAdded = true;
                        break;
                    }
                }
            }

            if (!itemAdded)
            {
                NepalTradeCenterServiceReference.Item item = new NepalTradeCenterServiceReference.Item();
                item.itemId = productId;
                item.product = product;
                item.quantity = quantity;
                client.addItem(item);
            }
            // add item to the cart ends here

            // Assert
            // I have added a item to shop cart with 2 existing item
            // so total item in shop cart should be 3
            itemList = client.getItemList();
            totalItem = itemList.Count;
            Assert.AreEqual(totalItem, 3);
        }

    }
}