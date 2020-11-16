using System.Linq;
using UniPonto.Interface;
using UniPonto.Models;

namespace UniPonto.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio()
        {
            var totalUsuarios = ObterTodos().Count();

            if (totalUsuarios == 0)
            {
                var user = new Usuario
                {
                    Admin = true,
                    Ativo = true,
                    Funcao = "Administrador",
                    Login = "admin",
                    Senha = "1234",
                    Nome = "Administrador"
                };

                Salvar(user);
            }
        }
        public Usuario Login(string user, string senha)
        {
            return col.FindOne(x => x.Login.ToLower() == user.ToLower() && x.Senha == senha);
        }

        public bool UsuarioExistente(string login)
        {
            return col.Find(x => x.Login.ToLower() == login.ToLower()).Any();
        }
    }
}
