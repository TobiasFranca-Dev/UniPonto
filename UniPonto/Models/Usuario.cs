using System.Collections.Generic;

namespace UniPonto.Models
{
    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Funcao { get; set; }
        public bool Admin { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public IEnumerable<Ponto> Historico { get; set; }

        public Usuario()
        {
            Nome = "";
            Ativo = true;
            Funcao = "";
            Admin = false;
            Login = "";
            Senha = "";
            Historico = new List<Ponto>();
        }

    }
}
