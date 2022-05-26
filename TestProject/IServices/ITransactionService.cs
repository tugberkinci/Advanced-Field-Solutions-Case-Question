using TestProject.Entities;
using TestProject.Models;

namespace TestProject.IServices
{
    public interface ITransactionService
    {
        List<Transaction> GetAllData();
        Transaction Insert(TransactionModel model);
        Transaction Delete(int id);
    }
}
