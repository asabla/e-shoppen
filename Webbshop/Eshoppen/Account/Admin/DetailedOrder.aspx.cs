using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;

namespace Eshoppen.Account.Admin
{
    public partial class DetailedOrder : System.Web.UI.Page
    {
        private DataTable OrderTable;
        private int Orderid = 0;
        private string OrderDate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbl_CheckStatus.Visible = false;
                LoadOrderDetails();
            }
        }

        private void LoadOrderDetails()
        {
            Orderid = Convert.ToInt32(Request.QueryString["orderid"]);
            OrderDate = Request.QueryString["orderdate"];

            I_EshopserviceClient client = new I_EshopserviceClient();
            OrderTable = client.GetOrderDetails(Orderid, OrderDate);

            Repeater_OrderDetails.DataSource = OrderTable;
            Repeater_OrderDetails.DataBind();
        }

        protected void btn_UpdateOrder_Click(object sender, EventArgs e)
        {
            //Makes sure that not both values are selected
            if (CheckBoxList_Update.Items[0].Selected && CheckBoxList_Update.Items[1].Selected)
            {
                lbl_CheckStatus.Text = "Du kan bara ange ett alternativ";
                lbl_CheckStatus.Visible = true;
            }
            else
            {
                I_EshopserviceClient client = new I_EshopserviceClient();
                string username = Request.QueryString["user"];
                string orderdate = Request.QueryString["orderdate"];

                //Just to be extra sure that right values are being inserted    
                if (CheckBoxList_Update.Items[0].Selected)
                {
                    client.UpdateOrder(username, orderdate, true);
                    System.Diagnostics.Debug.WriteLine("Order flyttad till levererade");
                }
                else if(CheckBoxList_Update.Items[1].Selected)
                {
                    client.UpdateOrder(username, orderdate, false);
                    System.Diagnostics.Debug.WriteLine("Order flyttad till ej levererade");
                }

                Response.Redirect("~/Account/Admin/MadeOrders.aspx");
            }
        }
    }
}