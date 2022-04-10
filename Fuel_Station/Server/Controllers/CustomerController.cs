﻿using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;
using FuelStation.Models.Enums;

namespace Fuel_Station.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IEntityRepo<Customer> _customerRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;

        public CustomerController(IEntityRepo<Customer> customerRepo, IEntityRepo<Employee> employeeRepo)
        {
            _customerRepo = customerRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            var result = await _customerRepo.GetAllAsync();

            var activecustomers = result.FindAll(x => x.Status == true);
            var t = activecustomers.Select(x => new CustomerViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                CardNumber = x.CardNumber,
                Status = x.Status.Value
                

            });

            return t;
        }
        [HttpGet("GetAllCust{user}")]
        public async Task<IEnumerable<CustomerViewModel>> GetAll(Guid user)
        {
            var result = await _customerRepo.GetAllAsync();
            var userEmploy = await _employeeRepo.GetByIdAsync(user);

            if (userEmploy.EmployeeType == EmployeeTypeEnum.Manager)
            {
                var notErasedCustomers = result.FindAll(x => x.Status != null);

                var t = notErasedCustomers.Select(x => new CustomerViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Surname = x.Surname,
                    CardNumber = x.CardNumber,
                    Status = x.Status.Value

                }
          );

                return t;
            }
            return null;
        }
            


        [HttpGet("GetOneCustomer{user}/{id}")]
        public async Task<CustomerViewModel> GetOne(Guid user,Guid id)
        {
            var type = await _employeeRepo.GetByIdAsync(user);
            if (!(type.EmployeeType == EmployeeTypeEnum.Manager|| type.EmployeeType == EmployeeTypeEnum.Cashier))
            {
                return null;
            }
            var result = await _customerRepo.GetByIdAsync(id);

            var t = new CustomerViewModel
            {
                ID = result.ID,
                Name = result.Name,
                Surname = result.Surname,
                CardNumber = result.CardNumber,
                Status = result.Status.Value

            };

            return t;
        }

        [HttpPost]

        public async Task Post(CustomerViewModel newcustomerview)
        {
            Customer customer = new Customer
            {
                
                ID = newcustomerview.ID,
                Name = newcustomerview.Name,
                Surname = newcustomerview.Surname,
                CardNumber = newcustomerview.CardNumber,
                Status = true
            };
            await _customerRepo.CreateAsync(customer);

        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            var x = await _customerRepo.GetByIdAsync(id);
            x.Status = !x.Status;
            await _customerRepo.UpdateAsync(id, x);
        }
        [HttpDelete("Erase{id}")]
        public async Task Erase(Guid id)
        {

            var result = await _customerRepo.GetByIdAsync(id);
            var t = new Customer
            {
                ID = result.ID,
                Name = result.Name,
                Surname = result.Surname,
                CardNumber = result.CardNumber,
                Status = null

            };

            await _customerRepo.DeleteAsync(id);
            await _customerRepo.CreateAsync(t);
        }

        [HttpPut]
        public async Task<ActionResult> Put(CustomerViewModel newcustomerview)
        {
            var customertoupdate = await _customerRepo.GetByIdAsync(newcustomerview.ID);
            if (customertoupdate == null) return NotFound();


            customertoupdate.ID = newcustomerview.ID;
            customertoupdate.Name = newcustomerview.Name;
            customertoupdate.Surname = newcustomerview.Surname;
            customertoupdate.CardNumber = newcustomerview.CardNumber;
            customertoupdate.Status = newcustomerview.Status;

            await _customerRepo.UpdateAsync(newcustomerview.ID, customertoupdate);



            return Ok();
        }








    }
}
