using Interview_Task2.Entity;
using Interview_Task2.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Interview_Task2.Services
{
    public class UserService : IUserService
    {
        private readonly InterviewDbContext _context;

        public UserService(InterviewDbContext interviewDbContext)
        {
            _context = interviewDbContext;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>?> Get()
        {
            return await _context.Users.ToListAsync();;
        }

        public async Task<User?> Get(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> LoginAsync(LoginViewModel loginViewModel)
        {
            var checkPhoneUser = await _context.Users.FirstOrDefaultAsync(x => x.Phone == loginViewModel.PhoneNumber);
            var checkEmailUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == loginViewModel.Email);
            var user = (checkPhoneUser == null) ? checkEmailUser : checkPhoneUser;
            if (user == null)
                return false;

            var result = new PasswordHasher<string>().VerifyHashedPassword(user.Fullname, user.Password, loginViewModel.Password);
            if (result == PasswordVerificationResult.Failed)
                return false;

            return true;
        }

        public async Task<bool> RegisterAsync(User user)
        {
            var userIsExist = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (userIsExist != null)
                return false;

            user.Password = new PasswordHasher<string>().HashPassword(user.Fullname, user.Password);

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
