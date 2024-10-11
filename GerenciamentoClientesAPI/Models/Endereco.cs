public class Endereco
{
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}
