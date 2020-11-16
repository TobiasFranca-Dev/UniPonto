using System;

namespace UniPonto.Models
{
    public class Ponto : Entity
    {
        public Guid IdUsuario { get; set; }
        public DateTime Data { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Intervalo { get; set; }
        public DateTime? Retorno { get; set; }
        public DateTime? Saida { get; set; }

    }
}
