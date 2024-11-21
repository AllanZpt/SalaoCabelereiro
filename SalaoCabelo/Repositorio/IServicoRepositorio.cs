using SalaoCabelo.Models;
namespace SalaoCabelo.Repositorio
{
    public interface IServicoRepositorio
    {
        Servico ListarPorId(int id);
        Task<List<Servico>> BuscarTodos();
        Servico Adicionar(Servico servico);
        Servico Atualizar(Servico servico);
        bool ApagarConfirmacao(int id);
        
    }
}
