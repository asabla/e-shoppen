using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;
using Resources;

namespace Eshoppen.Account
{
    public partial class Order : System.Web.UI.Page
    {
        //private ShoppingCart cart;
        private ShoppingCart cart;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!WebProfile.Current.IsAnonymous)
                {
                    cart = WebProfile.Current.Cart;
                    btn_SaveToProfile.Visible = true;

                    Repeater_cart.DataSource = cart.Items;
                    Repeater_cart.DataBind();

                    LoadProfileValues();

                    //Loads cartstatus
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }
                }
                else
                {
                    btn_SaveToProfile.Visible = false;
                }
            }
        }

        private void LoadProfileValues()
        {
            txtBox_FirstName.Text = WebProfile.Current.FirstName;
            txtBox_LastName.Text = WebProfile.Current.LastName;
            txtBox_City.Text = WebProfile.Current.City;
            txtBox_Address.Text = WebProfile.Current.Address;
            txtBox_ZipAddress.Text = WebProfile.Current.ZipCode;
        }

        protected void btn_SaveToProfile_Click(object sender, EventArgs e)
        {
            //Saves all the value to current profile
            if (!WebProfile.Current.IsAnonymous)    //just to make sure it does nothing if not logged in
            {
                WebProfile.Current.FirstName = txtBox_FirstName.Text;
                WebProfile.Current.LastName = txtBox_LastName.Text;
                WebProfile.Current.City = txtBox_City.Text;
                WebProfile.Current.Address = txtBox_Address.Text;
                WebProfile.Current.ZipCode = txtBox_ZipAddress.Text;

                Response.Redirect(Request.RawUrl);  //Reloads the site, to make sure everything was saved
            }
        }

        protected void btn_GoBackToCart_Click(object sender, EventArgs e)
        {
            //Goes back to cart
            Response.Redirect("~/Sites/Cart.aspx");
        }

        protected void btn_MakeDeal_Click(object sender, EventArgs e)
        {   
            //Make the deal
            string username = WebProfile.Current.UserName;
            string firstname = WebProfile.Current.FirstName;
            string lastname = WebProfile.Current.LastName;
            string city = WebProfile.Current.City;
            string address = WebProfile.Current.Address;
            int zipcode = Convert.ToInt32(WebProfile.Current.ZipCode);
            int totalprice = Convert.ToInt32(WebProfile.Current.Cart.TotalPrice);

            I_EshopserviceClient client = new I_EshopserviceClient();
            ShoppingCart OrderCart = new ShoppingCart();
            cart = WebProfile.Current.Cart; //Must be used for sending shoppingcart through

            OrderCart = OrderCart.CopyFrom(cart);
            System.Diagnostics.Debug.WriteLine("OrderCart: " + OrderCart.Items.Count + "varor");

            try
            {
                client.InsertNewOrder(username, firstname, lastname, city, address, zipcode, OrderCart);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong with inserting order: \n" + ex.Message);
            }

            WebProfile.Current.Cart.DeleteAllItems();
            Response.Redirect("~/Sites/StatusForm.aspx?statusid=madedeal");
        }
    }
}