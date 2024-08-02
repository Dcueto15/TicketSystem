using Microsoft.AspNetCore.Mvc;
using TicketSystem.Services;
using TicketSystem.Utils;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using TicketSystem.Models;

namespace TicketSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IConfiguration _configuration;

        public UsuarioController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            _usuarioService = usuarioService;
            _configuration = configuration;
        }

        [HttpPost("GetAllUsuarios")]
        public async Task<IActionResult> GetAllUsuarios()
        {
            try
            {
                var usuarios = await _usuarioService.GetAllUsuariosAsync();
                var token = JwtTokenGenerator.GenerateJwtToken(0, 0, _configuration["Jwt:Key"]); // Ajustar los parámetros del token según sea necesario
                return Ok(new { Usuarios = usuarios, Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("GetUsuarioById")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            try
            {
                var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
                var token = JwtTokenGenerator.GenerateJwtToken(usuario.Id, usuario.PerfilUsuarioId, _configuration["Jwt:Key"]);
                return Ok(new { Usuario = usuario, Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("AddUsuario")]
        public async Task<IActionResult> AddUsuario(Usuario usuario)
        {
            try
            {
                await _usuarioService.AddUsuarioAsync(usuario);
                var token = JwtTokenGenerator.GenerateJwtToken(usuario.Id, usuario.PerfilUsuarioId, _configuration["Jwt:Key"]);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("UpdateUsuario")]
        public async Task<IActionResult> UpdateUsuario(Usuario usuario)
        {
            try
            {
                await _usuarioService.UpdateUsuarioAsync(usuario);
                var token = JwtTokenGenerator.GenerateJwtToken(usuario.Id, usuario.PerfilUsuarioId, _configuration["Jwt:Key"]);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("DeleteUsuario")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            try
            {
                await _usuarioService.DeleteUsuarioAsync(id);
                var token = JwtTokenGenerator.GenerateJwtToken(0, 0, _configuration["Jwt:Key"]); // Ajustar los parámetros del token según sea necesario
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var usuario = await _usuarioService.LoginAsync(loginRequest.Username, loginRequest.Password);
                if (usuario == null)
                {
                    return Unauthorized("Invalid username or password.");
                }

                var token = JwtTokenGenerator.GenerateJwtToken(usuario.Id, usuario.PerfilUsuarioId, _configuration["Jwt:Key"]);
                return Ok(new { Usuario = usuario, Token = token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
