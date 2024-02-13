using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MinhaPrimeiraApllicacaoWeb.Models;
using MinhaPrimeiraAplicacaoWeb.Models;
using System.Linq;
using MinhaPrimeiraAplicacaoWeb.DataContext;

namespace MinhaPrimeiraApllicacaoWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ProdutoContext _context;

    public HomeController(ILogger<HomeController> logger,ProdutoContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult Listar()
    {
        var list = _context.Produtos.ToList();
        return View(list);
    }
    public IActionResult Criar()
    {
        return View(new ProdutoModel());
    }
    [HttpPost]
    public IActionResult Criar([Bind("Nome,Descricao,Preco,EstaAtivo,Id")] ProdutoModel produto)
    {
        _context.Add(produto);
        _context.SaveChanges();
        return RedirectToAction(nameof(Listar));
    }

    public IActionResult Editar(int id)
    {
        var produto = _context.Produtos.Find(id);
        return View(produto);
    }
    [HttpPost]
    public IActionResult Editar([Bind("Nome,Descricao,Preco,EstaAtivo,Id")] ProdutoModel produto)
    {
        _context.Update(produto);
        _context.SaveChanges();
        return RedirectToAction(nameof(Listar));
    }
     public IActionResult Deletar(int id)
    {
        var produto = _context.Produtos.Find(id);
        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        return RedirectToAction(nameof(Listar));
    }
}
