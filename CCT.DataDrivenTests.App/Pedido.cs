namespace CCT.DataDrivenTests.App
{
    public class Pedido
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public double CalcularValorTotal()
        {
            var valorEmEstoque = Produtos.Where(p => p.StatusEstoque == 1)
                                         .Sum(p => p.ValorUnitario);
            var valorEstoqueBaixo = Produtos.Where(p => p.StatusEstoque == 2)
                                            .Sum(p => p.ValorUnitario);
            var valorTotal = valorEmEstoque + (valorEstoqueBaixo * 1.1);
            return Math.Round(valorTotal, 2);
        }

        public bool ValorTotalEhMenorQueMinimo(double valorMinimo)
        {
            return (ValorTotal <= valorMinimo && ValorTotal > 0) ||
                   (ValorTotal >= -valorMinimo && ValorTotal < 0);
        }
    }
}
