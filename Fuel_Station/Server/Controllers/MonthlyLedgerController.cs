using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;
using FuelStation.Models.Enums;

namespace Fuel_Station.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MonthlyLedgerController : ControllerBase
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;

        //private readonly IEntityRepo<ItemRepo> _itemRepo;



        public MonthlyLedgerController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<Employee> employeeRepo,
              IEntityRepo<TransactionLine> transactionLineRepo)
        {
            _transactionRepo = transactionRepo;
            _employeeRepo = employeeRepo;
         
            _transactionLineRepo = transactionLineRepo;
        }

        [HttpGet("{year}/{month}/{rent}/{user}")]
        public async Task<IEnumerable<decimal>> Get(int year,int month,decimal rent,Guid user)
        {
            var employeeList = await _employeeRepo.GetAllAsync();

            decimal rentGeneral = 4000;
            var userEmploy = await _employeeRepo.GetByIdAsync(user);
            if (userEmploy.EmployeeType == EmployeeTypeEnum.Manager )
            {
                rentGeneral = rent;
            }


                var tranList = await _transactionRepo.GetAllAsync();//to ekana ligo argo
            var tranLineList = await _transactionLineRepo.GetAllAsync();

            var activeTransList = tranList.FindAll(x => x.Date.Year == year&& x.Date.Month == month);
            var activeTransListID= activeTransList.Select(x=>x.ID).ToList();
            var activeTranslineList = tranLineList.FindAll(x => activeTransListID.Contains( x.TransactionID));
            var Income = activeTransList.Sum(x => x.TotalValue);

            var itemExpenses = activeTranslineList.Sum(x =>x.Item.Cost);

            //var workingEmployees=
            decimal employeeExpenses = 0;
            var employeeWorking = employeeList.FindAll(x => x.HireDateStart.Year == year && x.HireDateStart.Month == month);
            foreach(var employee in employeeWorking)
            {
                if(employee.HireDateEnd==null|| employee.HireDateEnd.Value.Month> month)
                {
                    employeeExpenses += employee.SalaryPerMonth;
                }
                else
                {
                    employeeExpenses += employee.SalaryPerMonth * (employee.HireDateEnd.Value.Day-1)/30;
                }
                
            }
            var Expenses = rentGeneral + itemExpenses+ employeeExpenses;

            var Total = Income - Expenses;
            var list=new List<decimal>();
            list.Add(Income);
            list.Add(Expenses);
            list.Add(Total);

            return list;
        }
       








    }
}
