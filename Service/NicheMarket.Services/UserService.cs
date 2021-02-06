using NicheMarket.Data;
using NicheMarket.Data.Models.Users;
using NicheMarket.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NicheMarket.Services
{
    public class UserService : IUserService
    {
        private readonly NicheMarketDBContext dBContext;

        public UserService(NicheMarketDBContext dBContext)
        {
            this.dBContext = dBContext;
        }


        public Task<bool> EditUserRole()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserRoleViewModel>> AllUsers()
        {
            List<UserRoleViewModel> users = new List<UserRoleViewModel>();
            foreach (var item in dBContext.UserRoles)
            {
                users.Add(new UserRoleViewModel
                {
                    RoleId = item.RoleId,
                    UserId = item.UserId,
                    UserName = FindUser(item.UserId).UserName,
                    RoleName = FindRoleName(item.RoleId)
                });
            }
            return users;
        }

        public async Task<UserRoleViewModel> FindUserRole(string userId, string roleId)
        {
            UserRoleViewModel userRoleViewModel = new UserRoleViewModel
            {
                RoleId = roleId,
                UserId = userId,
                UserName = FindUser(userId).UserName,
                RoleName = FindRoleName(roleId)
            };
            return userRoleViewModel;

        }

        private NicheMarketUser FindUser(string id)
        {
            return dBContext.Users.FirstOrDefault(u => u.Id == id);
        }

        private string FindRoleName(string id)
        {
            return dBContext.Roles.FirstOrDefault(u => u.Id == id).Name;
        }

    }
}
