using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;
using Resources;

namespace Eshoppen.Account
{
    public partial class MadeOrders : System.Web.UI.Page
    {
        private DataTable DetailTable;
        private int Orderid = 0;
        private string OrderDate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!WebProfile.Current.IsAnonymous)
                {
                    LoadDetails();

                    //Loads cartstatus
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }
                }
            }
        }

        private void LoadDetails()
        {
            Orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            OrderDate = Request.QueryString["orderdate"];

            //For debugging
            //System.Diagnostics.Debug.WriteLine("\nOrderid: " + Orderid + "\nOrderdate: " + OrderDate + "\n\n");

            I_EshopserviceClient client = new I_EshopserviceClient();
            try
            {
                DetailTable = client.GetOrderDetails(Orderid, OrderDate);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when orderdetails was loading: " + ex.Message);
            }

            Repeater_OrderDetails.DataSource = DetailTable;
            Repeater_OrderDetails.DataBind();
        }
    }
}