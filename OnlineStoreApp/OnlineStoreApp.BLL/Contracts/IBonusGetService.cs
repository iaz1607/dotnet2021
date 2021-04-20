using OnlineStoreApp.Domain;
using System.Threading.Tasks;
using OnlineStoreApp.Domain.Contracts;
using System.Collections.Generic;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IBonusGetService
    {
        Task<IEnumerable<Bonus>> GetAsync();
        Task<Bonus> GetAsync(IBonusIdentity bonus);
    }
}