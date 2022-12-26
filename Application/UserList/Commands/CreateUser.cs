using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserList.Commands
{
    public class CreateUser
    {

        public async static Task<bool> CreateUserAsync(User user)
        {
            using (var db = new AppDBContext())
            {
                try
                {
                    await db.Users.AddAsync(user);
                    return await db.SaveChangesAsync() >= 1;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
