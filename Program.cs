using SampleDiffApp.Controllers;
using SampleDiffApp.Services;

namespace SampleDiffApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Diff Tool Sample App ===");
            var emailService = new EmailService();
            var userService = new UserService(emailService);
            var controller = new UserController(userService);
            controller.Run();
            Console.WriteLine("Execution finished.");
        }
    }
}
