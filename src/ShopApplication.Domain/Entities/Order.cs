using ShopApplication.Domain.Enums;

namespace ShopApplication.Domain.Entities
{
    public class Order : Entity
    {
        public Order(Customer customer, decimal deliveryFee, Discount discount)
        {
            Customer = customer;
            DeliveryFee = deliveryFee;
            Discount = discount;
            Items = new List<OrderItem>();
            Status = EOrderStatus.WaitingPayment;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
        }

        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public Discount? Discount { get; private set; }
        public List<OrderItem> Items { get; private set; }
        public EOrderStatus? Status { get; private set; }
        public string Number { get; private set; }

        public void AddItem(Item item, int quantity)
        {
            var product = new OrderItem(item, quantity);
            Items.Add(product);
        }

        public decimal Total()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFee;
            total -= Discount != null ? Discount.Price() : 0;

            return total;
        }

        public void Pay(decimal amount)
        {
            if (amount == Total()) this.Status = EOrderStatus.WaitingDelivery;
        }
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }
    }
}
