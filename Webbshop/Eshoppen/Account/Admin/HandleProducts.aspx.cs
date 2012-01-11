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
    public partial class HandleProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Do something here
                LoadValues();
            }
        }

        private void LoadValues()
        {
            I_EshopserviceClient client = new I_EshopserviceClient();
            DataTable table = new DataTable();
            table = client.GetAllProductsOutOfStock();

            Repeater_OutOfStock.DataSource = table;
            Repeater_OutOfStock.DataBind();
        }

        protected void btn_UpdateProducts_Click(object sender, EventArgs e)
        {
            I_EshopserviceClient client = new I_EshopserviceClient();

            foreach (RepeaterItem item in Repeater_OutOfStock.Items)
            {
                TextBox QuantityBox = new TextBox();
                QuantityBox = (TextBox)item.FindControl("txtBox_Quantity");
                int quantity = Convert.ToInt32(QuantityBox.Text);

                Label lbl_ProductTitle = new Label();
                lbl_ProductTitle = (Label)item.FindControl("lbl_ProductTitle");
                string productName = lbl_ProductTitle.Text;

                client.UpdateQuantity(productName, quantity, 0);
            }

            Response.Redirect(Request.RawUrl);
        }
    }
}