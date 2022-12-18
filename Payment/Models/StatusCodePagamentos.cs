using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Payment.Models
{
  public enum StatusCodePagamentos
  {
    [Display(Name = "Aguardando Pagamento")]
    AguardandoPagamento = 0,

    [Display(Name = "Pagamento Aprovado")]
    Aprovado = 1,

    [Display(Name = "Enviado para transportadora")]
    Transportadora = 3,

    [Display(Name = "Compra entregue")]
    Entregue = 4,

    [Display(Name = "Compra cancelada")]
    Cancelado = 5
  }
}