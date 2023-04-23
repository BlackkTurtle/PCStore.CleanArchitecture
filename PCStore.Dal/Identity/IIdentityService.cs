using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PCStore.Domain.PCStoreEntities;

namespace PCStore.Infrastructure.Identity
{
    public interface IIdentityService
    {
        public Task<IdentityResult> CreateUserAsync(string userName, string email, string password);

        public Task<SignInResult> SignInAsync(string userName, string password, bool rememberMe);

        public Task SignOutAsync();

        public Task<ApplicationUser> GetUserAsync(string userId);

        public Task<IList<string>> GetUserRolesAsync(ApplicationUser user);

        public Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string role);

        public Task<IdentityResult> RemoveUserFromRoleAsync(ApplicationUser user, string role);

        public Task<bool> UserIsInRoleAsync(ApplicationUser user, string role);
    }
}
