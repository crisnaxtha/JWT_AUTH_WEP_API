﻿using MeroKhata.Data;
using MeroKhata.Dtos;
using MeroKhata.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeroKhata.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            
            return Created("Success", _repository.Create(user));
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            if(user == null)
            {
                return BadRequest(new
                {
                    message = "Invalid Credential"
                });
            }
            if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                return BadRequest(new
                {
                    message = "Invalid Credential"
                });
            }
            return Ok(user);
        }
    }
}
