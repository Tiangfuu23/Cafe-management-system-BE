using AutoMapper;
using Contracts;
using Microsoft.Extensions.Configuration;
using Services.Contracts;
using Entities.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<ILoginService> _loginService;
        private readonly Lazy<IForgetPasswordService> _forgetPasswordService;
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBillService> _billService;
        private readonly Lazy<IDashboardService> _dashboardService;
        public ServiceManager(ILoggerManager logger, IMapper mapper, IConfiguration config, IRepositoryManager repositoryManager, EmailConfiguration emailConfiguration, IWebHostEnvironment env)
        {
            _userService = new Lazy<IUserService>(() => new UserService(logger, mapper, repositoryManager));
            _loginService = new Lazy<ILoginService> (() => new LoginService(config, mapper, logger, repositoryManager));
            _forgetPasswordService = new Lazy<IForgetPasswordService>(() => new ForgetPasswordService(repositoryManager, emailConfiguration, logger, config));
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, logger, mapper));
            _productService = new Lazy<IProductService>(() => new ProductService(repositoryManager, mapper));
            _billService = new Lazy<IBillService> (() => new BillService(logger, repositoryManager, mapper, env));
            _dashboardService = new Lazy<IDashboardService>(() => new DashboardService(logger, repositoryManager));
        }
        public IUserService UserService => _userService.Value;
        public ILoginService LoginService => _loginService.Value;

        public IForgetPasswordService ForgetPasswordService => _forgetPasswordService.Value;

        public ICategoryService CategoryService => _categoryService.Value;

        public IProductService ProductService => _productService.Value;

        public IBillService BillService => _billService.Value;

        public IDashboardService DashboardService => _dashboardService.Value;

    }
}
