using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Contracts;
using Entities.DataTransferObjects;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services
{
    internal class LoginService : ILoginService
    {
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repositoryManager;


        public LoginService( IConfiguration config, IMapper mapper, ILoggerManager logger, IRepositoryManager repositoryManager)
        {
            _config = config;
            _mapper = mapper;
            _logger = logger;
            _repositoryManager = repositoryManager;
        }
        public (UserDto, TokenDto) ValidateUSer(UserForAuthenticationDto userForAuth)
        {
            var user = _repositoryManager.RepositoryUser.GetUser(userForAuth.username, trackChange: false);

            if(user == null || user.password != userForAuth.password)
            {
                throw new WrongUsernameOrPasswordException((user == null), (user != null && user.password != user.password));

            }

            var roles = _repositoryManager.RepositoryRole.GetAllRoles(trackChange: false);

            foreach(var role in roles)
            {
                if(user.roleId == role.roleId)
                {
                    user.Role = role;
                }
            }
            var token = CreateToken(user);

            var tokenDto = _mapper.Map<TokenDto>(token);
            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, tokenDto);
        }

        public string CreateToken(User user)
        {
            // 1.Create Signing Credential
            var signingCredentials = GetSigningCredentials();
            var claims = GetClaims(user);
            // 2.Create Token Options - JwtSecurityToken
            var jwtTokenOptions = GenerateTokenOptions(signingCredentials, claims);
            // 3.Create Token
            return new JwtSecurityTokenHandler().WriteToken(jwtTokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var jwtSetting = _config.GetSection("JwtSettings");
            _logger.LogInfo($"my key: ${jwtSetting["key"]}");
            var key = Encoding.UTF8.GetBytes(jwtSetting["key"]);
            var secretKey = new SymmetricSecurityKey(key);
            return new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(User user)
        {
            var userRole = _repositoryManager.RepositoryRole.GetRole(user.roleId, trackChange: false);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.username),
                new Claim(ClaimTypes.Role, userRole.description)
        };
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
