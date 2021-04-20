using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class BonusGetService : IBonusGetService
    {
        private IBonusDataAccess BonusDataAccess { get; }

        public BonusGetService(IBonusDataAccess bonusDataAccess)
        {
            this.BonusDataAccess = bonusDataAccess;
        }

        public Task<IEnumerable<Bonus>> GetAsync()
        {
            return this.BonusDataAccess.GetAsync();
        }

        public Task<Bonus> GetAsync(IBonusIdentity bonus)
        {
            return this.BonusDataAccess.GetAsync(bonus);
        }
    }
}