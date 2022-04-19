using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using minhaAPI.src.Auth;
using minhaAPI.src.Servises.Interfaces;
using src.Models;
using System;
using System.Threading.Tasks;

namespace minhaAPI.src.Controllers
{
    [Route("v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Login(User model)
        {
            try
            {  
                // Recupera o usuário
                User user = await _userService.Login(model.Email, model.Password);

                // Verifica se o usuário existe
                if (user == null)
                {
                    return NotFound(new { message = "Usuário ou senha inválidos" });
                }
                else
                {
                    // Gera o Token
                    string token = JwtAuth.GenerateToken(user);

                    // Oculta a senha
                    user.Password = "";

                    // Retorna os dados
                    return Ok(token);
                }
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("add-user")]
        [AllowAnonymous]
        public IActionResult AddUser(User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else if(_userService.Add(user))
                {
                    return Created("usuario criado com sucesso!", user);
                }
                else
                    return Conflict("usuário já existente");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("get-user")]
        [AllowAnonymous]
        public IActionResult GetUser(string email)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                else
                {
                    User user = _userService.GetUser(email);
                    if(user == null)
                        return StatusCode(204, "Usuário não existe");
                    else
                        return Ok(user);
                    
                }
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpPut]
        [Route("update-user")]
        [AllowAnonymous]
        public IActionResult Update(long id, User user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(); 
                }
                else
                {
                    user.Id = id;
                    if (_userService.Update(user))
                        return Created("Usuario atualizado com sucesso", user);
                    else
                        return StatusCode(204, "Usuário inexistente");
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("delete-user")]
        [Authorize]
        public IActionResult Delete(long id)
        {
            try
            {
                if (_userService.Delete(id))
                    return Ok("usuário deletado com sucesso");
                else
                    return StatusCode(204, "usuário inexistente");
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }

        }
    }
}
