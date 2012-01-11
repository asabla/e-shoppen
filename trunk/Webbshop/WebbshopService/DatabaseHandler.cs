using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Resources;

namespace WebbshopService
{
    /// <summary>
    /// All consolecommands are still there, for the simple reason of being multipurpose
    /// </summary>
    public class DatabaseHandler
    {
        #region Definitions and variables
        private SqlCommand SqlCmd = null;
        private SqlConnection SqlCon = null;
        private SqlDataReader SqlReader = null;
        private SqlDataAdapter SqlAdapter = null;

        private string ConnectionString { get; set; }
        private string Datasource { get; set; }
        private string InitialCatalog { get; set; }
        private string IntegratedSecurity { get; set; }

        private string DefaultConnectionString { get; set; }
        private ShoppingCart Cart { get; set; }
        
        #endregion

        //Cunstructor, with a default connection string
        public DatabaseHandler()
        {
            //This is a intern ip-adress. So change it to your own needs
            this.ConnectionString = "Data Source=10.11.0.23;Initial Catalog=WebbshopDB;Persist Security Info=True;User ID=Webbservice;Password=Google123";
        }

        #region Connect 'n Close Connections
        /// <summary>
        /// Connects to the database
        /// </summary>
        /// <returns>Returns true if everything went fine</returns>
        private bool ConnectToDB()
        {
            Console.WriteLine("Try connect to database....");
            try
            {
                this.SqlCon = new SqlConnection(this.ConnectionString);
                this.SqlCon.Open(); //Opens the connection
                Console.WriteLine("Connected!");
                return true;
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("Could not connect to database....\nReason: " + sqlEx);
                return false;
            }
        }

