using OnlineStoreApp.DAL.Contracts;
using OnlineStoreApp.Domain;
using OnlineStoreApp.Domain.Contracts;
using OnlineStoreApp.Domain.Models;
using System.Threading.Tasks;
using AutoMapper;
using OnlineStoreApp.DAL.Context;
using System.Collections.Generic;

namespace OnlineStoreApp.DAL.Implementation
{
    public class UserDataAccess : IUserDataAccess
    {
        private StoreContext Context { get; }
        private IMapper Mapper { get; }
        public Task<User> GetAsync(IUserIdentity employeeId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> InsertAsync(User employee)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> UpdateAsync(UserUpdateModel employee)
        {
            throw new System.NotImplementedException();
        }
    }
}