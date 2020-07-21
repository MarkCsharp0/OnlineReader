using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineReader.Data.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
     /// <inheritdoc />
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Класс для маппинга.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// API для управления пользователями.
        /// </summary>
        private readonly UserManager<AppUser> userManager;

        /// <summary>
        /// Класс для хеширования паролей.
        /// </summary>
        private readonly IPasswordHasher<AppUser> passwordНasher;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminController"/> class.
        /// </summary>
        /// <param name="mapper">Класс для маппинга.</param>
        /// <param name="usrMgr">API для управления пользователями.</param>
        public AdminController(IPasswordHasher<AppUser> passwordHash, IMapper mapper, UserManager<AppUser> usrMgr)
        {
            userManager = usrMgr;
            _mapper = mapper;
            passwordНasher = passwordHash;
        }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [Route("create")]
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
        /// Удаление пользователя с данным id.
        /// </summary>
        /// <param name="id">Id удаляемого пользователя</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        [HttpPost]
        [Route("{id}")]
        public async Task<AppUser> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id).ConfigureAwait(true);
            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return user;
                } else
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Редактирование пользователя.
        /// </summary>
        /// <param name="model">Модель на основе которой происходят изменения</param>
        /// <returns>Измененный пользователь.</returns>
        [HttpPost]
        [Route("edit")]
        public async Task<AppUser> Edit(CreateModel model)
        {
            var user = await userManager.FindByNameAsync(model.Name).ConfigureAwait(true);
            if (user != null)
            {
                user.Email = model.Email;
                user.PasswordHash = passwordНasher.HashPassword(user, model.Password);
                var result = await userManager.UpdateAsync(user).ConfigureAwait(true);
                if (result.Succeeded)
                {
                    return user;
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
        /// <returns>Список пользователей</returns>
        [Route("index")]
        public List<AppUser> Index()
        {
            return userManager.Users.ToList();
        }
    }
}
