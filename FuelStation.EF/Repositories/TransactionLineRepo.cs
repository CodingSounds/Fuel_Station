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
    public class TransactionLineRepo : IEntityRepo<TransactionLine>
    {
        private readonly FuelStationContext _context;
        public TransactionLineRepo(FuelStationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TransactionLine entity)
        {
            await _context.TransactionLines.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var foundTransLine = await _context.TransactionLines.SingleOrDefaultAsync(transLine => transLine.ID == id);
            if (foundTransLine is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.TransactionLines.Remove(foundTransLine);
            await _context.SaveChangesAsync();
        }
        public async Task<List<TransactionLine>> GetAllAsync()
        {
            return await _context.TransactionLines.Include(x=>x.Item).Include(x=>x.Item).ToListAsync();
        }
        public async Task<TransactionLine?> GetByIdAsync(Guid id)
        {
            return await _context.TransactionLines.Where(transLine => transLine.ID == id).SingleOrDefaultAsync();//nullreference??

        }
        public async Task UpdateAsync(Guid id, TransactionLine entity)
        {
            var foundtransLIne = await _context.TransactionLines.SingleOrDefaultAsync(employee => employee.ID == id);
            if (foundtransLIne is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            foundtransLIne.NetValue = entity.NetValue;
            foundtransLIne.ItemPrice = entity.ItemPrice;
            foundtransLIne.ItemID = entity.ItemID;
            
            foundtransLIne.DiscountPercentage = entity.DiscountPercentage;
            foundtransLIne.DiscountValue = entity.DiscountValue;
            foundtransLIne.TransactionID=entity.TransactionID;
            foundtransLIne.TotalValueOfLine=entity.TotalValueOfLine;
            foundtransLIne.Quantity=entity.Quantity;//nul>??
            



            await _context.SaveChangesAsync();
        }

    }
}
