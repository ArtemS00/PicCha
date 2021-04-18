﻿using Microsoft.AspNetCore.Mvc;
using PicCha.Services.Interfaces;
using PicCha.Services.Models.Auth;
using System;

namespace PicCha.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login([FromBody]LoginModel loginModel)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Model is invalid!");

            var token = _authService.Login(loginModel);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register([FromBody]RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Model is invalid!");

            var token = _authService.Register(registerModel);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
