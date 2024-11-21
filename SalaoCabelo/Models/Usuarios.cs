using SalaoCabelo.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SalaoCabelo.Models
{
    public class Usuarios
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Aniversario { get; set; }

        [StringLength(11),MinLength(11)]
        public string CPF { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Senha { get; set; } // Campo sensível

        [Phone]
        public string Celular { get; set; }

        public PerfilEnum Perfil { get; set; } = PerfilEnum.Padrao; 
        public DateTime DtUsuinc { get; set; }
        public DateTime? DtUsualt { get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}