using FawaryInternShipTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawaryInternShipTask.Classes
{
    public class ShippingService
    {
        public static void Ship(List<IShippable> items)
        {
            Console.WriteLine("** Shipment notice **");
            double totalWeight = 0;
            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetName()} - {item.GetWeight()}g");
                totalWeight += item.GetWeight();
            }
            Console.WriteLine($"Total package weight {totalWeight / 1000}kg");
        }
    }
}
