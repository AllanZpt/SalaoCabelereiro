using SalaoCabelo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using SalaoCabelo.Data;

public class AgendamentoRepositorio : IAgendamentoRepositorio
{
    private readonly SalaoContext _salaocontext;
    public AgendamentoRepositorio(SalaoContext salaoContext)
    {
        _salaocontext = salaoContext;
    }

    public async Task<List<Agendamento>> BuscarAgendamentosPorData(DateTime dataAgendamento)
    {
        return await _salaocontext.Agendamentos
            .Where(a => a.Data_agendado.Date == dataAgendamento.Date && a.St_ativo)
            .ToListAsync();
    }

    public async Task<bool> BuscaData(DateTime dataAgendamento)
    {
        var agendamentoExistente = await _salaocontext.Agendamentos
            .Where(a => a.Data_agendado.Date == dataAgendamento.Date &&
                        a.Data_agendado.TimeOfDay == dataAgendamento.TimeOfDay &&
                        a.St_ativo)
            .FirstOrDefaultAsync();

        return agendamentoExistente != null;
    }

    public async Task<bool> GravaAgendamento(Agendamento agendamento)
    {
        _salaocontext.Agendamentos.Add(agendamento);
        await _salaocontext.SaveChangesAsync();
        return true;
         
    }
}
