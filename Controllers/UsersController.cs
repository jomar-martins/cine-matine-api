using cine_matine_api.Models;
using cine_matine_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cine_matine_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private UsersService _userService;
        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UsersModel model)
        {
            try
            {
                // create user
                _userService.Create(model);
                return Ok();
            }
            catch (System.Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult Update([FromBody] UsersModel model, int id)
        {
            model.Id = id;

            try
            {
                // update user 
                _userService.Update(model);
                return Ok();
            }
            catch (System.Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult GetAll()
        {
            var retorno = new
            {
                user = User.Identity.Name,
                users = _userService.GetAll(),
            };

            return Ok(retorno);
        }

    }
}