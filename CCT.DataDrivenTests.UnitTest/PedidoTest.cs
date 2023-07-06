using CCT.DataDrivenTests.App;

namespace CCT.DataDrivenTests.UnitTest
{
    [TestClass]
    public class PedidoTest
    {
        [TestCategory("Teste com desvios de lógica")]
        [TestMethod]
        [DataRow(1, 100.0, 1, 200.0, 300.0)]
        [DataRow(1, 100.0, 2, 200.0, 320.0)]
        [DataRow(2, 100.0, 2, 200.0, 330.0)]
        [DataRow(1, 100.0, 0, 0, 100.0)]
        [DataRow(2, 100.0, 0, 0, 110.0)]
        [DataRow(0, 0.0, 0, 0.0, 0.0)]
        public void DeveriaCalcularValorTotal(int statusProd1, 
                                              double valorProd1,
                                              int statusProd2,
                                              double valorProd2,
                                              double valorEsperado)
        {
            var pedido = new Pedido();
            if (statusProd1 > 0)
            {
                var prod1 = new Produto { StatusEstoque = statusProd1, ValorUnitario = valorProd1 };
                pedido.Produtos.Add(prod1);
            }
            if (statusProd2 > 0)
            {
                var prod2 = new Produto { StatusEstoque = statusProd2, ValorUnitario = valorProd2 };
                pedido.Produtos.Add(prod2);
            }

            var res = pedido.CalcularValorTotal();

            Assert.AreEqual(valorEsperado, res);
        }

        [TestMethod]
        public void DeveriaCalcularValorTotalZeradoSeAListaDeProdutosForVazia()
        {
            var pedido = new Pedido();
            var res = pedido.CalcularValorTotal();
            Assert.AreEqual(0.0, res);
        }

        [TestCategory("Teste com foco na lógica")]
        [TestMethod]
        [DataRow(17)]
        [DataRow(-17)]
        public void DeveriaIndicarQueValorEhMenorQueMinimoQuandoDentroDoIntervalo(double valorTotal)
        {
            var valorMinimo = 20; //de -20 a 20, exceto 0
            var pedido = new Pedido { ValorTotal = valorTotal };
            Assert.IsTrue(pedido.ValorTotalEhMenorQueMinimo(valorMinimo));
        }

        [TestMethod]
        public void DeveriaIndicarQueValorEhMenorQueMinimoSeValorTotalForNegativo()
        {
            var valorMinimo = 20;
            var pedido = new Pedido { ValorTotal = -17 };
            Assert.IsTrue(pedido.ValorTotalEhMenorQueMinimo(valorMinimo));
        }

        [TestMethod]
        public void DeveriaIndicarQueValorEhMenorQueMinimoSeValorTotalForPositivo()
        {
            var valorMinimo = 20;
            var pedido = new Pedido { ValorTotal = 17 };
            Assert.IsTrue(pedido.ValorTotalEhMenorQueMinimo(valorMinimo));
        }
    }
}