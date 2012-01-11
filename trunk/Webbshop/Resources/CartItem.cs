using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
namespace Resources
{
    [Serializable]
    [DataContract]
    public class CartItem
    {
        private int _ProductID;
        private string _ProductName;
        private string _imgUrl;
        private int _Quantity;
        private double _Price;
        private double _subTotal;

        /// <summary>
        /// Use it with care
        /// </summary>
        public CartItem()
        {
            //Do something here?
        }

        /// <summary>
        /// Add an product for the shoppingcart (or for something else)
        /// </summary>
        /// <param name="ProductID">The products id</param>
        /// <param name="ProductName">Name of the product</param>
        /// <param name="ImgUrl">The url for the image</param>
        /// <param name="Quantity">Number of the same product</param>
        /// <param name="Price">The price for just one product</param>
        public CartItem(int ProductID, string ProductName, string ImgUrl, int Quantity, double Price)
        {
            _ProductID = ProductID;
            _ProductName = ProductName;
            _imgUrl = ImgUrl;
            _Quantity = Quantity;
            _Price = Price;
            _subTotal = Quantity * Price;
        }

        /// <summary>
        /// Gets och sets the value for productid
        /// </summary>
        [DataMember]
        public int ProductID
        {
            get { return _ProductID; }
            set { _ProductID = value; }
        }

        /// <summary>
        /// Gets or sets the value for productname
        /// </summary>
        [DataMember]
        public string ProductName
        {
            get { return _ProductName; }
            set { _ProductName = value; }
        }

        /// <summary>
        /// Gets or sets the value for imageurl
        /// </summary>
        [DataMember]
        public string ImageUrl
        {
            get { return _imgUrl; }
            set { _imgUrl = value; }
        }

        /// <summary>
        /// Gets or sets the quantaty
        /// </summary>
        [DataMember]
        public int Quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }

        /// <summary>
        /// Gets or sets value for the price
        /// </summary>
        [DataMember]
        public double Price
        {
            get { return _Price; }
            set { _Price = value; }
        }

        /// <summary>
        /// Gets total cost of both quantity and price
        /// </summary>
        public double SubTotal
        {
            get { return _Quantity * _Price; }
        }
    }
}
