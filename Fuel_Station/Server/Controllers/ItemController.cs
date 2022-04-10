﻿using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;
using FuelStation.Models.Enums;

namespace Fuel_Station.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IEntityRepo<Item> _ItemRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;

        public ItemController(IEntityRepo<Item> ItemRepo, IEntityRepo<Employee> employeeRepo)
        {
            _ItemRepo = ItemRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<ItemViewModel>> Get()
        {
            var result = await _ItemRepo.GetAllAsync();

            var activeItems = result.FindAll(x => x.Status == true);
            var t = activeItems.Select(x => new ItemViewModel
            {
                ID = x.ID,
                Code = x.Code,
                Price = x.Price,
                Description = x.Description,
                Status = x.Status.Value,
                ItemType=x.ItemType,
                Cost = x.Cost


            });

            return t;
        }
        [HttpGet("GetAllItems{user}")]
        public async Task<IEnumerable<ItemViewModel>> GetAll(Guid user)
        {
            
            var userEmploy = await _employeeRepo.GetByIdAsync(user);
            if (userEmploy.EmployeeType == EmployeeTypeEnum.Manager
                || (userEmploy.EmployeeType == EmployeeTypeEnum.Staff))
            {
                var result = await _ItemRepo.GetAllAsync();
                var notErasedItems = result.FindAll(x => x.Status != null);
                var t = notErasedItems.Select(x => new ItemViewModel
                {
                    ID = x.ID,
                    Code = x.Code,
                    Price = x.Price,
                    Description = x.Description,
                    Status = x.Status.Value,
                    ItemType = x.ItemType,
                    Cost = x.Cost

                });
                return t;
            }
            return null;
            

            
        }
        [HttpGet("GetOneItem{user}/{id}")]
        public async Task<ItemViewModel> GetOne(Guid user, Guid id)
        {

            var userEmploy = await _employeeRepo.GetByIdAsync(user);
            if (userEmploy.EmployeeType == EmployeeTypeEnum.Manager
                || (userEmploy.EmployeeType == EmployeeTypeEnum.Staff))
            {

                var result = await _ItemRepo.GetByIdAsync(id);

                var t = new ItemViewModel
                {
                    ID = result.ID,
                    Code = result.Code,
                    Price = result.Price,
                    Description = result.Description,
                    Status = result.Status.Value,
                    ItemType = result.ItemType,
                    Cost = result.Cost

                };

                return t;

            }
            return null;


        }

        [HttpPost]

        public async Task Post(ItemViewModel itemViewModel)
        {
            Item item = new Item
            {
                ID = itemViewModel.ID,
                Code = itemViewModel.Code,
                Price = itemViewModel.Price,
                Description = itemViewModel.Description,

                ItemType = itemViewModel.ItemType,
                Cost = itemViewModel.Cost,
                Status = true
            };
            await _ItemRepo.CreateAsync(item);

        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {

            var x = await _ItemRepo.GetByIdAsync(id);
            x.Status = !x.Status;
            await _ItemRepo.UpdateAsync(id, x);
        }
        [HttpDelete("Erase{id}")]
        public async Task Erase(Guid id)
        {

            var x = await _ItemRepo.GetByIdAsync(id);
            Item item = new Item
            {
                ID = x.ID,
                Code = x.Code,
                Price = x.Price,
                Description = x.Description,

                ItemType = x.ItemType,
                Cost = x.Cost,
                Status = null
            };

            await _ItemRepo.DeleteAsync(id);
            await _ItemRepo.CreateAsync(item);
        }



        [HttpPut]
        public async Task<ActionResult> Put(ItemViewModel itemViewModel)
        {
            var itemtupdate = await _ItemRepo.GetByIdAsync(itemViewModel.ID);
            if (itemtupdate == null) return NotFound();


            itemtupdate.Price = itemViewModel.Price;
            itemtupdate.Code = itemViewModel.Code;
            itemtupdate.Description = itemViewModel.Description;
            itemtupdate.Cost = itemViewModel.Cost;
            itemtupdate.Status = itemViewModel.Status;
            itemtupdate.ItemType = itemViewModel.ItemType;

            await _ItemRepo.UpdateAsync(itemViewModel.ID, itemtupdate);



            return Ok();
        }








    }
}
