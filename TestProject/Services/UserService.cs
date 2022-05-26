using Microsoft.EntityFrameworkCore;
using TestProject.DbContexts;
using TestProject.Entities;
using TestProject.IServices;
using TestProject.Models;

namespace TestProject.Services
{
    public class UserService : IUserService
    {

        public List<User> GetAllData()
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.Users.ToList();
                return data;
            }

        }

        public User GetById(int id)
        {
            using (var context =  ContextHelper.Context())
            {
                var data = context.Users.SingleOrDefault(x => x.Id == id);
                return data;

            }
        }

        public User GetByMail(string mailAddress)
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.Users.SingleOrDefault(x => String.Equals(x.UserMail, mailAddress));
                return data;
            }
        }

        public User Insert(UserModel model)
        {
            using (var context = ContextHelper.Context())
            {
                model.CreatedAt = Utils.GetTurkeyTime();
                var newUser = new User
                {
                    UserMail = model.UserMail
                };
                try
                {
                    context.Users.Add(newUser);
                    context.SaveChanges();
                    return newUser;
                }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }
            }
        }

        public User Delete(int id)
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.Users.SingleOrDefault(x => x.Id == id);
                if (data == null)
                    return null;
                try
                {
                    context.Users.Remove(data);
                    context.SaveChanges();
                    return data;

                }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }
            }
        }

        public string TestService()
        {
            return "Clicked";
        }
    }
}
