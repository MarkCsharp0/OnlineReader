using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Вычисление хеша пароля.
        /// </summary>
        /// <param name="password">Пароль.</param>
        /// <returns>Вычисленный хеш.</returns>
        string HashPassword(string password);

        /// <summary>
        /// TODO: Заполнить.
        /// </summary>
        /// <param name="actualPassword">TODO</param>
        /// <param name="hashedPassword">TODO</param>
        /// <returns>TODO</returns>
        bool VerifyPassword(string actualPassword, string hashedPassword);

        /// <summary>
        /// TODO.
        /// </summary>
        /// <param name="id">TODO.</param>
        /// <returns>TODO.</returns>
        AuthData GetAuthData(string id);
    }
}
