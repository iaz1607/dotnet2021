using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;

namespace OnlineStoreApp.BLL.Contracts
{
    public interface IBonusCreateService
    {
        Task<Bonus> CreateAsync(BonusUpdateModel bonus);
    }
}