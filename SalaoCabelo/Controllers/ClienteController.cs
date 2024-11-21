using Microsoft.AspNetCore.Mvc;
using SalaoCabelo.Data;
using SalaoCabelo.Models;
using SalaoCabelo.Repositorio;

namespace SalaoCabelo.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly SalaoContext _context;

        public ClienteController(IUsuarioRepositorio usuarioRepositorio, SalaoContext context)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Novo(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.Adicionar(usuario);
                return RedirectToAction("Index", "Home");
            }
            return View(usuario);
        }
    }
}
