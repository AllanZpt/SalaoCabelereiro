using SalaoCabelo.Models;

namespace SalaoCabelo.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Usuarios usuario);
        void QuebrarSessao();
        Usuarios BuscarSessao();
    }
}
