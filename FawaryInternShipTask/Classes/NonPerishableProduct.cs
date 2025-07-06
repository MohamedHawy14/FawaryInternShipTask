using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawaryInternShipTask.Classes
{
    public class NonPerishableProduct : Product
    {
        public bool RequiresShipping { get; }
        public double Weight { get; }

        public NonPerishableProduct(string name, double price, int quantity, bool requiresShipping = false, double weight = 0)
            : base(name, price, quantity)
        {
            RequiresShipping = requiresShipping;
            Weight = weight;
        }

        public override bool IsExpired() => false;

        public string GetName() => Name;
        public double GetWeight() => Weight;
    }
}
