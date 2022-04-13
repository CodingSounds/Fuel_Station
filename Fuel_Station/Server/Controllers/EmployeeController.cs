using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;
using FuelStation.Models.Enums;

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
        [HttpGet("GetAllEmployees{user}")]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll(Guid user)
        {
            
            var userEmploy = await _employeeRepo.GetByIdAsync(user);

            if(userEmploy.EmployeeType == EmployeeTypeEnum.Manager)
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
            return null;
           
        }
        [HttpGet("GetUser{username}/{password}")]
        public async Task<Guid?> LoginGet(string username, string password)
        {
            var result = await _employeeRepo.GetAllAsync();
            List< Employee> activeemployee = result.FindAll(x => x.Status != null);
            
            Employee? loginEmployee= activeemployee.FirstOrDefault(x=>x.Password==password && x.UserName==username);

            if (loginEmployee == null)
            {
                return null;
            }

            return loginEmployee.ID;
        }
        [HttpGet("GetOneEmployee{user}/{id}")]
        public async Task<EmployeeViewModel> GetOne(Guid user, Guid id)
        {
            
            var type = await _employeeRepo.GetByIdAsync(user);
            if (!(type.EmployeeType == EmployeeTypeEnum.Manager))
            {
                return null;
            }
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


        [HttpGet("GetTypeOfEmpl{user}")]
        public async Task<EmployeeTypeEnum> GetEmployeeType(Guid user)//to exo xrisimopoiisi mono sto wf mexri stigmis
        {

            var type = await _employeeRepo.GetByIdAsync(user);
            if (type == null)
            {
                return EmployeeTypeEnum.None;
            }
            return type.EmployeeType;
        }


        [HttpPost("{id}")]

        public async Task Post(Guid id,EmployeeViewModel newEmployeeView)
        {
            var type = await _employeeRepo.GetByIdAsync(id);
            if (!(type.EmployeeType == EmployeeTypeEnum.Manager || type.EmployeeType == EmployeeTypeEnum.Cashier))
            {

            }
            else
            {
                Employee employee = new Employee
                {

                    ID = Guid.NewGuid(),
                    Name = newEmployeeView.Name,
                    Surname = newEmployeeView.Surname,
                    HireDateStart = newEmployeeView.HireDateStart,
                    HireDateEnd = newEmployeeView.HireDateEnd,
                    SalaryPerMonth = newEmployeeView.SalaryPerMonth,
                    EmployeeType = newEmployeeView.EmployeeType,

                    Status = true,
                };
                await _employeeRepo.CreateAsync(employee);
            }
            

        }

        [HttpDelete("{user}/{id}")]
        public async Task Delete(Guid user,Guid id)
        {
            var type = await _employeeRepo.GetByIdAsync(user);
            if (!(type.EmployeeType == EmployeeTypeEnum.Manager ))
            {

            }
            else
            {
               
                var x = await _employeeRepo.GetByIdAsync(id);
                if (x.Status == true)
                {
                    x.HireDateEnd = DateTime.Now;
                }
                else
                {
                    x.HireDateEnd = null;
                }
                x.Status = !x.Status;
                await _employeeRepo.UpdateAsync(id, x);
            }

         
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

            await _employeeRepo.UpdateAsync(id, employee);
          
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id,EmployeeViewModel newEmployeeView)
        {
            var employeeToUpdate = await _employeeRepo.GetByIdAsync(newEmployeeView.ID);
            if (employeeToUpdate == null) return NotFound();

            var type = await _employeeRepo.GetByIdAsync(id);
            if (!(type.EmployeeType == EmployeeTypeEnum.Manager || type.EmployeeType == EmployeeTypeEnum.Cashier))
            {
                return NotFound();
            }
            else
            {

                employeeToUpdate.ID = newEmployeeView.ID;
                employeeToUpdate.Name = newEmployeeView.Name;
                employeeToUpdate.Surname = newEmployeeView.Surname;
                employeeToUpdate.HireDateStart = newEmployeeView.HireDateStart;
                employeeToUpdate.HireDateEnd = newEmployeeView.HireDateEnd;
                employeeToUpdate.SalaryPerMonth = newEmployeeView.SalaryPerMonth;
                employeeToUpdate.EmployeeType = newEmployeeView.EmployeeType;
                employeeToUpdate.Status = newEmployeeView.Status;

                await _employeeRepo.UpdateAsync(newEmployeeView.ID, employeeToUpdate);
            }






            return Ok();
        }








    }
}










