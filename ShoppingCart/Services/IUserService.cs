﻿using ShoppingCart.Models;
using ShoppingCart.Repository.BankSystem.BankSystemModels;

namespace ShoppingCart.Services
{
    public interface IUserService
    {
        //Task<List<AppUser>> GetNonApprovedUsers();
        public Status ApproveUser(string UserId);

        public Status SaveUserAccount(UserAccount Account);

        Task<List<AppUser>> GetAllNonApprovedUsers();

        public Task<Status> DeleteUser(string UserId);
    }
}
