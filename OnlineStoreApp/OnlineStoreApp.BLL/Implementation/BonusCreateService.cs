using OnlineStoreApp.BLL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Contracts;

namespace OnlineStoreApp.BLL.Implementation
{
    public class BonusCreateService : IBonusCreateService
    {
        private IBonusDataAccess BonusDataAccess { get; }

        public BonusCreateService(IBonusDataAccess bonusDataAccess)
        {
            this.BonusDataAccess = bonusDataAccess;
        }
        public async Task<Bonus> CreateAsync(BonusUpdateModel bonus)
        {
            return await this.BonusDataAccess.InsertAsync(bonus);
        }
    }
}