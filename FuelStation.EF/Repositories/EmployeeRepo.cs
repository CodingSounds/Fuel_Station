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
    public class EmployeeRepo : IEntityRepo<Employee>
    {
        private readonly FuelStationContext _context;
        public EmployeeRepo(FuelStationContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var foundEmployee = await _context.Employees.SingleOrDefaultAsync(Employee => Employee.ID == id);
            if (foundEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            _context.Employees.Remove(foundEmployee);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            var t = await _context.Employees.ToListAsync();
            return t;
        }
        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees.Where(Employee => Employee.ID == id).SingleOrDefaultAsync();
        }
        public async Task UpdateAsync(Guid id, Employee entity)
        {
            var foundEmployee = await _context.Employees.SingleOrDefaultAsync(employee => employee.ID == id);
            if (foundEmployee is null)
                throw new KeyNotFoundException($"Given id '{id}' was not found in database");
            foundEmployee.Name = entity.Name;
            foundEmployee.Surname = entity.Surname;
            foundEmployee.SalaryPerMonth = entity.SalaryPerMonth;
            foundEmployee.Status = entity.Status;
            foundEmployee.EmployeeType = entity.EmployeeType;
            foundEmployee.HireDateEnd = entity.HireDateEnd;//bori na einai null SOS
            foundEmployee.HireDateStart = entity.HireDateStart;


            await _context.SaveChangesAsync();
        }
       
    }
    

}

