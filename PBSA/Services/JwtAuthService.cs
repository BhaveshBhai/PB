using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using PBSA.Interface;
using PBSA.Models.DB;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PBSA.Services
{
    public class JwtAuthService : IJwtAuthService
    {
        private readonly string key;
        public JwtAuthService(string key)
        {
            this.key = key;
        }
        public string Authorization(string userName, string password)
        {
            var user = new User();
            using (var db = new PBSAContext())
            {
                user = db.User.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            }
            if (user == null)
            {
                return null;
            }
            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
