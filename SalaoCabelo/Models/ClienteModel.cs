using SalaoCabelo.Enum;

namespace SalaoCabelo.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public PerfilEnum Perfil { get; set; }
        public DateTime DtUsuinc { get; set; }
    }
}