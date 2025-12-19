namespace SampleDiffApp.Services
{
    public class EmailService
    {
        public void SendEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Invalid email.");
                return;
            }

            Console.WriteLine($"Sending email to {email}");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(100);
            }
            Console.WriteLine("Email sent.");
        }
    }
}
