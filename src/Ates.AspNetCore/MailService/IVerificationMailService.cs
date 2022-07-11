namespace Ates.AspNetCore.MailService;

public interface IVerificationMailService
{
    public Task SendMail(String verificationCode, String toMailAddress, CancellationToken cancellationToken = default);
}
