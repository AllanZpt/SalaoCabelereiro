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
        [Required(ErrorMessage = "Digite a descri��o do servi�o!")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite a dura��o do servi�o em minutos!")]
        public double Duracao { get; set; }
        [Required(ErrorMessage = "Digite o valor do servi�o!")]
        public double Valor { get; set; }
    }
}