using SampleDiffApp.Models;
using SampleDiffApp.Services;

namespace SampleDiffApp.Controllers
{
    public class UserController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public void Run()
        {
            bool running = true;
            while (running)
            {
                PrintMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1": ListUsers(); break;
                    case "2": CreateUser(); break;
                    case "3": DisableUser(); break;
                    case "4": _userService.PrintSummary(); break;
                    case "0": running = false; break;
                    default: Console.WriteLine("Invalid choice"); break;
                }
            }
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n1. List users");
            Console.WriteLine("2. Create user");
            Console.WriteLine("3. Disable user");
            Console.WriteLine("4. Summary");
            Console.WriteLine("0. Exit");
            Console.Write("Select: ");
        }

        private void ListUsers()
        {
            foreach (var user in _userService.GetUsers())
                Console.WriteLine(user);
        }

        private void CreateUser()
        {
            Console.Write("First name: ");
            var first = Console.ReadLine() ?? "";
            Console.Write("Last name: ");
            var last = Console.ReadLine() ?? "";
            Console.Write("Email: ");
            var email = Console.ReadLine() ?? "";

            var user = new User { FirstName = first, LastName = last, Email = email };
            Console.WriteLine(_userService.AddUser(user) ? "User created." : "Validation failed.");
        }

        private void DisableUser()
        {
            Console.Write("User ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
                Console.WriteLine(_userService.DisableUser(id) ? "User disabled." : "User not found.");
        }
    }
}
