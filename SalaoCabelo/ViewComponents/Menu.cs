using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalaoCabelo.Models;

namespace SalaoCabelo.ViewComponents
{
    public class Menu : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return View("Default");

            Usuarios usuario = JsonConvert.DeserializeObject<Usuarios>(sessaoUsuario);

            return View(usuario);
        }
}
}
