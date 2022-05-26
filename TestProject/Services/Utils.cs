using System.Globalization;
using System.Net.Mail;
using TestProject.Entities;

namespace TestProject.Services
{
    public class Utils
    {
        private static UserToken currentUser = new UserToken();

        public static DateTime GetTurkeyTime()
        {
            return DateTime.Parse(DateTime.Now.ToString(new CultureInfo("tr-tr")));
        }

        public static string GetToken(int length)
        {
            var allChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var resultToken = new string(
                Enumerable.Repeat(allChar, length)
                    .Select(token => token[random.Next(token.Length)]).ToArray());

            return resultToken;
        }

        public static bool IsValidEmail(string email)
        {

            if (String.IsNullOrEmpty(email))
                return false;

            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith(".")) return false;
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        
        public static UserToken SetCurrentUser(UserToken model)
        {

            Utils.currentUser = model;
            return currentUser; ;
        }

        public static bool IsLogin()
        {
            if (String.IsNullOrEmpty(Utils.currentUser.Token) || String.IsNullOrEmpty(Utils.currentUser.Secret))
                return false;

            return true;
        }

        public static User CurrentUser()
        {
            if(currentUser.UserId != null)
            {
                var user = new UserService().GetById(currentUser.UserId);
                return user;
            }
            return null;  
        }

        public static UserToken GetCurrentToken()
        {
            return Utils.currentUser;
        }

   
    }
}
