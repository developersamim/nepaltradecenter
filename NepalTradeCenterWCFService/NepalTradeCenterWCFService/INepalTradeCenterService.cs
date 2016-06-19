using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NepalTradeCenterWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    //[ServiceContract]
    public interface INepalTradeCenterService
    {
        // start shopcart
        [OperationContract]
        ShopCart newCart();

        [OperationContract]
        bool addItem(Item item);

        [OperationContract]
        Item getItem(int itemId);

        [OperationContract]
        List<Item> getItemList();

        [OperationContract]
        void setQuantityofItem(Item item, int quantity);

        [OperationContract]
        bool deleteItem(int itemID);

        [OperationContract]
        Item findItem(string productId);



        [OperationContract]
        ShopCart getCart();
        // end shopcart

        [OperationContract]
        void RunDataInitializer();

        [OperationContract]
        int insertProduct(Product product);

        [OperationContract]
        List<Product> getAllProduct();

        [OperationContract]
        Product getProductById(int productId);

        [OperationContract]
        int updateProduct(int productId, string imageAddress);

        [OperationContract]
        List<Product> getLastNProduct();

        [OperationContract]
        List<Category> getAllCategory();

        [OperationContract]
        bool checkTableExist();

        [OperationContract]
        void insertCategory(Category category);

        [OperationContract]
        List<Product> getProductListByCategoryId(int categoryId);

        [OperationContract]
        User authentiateUser(string username, string password);

        [OperationContract]
        Category getCategoryById(int categoryId);
    }
}
