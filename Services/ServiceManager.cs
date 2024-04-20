using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Services.Contracts;
using Entities.Configuration;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ILoginService> _loginService;
        private readonly Lazy<IForgetPasswordService> _forgetPasswordService;
        private readonly Lazy<ICategoryService> _categoryService;
        public ServiceManager(ILoggerManager logger, IMapper mapper, IConfiguration config, IRepositoryManager repositoryManager, EmailConfiguration emailConfiguration)
        {
            _userService = new Lazy<IUserService>(() => new UserService(logger, mapper, repositoryManager));
            _loginService = new Lazy<ILoginService> (() => new LoginService(config, mapper, logger, repositoryManager));
            _forgetPasswordService = new Lazy<IForgetPasswordService>(() => new ForgetPasswordService(repositoryManager, emailConfiguration, logger));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, logger, mapper));
        }
        public IUserService UserService => _userService.Value;
        public ILoginService LoginService => _loginService.Value;

        public IForgetPasswordService ForgetPasswordService => _forgetPasswordService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

    }
}
