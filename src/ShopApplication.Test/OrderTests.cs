using ShopApplication.Domain.Entities;

namespace ShopApplication.Test
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Guilherme", "gui@test.com");
        private readonly Item _item = new Item("Item 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));


        [TestMethod]
        [TestCategory("Business")]
        public void Se_pedido_for_valido_gerar_numero_com_8_caracteres()
        {
            var customer = new Customer("Guilherme", "gui@test.com");
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        }
    }
}