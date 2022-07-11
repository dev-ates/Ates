namespace Ates.AspNetCore.MailService;

using Microsoft.Extensions.Options;

public class VerificationMailService : IVerificationMailService
{
    private readonly IMailService mailService;
    private readonly IOptions<MailServiceSettings> mailServiceSettings;

    public VerificationMailService(IMailService mailService, IOptions<MailServiceSettings> mailServiceSettings)
    {
        this.mailService = mailService;
        this.mailServiceSettings = mailServiceSettings;
    }

    public async Task SendMail(String verificationCode, String toMailAddress, CancellationToken cancellationToken = default)
    {
        await this.mailService.SendMail(mailServiceSettings.Value.VerificationMailDisplay, verificationCode, toMailAddress, cancellationToken);
    }
}
