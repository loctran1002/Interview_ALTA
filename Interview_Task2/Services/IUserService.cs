using Interview_Task2.Entity;
using Interview_Task2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Task2.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>?> Get();
        Task<User?> Get(Guid id);
        Task<bool> Delete(Guid id);

        Task<bool> LoginAsync(LoginViewModel loginViewModel);
        Task<bool> RegisterAsync(User user);
    }
}