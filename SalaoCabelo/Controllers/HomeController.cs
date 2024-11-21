using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalaoCabelo.Helper;
using SalaoCabelo.Models;

namespace SalaoCabelo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISessao _sessao;

    public HomeController(ILogger<HomeController> logger,
                          ISessao sessao)
    {
        _logger = logger;
        _sessao = sessao;
    }



    //public HomeController(ISessao sessao)
    //{
        
    //}

    public IActionResult Index()
    {
        {
  
            var usuarioLogado = _sessao.BuscarSessao();


            if (usuarioLogado != null)
            {
                ViewData["NomeUsuario"] = usuarioLogado.Name;
            }

            return View();
        }
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
}
