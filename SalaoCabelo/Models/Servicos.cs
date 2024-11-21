using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalaoCabelo.Models
{
    public class Servico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite a descrição do serviço!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite a duração do serviço em minutos!")]
        public double Duracao { get; set; }
        [Required(ErrorMessage = "Digite o valor do serviço!")]
        public double Valor { get; set; }
    }
}