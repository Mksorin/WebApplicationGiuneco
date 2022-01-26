using LoginAndAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndAuth.Services
{
    public class SecurityService
    {
        List<UserModel> knownUsers = new List<UserModel>();
        UsersDAO userDAO = new UsersDAO();
        public SecurityService()
        {

            
        }

        public bool IsValid(UserModel user)
        {
            return userDAO.FindUserByNamePassword(user);
            //Return True if found in the list
           // return knownUsers.Any(x => x.username == user.username && x.password == user.password);
        }
    }
}
