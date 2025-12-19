using SampleDiffApp.Models;
using SampleDiffApp.Utils;

namespace SampleDiffApp.Services
{
    public class UserService
    {
        private readonly EmailService _emailService;
        private readonly List<User> _users = new();

        public UserService(EmailService emailService)
        {
            _emailService = emailService;
            InitializeUsers();
        }

        private void InitializeUsers()
        {
            for (int i = 1; i <= 20; i++)
            {
                _users.Add(new User
                {
                    Id = i,
                    FirstName = "User" + i,
                    LastName = "Diff",
                    Email = $"user{i}@example.com",
                    IsActive = i % 2 == 0
                });
            }
        }

        public IEnumerable<User> GetUsers() => _users;

        public bool AddUser(User user)
        {
            if (!ValidationHelper.IsNameValid(user.FirstName) ||
                !ValidationHelper.IsNameValid(user.LastName) ||
                !ValidationHelper.IsEmailValid(user.Email))
            {
                return false;
            }

            user.Id = _users.Max(u => u.Id) + 1;
            user.IsActive = true;
            _users.Add(user);
            _emailService.SendEmail(user.Email);
            return true;
        }

        public bool DisableUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return false;
            user.IsActive = false;
            return true;
        }

        public void PrintSummary()
        {
            int active = _users.Count(u => u.IsActive);
            int inactive = _users.Count - active;
            Console.WriteLine($"Active users: {active}");
            Console.WriteLine($"Inactive users: {inactive}");
        }
    }
}
