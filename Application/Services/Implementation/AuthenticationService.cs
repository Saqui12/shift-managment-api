using Application.Services.DTOs;
using Application.Services.DTOs.Auth;
using Application.Services.DTOs.User;
using Application.Services.Iterfaces;
using Application.Services.Validators.Iterface;
using Dominio.Entities.Identity;
using Dominio.Interfaces.Authentication;
using FluentValidation;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Application.Services.Implementation
{
    public class AuthenticationService(ITokenMana tokenmana, IUserMana usermana, IRoleMana rolemana
        , IAppLogger<AuthenticationService> logger, IMapper _mapper, IValidationService _validator
        , IValidator<CreateUser> createUserValidate,IValidator<UpdateUser> updateUserValidate) : IAuthenticationService
    {

        //"email": "adminadmin@gmail.com",
        //"password": "Admin123!Admin123",

        public async Task<IEnumerable<UserDto>> GetAllUser()
        {
            var users = await usermana.GetAllUsers();
            if (users is null || !users.Any())
                return new List<UserDto>();
            
             var _user =  _mapper.Map<IEnumerable<UserDto>>(users);
            return _user;
        }
        public async Task<LoginResponse> Login(LoginUser loginuser)
        {
            if (loginuser == null)
                return new LoginResponse { Message = "Error al iniciar sesion" };
            // validation

         
            bool LoginResult = await usermana.LoginUser(loginuser.Email,loginuser.Password);
            if (!LoginResult)
                return new LoginResponse { Message = "Error al iniciar sesion" };

            var _user = await usermana.GetUserByEmail(loginuser.Email);
            var claims = await usermana.GetUserClaims(_user!.Email!);

            string jwttoken = tokenmana.GenerateToken(claims);
            string refreshtoken = tokenmana.getRefreshToken();

            int saveTokenResult = await tokenmana.AddRefreshToken(_user!.Id, refreshtoken);

            return saveTokenResult <= 0 ? new LoginResponse { Message = "Error al guardar el refreshtoken" }
                : new LoginResponse
                {
                    Token = jwttoken,
                    RefreshToken = refreshtoken,
                    Message = "Inicio de sesion exitoso",
                    Success = true
                };
        }

        public async Task<LoginResponse> RenewToken(string refreshToken)
        {
            bool validateTokenResult = await tokenmana.ValidateRefreshToken(refreshToken);
            if (!validateTokenResult)
                return new LoginResponse { Message = "invalid token" };

            string userId = await tokenmana.GetUserIdFromRefreshToken(refreshToken);
            AppUser? user = await usermana.GetUserById(userId);
            var claims = await usermana.GetUserClaims(user!.Email!);
            string newJwtToken = tokenmana.GenerateToken(claims);
            string newRefreshToken = tokenmana.getRefreshToken();
            await tokenmana.UpdateRefreshToken(userId, newRefreshToken);
            return new LoginResponse
            {
                Token = newJwtToken,
                RefreshToken = newRefreshToken,
                Message = "Token renewed",
                Success = true
            };
        }

        public async Task<ServiceResponse> Register(CreateUser createUser)
        {
            await _validator.ValidateAsync(createUser, createUserValidate);

            var model = _mapper.Map<AppUser>(createUser);
            model.UserName = createUser.Email;
            model.PasswordHash = createUser.Password;

            var result = await usermana.CreateUser(model);
            if (!result)
                return new ServiceResponse { Message = "Error al registrar el usuario" };

            var _user = await usermana.GetUserByEmail(createUser.Email);
            var Users = await usermana.GetAllUsers();
            bool Roleresult = await rolemana.AddUserToRole(_user!, Users.Count() > 1 ? "EMPLOYEE" : "ADMIN");

            if (!Roleresult)
            {
                var remove = await usermana.DeleteUserByEmail(_user!.Email!);
                if (!remove)
                {
                    logger.LogError($"user {_user.Email} failed to be remove", new Exception("Error a asignar un rol al usuario"));
                    return new ServiceResponse { Message = "Error al eliminar el usuario" };
                }

            }

            return new ServiceResponse { Message = "Usuario registrado con exito", Success = true };
        }
        public async Task<ServiceResponse> DeleteUser(string id)
        {
            if (id == null)
                return new ServiceResponse { Message = "Debe ingresar un id" };
            var user= await usermana.GetUserById(id);
  
            if (user is null)
                return new ServiceResponse { Message = "Usuario no encontrado" };

            await usermana.DeleteUserByEmail(user.Email!);
            return new ServiceResponse { Message = "Usuario eliminado con exito", Success = true };
        }

        public async Task<ServiceResponseData> GetByEmail(string email)
        {
            if (email == null)
                return new ServiceResponseData { Message = "Debe ingresar un email" };
            var user = await usermana.GetUserByEmail(email);
            if (user is null)
                return new ServiceResponseData { Message = "Usuario no encontrado" };

            return new ServiceResponseData { Message = "Usuario encontrado", Success = true, Data = user };

        }
        public async Task<ServiceResponseData> Update(string id,UpdateUser user)
        {
            if (user == null)
                return new ServiceResponseData { Message = "Debe ingresar un usuario" };

            await _validator.ValidateAsync(user, updateUserValidate);
            var _user = await usermana.GetUserById(id);
            if (_user is null)
                return new ServiceResponseData { Message = "Usuario no encontrado" };

            _user.FullName = user.FullName;
            _user.PhoneNumber = user.PhoneNumber;
            _user.UserName = user.UserName;
            _user.NormalizedUserName = user.UserName.ToUpper();
            _user.NormalizedEmail = user.Email.ToUpper();
            _user.Email = user.Email;

            var result = await usermana.UpdateUser(_user);
                
            if (result is null)
                return new ServiceResponseData { Message = "Error al actualizar el usuario" };
            return new ServiceResponseData { Message = "Usuario actualizado con exito", Success = true, Data = result };

        }

        public async Task<AuthenticatedUserDto> GetAuthenticatedUserAsync(ClaimsPrincipal user)
        {
            if (!user.Identity?.IsAuthenticated ?? true)
            {
                return new AuthenticatedUserDto { IsAuthenticated = false };
                
            }
            var email = user.FindFirst(ClaimTypes.Email)?.Value;
            var _user = await   usermana.GetUserByEmail(email!);

            var userDto = new AuthenticatedUserDto
            {
                IsAuthenticated = true,
                Id = _user?.Id,
                Name = _user?.FullName,
                Email = user.FindFirst(ClaimTypes.Email)?.Value,
                Roles = user.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList()
            };

            return userDto;
        }
        public async Task<string?> GetRoleIdByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return null;
            }
            var user = await usermana.GetUserByEmail(email);
            if (user == null)
            {
                return null;
            }
            var role = await rolemana.GetRoleIdByEmail(email);
            return role;
        }
        public async Task<bool> AddUserToRole(string userid ,string role)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(role))
            {
                return false;
            }
            var user = await usermana.GetUserById(userid);
            if (user == null)
            {
                return false;
            }
            var oldRole = await rolemana.GetRoleIdByEmail(user.Email!);
            if (!string.IsNullOrEmpty(oldRole))
            {
                
                await rolemana.DeleteUserRole(user, oldRole);
            }
            
          return  await rolemana.AddUserToRole(user,role);
            
        }
        public async Task<IdentityResult> ResetPassword(string id ,PasswordResetDto password)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password.oldPassword) || string.IsNullOrEmpty(password.newPassword))
            {
                throw new Exception("Id and password must be provided");
            }
            var user = await usermana.GetUserById(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }
  
            bool LoginResult = await usermana.LoginUser(user.Email!,password.oldPassword);
                if (!LoginResult)
                    throw new ArgumentException("Wrong password" );

            string token = await usermana.GeneratePasswordResetToken(user);
               var result = await usermana.ResetPassword(user, token, password.newPassword);
            return result;
        } 


    }

}
