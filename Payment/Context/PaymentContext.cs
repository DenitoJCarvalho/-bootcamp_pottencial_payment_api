using Microsoft.EntityFrameworkCore;
using Payment.Models;

namespace Payment.Context
{
  public class PaymentContext : DbContext
  {
    public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }

    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Venda> Vendas { get; set; }
  }
}