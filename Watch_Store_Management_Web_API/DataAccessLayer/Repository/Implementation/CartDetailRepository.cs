﻿using Watch_Store_Management_Web_API.DataAccessLayer.Context;
using Watch_Store_Management_Web_API.DataAccessLayer.Entities;
using Watch_Store_Management_Web_API.DataAccessLayer.Repository.Interface;

namespace Watch_Store_Management_Web_API.DataAccessLayer.Repository.Implementation
{

    public class CartDetailRepository : BaseRepository<CartDetail>, ICartDetailRepository
    {
        public CartDetailRepository(WatchStoreDBContext watchStoreDBContext) : base(watchStoreDBContext)
        {

        }
    }
}
