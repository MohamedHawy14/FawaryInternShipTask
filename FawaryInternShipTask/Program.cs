using FawaryInternShipTask.Classes;

namespace FawaryInternShipTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cheese = new PerishableProduct("Cheese", 100, 10, DateTime.Now.AddDays(1), 400);
            var biscuits = new PerishableProduct("Biscuits", 150, 5, DateTime.Now.AddDays(2), 700);
            var tv = new NonPerishableProduct("TV", 300, 3, true, 8000);
            var scratchCard = new NonPerishableProduct("Scratch Card", 50, 10);

            var cart = new Cart();
            var customer = new Customer("Mohamed", 1000);

            cart.Add(cheese, 2);
            cart.Add(biscuits, 1);
            cart.Add(scratchCard, 1);

            CheckoutService.Checkout(customer, cart);
        }
    }
}
