using CCT.DataDrivenTests.App;

namespace CCT.DataDrivenTests.UnitTest
{
    [TestClass]
    public class ClienteTest
    {
        [TestMethod]
        public void DeveriaIndicarQueClienteEhPessoaFisica()
        {
            var cli = new Cliente { TipoPessoa = "PF" };
            Assert.IsTrue(cli.EhPessoaFisica());
        }

        [TestCategory("Teste desnecessário")]
        [TestMethod]
        [DataRow("pf")]
        //[DataRow("pF")]
        [DataRow("PJ")]
        //[DataRow("Pj")]
        //[DataRow("F")]
        //[DataRow("J")]
        //[DataRow("AA")]
        //[DataRow("BB")]
        //[DataRow("123")]
        public void NaoDeveriaIndicarQueClienteEhPessoaFisica(string tipo)
        {
            var cli = new Cliente { TipoPessoa = tipo };
            var res = cli.EhPessoaFisica();
            Assert.IsFalse(res);
        }
    }
}