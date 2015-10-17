namespace chess_online.Data.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IGenericRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, bool>> filter);

        void Add(T entity);

        T Delete(T entity);

        void Update(T entity);

        void Detach(T entity);

        int SaveChanges();
    }
}
