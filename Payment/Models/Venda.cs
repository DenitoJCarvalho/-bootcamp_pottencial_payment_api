using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Payment.Models;

namespace Payment.Models;

public class Venda
{
  [Key]
  public int IdVenda { get; set; }

  [ForeignKey("IdVendedor")]
  public int CodigoVendedor { get; set; }

  [ForeignKey("IdProduto")]
  public int CodigoProduto { get; set; }

  public DateTime DataVenda { get; set; }

  public byte status { get; set; }

}
