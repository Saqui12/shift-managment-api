using Application.Services.DTOs;
using Application.Services.DTOs.User;
using Application.Services.Implementation;
using Application.Services.Iterfaces;
using Application.Services.Validators.Iterface;
using Dominio.Entities.Identity;
using Dominio.Interfaces.Authentication;
using FluentAssertions;
using FluentValidation;
using MapsterMapper;
using Moq;
using System.Security.Claims;


namespace Test.AppGestionPeloteros.UnitTest.Services
{

    public class AuthenticationServiceTests
    {
        private readonly Mock<ITokenMana> _tokenManaMock = new();
        private readonly Mock<IUserMana> _userManaMock = new();
        private readonly Mock<IRoleMana> _roleManaMock = new();
        private readonly Mock<IAppLogger<AuthenticationService>> _loggerMock = new();
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IValidationService> _validatorMock = new();
        private readonly Mock<IValidator<CreateUser>> _userValidatorMock = new();
        private readonly Mock<IValidator<UpdateUser>> _updateUserValidatorMock = new();
        private readonly AuthenticationService _service;

        public AuthenticationServiceTests()
        {
            _service = new AuthenticationService(
                _tokenManaMock.Object,
                _userManaMock.Object,
                _roleManaMock.Object,
                _loggerMock.Object,
                _mapperMock.Object,
                _validatorMock.Object,
                _userValidatorMock.Object,
                _updateUserValidatorMock.Object
            );
        }

        [Fact]
        public async Task Login_ShouldReturnSuccess_WhenCredentialsAreValid()
        {
            // Arrange
            var loginUser = new LoginUser { Email = "asd@gmail.com", Password = "Admin12445!!!" };
            var appUser = new AppUser { Email = loginUser.Email };
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Email, appUser.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };
            
            _userManaMock.Setup(u => u.GetUserClaims(appUser.Email)).ReturnsAsync(claims);
            _tokenManaMock.Setup(t => t.GenerateToken(claims)).Returns("jwt-token");

            _mapperMock.Setup(m => m.Map<AppUser>(loginUser)).Returns(appUser);
            _userManaMock.Setup(u => u.LoginUser(loginUser.Email,loginUser.Password)).ReturnsAsync(true);
            _userManaMock.Setup(u => u.GetUserByEmail(loginUser.Email)).ReturnsAsync(appUser);
            _tokenManaMock.Setup(t => t.GenerateToken(It.IsAny<List<Claim>>())).Returns("jwt-token");
            _tokenManaMock.Setup(t => t.getRefreshToken()).Returns("refresh-token");
            _tokenManaMock.Setup(t=> t.AddRefreshToken(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(1);

            // Act
            var result = await _service.Login(loginUser);

            // Assert
            result.Success.Should().BeTrue();
            result.Token.Should().Be("jwt-token");
            result.RefreshToken.Should().Be("refresh-token");
        }
        [Fact]
        public async Task Login_ShouldReturnFasle_WhenWorngUserCredentials()
        {
            var user = new AppUser();
            var userlogin = new LoginUser  { Email = "",Password = "" };

            _userManaMock.Setup(x => x.LoginUser(userlogin.Email,userlogin.Password)).ReturnsAsync(false);
            _mapperMock.Setup(t => t.Map<AppUser>(userlogin)).Returns(user);

            var result = await _service.Login(userlogin);

            result.Success.Should().BeFalse();
            result.Message.Equals("Error al iniciar sesion ");
        }

        [Fact]
        public async Task Delete_shouldReturnSucces_WhenEmailExist()
        {
            var user = new AppUser();
            string email = "email@gmail.com";
            //Arrange
            _userManaMock.Setup(t => t.DeleteUserByEmail(email)).ReturnsAsync(true);
            _userManaMock.Setup(x => x.GetUserByEmail(email)).ReturnsAsync(user);
            //Act
            var result = await _service.DeleteUser(email);

            //Assert
            result.Success.Should().BeTrue();
            result.Message.Equals("Usuario eliminado con exito");
        }

        [Fact]
        public async Task Delete_ShouldReturnFalse_WhenEmailNotFound()
        {

            string email = "email@gmail.com";
            _userManaMock.Setup(x => x.GetUserByEmail(email)).ReturnsAsync(value: null);

            var result = await _service.DeleteUser(email);

            result.Success.Should().BeFalse();
            result.Message.Equals("Usuario no encontrado");
        }
        [Fact]
        public async Task Delete_ShouldReturnFalse_WhenArgumentNull()
        {
            string? email = null;

            var result = await _service.DeleteUser(email);

            result.Success.Should().BeFalse();
            result.Message.Equals("Debe ingresar un email");
        }
    }

}
