using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaoCabelo.Data;
using SalaoCabelo.Models;
using SalaoCabelo.Repositorio;
using SalaoCabelo.Helper;
using SalaoCabelo.Migrations;
using SalaoCabelo.Enum;

namespace SalaoCabelo.Controllers
{
    public class ServicosController : Controller
    {
        private readonly IServicoRepositorio _servicoRepositorio;
        private readonly SalaoContext _context;
        private readonly ISessao _sessao;

        public ServicosController(IServicoRepositorio servicoRepositorio, SalaoContext context, ISessao sessao)
        {
            _servicoRepositorio = servicoRepositorio;
            _sessao = sessao;
        }

        public async Task<IActionResult> Index()
        {
            List<Servico> servico = await _servicoRepositorio.BuscarTodos();
            var usuarioLogado = _sessao.BuscarSessao();
            bool isAdmin = usuarioLogado?.Perfil == PerfilEnum.Admin;
            ViewData["IsAdmin"] = isAdmin;
            return View(servico);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int Id)
        {
            Servico servico = _servicoRepositorio.ListarPorId(Id);
            return View(servico);
        }

 
        public IActionResult Apagar(int Id)
        {
            Servico servico = _servicoRepositorio.ListarPorId(Id);
            return View(servico);
        }

        public IActionResult ApagarConfirmacao(int Id)
        {
            _servicoRepositorio.ApagarConfirmacao(Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _servicoRepositorio.Adicionar(servico);
                return RedirectToAction("Index");
            }
            return View(servico);
        }

        [HttpPost]
        public IActionResult Alterar(Servico servico)
        {
            _servicoRepositorio.Atualizar(servico);
            return RedirectToAction("Index");
        }

    }
}

