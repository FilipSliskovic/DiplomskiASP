﻿using KaficiProjekat.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace KaficiProjekat.API.Core
{
    public class JwtManager
    {


        private readonly KaficiProjekatDbContext _context;
        private readonly JwtSettings _settings;

        public JwtManager(KaficiProjekatDbContext context, JwtSettings settings)
        {
            _context = context;
            _settings = settings;
        }



        public string MakeToken(string username, string password)
        {
            var user = _context.Users.Include(x => x.UseCases).FirstOrDefault(x => x.UserName == username);

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!valid)
            {
                throw new UnauthorizedAccessException();
            }

            //var useCases = _context.UserUseCase.Where(x => x.UserId == user.UserId).Select(x => x.UseCaseId);

            var actor = new JwtUser
            {
                Id = user.Id,
                UseCaseIds = user.UseCases.Select(x => x.UseCaseId).ToList(),
                Identity = user.UserName,
                Username = user.UserName,
                IsSuperUser = user.IsSuperUser
            };

            var claims = new List<Claim> // Jti : "",
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _settings.Issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _settings.Issuer),
                new Claim("UserId", actor.Id.ToString(), ClaimValueTypes.String, _settings.Issuer),
                new Claim("UseCases", JsonConvert.SerializeObject(actor.UseCaseIds)),
                new Claim("IsSuperUser", user.IsSuperUser.ToString()),
                new Claim("Username", user.UserName),
                
                
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _settings.Issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_settings.Minutes),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
