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

    public class ItemDataAccess : IItemDataAccess
    {
        private StoreContext Context { get; }
        private IMapper Mapper { get; }
        public Task<Item> GetAsync(IItemIdentity itemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> GetAsync(int itemId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> InsertAsync(Item item)
        {
            throw new System.NotImplementedException();
        }

        public Task<Item> UpdateAsync(ItemUpdateModel item)
        {
            throw new System.NotImplementedException();
        }


        Task<IEnumerable<Item>> IItemDataAccess.GetAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}