using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using WebAppClase08.Controllers;
using WebAppClase08.Interfaces;
using WebAppClase08.EF;
using System.Collections.Generic;

namespace WebAppClase08.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly UserController _controller;

        public UserControllerTests()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _controller = new UserController(_userRepoMock.Object);
        }

        // --- TESTS DE UPDATE ---

        [Fact]
        public void UpdateUser_DeberiaRetornarOk_SiActualizaCorrectamente()
        {
            var id = 1;
            var modelo = new User { FirstName = "Ana", LastName = "López", Dni = "87654321" };
            _userRepoMock.Setup(r => r.GetUserById(id)).Returns(new User { UserId = id });

            var resultado = _controller.UpdateUser(id, modelo).Result;

            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void UpdateUser_DeberiaRetornarNotFound_SiUsuarioNoExiste()
        {
            var modelo = new User { FirstName = "Ana", LastName = "López", Dni = "87654321" };
            _userRepoMock.Setup(r => r.GetUserById(It.IsAny<long>())).Returns((User)null);

            var resultado = _controller.UpdateUser(99, modelo).Result;

            Assert.IsType<NotFoundResult>(resultado);
        }

        // --- TEST DE ADD ---

        [Fact]
        public void AddUser_DeberiaRetornarBadRequest_SiUsuarioEsNull()
        {
            var resultado = _controller.AddUser(null);
            Assert.IsType<BadRequestResult>(resultado);
        }

        // --- TESTS DE GET ---

        [Fact]
        public void GetAllUsers_DeberiaRetornarOkConLista()
        {
            _userRepoMock.Setup(r => r.GetAllUsers()).Returns(new List<User>());

            var resultado = _controller.GetAllUsers();

            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void GetUserById_DeberiaRetornarOk_SiUsuarioExiste()
        {
            _userRepoMock.Setup(r => r.GetUserById(1)).Returns(new User { UserId = 1 });

            var resultado = _controller.GetUserById(1);

            Assert.IsType<OkObjectResult>(resultado);
        }

        [Fact]
        public void GetUserById_DeberiaRetornarNotFound_SiUsuarioNoExiste()
        {
            _userRepoMock.Setup(r => r.GetUserById(It.IsAny<long>())).Returns((User)null);

            var resultado = _controller.GetUserById(99);

            Assert.IsType<NotFoundResult>(resultado);
        }

        // --- TESTS DE DELETE ---

        [Fact]
        public void DeleteUser_DeberiaRetornarNoContent_SiUsuarioExiste()
        {
            _userRepoMock.Setup(r => r.GetUserById(1)).Returns(new User { UserId = 1 });

            var resultado = _controller.DeleteUser(1);

            Assert.IsType<NoContentResult>(resultado);
        }

        [Fact]
        public void DeleteUser_DeberiaRetornarNotFound_SiUsuarioNoExiste()
        {
            _userRepoMock.Setup(r => r.GetUserById(It.IsAny<long>())).Returns((User)null);

            var resultado = _controller.DeleteUser(99);

            Assert.IsType<NotFoundResult>(resultado);
        }
    }
}
