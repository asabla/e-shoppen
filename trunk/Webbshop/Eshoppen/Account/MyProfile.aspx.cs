using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;

namespace Eshoppen.Account
{
    public partial class MyProfile : System.Web.UI.Page
    {
        private DataTable DeliveredOrders;
        private DataTable unDeliveredOrders;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!WebProfile.Current.IsAnonymous)
                {
                    LoadOrders();

                    Repeater_Delivered.DataSource = DeliveredOrders;
                    Repeater_Delivered.DataBind();

                    Repeater_unDelivered.DataSource = unDeliveredOrders;
                    Repeater_unDelivered.DataBind();

                    //Loads cartstatus
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }
                }
            }
        }

        private void LoadOrders()
        {
            I_EshopserviceClient client = new I_EshopserviceClient();
            unDeliveredOrders = client.GetOrders(WebProfile.Current.UserName, false);
            DeliveredOrders = client.GetOrders(WebProfile.Current.UserName, true);
        }
    }
}