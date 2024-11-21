using SalaoCabelo.Data;
using SalaoCabelo.Models;

namespace SalaoCabelo.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuarios BuscaLogin(string login);
        Usuarios Adicionar(Usuarios usuario);
        public Usuarios ListarPorId(int id);

        
    }
}
