using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eshoppen.Sites
{
    public partial class StatusForm : System.Web.UI.Page
    {
        private string StatusText = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string statusid = Request.QueryString["statusid"];
                if (statusid.Equals("madedeal"))
                {
                    LoadDealValues();
                }

                if (!WebProfile.Current.IsAnonymous)
                {
                    //Loads cartstatus
                    Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
                    if (lbl_Cart != null)
                    {
                        lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
                    }
                }
            }
        }

        /// <summary>
        /// Loads values for a newly maked deal
        /// </summary>
        private void LoadDealValues()
        {
            StatusText = "Grattis! Du har nu genomfört ditt köp! Och borde även ha mottagit ett kvitto via mail.\n";
            StatusText += "Du kommer även få ännu ett mail så fort allting är klart för nedladdning.";
            StatusText += "Där instruktioner för hur du laddar ner din mjukvara skall gå till.";
            lbl_Status.Text = StatusText;
        }
    }
}