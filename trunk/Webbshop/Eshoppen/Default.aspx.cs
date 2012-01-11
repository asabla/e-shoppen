using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;

namespace Eshoppen
{
    public partial class _Default : System.Web.UI.Page
    {
        private DataTable ProductTable;
        private ArrayList Productrows;
        private ArrayList ProductColumns;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductValues();

                if (!WebProfile.Current.IsAnonymous)
                {
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }
                }
            }
        }

        private void LoadProductValues()
        {
            //Show admin all products
            bool isAdmin = false;
            if (User.IsInRole("admin"))
                isAdmin = true;

            I_EshopserviceClient client = new I_EshopserviceClient();
            ProductTable = client.GetAllProductsByAmount(12, isAdmin);    //Gets the 5 latest added products

            Repeater_Products.DataSource = ProductTable;
            Repeater_Products.DataBind();

            Repeater_Slideshow.DataSource = ProductTable;
            Repeater_Slideshow.DataBind();
            
            //just to make sure that the arraylists are empty
            Productrows = new ArrayList();
            ProductColumns = new ArrayList(); 
        }
    }
}
