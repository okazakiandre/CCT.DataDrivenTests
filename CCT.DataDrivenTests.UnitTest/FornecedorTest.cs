using CCT.DataDrivenTests.App;

namespace CCT.DataDrivenTests.UnitTest
{
    [TestClass]
    public class FornecedorTest
    {
        [TestCategory("Teste com nome genérico")]
        [TestMethod]
        [DataRow(11)] //Empório das Flores
        [DataRow(22)] //Joca Madeiras
        [DataRow(33)] //Adega dos Amigos
        public void DeveriaIndicarQueFornecedorAceitaBoleto(int codigo)
        {
            var fornecedor = new Fornecedor { CodigoInterno = codigo };
            Assert.IsTrue(fornecedor.AceitaBoleto());
        }

        [TestMethod]
        public void DeveriaIndicarQueFornecedorJocaMadeirasAceitaBoleto()
        {
            var fornecedor = new Fornecedor { CodigoInterno = 22 };
            Assert.IsTrue(fornecedor.AceitaBoleto());
        }
    }
}