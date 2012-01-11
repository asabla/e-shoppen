using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eshoppen.Eshop;

//http://www.codeproject.com/KB/aspnet/ajaxfileupload.aspx
//http://msdn.microsoft.com/en-us/library/ms227669%28v=VS.85%29.aspx

namespace Eshoppen.Account.Admin
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            else if (IsPostBack)
            {
                uploadImage();
            }
        }

        private void uploadImage()
        {
            bool fileOk = false; //Used to check if file is ok
            string imgPath = "~/imgs/products/";
            FileUpload imageupload = new FileUpload();
            imageupload = (FileUpload)FormView_newProduct.FindControl("ImageUpload");
            Label lbl_status = new Label();
            lbl_status = (Label)FormView_newProduct.FindControl("lbl_ImgStatus");

            if (imageupload.HasFile)
            {
                string imageExtension = System.IO.Path.GetExtension(imageupload.FileName).ToLower();
                string[] approvedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < approvedExtensions.Length; i++)
                {
                    if (imageExtension == approvedExtensions[i])
                    {
                        //If filetype is ok, the continue
                        fileOk = true;
                    }
                }

                if (fileOk)
                {
                    try
                    {
                        imageupload.PostedFile.SaveAs(Server.MapPath(imgPath + imageupload.FileName));
                    }
                    catch (Exception ex)
                    {
                        lbl_status.Text = "Unable to upload image";
                        System.Diagnostics.Debug.WriteLine("Something went wrong with the fileupload: " + ex.Message);
                    }
                }
                else
                {
                    lbl_status.Text = "Wrong type of image";
                }
            }
        }

        private void InsertProduct(string Title, string Info, int Quantity, string Tags, string ImgUrl, double Price)
        {
            I_EshopserviceClient client = new I_EshopserviceClient();
            try
            {
                client.InsertProduct(Title, Info, Quantity, Tags, ImgUrl, Price);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Couldn't send insertvalues");
            }
        }

        protected void btn_InsertImage_Click(object sender, EventArgs e)
        {
            FileUpload imageupload = new FileUpload();
            imageupload = (FileUpload)FormView_newProduct.FindControl("ImageUpload");
            TextBox PTitle = new TextBox();
            PTitle = (TextBox)FormView_newProduct.FindControl("txtBox_PTitle");
            TextBox PInfo = new TextBox();
            PInfo = (TextBox)FormView_newProduct.FindControl("txtBox_PInfo");
            TextBox PQuantity = new TextBox();
            PQuantity = (TextBox)FormView_newProduct.FindControl("txtBox_PQuantity");
            TextBox PTags = new TextBox();
            PTags = (TextBox)FormView_newProduct.FindControl("txtBox_PTags");
            TextBox PPrice = new TextBox();
            PPrice = (TextBox)FormView_newProduct.FindControl("txtBox_PPrice");

            string title = PTitle.Text;
            string info = PInfo.Text;
            int quantity = Convert.ToInt32(PQuantity.Text);
            string tags = PTags.Text;
            string imgurl = "";
            double price = Convert.ToDouble(PPrice.Text);

            if (imageupload.FileName == null)
            {
                imgurl = "~/imgs/products/no_image.jpg";
            }
            else
            {
                imgurl = "~/imgs/products/" + imageupload.FileName;
            }

            //InsertProduct(title, info, quantity, tags, imgurl, price);
            Label1.Text = imgurl = "~/imgs/products/" + imageupload.FileName;
        }
    }
}