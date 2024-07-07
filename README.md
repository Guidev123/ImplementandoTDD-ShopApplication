 <h1>Aplicação de Testes Unitários em um Domínio Rico</h1>

  <p>Esta é uma aplicação que implementei testes unitários em um domínio rico. A aplicação inclui:</p>
    
   <ul>
      <li>Entidades</li>
       <li>Eventos de notificação</li>
       <li>Validações com FluentValidation</li>
    </ul>
    
   <h2>Funcionalidades</h2>
   
  <p>Os testes implementados foram para verificação do funcionamento de todas as operações relacionadas a pedidos. Isso inclui:</p>
    
  <ul>
        <li><b>Geração de Número de Pedido:</b> Verifica se, ao criar um pedido válido, o número gerado possui 8 caracteres.</li>
        <li><b>Status Inicial do Pedido:</b> Verifica se um novo pedido tem o status "Aguardando Pagamento".</li>
        <li><b>Status Após Pagamento:</b> Verifica se, após adicionar um item e realizar o pagamento, o status do pedido muda para "Aguardando Entrega".</li>
        <li><b>Status de Pedido Cancelado:</b> Verifica se, ao cancelar um pedido, o status é alterado para "Cancelado".</li>
        <li><b>Adição de Item Nulo:</b> Verifica se itens nulos não são adicionados ao pedido.</li>
        <li><b>Adição de Item com Quantidade Zero:</b> Verifica se itens com quantidade zero não são adicionados ao pedido.</li>
        <li><b>Cálculo de Total do Pedido:</b> Verifica o total do pedido em diferentes cenários de desconto e taxa de entrega.</li>
    </ul>

  <h2>Video Demo dos testes<h2/>
    
https://github.com/Guidev123/ImplementandoTDD-ShopApplication/assets/155389912/66443ed8-5a5c-44c5-8c7d-c788f9855f1a

