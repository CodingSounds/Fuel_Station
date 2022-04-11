using FuelStation.EF.Context;
using FuelStation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.EF.Repositories
{
    public class TransactionRepo:IEntityRepo<Transaction>
    {

        private readonly FuelStationContext _context;
        public TransactionRepo(FuelStationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Transaction entity)
        {
            await _context.Transactions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var foundTrans = await _context.Transactions.SingleOrDefaultAsync(trans => trans.ID == id);
            if (foundTrans is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.Transactions.Remove(foundTrans);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions.Include(x => x.Employee).Include(x => x.Customer).ToListAsync();
        }
       

        public async Task<Transaction?> GetByIdAsync(Guid id)
        {
            return await _context.Transactions.Where(item => item.ID == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Guid id, Transaction entity)
        {
            var foundTrans = await _context.Transactions.SingleOrDefaultAsync(item => item.ID == id);
            if (foundTrans is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            
            foundTrans.Status = entity.Status.Value;
            foundTrans.Date = entity.Date;
            foundTrans.EmployeeID = entity.EmployeeID;
            foundTrans.PaymentMethod = entity.PaymentMethod;
            foundTrans.CustomerID = entity.CustomerID;
            
            await _context.SaveChangesAsync();
        }
      
    }
}



