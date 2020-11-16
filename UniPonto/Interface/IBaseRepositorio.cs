using System;
using System.Collections.Generic;

namespace UniPonto.Interface
{
    public interface IBaseRepositorio<T> : IDisposable
    {
        void Salvar(T entity);
        IEnumerable<T> ObterTodos();
        T BuscarPorId(Guid id);
        bool Excluir(Guid id);
    }
}
