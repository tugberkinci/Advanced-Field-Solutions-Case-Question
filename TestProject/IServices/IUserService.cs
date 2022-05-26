using TestProject.Entities;
using TestProject.Models;

namespace TestProject.IServices
{
    public interface IUserService
    {
        List<User> GetAllData();
        User GetById(int id);
        User Insert(UserModel model);
        User Delete(int id);
        string TestService();
        User GetByMail(string mailAddress);
    }
}
