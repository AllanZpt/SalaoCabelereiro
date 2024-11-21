namespace SalaoCabelo.Models
{
    public class AgendamentoModel
    {
        public DateTime DataAgendamento { get; set; } // A data e hora selecionada para o agendamento
        public List<int> ServicosSelecionados { get; set; } // Lista de IDs dos serviços selecionados
    }
}
