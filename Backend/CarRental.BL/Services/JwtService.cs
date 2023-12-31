﻿using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.BL.Services
{
    public class JwtService
    {
        public String SecretKey { get; set; }
        public int TokenDuration { get; set; }

        private readonly IConfiguration config;
        public JwtService(IConfiguration _config)
        {
            config = _config;
            this.SecretKey = config.GetSection("jwtConfig").GetSection("Key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);
        }
        public String GenerateToken(String id, String name, String email, String phone, Boolean isAdmin)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            string role = "Normal";
            if (isAdmin)
            {
                role = "Admin";
            }

            var payload = new[]
            {
                new Claim("id",id),
                new Claim("name",name),
                new Claim("email",email),
                new Claim("phone", phone),
                new Claim("isAdmin", role),

            };
            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
