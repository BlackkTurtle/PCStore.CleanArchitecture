using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Application.Contracts
{
    public interface IUserService
    {
        Task<User> GetById(string id);
        Task<User> Create(User user);
        Task Update(string id,User user); 
        Task Remove(string id);
        Task<User> GetByUserName(string userName);
        Task<User> GetByEmail(string email);
        Task<User> GetByPhone(string phone);
        Task<User> GetByUserNameAndPassword(string UserName,string Password);
    }
}
