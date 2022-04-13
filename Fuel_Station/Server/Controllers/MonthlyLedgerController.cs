using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;



namespace Fuel_Station.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MonthlyLedgerController : ControllerBase
    {
        private readonly IEntityRepo<Transaction> _transactionRepo;
        private readonly IEntityRepo<TransactionLine> _transactionLineRepo;
        
        private readonly RentRepo _RentRepo;

        public MonthlyLedgerController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<TransactionLine> transactionLineRepo,
            RentRepo RentRepo)
        {
            _transactionRepo = transactionRepo;
            _transactionLineRepo = transactionLineRepo;
            _RentRepo = RentRepo;
        }

        [HttpGet("{month}/{year}")]
        public async Task<IEnumerable<decimal>> Get(int month, int year)
        {
            string date=month.ToString()+year.ToString();//desssssssss
            decimal? rentCost = await _RentRepo.GetByIdAsync(date);
            var tranList = await _transactionRepo.GetAllAsync();//to ekana ligo argo
            var tranLineList = await _transactionLineRepo.GetAllAsync();

            var activeTransList = tranList.FindAll(x => x.Date.Year == year&& x.Date.Month == month);
            var activeTransListID= activeTransList.Select(x=>x.ID).ToList();
            var activeTranslineList = tranLineList.FindAll(x => activeTransListID.Contains( x.ID));
            var Income = activeTranslineList.Sum(x => x.TotalValueOfLine);
            var Expenses = activeTranslineList.Sum(x => (1-x.DiscountPercentage)*x.Quantity*x.ItemPrice);
            Expenses += rentCost.Value + Expenses;
            var Total = Income - Expenses;
            var list=new List<decimal>();
            list.Add(Income);
            list.Add(Expenses.Value);
            list.Add(Total.Value);

            return list;
        }
       








    }
}
