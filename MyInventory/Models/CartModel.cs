using System.Collections.Generic;

namespace LifeLine.Models
{
    public class CartItemModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartItemModel> ProductList { get; set; }
    }
}
