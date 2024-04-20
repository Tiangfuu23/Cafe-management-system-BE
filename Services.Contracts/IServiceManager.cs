
namespace Services.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }   
        ILoginService LoginService { get; }

        ICategoryService CategoryService { get; }
        IForgetPasswordService ForgetPasswordService { get; }
    }
}
