namespace Ates.AspNetCore.MailService;
public class MailServiceSettings
{
    public String MailAddress
    {
        get; set;
    }

    public String MailPassword
    {
        get; set;
    }

    public String VerificationMailDisplay
    {
        get; set;
    }

    public Int32 Port
    {
        get; set;
    }

    public String Host
    {
        get; set;
    }

    public Boolean EnableSsl
    {
        get; set;
    }
}
