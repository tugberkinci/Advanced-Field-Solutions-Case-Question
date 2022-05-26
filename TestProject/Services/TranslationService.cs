using Newtonsoft.Json.Linq;
using System.Net;
using TestProject.IServices;

namespace TestProject.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITransactionService _transactionService;

        public TranslationService(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }


        private string SendRequest(string input)
        {
            
            HttpWebRequest wr = (HttpWebRequest) WebRequest.Create($"https://api.funtranslations.com/translate/shakespeare.json?text={input}");
            //wr.ContentType = "Application/Json";
            wr.Method = "Get";
            IAsyncResult asyncResult = wr.BeginGetResponse(null, null);
            asyncResult.AsyncWaitHandle.WaitOne();
            try
            {
                using (WebResponse response = wr.EndGetResponse(asyncResult))
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
            catch(WebException ex)
            {
                using (var stream = ex.Response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string error = reader.ReadToEnd();
                    return error;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TransalateMe(string input)
        {
            var result = SendRequest(input);
            var obj = JObject.Parse(result);
            string output = String.Empty;
            var userId = Utils.GetCurrentToken().UserId;

            var succ = obj["contents"];
            var err = obj["error"];

            if (err == null)
                output = succ["translated"].ToString();
            else
                output = err["message"].ToString();


            _transactionService.Insert(new Models.TransactionModel
            {
                UserId = userId,
                Input = input,
                Output = output
            });

            return result;
        }


    }
}
