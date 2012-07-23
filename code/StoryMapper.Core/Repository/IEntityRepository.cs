using System;
using System.Collections.Generic;
namespace StoryMapper.Core.Repository
{
    public interface IEntityRepository<T>
    {
        IEnumerable<T> GetList();
        IEnumerable<T> GetList(Func<T, bool> predicate);
        T Single(Func<T, bool> predicate);
        T Update(T entity);
        void Delete(T entity);
        T Create(T entity);
    }
}
