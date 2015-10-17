namespace chess_online.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models.UserModels;

    public interface IApplicationDbContext
    {

        IDbSet<Player> players { get; set; }

        IDbSet<TEntity> Set<TEntity>() where TEntity:class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
