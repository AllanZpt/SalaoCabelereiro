using Newtonsoft.Json;
using SalaoCabelo.Models;

namespace SalaoCabelo.Helper
{
    public class Sessao : ISessao

    {
        private readonly IHttpContextAccessor _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public Usuarios BuscarSessao()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            return JsonConvert.DeserializeObject<Usuarios>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(Usuarios usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);

        }

        public void QuebrarSessao()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
