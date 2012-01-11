using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Resources;

namespace WebbshopService
{
    [ServiceContract]
    public interface I_Eshopservice
    {
        [OperationContract]
        DataTable GetAllProducts(bool isAdmin);

        [OperationContract]
        DataTable GetProduct(string ProductTitle);

        [OperationContract]
        DataTable GetProductsFromDataSet();

        [OperationContract]
        DataTable GetSiteMap();

        [OperationContract]
        DataTable GetAllProductsByAmount(int amountofproducts, bool isAdmin);

        [OperationContract]
        DataTable GetAllProductsOutOfStock();

        [OperationContract]
        DataTable GetProductsBySearch(string SearchString);

        [OperationContract]
        DataTable GetProductsByTags(string current, string parent, bool isAdmin);

        [OperationContract]
        DataTable GetOrderDetails(int OrderID, string OrderDate);

        [OperationContract]
        DataTable GetOrders(string Username, bool Delivered);

        [OperationContract]
        DataTable AdminGetOrders(bool Delivered);

        [OperationContract]
        DataTable AdminGetOrdersByDate(bool delivered, string startdate, string enddate);

        [OperationContract]
        void InsertNewOrder(string UserName, string Firstname, string Lastname, string City, string Address, int Zipcode, ShoppingCart Cart);

        [OperationContract]
        void InsertProduct(string Title, string Info, int Quantity, string Tags, string ImgUrl, double Price);

        [OperationContract]
        void UpdateOrder(string username, string orderdate, bool delivered);

        [OperationContract]
        void UpdateQuantity(string ProductTitle, int Quantity, int oldQuantity);
    }
}
