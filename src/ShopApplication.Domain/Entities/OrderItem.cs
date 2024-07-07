using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Domain.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Item item, int quantity)
        {
            Item = item;
            Value = Item != null ? item.Value : 0;
            Quantity = quantity;
        }
        public Item Item { get; private set; } = null!;
        public decimal Value { get; private set; }

        public int Quantity { get; private set; }


        public decimal Total()
        {
            return Value * Quantity;
        }
    }
}
