namespace CCT.DataDrivenTests.App
{
    public class Cliente
    {
        public long CpfCnpj { get; set; }
        public string Nome { get; set; }
        public string TipoPessoa { get; set; }

        public bool EhPessoaFisica() => TipoPessoa == "PF";
    }
}
