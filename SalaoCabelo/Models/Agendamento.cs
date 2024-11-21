using System.ComponentModel.DataAnnotations.Schema;

namespace SalaoCabelo.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        public int Id_cliente { get; set; }
        [ForeignKey("Id")]
        public Usuarios usuarios { get; set; }

        public int Id_servico {  get; set; }
        [ForeignKey("Id")]
        public Servico servico{ get; set; }

        public DateTime Data_agendado { get; set; }

        public bool St_ativo { get; set; }

    }
}
