using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;

namespace Eshoppen
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel_Login.Visible = false;    //For future login
            btn_ShowForm.Visible = false;   //For future login

            if (!IsPostBack)
            {
                if (!WebProfile.Current.IsAnonymous)
                {
                    //Do something if user is logged in
                    if (WebProfile.Current.Cart.Items.Count < 0)    //Makes sure that this label is only shown when something is in the cart
                    {
                        lbl_CartStatus.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }
                }
                else
                {
                    //Do something here if not logged in?
                    ShoppingCart cart = new ShoppingCart();
                    Session["Cart"] = cart;

                    if (lbl_CartStatus != null)
                    {
                        lbl_CartStatus.Text = cart.TotalPrice + "kr";
                    }
                }
            }
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            string query = txtBox_Search.Text;
            Response.Redirect("~/Sites/Search.aspx?searchstring=" + query);
        }
    }
}
