using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;

namespace Eshoppen.Sites
{
    public partial class Cart : System.Web.UI.Page
    {
        //private ShoppingCart cart;
        private ShoppingCart cart;
        public string TheCart;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //cart = new ShoppingCart();
                cart = new ShoppingCart();

                if (!WebProfile.Current.IsAnonymous)
                {
                    cart = WebProfile.Current.Cart;

                    //Loads all values into the repeater
                    Repeater_cart.DataSource = cart.Items;
                    Repeater_cart.DataBind();

                    //LoadProfileValues();  //is not used anymore
                    lbl_TotalPrice.Text = cart.TotalPrice + "kr";
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = cart.TotalPrice + "kr";
                    }

                    //If cart is empty, just hide button to go forth
                    if (cart.Items.Count > 0)
                    {
                        btn_CheckForOrder.Visible = true;
                    }
                    else
                    {
                        btn_CheckForOrder.Visible = false;
                    }
                }
                else
                {
                    ShoppingCart cartFromProduct = new ShoppingCart();
                    cartFromProduct = (ShoppingCart)Session["Cart"];

                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null && cartFromProduct != null)
                    {
                        lbl_Cart.Text = cartFromProduct.TotalPrice + "kr";

                        Repeater_cart.DataSource = cartFromProduct.Items;
                        Repeater_cart.DataBind();
                    }
                }
            }
        }

        //Is not being used anymore
        private void LoadProfileValues()
        {
            TheCart = "";

            for (int i = 0; i < cart.Items.Count; i++)
            {
                int quant = cart.Items[i].Quantity;

                TheCart += "<p>Produktnamn: " + cart.Items[i].ProductName + "</p>";
                TheCart += "<p>Antal: " + cart.Items[i].Quantity + "</p>";
                //TheCart += "<p><input type='text' " +  + "</p>";
                TheCart += "<hr />";
            }

            TheCart += "Totalt: " + cart.TotalPrice + "kr";
        }

        #region OnButtonClick
        protected void btn_ClearCart_Click(object sender, EventArgs e)
        {
            if (!WebProfile.Current.IsAnonymous)
            {
                cart = WebProfile.Current.Cart;
                cart.DeleteAllItems();
                cart.TotalPrice = 0;
                WebProfile.Current.Cart = cart;

                Response.Redirect(Request.RawUrl);

                Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                if (lbl_Cart != null)
                {
                    lbl_Cart.Text = cart.TotalPrice + "kr";
                }
            }
            else
            {
                cart = (Resources.ShoppingCart)Session["ShoppingCart"];
                cart.DeleteAllItems();
                //cart.Insert(11, 23, 1, "TestProduct", "noimg");
            }
        }

        protected void btn_UpdateCart_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in Repeater_cart.Items)
            {
                Label lbl_productid = (Label)item.FindControl("lbl_ProudctID");
                TextBox txtBox_quantity = (TextBox)item.FindControl("txtBox_Quantity");

                int productid = Convert.ToInt32(lbl_productid.Text);
                int quantity = Convert.ToInt32(txtBox_quantity.Text);
                WebProfile.Current.Cart.UpdateQuantity(productid, quantity);
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void btn_CheckForOrder_Click(object sender, EventArgs e)
        {
            //Sends user to make order site
            Response.Redirect("~/Account/Order.aspx");
        }
        #endregion
    }
}