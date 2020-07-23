using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// <summary>
    ///  Модель для аутентификации.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Почта.
        /// </summary>
        [Required]
        [UIHint("email")]
        public string Email { get; set; }

        /// <summary>
        /// Пароль.
        /// </summary>
        [Required]
        [UIHint("password")]
        public string Password { get; set; }
    }
}
