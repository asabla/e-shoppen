using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;
using Resources;

namespace Eshoppen.Sites
{
    public partial class Products : System.Web.UI.Page
    {
        private string QueryString { get; set; }
        private string CurrentNode { get; set; }
        private string ParentNode { get; set; }
        private ShoppingCart cart;

        protected void Page_Load(object sender, EventArgs e)
        {
            QueryString = Request.QueryString["catid"]; //Reads current query (for later use?)

            if (!IsPostBack)
            {
                //If querystring is empty or null, it will load all values. If not just load the right ones
                if (QueryString != "all")
                {
                    //lbl_webbService.Text = QueryString;   //Felsökningssträng
                    
                    SiteMapPath path = new SiteMapPath();
                    //If no provider is specified, then it will use the default in web.config

                    //Needed this try 'n catch. Or else it wouldn't set any values at all
                    try
                    {
                        CurrentNode = path.Provider.CurrentNode.ToString();
                        #region Old code
                        ///Region is really not needed. Function for finding parts of producs is handled by the server instead
                        //if (!path.Provider.GetParentNode(path.Provider.CurrentNode).ToString().ToLower().Equals("alla kategorier"))
                        //{
                        //    //if parent node equals 'Alla kategorier' then send through null/nothing
                        //    ParentNode = path.Provider.GetParentNode(path.Provider.CurrentNode).ToString();
                        //}
                        //else
                        //{
                        //    ParentNode = "";
                        //}
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Something went wrong with current nodes: " + ex);
                    }

                    LoadData(CurrentNode, "");    //Loads all products
                }
                else
                {
                    //lbl_webbService.Text = "Webbservice: ";   //Makes sure that the service actually works
                    LoadData(); //Loads all products
                }

                //Updates shoppingcart if user is logged in
                if (!WebProfile.Current.IsAnonymous)
                {
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }
                }
                else
                {
                    
                }
            }
        }

        /// <summary>
        /// Loads all products to be shown
        /// </summary>
        private void LoadData()
        {
            //Shows all products for admins
            bool isAdmin = false;
            if (User.IsInRole("admin"))
                isAdmin = true;

            I_EshopserviceClient client = new I_EshopserviceClient();
            DataTable table = new DataTable();

            try
            {
                //lbl_webbService.Text += client.Test();    //Makes sure that the service actually works
                table = client.GetAllProducts(isAdmin).Copy();
                //table = client.GetProductsFromDataSet().Copy();   //Should be used later
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Errormessage: " + ex.Message);
            }
            Repeater1.DataSource = table;
            Repeater1.DataBind();

            //lbl_querystring.Text = table.Rows[0]["PTitle"].ToString();
        }

        /// <summary>
        /// Loads all products that matches the current node
        /// </summary>
        /// <param name="current">Tell webbservice which products to get</param>
        /// <param name="parent">Ignore this, no longer used</param>
        private void LoadData(string current, string parent)
        {
            //Shows all products for admins
            bool isAdmin = false;
            if (User.IsInRole("admin"))
                isAdmin = true;

            I_EshopserviceClient client = new I_EshopserviceClient();
            DataTable table = new DataTable();

            try
            {
                table = client.GetProductsByTags(current, parent, isAdmin);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error message: " + ex.Message);
            }

            Repeater1.DataSource = table;
            Repeater1.DataBind();
        }
    }
}