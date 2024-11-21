using Microsoft.EntityFrameworkCore;
using SalaoCabelo.Data;
using SalaoCabelo.Migrations;
using SalaoCabelo.Models;

namespace SalaoCabelo.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SalaoContext _salaocontext;
        public UsuarioRepositorio(SalaoContext salaoContext)
        {
            _salaocontext = salaoContext;
        }
        public Usuarios Adicionar(Usuarios usuario)
        {
            _salaocontext.Clientes.Add(usuario);
            _salaocontext.SaveChanges();
            return usuario;
        }

        public Usuarios ListarPorId(int id)
        {
            return _salaocontext.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public Usuarios BuscaLogin(string login)
        {
        return _salaocontext.Clientes.FirstOrDefault(x => x.Email.ToUpper() == login.ToUpper());
        }
    }
}
