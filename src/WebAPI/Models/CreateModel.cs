using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    /// <summary>
    /// Модель создания пользователя.
    /// </summary>
    public class CreateModel
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Почта пользователя.
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Пароль пользователя.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
