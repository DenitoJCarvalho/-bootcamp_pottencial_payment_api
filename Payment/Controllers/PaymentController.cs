using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Payment.Context;
using Payment.Models;

namespace Payment.Controllers;

[ApiController]
[Route("Venda")]

public class PaymentController : ControllerBase
{
  private readonly PaymentContext _context;

  public PaymentController(
      PaymentContext _context
  )
  {
    this._context = _context;
  }

  #region Registrar Venda
  [HttpPost("RegistrarVenda")]
  public IActionResult RegistrarVenda(Venda[] venda)
  {
    try
    {
      var registrarVenda = new Venda();

      foreach (var item in venda)
      {
        registrarVenda.CodigoProduto = item.CodigoProduto;
        registrarVenda.CodigoVendedor = item.CodigoVendedor;
        registrarVenda.DataVenda = DateTime.Now;
        registrarVenda.status = (byte)StatusCodePagamentos.AguardandoPagamento;
      }

      _context.Vendas.Add(registrarVenda);
      _context.SaveChanges();

      return Ok(registrarVenda);
    }
    catch (Exception ex)
    {
      return BadRequest(new
      {
        Erro = @$"
          Não foi possível registrar venda. Contate o administrador.
          ERRO - {ex.Message}
          "
      });
    }
  }
  #endregion

}
