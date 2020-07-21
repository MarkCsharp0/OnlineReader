using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineReader.Data.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    /// <summary>
    /// Контроллер для администратора.
    /// </summary>
    public class AdminController : Controller
    {
        /// <summary>
        /// API для управления пользователями.
        /// </summary>
        private UserManager<AppUser> userManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="usrMgr">API для управления пользователями.</param>
        public AdminController(UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="model"></param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        public async Task<CreateModel> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email,
                };
                var result = await userManager.CreateAsync(user, model.Password).ConfigureAwait(true);
                if (result.Succeeded)
                {
                    return model;
                } else
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Возвращает список пользователей.
        /// </summary>
        /// <returns></returns>
        public List<AppUser> Index()
        {
            return userManager.Users.ToList();
        }
    }
}
