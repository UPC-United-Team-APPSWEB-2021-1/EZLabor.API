using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EZLabor.API.Domain.Models;
using EZLabor.API.Domain.Services;
using EZLabor.API.Domain.Services.Communications;
using EZLabor.API.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using BCryptNet = BCrypt.Net;



namespace EZLabor.API.Services
{

    public class UserService : IUserService
    {
        // TODO: Replace by Repository-based Implementation
        private List<User> _users = new List<User>
        {
            new User
            {
                Id = 1,
                UserName = "Aldair",
                Email = "aldaircuarez98@gmail.com",
                PasswordHash = BCryptNet.BCrypt.HashPassword("123")
            },
            new User
            {
                Id = 1,
                UserName = "JohnDoe",
                Email = "Doe@gmail.com",
                PasswordHash = BCryptNet.BCrypt.HashPassword("123")
            },
        };

        private readonly AppSettings _appSettings;

        private readonly IMapper _mapper;


        public UserService(IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public AuthenticationResponse Authenticate(AuthenticationRequest request)
        {
            // TODO: Replace with Repository-based Behavior
            var user = _users.SingleOrDefault(x => x.Email == request.Email);

            if (user == null || !BCryptNet.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                throw new ApplicationException("Username or password ir incorrect");
            }

            if (user == null) return null;

            var response = _mapper.Map<User, AuthenticationResponse>(user);
            response.Token = GenerateJwtToken(user);

            return response;
        }

        public IEnumerable<User> GetAll()
        {
            Console.WriteLine("Users Count is " + _users.Count);
            return _users;
        }

        private string GenerateJwtToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public void Register(RegisterRequest request)
        {
            // TODO: Replace with Repository-based Behavior
            if (_users.Any(x => x.Email == request.Email))
                throw new ApplicationException("Email '" + request.Email + "' is already taken");

            var user = _mapper.Map<RegisterRequest, User>(request);

            user.PasswordHash = BCryptNet.BCrypt.HashPassword(request.Password);

            // TODO: Replace with Repository-based Behavior
            _users.Add(user);
            Console.WriteLine("Users Count is " + _users.Count);

        }
    }
}
