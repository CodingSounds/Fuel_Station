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
    public class RentRepo 
    {
        private readonly FuelStationContext _context;
        public RentRepo(FuelStationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Rent entity)
        {
            await _context.Rents.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Rent>> GetAllAsync()
        {
            return await _context.Rents.ToListAsync();
        }

        public async Task<decimal?> GetByIdAsync(string date)
        {
            var foundRent = await _context.Rents.SingleOrDefaultAsync(rent => rent.Date == date);
            return foundRent.RentingCost;
        }

       
    }
}
