namespace TestProject.IServices
{
    public interface IMailService
    {
        object SendEmail(string to, string subject, string body);
    }
}
