using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using cine_matine_api.Models;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace cine_matine_api.Services
{
    public class UsersService
    {
        private readonly AppSettings _appSettings;
        private readonly CineContext _context;

        public UsersService(IOptions<AppSettings> appSettings, CineContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public AuthenticatedModel Authenticate(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Login == login);

            // return null if user not found
            if (user == null)
                return null;

            if (!VerifyPasswordHash(senha, Convert.FromBase64String(user.Senha), Convert.FromBase64String(user.Salt)))
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Login.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticatedModel
            {
                Id = user.Id,
                Login = user.Login,
                Role = user.Role,
                Token = tokenHandler.WriteToken(token)
            };
        }

        public IEnumerable<UsersModel> GetAll()
        {
            return _context.Users.Select(s => new UsersModel
            {
                Id = s.Id,
                Login = s.Login
            });
        }

        public void Create(UsersModel user)
        {
            if (string.IsNullOrWhiteSpace(user.Senha))
                throw new Exception("Senha não pode ser nula");

            if (_context.Users.Any(x => x.Login == user.Login))
                throw new Exception("Login \"" + user.Login + "\" já existente");

            //int id = _context.Users.Max(m => m.Id).GetValueOrDefault() + 1;

            string passwordHash, passwordSalt;
            CreatePasswordHash(user.Senha, out passwordHash, out passwordSalt);

            //user.Id = id;
            user.Senha = passwordHash;
            user.Salt = passwordSalt;
            user.Role = "user";

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(UsersModel userParam)
        {
            var user = _context.Users.Find(userParam.Login);

            if (user == null)
                throw new Exception("Login não encontrado");

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.Role))
                user.Role = userParam.Role;

            if (!string.IsNullOrWhiteSpace(userParam.Senha))
            {
                string passwordHash, passwordSalt;
                CreatePasswordHash(userParam.Senha, out passwordHash, out passwordSalt);

                user.Senha = passwordHash;
                user.Salt = passwordSalt;
            }

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private static void CreatePasswordHash(string senha, out string passwordHash, out string passwordSalt)
        {
            if (senha == null)
                throw new ArgumentNullException("senha");

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode estar vazia.", "senha");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha)));
            }
        }

        private static bool VerifyPasswordHash(string senha, byte[] storedHash, byte[] storedSalt)
        {
            if (senha == null)
                throw new ArgumentNullException("senha");

            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode estar vazia.", "senha");

            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");

            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
