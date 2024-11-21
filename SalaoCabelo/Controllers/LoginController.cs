using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalaoCabelo.Helper;
using SalaoCabelo.Models;
using SalaoCabelo.Repositorio;

namespace SalaoCabelo.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositorio,
                               ISessao sessao)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if (_sessao.BuscarSessao() != null) { return RedirectToAction("Index", "Home"); }
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Verifica se o login existe
                    Usuarios usuario = _usuarioRepositorio.BuscaLogin(loginModel.Login);

                    // Verifica se o usuário foi encontrado e se a senha está correta
                    if (usuario != null && usuario.SenhaValida(loginModel.Password))
                    {
                        // Salva os dados do usuário na sessão
                        
                        _sessao.CriarSessaoUsuario(usuario);
                        // Redireciona para a Home
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        // Se não logar, exibe mensagem de erro
                        TempData["Erro"] = "Login ou senha inválidos.";
                    }
                }

                return View("Index");  // Exibe o formulário de login novamente em caso de erro
            }
            catch (Exception)
            {
                TempData["Erro"] = "Ocorreu um erro inesperado.";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Sair()
        {
            _sessao.QuebrarSessao();
            return RedirectToAction("Index", "Login");
        }
    }
}
