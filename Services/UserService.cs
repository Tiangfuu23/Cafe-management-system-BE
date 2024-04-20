﻿using AutoMapper;
using Services.Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Contracts;
using Entities.Exceptions;
namespace Services
{
    internal class UserService : IUserService
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _repositoryManager;
        public UserService(ILoggerManager logger, IMapper mapper, IRepositoryManager repositoryManager)
        {
            _logger = logger;
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<UserDto> GetAllUsers()
        {
            var usersList = _repositoryManager.RepositoryUser.GetAllUsers(false);
            var rolesList = _repositoryManager.RepositoryRole.GetAllRoles(false);
            var usersForResponse = (from user in usersList
                                    join role in rolesList
                                    on user.roleId equals role.roleId
                                    orderby user.userId 
                                    select new User
                                    {
                                        userId = user.userId,
                                        username = user.username,
                                        fullname = user.fullname,
                                        Role = new Role
                                        {
                                            roleId = user.roleId,
                                            description = role.description
                                        }
                                    });
            //foreach(var user in usersList)
            //{
            //    user.Role = GetRoleByRoleId(user.roleId, trackChange: false);
            //}
            var usersDtoList = _mapper.Map<IEnumerable<UserDto>>(usersForResponse);
            return usersDtoList;
        }

        public bool Register(UserForRegistrationDto userForRegistrationDto)
        {
            var userEntity = _mapper.Map<User>(userForRegistrationDto);
            userEntity.birthday = ConvertDateTimeToUTC(userEntity.birthday);

            _logger.LogInfo("userForRegistration: " + userEntity.username);
            // 1. Check username's already exist or not 
            var userFound = _repositoryManager.RepositoryUser.getUser(userEntity.username, false);

            if (userFound != null) throw new UsernameExistException(userForRegistrationDto.username);
                

            _logger.LogInfo("User Not Exist in DB -> Can sign up");
            // 2. Add userForRegistration to Dtb
            _repositoryManager.RepositoryUser.CreateUser(userEntity);
            _repositoryManager.Save(); // <-- need to call this method to update db when implemting CUD Method
            return true;

        }

        public void UpdatePassword(int userId, PasswordForUpdateDto passwordForUpdateDto)
        {
            var userEntity = _repositoryManager.RepositoryUser.getUser(userId, trackChange: true);
            if (userEntity == null) throw new UserNotFoundException(userId);

            if (userEntity.password != passwordForUpdateDto.OldPassword) throw new WrongUsernameOrPasswordException(isWrongPassword: true);

            // Update new password
            userEntity.password = passwordForUpdateDto.NewPasswrod;
            _repositoryManager.Save();
        }

        public void UpdateUser(int userId, UserForUpdateDto userForUpdateDto)
        {
            var userEntity = _repositoryManager.RepositoryUser.getUser(userId, trackChange: true);

            if (userEntity == null) throw new UserNotFoundException(userId);

            _mapper.Map(userForUpdateDto, userEntity);
            userEntity.birthday = ConvertDateTimeToUTC(userEntity.birthday);
            _repositoryManager.Save();


        }

        private DateTime? ConvertDateTimeToUTC(DateTime? datetime)
        {
            return datetime?.ToUniversalTime();
        }

        //private Role? GetRoleByRoleId(int roleId, bool trackChange)
        //{
        //    return _repositoryManager.RepositoryRole.GetRole(roleId, trackChange);
        //} 
    }
}
