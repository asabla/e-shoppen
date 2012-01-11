using System;
using System.Collections;
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
    public class Eshopservice : I_Eshopservice
    {
        private DatabaseHandler DBH = new DatabaseHandler();
        private DataSet dataset = null;
        private DataTable table = null;

        public Eshopservice()
        {
            //Do something here later on
        }

        public DataTable GetAllProducts(bool isAdmin)
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.GetAllProducts(isAdmin));
                //table = DBH.GetAllProducts().Copy();  //Används inte längre....
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to get all products: " + ex.Message);
            }

            return dataset.Tables[0];
        }

        public DataTable GetAllProductsByAmount(int amountofproducts, bool isAdmin)
        {
            dataset = new DataSet();

            try
            {
                dataset.Tables.Add(DBH.GetAllProductsByAmount(amountofproducts, isAdmin));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to get all products by amount: " + ex.Message);
            }

            return dataset.Tables[0];
        }

        public DataTable GetProduct(string ProductTitle)
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.GetProduct(ProductTitle));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong with getting product: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public DataTable GetProductsFromDataSet()
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.GetProductsFromDataset());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to get all products: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public DataTable GetSiteMap()
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.GetSiteMap());
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to get all products: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public DataTable GetProductsByTags(string current, string parent, bool isAdmin)
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.GetProductsByTags(current, parent, isAdmin));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when finding products by tags: " + ex.Message);
            }

            return dataset.Tables[0];
            //http://www.homeandlearn.co.uk/csharp/csharp_s16p1.html
        }

        public void InsertNewOrder(string UserName, string Firstname, string Lastname, string City, string Address, int Zipcode, ShoppingCart Cart)
        {
            DateTime orderDate = DateTime.Now;
            System.Diagnostics.Debug.WriteLine("TotalPrice of Cart: " + Cart.TotalPrice);
            DBH.InsertOrder(UserName, orderDate, 0, Firstname, Lastname, City, Address, Zipcode, Cart);
        }


        public DataTable GetOrderDetails(int OrderID, string OrderDate)
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.GetOrderDetails(OrderID, OrderDate));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to find orderDetails: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public DataTable GetOrders(string Username, bool Delivered)
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.GetOrders(Username, Delivered));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to find orders: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public DataTable AdminGetOrders(bool Delivered)
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.AdminGetOrders(Delivered));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to find adminorders: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public void UpdateOrder(string username, string orderdate, bool delivered)
        {
            try
            {
                DBH.UpdateOrder(username, orderdate, delivered);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in the service " + ex.Message);
            }
        }


        public DataTable AdminGetOrdersByDate(bool delivered, string startdate, string enddate)
        {
            dataset = new DataSet();
            table = new DataTable();

            try
            {
                dataset.Tables.Add(DBH.AdminGetOrdersByDate(delivered, startdate, enddate));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to get adminorders by date\n" + ex.Message + "\n\n");
            }

            return dataset.Tables[0];
        }


        public void UpdateQuantity(string ProductTitle, int Quantity, int oldQuantity)
        {
            try
            {
                DBH.UpdateQuantity(ProductTitle, Quantity, oldQuantity);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to update quantity for product: " + ex.Message);
            }
        }


        public DataTable GetProductsBySearch(string SearchString)
        {
            dataset = new DataSet();

            try
            {
                dataset.Tables.Add(DBH.GetProductsBySearch(SearchString));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when a search was made: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public DataTable GetAllProductsOutOfStock()
        {
            dataset = new DataSet();

            try
            {
                dataset.Tables.Add(DBH.GetAllProductsOutOfStock());
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to get all products outofstock: " + ex.Message);
            }

            return dataset.Tables[0];
        }


        public void InsertProduct(string Title, string Info, int Quantity, string Tags, string ImgUrl, double Price)
        {
            try
            {
                DBH.InsertProduct(Title, Info, Quantity, Tags, ImgUrl, Price);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong in the server: " + ex.Message);
            }
        }
    }
}