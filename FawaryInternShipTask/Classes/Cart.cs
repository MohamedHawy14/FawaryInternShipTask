using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawaryInternShipTask.Classes
{
    public class Cart
    {
        public List<CartItem> Items { get; } = new();

        public void Add(Product product, int quantity)
        {
            if (quantity > product.Quantity)
                throw new InvalidOperationException($"Not enough quantity for {product.Name}.");
            Items.Add(new CartItem(product, quantity));
        }

        public bool IsEmpty() => !Items.Any();
    }
}
