using FawaryInternShipTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawaryInternShipTask.Classes
{
    public class CheckoutService
    {
        public static void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
                throw new Exception("Cart is empty");

            var expired = cart.Items.FirstOrDefault(i => i.Product.IsExpired());
            if (expired != null)
                throw new Exception($"{expired.Product.Name} is expired!");

            double subtotal = 0;
            double shipping = 0;
            List<IShippable> toShip = new();

            foreach (var item in cart.Items)
            {
                if (item.Quantity > item.Product.Quantity)
                    throw new Exception($"{item.Product.Name} is out of stock!");

                subtotal += item.TotalPrice;
                if (item.Product is IShippable shippable)
                {
                    for (int i = 0; i < item.Quantity; i++)
                        toShip.Add(shippable);
                    shipping += 15;
                }

                item.Product.Quantity -= item.Quantity;
            }

            double total = subtotal + shipping;

            if (customer.Balance < total)
                throw new Exception("Insufficient balance.");

            customer.Balance -= total;

            if (toShip.Any())
                ShippingService.Ship(toShip);

            Console.WriteLine("** Checkout receipt **");
            foreach (var item in cart.Items)
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} - {item.TotalPrice}");
            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal     {subtotal}");
            Console.WriteLine($"Shipping     {shipping}");
            Console.WriteLine($"Amount       {total}");
            Console.WriteLine($"Remaining Balance: {customer.Balance}");
        }
    }

}
