using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using Resources;

namespace Eshoppen.Sites
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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

        protected override void InitializeCulture()
        {
            base.InitializeCulture();
            
            string culturecode = "en-US";

            Page.Culture = culturecode;
            Page.UICulture = culturecode;

            CultureInfo culture = CultureInfo.CreateSpecificCulture(culturecode);

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culturecode);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culturecode);
        }

        protected void btn_changeCulture_Click(object sender, EventArgs e)
        {
            
        }
    }
}