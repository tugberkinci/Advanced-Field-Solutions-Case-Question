
using Microsoft.EntityFrameworkCore;
using TestProject.DbContexts;
using TestProject.Entities;
using TestProject.IServices;
using TestProject.Models;

namespace TestProject.Services
{
    public class TransactionService : ITransactionService
    {

        public List<Transaction> GetAllData()
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.Transactions.ToList();
                return data;
            }
        }

        public Transaction Insert(TransactionModel model)
        {
            using (var context = ContextHelper.Context())
            {
                var newTransaction = new Transaction
                {
                    UserId = model.UserId,
                    Input = model.Input,
                    Output = model.Output

                };

                try
                {
                    context.Transactions.Add(newTransaction);
                    context.SaveChanges();
                    return newTransaction;
                }
                catch (DbUpdateException ex)
                {
                    throw ex;
                }
            }
        }

        public Transaction Delete(int id)
        {
            using (var context = ContextHelper.Context())
            {
                var data = context.Transactions.SingleOrDefault(x => x.Id == id);
                if (data == null)
                    return null;
                try
                {
                    context.Transactions.Remove(data);
                    context.SaveChanges();
                    return data;

                }
                catch(DbUpdateException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
