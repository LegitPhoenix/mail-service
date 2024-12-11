using System;
using System.Net;
using System.Net.Mail;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Configure SMTP client
            var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587, // Common SMTP port
                Credentials = new NetworkCredential("your-email@example.com", "your-password"),
                EnableSsl = true, // Secure connection
            };

            // Create the email
            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@example.com"),
                Subject = "Hello from .NET",
                Body = "This is a test email sent using .NET.",
                IsBodyHtml = false, // Set to true if you want to send HTML email
            };

            mailMessage.To.Add("recipient@example.com");

            // Send the email
            smtpClient.Send(mailMessage);

            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email: {ex.Message}");
        }
    }
}
