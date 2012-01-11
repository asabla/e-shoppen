using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eshoppen.Account
{
    public partial class Settings : System.Web.UI.Page
    {
        #region Could be used later on
        private string FirstName = null;
        private string LastName = null;
        private string City = null;
        private string Address = null;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfile();

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

        private void LoadProfile()
        {
            txtBox_Firstname.Text = WebProfile.Current.FirstName;
            txtBox_Lastname.Text = WebProfile.Current.LastName;
            txtBox_City.Text = WebProfile.Current.City;
            txtBox_Address.Text = WebProfile.Current.Address;
            txtBox_ZipCode.Text = WebProfile.Current.ZipCode;

            txtBox_Firstname.Text = WebProfile.Current.FirstName;

            Label lbl_Cart = (Label)Master.FindControl("lbl_CartStatus");
            if (lbl_Cart != null)
            {
                lbl_Cart.Text = WebProfile.Current.Cart.TotalPrice + "kr";
            }
        }

        protected void btn_SaveSettings_Click(object sender, EventArgs e)
        {
            WebProfile.Current.FirstName = txtBox_Firstname.Text;
            WebProfile.Current.LastName = txtBox_Lastname.Text;
            WebProfile.Current.City = txtBox_City.Text;
            WebProfile.Current.Address = txtBox_Address.Text;
            WebProfile.Current.ZipCode = txtBox_ZipCode.Text;
        }
    }
}