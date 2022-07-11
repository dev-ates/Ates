namespace Ates.AspNetCore.MailService;

public interface IMailService
{
    public Task SendMail(String subject, String body, String toMailAddress, CancellationToken cancellationToken = default);
}
