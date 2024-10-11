public class Telefone
{
    public int Id { get; set; }
    public string Numero { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
}
