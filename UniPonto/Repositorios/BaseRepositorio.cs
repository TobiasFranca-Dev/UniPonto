using LiteDB;
using System;
using System.Collections.Generic;
using UniPonto.Interface;
using UniPonto.Models;

namespace UniPonto.Repositorios
{
    public abstract class BaseRepositorio<T> : IDisposable, IBaseRepositorio<T> where T : Entity
    {
        public readonly ILiteDatabase db;
        public readonly ILiteCollection<T> col;

        public BaseRepositorio()
        {
            db = new LiteDatabase("Filename=database.db;Password=6E9E48446DE34242AB4AE82527A43918");
            col = db.GetCollection<T>(typeof(T).Name);
        }

        public virtual void Salvar(T entity)
        {            
            col.Upsert(entity);
        }

        public T BuscarPorId(Guid id)
        {
            return col.FindOne(x => x.Id == id);
        }

        public bool Excluir(Guid id)
        {
            return col.Delete(id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return col.FindAll();
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
