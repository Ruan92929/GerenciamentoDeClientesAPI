namespace GerenciamentoClientesAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public List<Telefone> Telefones { get; set; }
        public List<Email> Emails { get; set; }
    }
}
