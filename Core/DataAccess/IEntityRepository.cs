using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // where T : bize kıst getiriyor
    // class -> sadece class gelebilir
    // IEntity -> sadece Entitties.Abstract da tanımlamış olduğumuz IEntity veya IEntity implemente eden classlar gelebilir
    // new() -> sadece new lenebilir classlar gelebiler. IEntity 'nin kendisi interface olduğu için new lenemez
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
