using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Payment.Models
{
  public class Vendedor
  {
    [Key]
    public int IdVendedor { get; set; }
    public string Nome { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public bool WhatsApp { get; set; }
  }
}