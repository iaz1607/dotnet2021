using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;
using OnlineStoreApp.DAL.Context;
using AutoMapper;
using System.Collections.Generic;

namespace OnlineStoreApp.DAL.Implementation
{
    public class BonusDataAccess : IBonusDataAccess
    {
        private StoreContext Context { get; }
        private IMapper Mapper { get; }

        public Task<IEnumerable<Bonus>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<Bonus> IBonusDataAccess.GetAsync(IBonusIdentity employeeId)
        {
            throw new System.NotImplementedException();
        }

        Task<Bonus> IBonusDataAccess.InsertAsync(BonusUpdateModel employee)
        {
            throw new System.NotImplementedException();
        }

        Task<Bonus> IBonusDataAccess.UpdateAsync(BonusUpdateModel employee)
        {
            throw new System.NotImplementedException();
        }
    }
}