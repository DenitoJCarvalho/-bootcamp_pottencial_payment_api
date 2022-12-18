using System.ComponentModel.DataAnnotations;

namespace Payment.Models
{
  public class Produto
  {
    [Key]
    public int IdProduto { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
  }
}