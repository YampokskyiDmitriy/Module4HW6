using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Module4HW6.Helpers
{
    public class GoTransaction
    {
        private readonly ApplicationDbContext _context;

        public GoTransaction(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ExecuteTransaction(Func<Task> func)
        {
            await using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await func.Invoke();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                }
            }
        }
    }
}