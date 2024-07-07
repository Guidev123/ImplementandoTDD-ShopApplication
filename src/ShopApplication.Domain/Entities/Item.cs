using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Domain.Entities
{
    public class Item : Entity
    {
        public Item(string title, decimal value, bool active)
        {
            Title = title;
            Value = value;
            Active = active;
        }
        public string Title { get; private set; }
        public decimal Value { get; private set; }
        public bool Active { get; private set; }

    }
}
