﻿using ShoppingCart.Models;
using ShoppingCart.Repository.BankSystem.BankSystemModels;

namespace ShoppingCart.Repository
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAllNonApprovedUsers();
        public Status ApproveUser(string UserId);
        public Status SaveUserAccount (UserAccount account);

        public Task<Status> DeleteUser(string UserId);
    }
}
