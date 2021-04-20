using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;

namespace OnlineStoreApp.DAL.Contracts
{
    public interface IBonusDataAccess
    {
        Task<Bonus> InsertAsync(BonusUpdateModel bonus);
        Task<IEnumerable<Bonus>> GetAsync();
        Task<Bonus> GetAsync(IBonusIdentity bonus);
        Task<Bonus> UpdateAsync(BonusUpdateModel bonus);
    }
}