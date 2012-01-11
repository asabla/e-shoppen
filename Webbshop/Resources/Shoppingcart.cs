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
    public class ShoppingCart
    {
        private DateTime _DateCreated;
        private DateTime _LastUpdated;
        private List<CartItem> _Items;
        private double _TotalPrice;

        public ShoppingCart()
        {
            if (this._Items == null)    //If no items has been added, then make new instance
            {
                this._Items = new List<CartItem>();
                this._DateCreated = DateTime.Now;   //Make sure that created date is saved (for later use)
            }
        }

        /// <summary>
        /// Gets or sets the list of cartitems (the cart)
        /// </summary>
        [DataMember]
        public List<CartItem> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        /// <summary>
        /// Inserts a new product, and if product already excist in the list, the quantity will just be updated
        /// </summary>
        /// <param name="ProductID">Products id</param>
        /// <param name="Price">The Price for the product</param>
        /// <param name="Quantity">Quantity of the product</param>
        /// <param name="ProductName">Product name</param>
        /// <param name="Imageurl">The imageurl for the product</param>
        [OperationBehavior]
        public void Insert(int ProductID, double Price, int Quantity, string ProductName, string Imageurl)
        {
            int ItemIndex = ItemIndexOf(ProductID);
            if (ItemIndex == -1)    //If not found, just create a new item in the list
            {
                CartItem NewItem = new CartItem();
                NewItem.ProductID = ProductID;
                NewItem.Price = Price;
                NewItem.Quantity = Quantity;
                NewItem.ProductName = ProductName;
                NewItem.ImageUrl = Imageurl;

                _Items.Add(NewItem);    //adds the new item
            }
            else
            {
                _Items[ItemIndex].Quantity += 1;    //If index was found, just add another to quantity
            }

            _LastUpdated = DateTime.Now;    //Make sure that latest 
        }

        /// <summary>
        /// Updates values for selected rowid
        /// </summary>
        /// <param name="RowId">The id of product(not in database)</param>
        /// <param name="ProductId">The id from the database</param>
        /// <param name="Quantity">Number of products</param>
        /// <param name="Price">The price</param>
        [OperationBehavior]
        public void Update(int RowId, int ProductId, int Quantity, double Price)
        {
            CartItem Item = _Items[RowId];  //Gets the item in the cart to be updated
            Item.ProductID = ProductId;
            Item.Quantity = Quantity;
            Item.Price = Price;
            _LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Updates the quantity for a given productids
        /// </summary>
        /// <param name="ProductId">The productid</param>
        /// <param name="Quantity">The new quantity for the product</param>
        [OperationBehavior]
        public void UpdateQuantity(int ProductId, int Quantity)
        {
            int ItemIndex = ItemIndexOf(ProductId);
            if (ItemIndex != -1)
            {
                if (Quantity == 0)
                {
                    //If quantity is set to zero, then remove it
                    DeleteItem(ItemIndex);
                }
                else
                {
                    //if not 0, just update with new values
                    _Items[ItemIndex].Quantity = Quantity;
                }
            }
            else
            {
                //Product not found...do nothing?
            }
        }

        /// <summary>
        /// Delete item with rowid
        /// </summary>
        /// <param name="RowId"></param>
        [OperationBehavior]
        public void DeleteItem(int RowId)
        {
            _Items.RemoveAt(RowId); //Removes item at rowid
            _LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Deletes every single value in the cart
        /// </summary>
        [OperationBehavior]
        public void DeleteAllItems()
        {
            _Items.Clear();
            _LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Copy all values from shoppingcart to another
        /// Was created for handle the problem with sessions
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        [OperationBehavior]
        public ShoppingCart CopyFrom(ShoppingCart cart)
        {
            ShoppingCart newCart = new ShoppingCart();
            int pId = 0;
            string pName = "";
            string pImgurl = "";
            int pQuant = 0;
            double pPrice = 0;

            for (int i = 0; i < cart.Items.Count; i++)
            {
                pId = cart.Items[i].ProductID;
                pName = cart.Items[i].ProductName;
                pImgurl = cart.Items[i].ImageUrl;
                pQuant = cart.Items[i].Quantity;
                pPrice = cart.Items[i].Price;

                newCart.Insert(pId, pPrice, pQuant, pName, pImgurl);    //foreach item in cart, adds to the new
            }

            return newCart;
        }

        /// <summary>
        /// Gets the totalprice for the shoppingcart
        /// </summary>
        [DataMember]
        public double TotalPrice
        {
            get
            {
                if (_Items == null)
                {
                    return 0;
                }

                _TotalPrice = 0;   
                foreach (CartItem Item in _Items)
                {
                    _TotalPrice += Item.SubTotal; //Get the totalprice foreach item (quantity * price)
                }

                return _TotalPrice;
            }
            set
            {
                _TotalPrice = value;
            }
        }

        //Tries to find the index of a certain item. If not found just return -1
        private int ItemIndexOf(int ProductId)
        {
            int index = 0;
            foreach (CartItem item in _Items)
            {
                if (item.ProductID == ProductId)
                {
                    return index;
                }

                index += 1;
            }

            return -1;
        }
    }
}
