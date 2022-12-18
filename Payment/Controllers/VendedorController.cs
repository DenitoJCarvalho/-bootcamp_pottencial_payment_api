using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Payment.Models;
using Payment.Context;

namespace Payment.Controllers;

[ApiController]
[Route("Vendedor")]
public class VendedorController : ControllerBase
{
  private readonly PaymentContext _context;
  public VendedorController(
    PaymentContext _context
  )
  {
    this._context = _context;
  }

  #region Inserir Vendedor

  [HttpPost]
  public IActionResult InserirVendedor(Vendedor item)
  {
    try
    {
      Vendedor vendedor = new Vendedor();

      if (item is null)
        return NotFound(new { Erro = "Não dados do vendedor para cadastrar. Verifique as informações e tente novamente." });

      vendedor.CPF = item.CPF;
      vendedor.Email = item.Email;
      vendedor.Nome = item.Nome;
      vendedor.Telefone = item.Telefone;
      vendedor.WhatsApp = item.WhatsApp;

      _context.Vendedores.Add(vendedor);
      _context.SaveChanges();

      return Ok(vendedor);

    }
    catch (Exception ex)
    {
      return BadRequest(new { Erro = $"Não foi possível inserir os dados. {ex.Message}" });
    }
  }
  #endregion

  #region Obter Todos os Vendedores
  [HttpGet("ObterTodosVendedores")]
  public IActionResult ObterTodosVendedores()
  {
    try
    {
      var vendedores = _context.Vendedores.ToList();

      return Ok(vendedores);
    }
    catch (Exception ex)
    {
      return NotFound(new { Erro = $"Não foi possível obter todos os vendedores. {ex.Message}" });
    }
  }
  #endregion

  #region  Obter um vendedor
  [HttpGet("ObterVendedor")]
  public IActionResult ObterVendedor(int ID)
  {
    try
    {
      var db = _context
        .Vendedores
        .FirstOrDefault(
            v => v.IdVendedor.Equals(ID)
        );


      return Ok(db);
    }
    catch (Exception ex)
    {
      return BadRequest(new { Erro = $"Nao foi possível encontrar o vendedor solicitado. {ex.Message}" });
    }
  }
  #endregion

  #region Atualizar vendedor
  [HttpPut("AtualizarVendedor")]
  public IActionResult AtualizarVendedor(int ID, Vendedor items)
  {
    try
    {
      var vendedor = _context.Vendedores.Find(ID);

      if (items is null)
        return NotFound(new { Erro = "Vendedor não encontrado." });

      vendedor.IdVendedor = items.IdVendedor;
      vendedor.CPF = items.CPF;
      vendedor.Email = items.Email;
      vendedor.Nome = items.Nome;
      vendedor.Telefone = items.Telefone;
      vendedor.WhatsApp = items.WhatsApp;

      _context.Vendedores.Update(vendedor);
      _context.SaveChanges();

      return Ok(vendedor);

    }
    catch (Exception ex)
    {
      return BadRequest(new { Erro = $"Erro ao atualizar cadastro do vendedor {items.IdVendedor} - {items.Nome} - {ex.Message}" });
    }
  }
  #endregion

  #region Excluir vendedor
  [HttpDelete("ExcluirVendedor")]
  public IActionResult ExcluirVendedor(int ID)
  {
    try
    {
      var vendedor = _context.Vendedores.Find(ID);

      _context.Vendedores.Remove(vendedor);
      _context.SaveChanges();

      return Ok(vendedor);
    }
    catch (Exception ex)
    {
      return BadRequest(new
      {
        Erro = @$"
        Erro ao excluir os dados do vendedor. Confira os dados e tente novamente.
        {ex.Message}
        "
      });
    }
  }
  #endregion
}
