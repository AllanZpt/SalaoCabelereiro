using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SalaoCabelo.Data;
using SalaoCabelo.Models;
using SalaoCabelo.Repositorio;

namespace SalaoCabelo.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly IAgendamentoRepositorio _agendamentoRepositorio;
        private readonly SalaoContext _context;

        public AgendamentoController(IAgendamentoRepositorio agendamentoRepositorio, SalaoContext context)
        {
            _agendamentoRepositorio = agendamentoRepositorio;
            _context = context;
        }

        //Carrega a tela com as datas já preenchendo uma data(de amanha por default)
        public IActionResult Index(string dataAgendamento)
        {
            // Verifica se a data foi passada; se não, define o padrão como o dia de amanhã
            if (string.IsNullOrEmpty(dataAgendamento))
            {
                dataAgendamento = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");

            }

            ViewBag.DataAgendamento = dataAgendamento;

            return View();
        }

        //Usado para que a data selecionada persista entre sessoes
        [HttpPost]
        public IActionResult CarregarHorarios(string dataAgendamento)
        {
            if (string.IsNullOrEmpty(dataAgendamento) || !DateTime.TryParse(dataAgendamento, out DateTime parsedDate) || parsedDate <= DateTime.Today)
            {
                dataAgendamento = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            }
            TempData["dataAgendamento"] = dataAgendamento;
            return View("Index");
        }


        //Usado para efetuar o agendamento/ gravar na tabela
        [HttpPost]
        public async Task<IActionResult> Agendar(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                var agenda = new Agendamento
                {
                    Id_cliente = agendamento.Id_cliente,
                    Id_servico = agendamento.Id_servico,
                    Data_agendado = agendamento.Data_agendado,
                    St_ativo = true 
                };

                // Gravar o agendamento
                bool sucesso = await _agendamentoRepositorio.GravaAgendamento(agendamento);

                if (sucesso)
                {
                    TempData["Mensagem"] = "Agendamento realizado com sucesso!";
                    return RedirectToAction("Sucesso");
                }
                else
                {
                    TempData["Mensagem"] = "Erro ao agendar. Tente novamente.";
                    return RedirectToAction("Falha");
                }
            }


            TempData["Mensagem"] = "Dados inválidos. Verifique as informações.";
            return View(agendamento);
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult Apagar()
        {
            return View();
        }
    }
}