using UniPonto.Models;

namespace UniPonto.Interface
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Login(string user, string senha);

        bool UsuarioExistente(string login);
    }
}
