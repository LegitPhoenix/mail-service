using System;
using MailKit.Net.Smtp;
using MimeKit;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender Name", "your-email@example.com"));
            message.To.Add(new MailboxAddress("Recipient Name", "recipient@example.com"));
            message.Subject = "Hello from .NET with MailKit";

            message.Body = new TextPart("plain")
            {
                Text = "This is a test email sent using MailKit."
            };

            // Send email
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.example.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate("your-email@example.com", "your-password");

                client.Send(message);
                client.Disconnect(true);
            }

            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email: {ex.Message}");
        }
    }
}
