using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineReader.Data.Entities;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    /// <summary>
    /// Контроллер для управления аккаунтом.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> userManager;

        private IAuthService authService;

        public AccountController(UserManager<AppUser> usrManager, IAuthService service)
        {
            userManager = usrManager;
            authService = service;
        }

        /// <summary>
        /// Процесс аутентификации и авторизации.
        /// </summary>
        /// <param name="details"></param>
        /// <param name="returnUrl"></param>
        /// <returns>Модель для аутентификации.</returns>
        [HttpPost("login")]
        public async Task<ActionResult<AuthData>> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null) {
                return BadRequest(new { email = "no user with this email" });
            }

            /* var passwordValid = authService.VerifyPassword(model.Password, user.Password);
            if (!passwordValid) {
                return BadRequest(new { password = "invalid password" });
            }*/

            return authService.GetAuthData(user.Id);
        }
    }
}
