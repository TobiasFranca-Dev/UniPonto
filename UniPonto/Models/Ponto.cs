using System;

namespace UniPonto.Models
{
    public class Ponto : Entity
    {
        public DateTime Data { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? SaidaIntervalo { get; set; }
        public DateTime? RetornoIntervalo { get; set; }
        public DateTime? Saida { get; set; }

    }
}
