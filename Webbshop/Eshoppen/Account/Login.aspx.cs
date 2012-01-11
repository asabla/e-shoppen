using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Resources;

namespace Eshoppen.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!WebProfile.Current.IsAnonymous)
            {
                //ShoppingCart cart = new ShoppingCart();
                Resources.ShoppingCart cart = new Resources.ShoppingCart();
                WebProfile.Current.Cart = cart;
            }
        }
    }
}
