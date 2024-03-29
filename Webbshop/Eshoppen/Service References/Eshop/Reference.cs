﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Eshoppen.Eshop {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Eshop.I_Eshopservice")]
    public interface I_Eshopservice {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetAllProducts", ReplyAction="http://tempuri.org/I_Eshopservice/GetAllProductsResponse")]
        System.Data.DataTable GetAllProducts(bool isAdmin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetProduct", ReplyAction="http://tempuri.org/I_Eshopservice/GetProductResponse")]
        System.Data.DataTable GetProduct(string ProductTitle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetProductsFromDataSet", ReplyAction="http://tempuri.org/I_Eshopservice/GetProductsFromDataSetResponse")]
        System.Data.DataTable GetProductsFromDataSet();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetSiteMap", ReplyAction="http://tempuri.org/I_Eshopservice/GetSiteMapResponse")]
        System.Data.DataTable GetSiteMap();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetAllProductsByAmount", ReplyAction="http://tempuri.org/I_Eshopservice/GetAllProductsByAmountResponse")]
        System.Data.DataTable GetAllProductsByAmount(int amountofproducts, bool isAdmin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetAllProductsOutOfStock", ReplyAction="http://tempuri.org/I_Eshopservice/GetAllProductsOutOfStockResponse")]
        System.Data.DataTable GetAllProductsOutOfStock();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetProductsBySearch", ReplyAction="http://tempuri.org/I_Eshopservice/GetProductsBySearchResponse")]
        System.Data.DataTable GetProductsBySearch(string SearchString);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetProductsByTags", ReplyAction="http://tempuri.org/I_Eshopservice/GetProductsByTagsResponse")]
        System.Data.DataTable GetProductsByTags(string current, string parent, bool isAdmin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetOrderDetails", ReplyAction="http://tempuri.org/I_Eshopservice/GetOrderDetailsResponse")]
        System.Data.DataTable GetOrderDetails(int OrderID, string OrderDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/GetOrders", ReplyAction="http://tempuri.org/I_Eshopservice/GetOrdersResponse")]
        System.Data.DataTable GetOrders(string Username, bool Delivered);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/AdminGetOrders", ReplyAction="http://tempuri.org/I_Eshopservice/AdminGetOrdersResponse")]
        System.Data.DataTable AdminGetOrders(bool Delivered);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/AdminGetOrdersByDate", ReplyAction="http://tempuri.org/I_Eshopservice/AdminGetOrdersByDateResponse")]
        System.Data.DataTable AdminGetOrdersByDate(bool delivered, string startdate, string enddate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/InsertNewOrder", ReplyAction="http://tempuri.org/I_Eshopservice/InsertNewOrderResponse")]
        void InsertNewOrder(string UserName, string Firstname, string Lastname, string City, string Address, int Zipcode, Resources.ShoppingCart Cart);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/InsertProduct", ReplyAction="http://tempuri.org/I_Eshopservice/InsertProductResponse")]
        void InsertProduct(string Title, string Info, int Quantity, string Tags, string ImgUrl, double Price);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/UpdateOrder", ReplyAction="http://tempuri.org/I_Eshopservice/UpdateOrderResponse")]
        void UpdateOrder(string username, string orderdate, bool delivered);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/I_Eshopservice/UpdateQuantity", ReplyAction="http://tempuri.org/I_Eshopservice/UpdateQuantityResponse")]
        void UpdateQuantity(string ProductTitle, int Quantity, int oldQuantity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface I_EshopserviceChannel : Eshoppen.Eshop.I_Eshopservice, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class I_EshopserviceClient : System.ServiceModel.ClientBase<Eshoppen.Eshop.I_Eshopservice>, Eshoppen.Eshop.I_Eshopservice {
        
        public I_EshopserviceClient() {
        }
        
        public I_EshopserviceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public I_EshopserviceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public I_EshopserviceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public I_EshopserviceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Data.DataTable GetAllProducts(bool isAdmin) {
            return base.Channel.GetAllProducts(isAdmin);
        }
        
        public System.Data.DataTable GetProduct(string ProductTitle) {
            return base.Channel.GetProduct(ProductTitle);
        }
        
        public System.Data.DataTable GetProductsFromDataSet() {
            return base.Channel.GetProductsFromDataSet();
        }
        
        public System.Data.DataTable GetSiteMap() {
            return base.Channel.GetSiteMap();
        }
        
        public System.Data.DataTable GetAllProductsByAmount(int amountofproducts, bool isAdmin) {
            return base.Channel.GetAllProductsByAmount(amountofproducts, isAdmin);
        }
        
        public System.Data.DataTable GetAllProductsOutOfStock() {
            return base.Channel.GetAllProductsOutOfStock();
        }
        
        public System.Data.DataTable GetProductsBySearch(string SearchString) {
            return base.Channel.GetProductsBySearch(SearchString);
        }
        
        public System.Data.DataTable GetProductsByTags(string current, string parent, bool isAdmin) {
            return base.Channel.GetProductsByTags(current, parent, isAdmin);
        }
        
        public System.Data.DataTable GetOrderDetails(int OrderID, string OrderDate) {
            return base.Channel.GetOrderDetails(OrderID, OrderDate);
        }
        
        public System.Data.DataTable GetOrders(string Username, bool Delivered) {
            return base.Channel.GetOrders(Username, Delivered);
        }
        
        public System.Data.DataTable AdminGetOrders(bool Delivered) {
            return base.Channel.AdminGetOrders(Delivered);
        }
        
        public System.Data.DataTable AdminGetOrdersByDate(bool delivered, string startdate, string enddate) {
            return base.Channel.AdminGetOrdersByDate(delivered, startdate, enddate);
        }
        
        public void InsertNewOrder(string UserName, string Firstname, string Lastname, string City, string Address, int Zipcode, Resources.ShoppingCart Cart) {
            base.Channel.InsertNewOrder(UserName, Firstname, Lastname, City, Address, Zipcode, Cart);
        }
        
        public void InsertProduct(string Title, string Info, int Quantity, string Tags, string ImgUrl, double Price) {
            base.Channel.InsertProduct(Title, Info, Quantity, Tags, ImgUrl, Price);
        }
        
        public void UpdateOrder(string username, string orderdate, bool delivered) {
            base.Channel.UpdateOrder(username, orderdate, delivered);
        }
        
        public void UpdateQuantity(string ProductTitle, int Quantity, int oldQuantity) {
            base.Channel.UpdateQuantity(ProductTitle, Quantity, oldQuantity);
        }
    }
}
