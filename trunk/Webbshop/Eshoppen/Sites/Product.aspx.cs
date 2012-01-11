using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;
using Resources;

namespace Eshoppen.Sites
{
    public partial class Product : System.Web.UI.Page
    {
        private I_EshopserviceClient client;
        private string QueryString = "";
        private int _Quantity = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //QueryString = Request.QueryString["title"];
            //LoadValues(QueryString);

            if (!IsPostBack)
            {
                QueryString = Request.QueryString["title"];
                LoadValues(QueryString);
                //lbl_TestQuery.Text = "QueryString = " + QueryString;  //Just for errorhunting

                if (!WebProfile.Current.IsAnonymous)
                {
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }

                    //Shows a little bit more information for admins
                    if (User.IsInRole("admin"))
                    {
                        btn_UpdateQuantity.Visible = true;
                        btn_UpdateQuantity.Enabled = true;
                    }
                    else
                    {
                        btn_UpdateQuantity.Visible = false;
                        btn_UpdateQuantity.Enabled = false;
                    }
                }
                else
                {
                    //Hides controls for filling up quantity
                    btn_UpdateQuantity.Visible = false;
                    btn_UpdateQuantity.Enabled = false;

                    ShoppingCart loadCart = new ShoppingCart();
                    loadCart = (ShoppingCart)Session["Cart"];

                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null && loadCart != null)
                    {
                        lbl_Cart.Text = loadCart.TotalPrice + "kr";
                    }
                }
            }
        }

        private void LoadValues(string PTitle)
        {
            client = new I_EshopserviceClient();    //Just to make sure that a new request is made each time
            DataTable table = new DataTable();

            try
            {
                table = client.GetProduct(PTitle).Copy();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong when getting product: " + ex.Message);
            }

            if (table.Rows.Count != 0)  //Last check, to make sure that the table contains values
            {
                txtbox_quantity.Visible = true;
                lbl_productnrlabel.Visible = true;
                lbl_productpricelabel.Visible = true;
                lbl_productquantitylabel.Visible = true;

                //If everything went fine, just load values into website elements
                lbl_ProductNr.Text = table.Rows[0]["PId"].ToString();
                lbl_ProductTitle.Text = table.Rows[0]["PTitle"].ToString();
                img_Product.ImageUrl = table.Rows[0]["PImgurl"].ToString();
                //img_Product.ImageUrl = "~/imgs/products/no_image.jpg";
                img_Product.DescriptionUrl = "En bild på " + table.Rows[0]["PTitle"].ToString();
                
                double price = Convert.ToDouble(table.Rows[0]["PPrice"].ToString());
                lbl_ProductPrice.Text = price.ToString();
                
                _Quantity = Convert.ToInt32(table.Rows[0]["PInStock"]);
                lbl_ProductInStock.Text = "" + _Quantity;
                lbl_ProductInfo.Text = table.Rows[0]["PInfo"].ToString();

                //Makes it impossible for users add to cart if quantity is 0
                if (_Quantity == 0)
                {
                    btn_addToCart.Enabled = false;
                }
                else
                {
                    btn_addToCart.Enabled = true;
                }
            }
            else
            {
                btn_addToCart.Visible = false;  //Hides button for add to cart
                lbl_ProductTitle.Text = "Produkten finns inte!";
                lbl_ProductInfo.Text = "Kontrollera sökvägen igen, eller kontakta supporten för hjälp";
                txtbox_quantity.Visible = false;
                lbl_productnrlabel.Visible = false;
                lbl_productpricelabel.Visible = false;
                lbl_productquantitylabel.Visible = false;
            }
            //lbl_ProductTitle.Text = "Nu fungerar det inte" + "<br />Värdet: " + PTitle;    //used with errorhunting
        }

        protected void btn_addToCart_Click(object sender, EventArgs e)
        {
            int productNr = Convert.ToInt32(lbl_ProductNr.Text);
            double price = Convert.ToDouble(lbl_ProductPrice.Text);
            int quantity = 1;
            string productName = lbl_ProductTitle.Text;

            if (txtbox_quantity.Text != "")
                quantity = Convert.ToInt32(txtbox_quantity.Text);

            if (!WebProfile.Current.IsAnonymous)
            {
                ShoppingCart cart = new ShoppingCart();
                cart = WebProfile.Current.Cart;
                cart.Insert(productNr, price, quantity, productName, "");
                WebProfile.Current.Cart = cart;
                
                Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                if (lbl_Cart != null)
                {
                    lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                }
            }
            else
            {
                //If current user is not logged in, then it tries to save shoppingcart in session
                try
                {
                    ShoppingCart sendCart = new ShoppingCart();
                    sendCart = (ShoppingCart)Session["Cart"];
                    sendCart.Insert(productNr, price, quantity, productName, "");
                    Session["Cart"] = sendCart;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Something went wrong with adding items to cart: " + ex.Message);
                }
            }

            Response.Redirect("~/Sites/Cart.aspx");
        }

        protected void btn_UpdateQuantity_Click(object sender, EventArgs e)
        {
            if (User.IsInRole("admin"))
            {
                int quantity = Convert.ToInt32(txtbox_quantity.Text);
                int oldquantity = Convert.ToInt32(lbl_ProductInStock.Text);
                string productTitle = lbl_ProductTitle.Text;

                //For debugging
                //System.Diagnostics.Debug.WriteLine("In stock: " + oldquantity);

                I_EshopserviceClient client = new I_EshopserviceClient();
                client.UpdateQuantity(productTitle, quantity, oldquantity);

                Response.Redirect(Request.RawUrl);  //reloads the page
            }
        }
    }
}