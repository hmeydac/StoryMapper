namespace StoryMapper.Core.Repository
{
    using System;
    using System.Collections.Generic;

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