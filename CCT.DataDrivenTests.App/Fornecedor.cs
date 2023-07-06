namespace CCT.DataDrivenTests.App
{
    public class Fornecedor
    {
        public int CodigoInterno { get; set; }
        public string Nome { get; set; }

        public bool AceitaBoleto() => new List<int> { 11, 22, 33 }.Contains(CodigoInterno);
    }
}
