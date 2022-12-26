using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserList.Queries
{
    public class AuthenticateUser
    {
        public User AuthenticateUserCredentials(User user)
        {
            var db = new AppDBContext();
            var result = db.Users.FirstOrDefault(u => u.email.ToLower() == user.email.ToLower() && u.password == user.password);

            if (result == null)
            {
                return null;

            }
            else
            {
                return result;
            }
        }
    }
}
