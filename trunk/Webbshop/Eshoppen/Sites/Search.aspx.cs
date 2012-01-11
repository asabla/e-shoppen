using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;

namespace Eshoppen.Sites
{
    public partial class Search : System.Web.UI.Page
    {
        private string _QueryString;
        private DataTable ResultTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckSearchString();
        }

        private void CheckSearchString()
        {
            try
            {
                _QueryString = Request.QueryString["searchstring"];
                lbl_ResultString.Text = "<b>Resultat för:</b> " + _QueryString;
                MakeSearch();
            }
            catch
            {
                lbl_ResultString.Text = "Couldn't make out anything to search for. Contact support for help";
            }
        }

        private void MakeSearch()
        {
            I_EshopserviceClient client = new I_EshopserviceClient();
            
            try
            {
                ResultTable = client.GetProductsBySearch(_QueryString);

                Repeater_SearchResult.DataSource = ResultTable;
                Repeater_SearchResult.DataBind();
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Unable to send Querystring: " + _QueryString + "\nMessage: " + ex.Message);
            }

            int resultnr = 1;
            foreach (RepeaterItem item in Repeater_SearchResult.Items)
            {
                Label lbl_resultnr = (Label)item.FindControl("lbl_ResultNumber");
                lbl_resultnr.Text = "Nr: " + resultnr;

                resultnr++; //+1 foreach item
            }
        }
    }
}