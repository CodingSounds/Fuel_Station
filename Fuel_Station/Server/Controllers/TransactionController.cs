using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;
using FuelStation.Models.Enums;

namespace Fuel_Station.Server.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class TransactionController {
        private IEntityRepo<Transaction> _transactionRepo;
        private IEntityRepo<TransactionLine> _translinesRepo;
        private readonly IEntityRepo<Employee> _employeeRepo;

        public TransactionController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<TransactionLine> translinesRepo,
             IEntityRepo<Employee> employeeRepo) {
            _transactionRepo = transactionRepo;
            _translinesRepo = translinesRepo;
            _employeeRepo = employeeRepo;
        }

        [HttpGet("WholeTransaction{user}")]
        public async Task<IEnumerable<TransactionViewModel>> GetalsoTransactionLines(Guid user)
        {
           

            var userEmploy = await _employeeRepo.GetByIdAsync(user);
            if (userEmploy.EmployeeType == EmployeeTypeEnum.Manager || userEmploy.EmployeeType == EmployeeTypeEnum.Cashier)
            {
                var result = await _transactionRepo.GetAllAsync();
                return result.Select(x => new TransactionViewModel
                {
                    ID = x.ID,
                    CustomerID = x.CustomerID,
                    EmployeeID = x.EmployeeID,
                    PaymentMethod = x.PaymentMethod,
                    CardNumber=x.Customer.CardNumber,
                    EmployeeType=x.Employee.EmployeeType.ToString(),
                    Date = x.Date,
                    TotalValue=x.TotalValue
                    




                });
            }
            return null;           
        }
       



        
        [HttpGet("{user}")]
        public async Task<IEnumerable<TransactionViewModel>> Get(Guid user)
        {
            var userEmploy = await _employeeRepo.GetByIdAsync(user);
            if (!(userEmploy.EmployeeType == EmployeeTypeEnum.Manager || userEmploy.EmployeeType == EmployeeTypeEnum.Cashier))
            {
                return null;
            }



            var result = await _transactionRepo.GetAllAsync();

            var newtransviewList = new List<TransactionViewModel>();
           
            foreach (var trans in result)
            {
                var newtransview = new TransactionViewModel();
                newtransview.ID = trans.ID;
                newtransview.CustomerID = trans.CustomerID;
                newtransview.PaymentMethod = trans.PaymentMethod;
                newtransview.TotalValue = trans.TotalValue;


                newtransview.Date = trans.Date;
                newtransview.CardNumber = trans.Customer.CardNumber;
                newtransview.EmployeeType = trans.Employee.EmployeeType.ToString();
                newtransview.TransactionLinesList = new();

                var transactionLinesList = await _translinesRepo.GetAllAsync();
                var lines = transactionLinesList.Where(x => x.TransactionID == trans.ID);

                foreach (var transline in lines)
                {
                    
                    var translineViewModel = new TransactionLineViewModel()
                    {
                        ItemPrice = transline.ItemPrice,
                        ID = transline.ID,
                        TotalValueOfLine = transline.TotalValueOfLine,
                        NetValue = transline.NetValue,
                        DiscountPercent = transline.DiscountPercentage,
                        ItemCode = transline.Item.Code,
                        DiscountValue = transline.DiscountValue,
                        Quantity=transline.Quantity,



                    };


                    newtransview.TransactionLinesList.Add(translineViewModel);
                }
                newtransviewList.Add(newtransview);




            }

            return newtransviewList;
        }

        [HttpGet("create/{Id}")]
        public async Task<TransactionCreateViewModel> GetCreate(Guid Id) {

            TransactionCreateViewModel model = new();
            //if (id is not null) {
            //    //Edit ?
            //}
            return model;
        }



        [HttpPost("{userID}")]
        public async Task Post(Guid userID,TransactionCreateViewModel transactionViewModel) {


            var userEmploy = await _employeeRepo.GetByIdAsync(userID);
            if (userEmploy.EmployeeType == EmployeeTypeEnum.Manager || userEmploy.EmployeeType == EmployeeTypeEnum.Cashier)
            {
                var dbTrans = new Transaction()
                {
                    ID = Guid.NewGuid(),
                    CustomerID = transactionViewModel.CustomerID,
                    EmployeeID = transactionViewModel.EmployeeID,
                    PaymentMethod = transactionViewModel.PaymentMethod,
                    TotalValue = transactionViewModel.TotalValue,

                     Status = true,
                    TransactionLinesList = new()
                };
                foreach (var line in transactionViewModel.TransactionLinesList)
                {
                    var dbLine = new TransactionLine()
                    {
                        ID = Guid.NewGuid(),
                        ItemPrice = line.ItemPrice,
                       
                        TotalValueOfLine = line.TotalValueOfLine,
                        NetValue = line.NetValue,
                        DiscountPercentage = line.DiscountPercent,
                        ItemID = line.ItemID,
                        DiscountValue = line.DiscountValue,
                        Quantity=line.Quantity
                        

                    };

                    dbTrans.TransactionLinesList.Add(dbLine);

                }
                await _transactionRepo.CreateAsync(dbTrans);
            }
           
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id) {
            await _transactionRepo.DeleteAsync(id);
        }

    }
}

                    