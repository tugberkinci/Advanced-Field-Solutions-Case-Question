using TestProject.Entities;

namespace TestProject.IServices;

public interface IUserAuthorizeService
{
    //void FillUser(string name);


    Task<UserToken> AuthenticateUser(string username, string password);
}