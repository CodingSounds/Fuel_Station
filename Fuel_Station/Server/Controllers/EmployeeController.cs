using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;



namespace Fuel_Station.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEntityRepo<Employee> _employeeRepo;

        public EmployeeController(IEntityRepo<Employee> employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> Get()
        {
            var result = await _employeeRepo.GetAllAsync();

            var activeemployee = result.FindAll(x => x.Status.Value == true);
            var t = activeemployee.Select(x => new EmployeeViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                HireDateStart = x.HireDateStart,
                HireDateEnd=x.HireDateEnd,
                SalaryPerMonth=x.SalaryPerMonth,
                EmployeeType=x.EmployeeType,
                Status = x.Status.Value


            });

            return t;
        }
        [HttpGet("GetAllEmployees")]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            var result = await _employeeRepo.GetAllAsync();
            var activeemployee = result.FindAll(x => x.Status != null);
            var t = activeemployee.Select(x => new EmployeeViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                HireDateStart = x.HireDateStart,
                HireDateEnd = x.HireDateEnd,
                SalaryPerMonth = x.SalaryPerMonth,
                EmployeeType = x.EmployeeType,
                Status = x.Status.Value

            });

            return t;
        }
        [HttpGet("GetOneEmployee{id}")]
        public async Task<EmployeeViewModel> GetOne(Guid id)
        {
            var result = await _employeeRepo.GetByIdAsync(id);

            var t = new EmployeeViewModel
            {
                ID = result.ID,
                Name = result.Name,
                Surname = result.Surname,
                HireDateStart = result.HireDateStart,
                HireDateEnd = result.HireDateEnd,
                SalaryPerMonth = result.SalaryPerMonth,
                EmployeeType = result.EmployeeType,
                Status = result.Status.Value

            };

            return t;
        }

        [HttpPost]

        public async Task Post(EmployeeViewModel newEmployeeView)
        {
            Employee employee = new Employee
            {

                ID = Guid.NewGuid(),
                Name = newEmployeeView.Name,
                Surname=newEmployeeView.Surname,
                HireDateStart = newEmployeeView.HireDateStart,
                HireDateEnd = newEmployeeView.HireDateEnd,
                SalaryPerMonth= newEmployeeView.SalaryPerMonth,
                EmployeeType=newEmployeeView.EmployeeType,

                Status = true,
            };
            await _employeeRepo.CreateAsync(employee);

        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            var x = await _employeeRepo.GetByIdAsync(id);
            x.Status = !x.Status;
            await _employeeRepo.UpdateAsync(id, x);
        }
        [HttpDelete("Erase{id}")]
        public async Task Erase(Guid id)
        {

            var x = await _employeeRepo.GetByIdAsync(id);
            Employee employee = new Employee
            {

                ID = Guid.NewGuid(),
                Name = x.Name,
                Surname = x.Surname,
                HireDateStart = x.HireDateStart,
                HireDateEnd = x.HireDateEnd,
                SalaryPerMonth = x.SalaryPerMonth,
                EmployeeType = x.EmployeeType,
                Status = null

                
            };

            await _employeeRepo.DeleteAsync(id);
            await _employeeRepo.CreateAsync(employee);
        }


        [HttpPut]
        public async Task<ActionResult> Put(EmployeeViewModel newEmployeeView)
        {
            var employeeToUpdate = await _employeeRepo.GetByIdAsync(newEmployeeView.ID);
            if (employeeToUpdate == null) return NotFound();


            employeeToUpdate.ID = newEmployeeView.ID;
            employeeToUpdate.Name = newEmployeeView.Name;
            employeeToUpdate.Surname = newEmployeeView.Surname;
            employeeToUpdate.HireDateStart = newEmployeeView.HireDateStart;
            employeeToUpdate.HireDateEnd = newEmployeeView.HireDateEnd;
            employeeToUpdate.SalaryPerMonth = newEmployeeView.SalaryPerMonth;
            employeeToUpdate.EmployeeType = newEmployeeView.EmployeeType;
            employeeToUpdate.Status = newEmployeeView.Status;

            await _employeeRepo.UpdateAsync(newEmployeeView.ID, employeeToUpdate);



            return Ok();
        }








    }
}










