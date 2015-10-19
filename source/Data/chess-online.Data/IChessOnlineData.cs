namespace chess_online.Data
{
    using Repositories;
    using Models.SocialModels;
    using Models.UserModels;
    using Models;

    public interface IChessOnlineData
    {
        IGenericRepository<Player> Players { get; }

        IGenericRepository<ChatRoom> ChatRooms { get; }

        IGenericRepository<ApplicationUser> ApplicationUsers { get; }

        void SaveChanges();
    }
}
