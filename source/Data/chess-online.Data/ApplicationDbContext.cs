namespace chess_online.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using Migrations;
    using Models.UserModels;
    using Models.SocialModels;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("Chess-online", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Player> players { get; set; }
        public IDbSet<ChatRoom> chatRooms { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        IDbSet<TEntity> IApplicationDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }
    }
}
