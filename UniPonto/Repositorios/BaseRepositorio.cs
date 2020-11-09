using LiteDB;
using UniPonto.Models;

namespace UniPonto.Repositorios
{
    public abstract class BaseRepositorio<T> where T : Entity, new()
    {        
        private readonly LiteDatabase db;
        private readonly ILiteCollection<T> col;

        public BaseRepositorio()
        {
            db = new LiteDatabase("Filename=database.db;Password=6E9E48446DE34242AB4AE82527A43918");
            col = db.GetCollection<T>(typeof(T).Name);
        }

        public virtual void Adicionar(Entity entity)
        {
            col.Insert(entity);
        }



    }
}
