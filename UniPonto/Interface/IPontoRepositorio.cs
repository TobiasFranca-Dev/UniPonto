using System;
using System.Collections.Generic;
using UniPonto.Models;

namespace UniPonto.Interface
{
    public interface IPontoRepositorio: IBaseRepositorio<Ponto>
    {
        IEnumerable<Ponto> ObterPorusuario(Guid idUser);
    }
}
