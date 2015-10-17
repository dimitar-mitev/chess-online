namespace chess_online.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {

        private IApplicationDbContext context;

        public GenericRepository(IApplicationDbContext chessOnlineDbContext)
        {
            this.context = chessOnlineDbContext;
        }

        public void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public IQueryable<T> All()
        {
            return this.context.Set<T>();
        }

        public T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            this.ChangeState(entity, EntityState.Detached);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> filter)
        {
            return this.All().Where(filter);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

     
        private void ChangeState(T entity, EntityState newState)
        {
            this.context.Set<T>().Attach(entity);
            this.context.Entry(entity).State = newState;
        }
    }
}
