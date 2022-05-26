using Microsoft.EntityFrameworkCore;
using TestProject.DbContexts;
using TestProject.Entities;
using TestProject.IServices;
using TestProject.Models;

namespace TestProject.Services
{
    public class UserTokenService : IUserTokenService
    {
        public List<UserToken> GetAllData()
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.UserTokens.ToList();
                return data;
            }
        }

        public UserToken GetById(int id)
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.UserTokens.SingleOrDefault(x => x.Id == id);
                return data;
            }
        }

        public UserToken GetByUserId(int id)
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.UserTokens.SingleOrDefault(x => x.UserId == id);
                return data;
            }
        }

        public UserToken Validate(string token,string secret)
        {
            using (var context =  ContextHelper.Context())
            {
                var data = context.UserTokens.SingleOrDefault(x => String.Equals(x.Token, token) && String.Equals(x.Secret, secret));
                return data;
            }
        }

      

        public UserToken Insert(int userId)
        {
            using (var context = ContextHelper.Context())
            {
                var checkUser = context.Users.SingleOrDefault(x => x.Id == userId);
                if (checkUser == null)
                    return null;

                var newToken = new UserToken
                {
                    UserId = userId,
                    Token = Utils.GetToken(24),
                    Secret = Utils.GetToken(24),
                    CreatedAt = Utils.GetTurkeyTime()
                };
                try
                {
                    context.UserTokens.Add(newToken);
                    context.SaveChanges();
                    return newToken;
                }
                catch(DbUpdateException ex)
                {
                    throw ex;
                }

            }
        }

        public UserToken Delete(int id)
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.UserTokens.SingleOrDefault(x => x.Id == id);
                if (data == null)
                    return null;

                try
                {
                    context.UserTokens.Remove(data);
                    context.SaveChanges();
                    return data;
                }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
