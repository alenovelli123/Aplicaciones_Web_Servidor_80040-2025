using Microsoft.AspNetCore.Mvc;
using WebAppClase08.EF;
using WebAppClase08.Interfaces;
using WebAppClase08.Models;

namespace WebAppClase08.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(long id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] User user)
        {
            if (user == null)
                return BadRequest();

            _userRepository.AddUser(user);

            // Devuelve el usuario completo con el ID generado
            return Ok(user);
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(long id, [FromBody] User updatedUser)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();

            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.Dni = updatedUser.Dni;

            _userRepository.UpdateUser(user);
            return Ok("Usuario actualizado correctamente.");
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(long id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return NotFound();

            _userRepository.DeleteUser(id);
            return NoContent();
        }
    }
}
