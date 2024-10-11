using System.ComponentModel.DataAnnotations;

public class Cliente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo CNPJ é obrigatório.")]
    [RegularExpression(@"\d{14}", ErrorMessage = "O CNPJ deve conter 14 dígitos.")]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }
    public bool Ativo { get; set; }

    [Required(ErrorMessage = "É necessário adicionar ao menos um endereço.")]
    public List<Endereco> Enderecos { get; set; }

    [Required(ErrorMessage = "É necessário adicionar ao menos um telefone.")]
    public List<Telefone> Telefones { get; set; }

    [Required(ErrorMessage = "É necessário adicionar ao menos um e-mail.")]
    public List<Email> Emails { get; set; }
}
