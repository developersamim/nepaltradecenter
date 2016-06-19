using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    public class ShopCart
    {
        private List<Item> itemList;

        public ShopCart()
        {
            itemList = new List<Item>();
        }

        public void addItem(Item item)
        {
            itemList.Add(item);
        }
        public List<Item> getItemList()
        {
            return itemList;
        }
        public bool deleteItem(int itemID)
        {
            Item myItem = itemList.Where(i => i.itemId == itemID).SingleOrDefault();
            return itemList.Remove(myItem);
        }
    }
}