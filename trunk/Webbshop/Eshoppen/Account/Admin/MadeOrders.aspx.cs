using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;

namespace Eshoppen.Account.Admin
{
    public partial class MadeOrders : System.Web.UI.Page
    {
        private DataTable UnDeliveredOrders;
        private DataTable DeliveredOrders;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime today = DateTime.Today;
                Calendar_Startdate.TodaysDate = today - TimeSpan.FromDays(3);
                Calendar_Startdate.SelectedDate = Calendar_Startdate.TodaysDate;
                Calendar_Enddate.TodaysDate = today;
                Calendar_Enddate.SelectedDate = Calendar_Enddate.TodaysDate;

                LoadUnDeliveredOrders();    //And some delivered orders aswell
                LoadDeliveredOrdersByDate();
            }
        }

        private void LoadUnDeliveredOrders()
        {
            I_EshopserviceClient client = new I_EshopserviceClient();
            UnDeliveredOrders = new DataTable();
            UnDeliveredOrders = client.AdminGetOrders(false);
            //DeliveredOrders = client.AdminGetOrders(true);

            Repeater_unDelivered.DataSource = UnDeliveredOrders;
            Repeater_unDelivered.DataBind();

            //Repeater_Delivered.DataSource = DeliveredOrders;
            //Repeater_Delivered.DataBind();
        }

        private void LoadDeliveredOrdersByDate()
        {
            string startdate = Calendar_Startdate.SelectedDate.ToString();
            string enddate = Calendar_Enddate.SelectedDate.ToString();
            System.Diagnostics.Debug.WriteLine("Startdate: " + startdate + " Enddate: " + enddate);

            I_EshopserviceClient client = new I_EshopserviceClient();
            DeliveredOrders = new DataTable();
            DeliveredOrders = client.AdminGetOrdersByDate(true, startdate, enddate);
           
            Repeater_Delivered.DataSource = DeliveredOrders;
            Repeater_Delivered.DataBind();
        }

        protected void Calendar_Startdate_SelectionChanged(object sender, EventArgs e)
        {
            LoadDeliveredOrdersByDate();
        }

        protected void Calendar_Enddate_SelectionChanged(object sender, EventArgs e)
        {
            LoadDeliveredOrdersByDate();
        }
    }
}