        /// <summary>
        /// Closes down the connection to the database
        /// </summary>
        /// <returns>Returns true if the connection was closed</returns>
        private bool CloseConnection()
        {
            if (this.SqlCon != null)
            {
                Console.WriteLine("Closing down the connection to database....");
                this.SqlCon.Close();
                Console.WriteLine("Connection closed!");
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Other functions
        /// <summary>
        /// Makes sure that no injections or faulty commands find it's way in a select clause
        /// </summary>
        /// <param name="StringToCheck">String to be checked</param>
        /// <returns>True if everything is fine</returns>
        private bool CheckString(string StringToCheck)
        {
            if (StringToCheck.ToUpper().Contains("INSERT"))
            {
                Console.WriteLine("Don't use inserts when you try to select!");
                return false;
            }
            else if (StringToCheck.ToUpper().Contains("DELETE"))
            {
                Console.WriteLine("Don't use delete when you try to select!");
                return false;
            }
            else
            {
                //If everything is fine, just send it back!
                return true;
            }
        }

        /// <summary>
        /// Returns a single result, 
        /// </summary>
        /// <param name="column">The column to get value from</param>
        /// <param name="Table">From Which table</param>
        /// <param name="WhereClause">If you need to find a specific value</param>
        /// <returns>Returns a string with the result</returns>
        public string SelectSingleValue(string column, string Table, string WhereClause=null)
        {
            string result = null;
            string Command = "SELECT " + column + " FROM " + Table;
            if (WhereClause != null)    //Adds the whereclause if there is one
            {
                Command += " WHERE " + WhereClause;
            }

            if (CheckString(Command))   //Checks for wrong sqlcommands
            {
                try
                {
                    ConnectToDB();
                    this.SqlCmd = new SqlCommand(Command, this.SqlCon);
                    result = Convert.ToString(this.SqlCmd.ExecuteScalar()); //Only gets a single result
                }
                finally
                {
                    CloseConnection();
                }
            }
            return result;
        }
        #endregion

        #region All the gets
        /// <summary>
        /// Gets all products (without any kind of order)
        /// </summary>
        /// <returns>A datatable filled with products</returns>
        public DataTable GetAllProducts(bool isAdmin)
        {
            ConnectToDB();
            string command = "SELECT * FROM Products ";
            if (!isAdmin)
                command += "WHERE PInstock >= 1 ";
            command += "ORDER BY PTitle";

            SqlDataAdapter adapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConnection();

            return table;   //Returns a table filled with values
        }

        public DataTable GetAllProductsByAmount(int amountofproducts, bool isAdmin)
        {
            ConnectToDB();
            string command = "SELECT TOP " + amountofproducts + " * FROM Products ";
            if (!isAdmin)
                command += "WHERE PInstock >= 1";
            command += " ORDER BY PId DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConnection();

            return table;   //Returns a table filled with values
        }

        public DataTable GetAllProductsOutOfStock()
        {
            ConnectToDB();
            string command = "SELECT * FROM Products WHERE PInStock<=0";
            SqlAdapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            SqlAdapter.Fill(table);
            CloseConnection();

            return table;
        }

        //Is not used anymore?
        public DataTable GetProductsFromDataset()
        {
            DataTable table = new DataTable();
            WebShopDataSet.ProductsDataTable productsDataSet = new WebShopDataSet.ProductsDataTable();
            table = productsDataSet;
            return table;
        }

        /// <summary>
        /// Get a product with a specific title, with all it's values
        /// </summary>
        /// <param name="ProductTitle">The title of the product</param>
        /// <returns>A table with the everything for the product</returns>
        public DataTable GetProduct(string ProductTitle)
        {
            ConnectToDB();
            string command = "SELECT * FROM Products WHERE PTitle='" + ProductTitle + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConnection();

            return table;   
        }

        /// <summary>
        /// Triees to get all categorys //Is not used anymore
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllCategorys()
        {
            ConnectToDB();
            string command = "SELECT * FROM Categorys";
            SqlDataAdapter adapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConnection();

            return table;
        }

        public DataTable GetProductsBySearch(string SearchString)
        {
            ConnectToDB();
            string command = "SELECT * FROM Products WHERE ";
            command += "PTitle LIKE '%" + SearchString + "%' ";
            command += "OR PTags LIKE '%" + SearchString + "%'";

            SqlAdapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            SqlAdapter.Fill(table);
            CloseConnection();

            return table;
        }

        /// <summary>
        /// Returns a datatable with matching results. So if you want all products from microsoft, just add it to 
        /// the stringarray.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public DataTable GetProductsByTags(string current, string parent, bool isAdmin)
        {
            ConnectToDB();
            string command = "SELECT * FROM Products WHERE ";

            #region Old code
            //int itemp = 0;
            //foreach (string s in Tags)
            //{
            //    //Makes sures that no null och emptyexceptions is being made
            //    if (String.IsNullOrEmpty(s))
            //    {
            //        //Just to make sure that sqlcommands adepts for every tag it should match
            //        if (itemp == 0)
            //        {
            //            command += "PTags LIKE '%" + s + "%' ";
            //        }
            //        else
            //        {
            //            command += " AND PTags LIKE '%" + s + "%'";
            //        }
            //    }
            //}
            #endregion

            command += "PTags LIKE '%" + current + "%' ";
            if (!parent.Equals("") || parent != null)
            {
                command += " AND PTags LIKE '%" + parent + "%'";
            }

            if(!isAdmin)
                command += " AND PInstock >= 1";
            
            //For debugging
            //System.Diagnostics.Debug.WriteLine("Command: " + command);

            SqlDataAdapter adapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConnection();

            return table;
        }

        /// <summary>
        /// Gets the sitemap in a datatable, which is later used by the custom sitemapprovider
        /// </summary>
        /// <returns></returns>
        public DataTable GetSiteMap()
        {
            ConnectToDB();
            string command = "SELECT * FROM SiteMap ORDER BY Title";
            SqlDataAdapter adapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);
            CloseConnection();

            return table;
        }

        public DataTable GetOrderDetails(int OrderID, string OrderDate)
        {
            #region OldCommand
            //int deliveredVal = 0;
            //if (delivered)
            //{
            //    deliveredVal = 1;
            //}
            //Old command - didn't work as it should (dumb code)
            //string command = "SELECT * FROM Products ";
            //command += "INNER JOIN OrderProducts ON Products.PId=OrderProducts.productId ";
            //command += "INNER JOIN Orders ON OrderProducts.productId=Orders.id ";
            //command += "WHERE Orders.username='" + username + "' AND delivered=" + deliveredVal + " ";
            //command += "AND 
            #endregion

            string command = "SELECT * FROM Products ";
            command += "INNER JOIN OrderProducts ON Products.PId=OrderProducts.productId ";
            command += "WHERE OrderProducts.orderId=" + OrderID + " ";
            command += "AND OrderProducts.orderdate='" + OrderDate + "'";

            System.Diagnostics.Debug.WriteLine("\nDatabasehandler, Getorderdetails: " + command + "\n\n");

            ConnectToDB();
            SqlAdapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            SqlAdapter.Fill(table);
            CloseConnection();

            return table;
        }

        public DataTable GetOrders(string username, bool delivered)
        {
            int deliveredVal = 0;
            if (delivered)
            {
                deliveredVal = 1;
            }

            string command = "SELECT * FROM Orders WHERE username='" + username + "' AND delivered=" + deliveredVal;

            ConnectToDB();
            SqlAdapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            SqlAdapter.Fill(table);
            CloseConnection();

            return table;
        }

        public DataTable AdminGetOrders(bool delivered)
        {
            int deliveredVal = 0;
            if (delivered)
            {
                deliveredVal = 1;
            }

            string command = "SELECT * FROM orders WHERE delivered=" + deliveredVal;

            ConnectToDB();
            SqlAdapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            SqlAdapter.Fill(table);
            CloseConnection();

            return table;
        }

        public DataTable AdminGetOrdersByDate(bool delivered, string startdate, string enddate)
        {
            int deliveredVal = 0;
            if (delivered)
            {
                deliveredVal = 1;
            }

            string command = "SELECT * FROM orders WHERE orderdate BETWEEN '" + startdate + "' AND '" + enddate + "' ";
            command += "AND delivered=" + deliveredVal;

            ConnectToDB();
            SqlAdapter = new SqlDataAdapter(command, this.ConnectionString);
            DataTable table = new DataTable();
            SqlAdapter.Fill(table);
            CloseConnection();

            return table;
        }
        #endregion

        #region Updates
        public void UpdateOrder(string username, string orderdate, bool delivered)
        {
            //Makes it possible to change status for a order
            int deliveredVal = 0;
            if (delivered)
            {
                deliveredVal = 1;
            }

            string command = "UPDATE Orders SET delivered=" + deliveredVal + " ";
            command += "WHERE username='" + username + "' AND orderdate='" + orderdate + "'";

            try
            {
                ConnectToDB();
                this.SqlCmd = new SqlCommand(command, this.SqlCon);
                this.SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to update order: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateQuantity(string ProductTitle, int Quantity, int oldQuantity)
        {
            int newQuantity = Quantity + oldQuantity;
            string command = "UPDATE Products SET PInStock=" + newQuantity + " ";
            command += "WHERE PTitle='" + ProductTitle + "'";

            try
            {
                ConnectToDB();
                this.SqlCmd = new SqlCommand(command, this.SqlCon);
                this.SqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Couldn't update quantity for product: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region Inserts
        public void InsertOrder(string UserName, DateTime OrderDate, int Delivered, string Firstname, string Lastname, string City, string Address, int Zipcode, ShoppingCart cart)
        {
            try
            {
                Cart = new ShoppingCart();
                Cart = Cart.CopyFrom(cart);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Could not Copy information from Cart (In Databasehandler)! " + ex.Message);
            }

            string TodayDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            string cmd_InsertOrder = "INSERT INTO orders ";
            cmd_InsertOrder += "(username, orderdate, delivered, firstname, lastname, city, address, zipcode, totalprice) ";
            cmd_InsertOrder += "VALUES ('" + UserName + "', '" + TodayDate +"', " + Delivered + ", '" +
                                    Firstname + "', '" + Lastname + "', '" + City + "', '" + Address + "', " +
                                    Zipcode + ", " + Cart.TotalPrice + ")";

            System.Diagnostics.Debug.WriteLine("Insertorder: " + cmd_InsertOrder + "\n\n\n");

            ArrayList arCommandList = new ArrayList();

            foreach (CartItem item in cart.Items)
            {
                string cmd_InsertProductOrder = "INSERT INTO orderproducts ";
                cmd_InsertProductOrder += "(productid, orderid, quantity, orderdate) ";
                cmd_InsertProductOrder += "VALUES (" + item.ProductID + ", ";

                //Gets the right orderid from orders
                cmd_InsertProductOrder += "(SELECT id FROM orders WHERE username='" + UserName + "' AND orderdate='" + OrderDate + "'), ";
                cmd_InsertProductOrder += item.Quantity + ", '" + TodayDate + "')";

                System.Diagnostics.Debug.WriteLine("Item: " + cmd_InsertProductOrder + "\n\n");
                arCommandList.Add(cmd_InsertProductOrder);
            }

            ConnectToDB();

            try
            {
                this.SqlCmd = new SqlCommand(cmd_InsertOrder, this.SqlCon);
                this.SqlCmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("New Order inserted!");

                foreach (string s in arCommandList)
                {
                    try
                    {
                        this.SqlCmd = new SqlCommand(s, this.SqlCon);
                        this.SqlCmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine("A new product has been added to OrderProducts");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error while inserting new orderpdruct: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error while inserting new order: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void InsertProduct(string Title, string Info, int Quantity, string Tags, string ImgUrl, double Price)
        {
            string Today = DateTime.Now.ToString("yyyy-MM-dd");
            string InsertCommand = "INSERT INTO Products ";
            InsertCommand += "(PTitle, PInfo, PInStock, PTags, PImgurl, PDate, PPrice) ";
            InsertCommand += "VALUES ('" + Title + "', '" + Info + "'," + Quantity + ", '" + Tags
                            + "', '" + ImgUrl + "', '" + Today + "', " + Price + ")";

            try
            {
                ConnectToDB();
                SqlCmd = new SqlCommand(InsertCommand, SqlCon);
                SqlCmd.ExecuteNonQuery();
                System.Diagnostics.Debug.WriteLine("Inserted a new product!");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when trying to insert a new product: " + ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region TestFunctions
        //Will not be accessed by anyone except with first test
        private void PrintAllTestNames()    //A test function to make sure it works
        {
            try
            {
                ConnectToDB();
                DataSet dataset = new DataSet();
                DataTable datatable = new DataTable();
                this.SqlAdapter = new SqlDataAdapter();

                this.SqlCmd.CommandText = "SELECT name FROM TestTable";
                this.SqlAdapter.SelectCommand = this.SqlCmd;
                this.SqlAdapter.Fill(dataset, "SQL Names");
                this.SqlAdapter.Dispose();

                datatable = dataset.Tables[0];
                DataRow datarow = datatable.Rows[0];
                Console.WriteLine("Datarow: " + datarow["name"]);   //Hämtar första

                int itemp = 0;
                foreach (DataRow row in datatable.Rows)
                {
                    Console.WriteLine("Nr: " + itemp + " Name: " + row["name"]);    //Hämtar alla
                    itemp++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion
    }
}
