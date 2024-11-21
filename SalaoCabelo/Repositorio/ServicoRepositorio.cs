using Microsoft.EntityFrameworkCore;
using SalaoCabelo.Data;
using SalaoCabelo.Migrations;
using SalaoCabelo.Models;

namespace SalaoCabelo.Repositorio
{
    public class ServicoRepositorio : IServicoRepositorio
    {
        private readonly SalaoContext _salaocontext;
        public ServicoRepositorio(SalaoContext salaoContext)
        {
            _salaocontext = salaoContext;
        }

        public async Task<List<Servico>> BuscarTodos()
        {
            return await _salaocontext.Servicos.ToListAsync();
        }
        public Servico Adicionar(Servico servico)
        {
            _salaocontext.Servicos.Add(servico);
            _salaocontext.SaveChanges();
            return servico;
        }

        public Servico ListarPorId(int id)
        {
            return _salaocontext.Servicos.FirstOrDefault(x => x.Id == id);
        }

        public Servico Atualizar(Servico servico)
        {
            Servico servicoDB = ListarPorId(servico.Id);

            if (servicoDB == null) throw new System.Exception("Houve erro na atualização");

            servicoDB.Descricao = servico.Descricao;
            servicoDB.Valor = servico.Valor;
            servicoDB.Duracao = servico.Duracao;

            _salaocontext.Servicos.Update(servicoDB);
            _salaocontext.SaveChanges();

            return servicoDB;
        }

        public bool ApagarConfirmacao(int id)
        {
            Servico servicoDB = ListarPorId(id);
            if (servicoDB == null) throw new System.Exception("Houve erro no momento de deletar");

            _salaocontext.Servicos.Remove(servicoDB);
            _salaocontext.SaveChanges(true);

            return true;
        }
    }
}
