using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace NepalTradeCenterWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IProductService" in both code and config file together.
    [ServiceContract]
    public interface IProductService
    {
        [OperationContract]
        void DoWork();

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
    }
}
