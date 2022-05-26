using TestProject.Entities;

namespace TestProject.IServices
{
    public interface IUserTokenService
    {
        List<UserToken> GetAllData();
        UserToken GetById(int id);
        UserToken Insert(int userId);
        UserToken Delete(int id);
        UserToken GetByUserId(int id);
        UserToken Validate(string token, string secret);
    }
}
