using chess_online.Data.Repositories;
using chess_online.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_online.Data
{
    public class ChessOnlineData : IChessOnlineData
    {
        private IApplicationDbContext context;
        private IDictionary<Type, object> repositories;

        public ChessOnlineData()
            :this(new ApplicationDbContext())
        {
            this.repositories = new Dictionary<Type, object>();
        }

        public ChessOnlineData(IApplicationDbContext chessOnlineDbContext)
        {
            this.context = chessOnlineDbContext;
        }

        public IGenericRepository<Player> Players
        {
            get
            {
                return this.GetRepository<Player>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var newRepository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(typeOfModel, newRepository);
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}
