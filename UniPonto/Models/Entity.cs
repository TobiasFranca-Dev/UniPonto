using LiteDB;
using System;

namespace UniPonto.Models
{
    public abstract class Entity
    {        
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        [BsonId]
        public Guid Id { get; set; }
    }
}
