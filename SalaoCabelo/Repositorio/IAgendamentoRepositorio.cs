using SalaoCabelo.Models;
using System;
using System.Threading.Tasks;

public interface IAgendamentoRepositorio
{
    Task<bool> BuscaData(DateTime dataAgendamento);
    Task<bool> GravaAgendamento(Agendamento agendamento);
    Task<List<Agendamento>> BuscarAgendamentosPorData(DateTime dataAgendamento);
}
