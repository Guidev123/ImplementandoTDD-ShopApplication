using ShopApplication.Domain.Entities;
using ShopApplication.Domain.Enums;

namespace ShopApplication.Test.Entities
{
    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer = new Customer("Guilherme", "gui@test.com");
        private readonly Item _item = new Item("Item 1", 10, true);
        private readonly Discount _discount = new Discount(10, DateTime.Now.AddDays(5));


        [TestMethod]
        [TestCategory("Domain")]
        public void Se_pedido_for_valido_gerar_numero_com_8_caracteres()
        {
            var customer = new Customer("Guilherme", "gui@test.com");
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Se_pedido_for_novo_seu_status_deve_ser_aguardando_pagamento()
        {
            var order = new Order(_customer, 0, null);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingPayment);
        }
        [TestMethod]
        [TestCategory("Domain")]
        public void Se_pedido_for_novo_seu_status_deve_ser_aguardando_entrega()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_item, 1);
            order.Pay(10);
            Assert.AreEqual(order.Status, EOrderStatus.WaitingDelivery);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Se_pedido_for_cancelado_seu_status_deve_ser_cancelado()
        {
            var order = new Order(_customer, 0, null);
            order.Cancel();
            Assert.AreEqual(order.Status, EOrderStatus.Canceled);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Se_produto_vier_sem_items_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(null, 10);
            Assert.AreEqual(order.Items.Count, 0);
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Se_item_vier_com_quantidade_zero_o_mesmo_nao_deve_ser_adicionado()
        {
            var order = new Order(_customer, 0, null);
            order.AddItem(_item, 0);
            Assert.AreEqual(order.Items.Count, 0);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Se_pedido_for_valido_seu_total_deve_ser_50()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_item, 5);
            Assert.AreEqual(order.Total(), 50);
        }
        [TestMethod]
        [TestCategory("Domain")]
        public void Se_pedido_for_valido_seu_total_deve_ser_21()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(new Item("Item 1", 3, true), 7);
            Assert.AreEqual(order.Total(), 21);
        }

        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_invalido_o_valor_do_pedido_deve_ser_55()
        {
            var order = new Order(_customer, 5, null);
            order.AddItem(_item, 5);
            Assert.AreEqual(order.Total(), 55);
        }


        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_desconto_10_o_valor_do_pedido_deve_ser_55()
        {
            var order = new Order(_customer, 10, _discount);
            order.AddItem(_item, 5);
            Assert.AreEqual(order.Total(), 50);
        }
    }
}