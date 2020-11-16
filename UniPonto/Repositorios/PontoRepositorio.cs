using System;
using System.Collections.Generic;
using UniPonto.Interface;
using UniPonto.Models;

namespace UniPonto.Repositorios
{
    public class PontoRepositorio : BaseRepositorio<Ponto>, IPontoRepositorio
    {
        public IEnumerable<Ponto> ObterPorusuario(Guid idUser)
        {
            return col.Find(x => x.IdUsuario == idUser);
        }
    }
}
