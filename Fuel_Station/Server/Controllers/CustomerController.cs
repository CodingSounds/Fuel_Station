using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;



namespace Fuel_Station.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IEntityRepo<Customer> _customerRepo;

        public CustomerController(IEntityRepo<Customer> customerRepo)
        {
            _customerRepo = customerRepo;
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
                Status = x.Status,
                

            });

            return t;
        }
        [HttpGet("GetAllCust")]
        public async Task<IEnumerable<CustomerViewModel>> GetAll()
        {
            var result = await _customerRepo.GetAllAsync();

            var t = result.Select(x => new CustomerViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Surname = x.Surname,
                CardNumber = x.CardNumber,
                Status = x.Status,

            });

            return t;
        }
        [HttpGet("GetOneCustomer{id}")]
        public async Task<CustomerViewModel> GetOne(Guid id)
        {
            var result = await _customerRepo.GetByIdAsync(id);

            var t = new CustomerViewModel
            {
                ID = result.ID,
                Name = result.Name,
                Surname = result.Surname,
                CardNumber = result.CardNumber,
                Status = result.Status,

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
