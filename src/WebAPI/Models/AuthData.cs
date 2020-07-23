using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class AuthData
    {
        /// <summary>
        /// Jwt token.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Время истечения токена.
        /// </summary>
        public long TokenExpirationTime { get; set; }

        /// <summary>
        /// Id пользователя.
        /// </summary>
        public string Id { get; set; }
    }
}
