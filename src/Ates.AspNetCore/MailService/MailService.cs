namespace Ates.AspNetCore.MailService;

using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading;

public class MailService : IMailService
{
    private readonly IOptions<MailServiceSettings> mailServiceSettings;

    public MailService(IOptions<MailServiceSettings> mailServiceSettings)
    {
        this.mailServiceSettings = mailServiceSettings;
    }

    public async Task SendMail(String subject, String body, String toMailAddress, CancellationToken cancellationToken = default)
    {
        var smtpClient = await this.CreateSmtpClient();
        var mail = await this.CreateMailMessage(subject, body, toMailAddress);
        await smtpClient.SendMailAsync(mail, cancellationToken);
    }

    private async Task<SmtpClient> CreateSmtpClient()
    {
        return await Task.Run(() =>
        {
            return new SmtpClient
            {
                Port = this.mailServiceSettings.Value.Port,
                Host = this.mailServiceSettings.Value.Host,
                EnableSsl = this.mailServiceSettings.Value.EnableSsl,
                Credentials = new NetworkCredential(this.mailServiceSettings.Value.MailAddress, this.mailServiceSettings.Value.MailPassword),
            };
        });
    }

    private async Task<MailMessage> CreateMailMessage(String subject, String body, String toMailAddress)
    {
        return await Task.Run(() =>
        {
            var mail = new MailMessage
            {
                From = new MailAddress(this.mailServiceSettings.Value.MailAddress, this.mailServiceSettings.Value.VerificationMailDisplay),
                IsBodyHtml = true,
                Subject = subject,
                Body = body,
            };
            mail.To.Add(toMailAddress);

            return mail;
        });
    }
}
