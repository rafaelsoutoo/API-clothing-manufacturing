﻿using Application.UseCase.Users.Authenticate;
using Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthenticateUseCase _authenticateUseCase;

        public AuthController(AuthenticateUseCase authenticateUserUseCase)
        {
            _authenticateUseCase = authenticateUserUseCase;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginUserRequest request)
        {
            try
            {
                var token = _authenticateUseCase.Authenticate(request.Email, request.Password);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}