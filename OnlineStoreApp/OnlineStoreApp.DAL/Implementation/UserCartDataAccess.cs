using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStoreApp.DAL.Context;
using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;
using User = OnlineStoreApp.Domain.User;

namespace OnlineStoreApp.DAL.Implementation
{
    public class UserCartDataAccess : IUserCartDataAccess
    {
        private StoreContext Context { get; }
        private IMapper Mapper { get; }
        public Task<UserCart> GetAsync(IUserIdentity userId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<UserCart>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserCart> InsertAsync(UserCart userCart)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserCart> UpdateAsync(UserCart userCart)
        {
            throw new System.NotImplementedException();
        }
    }
}