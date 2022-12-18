using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Payment.Context;
using Payment.Models;

namespace Payment.Controllers
{
  [ApiController]
  [Route("produto")]
  public class ProdutosController : ControllerBase
  {
    private readonly PaymentContext _context;

    public ProdutosController(
        PaymentContext _context
    )
    {
      this._context = _context;
    }

    #region Cadastrar Produto

    [HttpPost]
    public IActionResult CadastrarProduto(Produto item)
    {
      try
      {
        Produto produto = new Produto();

        if (String.IsNullOrEmpty(item.Descricao)) return BadRequest(new { Erro = $"É necessário informar o nome do produto." });
        if (item.Preco == 0) return BadRequest(new { Erro = $"É necessário informar o preço do produto" });

        produto.Descricao = item.Descricao;
        produto.Preco = item.Preco;

        _context.Produtos.Add(produto);
        _context.SaveChanges();

        return Ok(produto);
      }
      catch (Exception ex)
      {
        return BadRequest(new { Erro = $"{ex.Message}" });
      }
    }

    #endregion

    #region Obter Produto
    [HttpGet("ObterProdutos")]
    public IActionResult ObterProduto()
    {
      try
      {
        var produtos = _context.Produtos.ToList();
        return Ok(produtos);
      }
      catch (Exception ex)
      {
        return NotFound($"{ex.Message}");
      }


    }
    #endregion

    #region Atualizar Produto
    [HttpPut("{id}")]
    public IActionResult AtualizarProduto(int id, Produto item)
    {
      try
      {
        var produto = _context.Produtos.Find(id);

        if (produto is null)
        {
          return NotFound($"Produto não existe.");
        }
        else
        {
          produto.IdProduto = item.IdProduto;
          produto.Descricao = item.Descricao;
          produto.Preco = item.Preco;

          _context.Update(produto);
          _context.SaveChanges();
        }

        return Ok(produto);
      }
      catch (Exception ex)
      {
        return NotFound($"Produto não encontrado. {ex.Message}");
      }

    }
    #endregion
  }
}