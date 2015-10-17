namespace chess_online.Data
{

    using chess_online.Data.Repositories;
    using chess_online.Models.UserModels;

    public interface IChessOnlineData
    {
        IGenericRepository<Player> Players { get; }

        void SaveChanges();
    }
}
