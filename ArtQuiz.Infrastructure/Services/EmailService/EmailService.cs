using ArtQuiz.Application;
using ArtQuiz.Application.Services;
using ArtQuiz.Application.Services.Interface;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ArtQuiz.Infrastructure.Services.EmailService;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string body)
    {
        var smtpConfig = _configuration.GetSection("Smtp");
        var name = smtpConfig["Name"];
        var address = smtpConfig["Address"];
        var host = smtpConfig["Host"];
        var login = smtpConfig["Login"];
        var password = smtpConfig["Password"];
        
        var message = new MimeMessage();
        
        message.From.Add(new MailboxAddress(name, address));
        message.To.Add(new MailboxAddress(email, email));
        message.Subject = subject;
        message.Body = new TextPart("plain") { Text = body };
        
        using var client = new SmtpClient();
        
        await client.ConnectAsync(host, 465 , true);
        await client.AuthenticateAsync(login, password);
        await client.SendAsync(message);
        
        await client.DisconnectAsync(true);
    }
}