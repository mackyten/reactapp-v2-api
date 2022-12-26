using Application.NoteList.Commands;
using Application.UserList.Commands;
using Application.UserList.Queries;
using Domain;
using Infrastructure.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Infrastructure.Services
{
    public class AuthServiceRepository
    {

        private IConfiguration configuration;

        public AuthServiceRepository(IConfiguration configuration) {
            this.configuration = configuration;
        }

   

        //createnewuser
        public async static Task<object> CreateNewUser(User user)
        {
            var result = await CreateUser.CreateUserAsync(user);
            if (result) {
                return user;
            }
            return null;
        }


        //loginUser
        public object LoginCurrentUser(User user) {
            //var result = AuthenticateUser(user);
            var au = new AuthenticateUser();
            var result = au.AuthenticateUserCredentials(user);

            if (result != null)
            {
                CurrentUser _user = new CurrentUser();
                GenerateToken generate = new GenerateToken();
                var token = generate.Generate(user, configuration);

                _user.authenticated = true;
                _user.email = result.email;
                _user.firstname = result.firstname;
                _user.surname = result.surname;
                _user.role = result.role;
                _user.JWT = token;

                
                return _user;
            }
            else {
                return null;
            }

        }


        //token generator
       /* public  string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gTqVff3L2j93ufiWf4l0"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, user.role),
            };

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }*/
    }
}
