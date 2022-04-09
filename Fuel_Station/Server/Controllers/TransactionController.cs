using FuelStation.EF.Repositories;
using FuelStation.Models;
using Microsoft.AspNetCore.Mvc;
using Fuel_Station.Shared;



namespace Fuel_Station.Server.Controllers
{    [Route("[controller]")]
    [ApiController]
    public class TransactionController {
        private IEntityRepo<Transaction> _transactionRepo;
        private IEntityRepo<TransactionLine> _translinesRepo;

        public TransactionController(IEntityRepo<Transaction> transactionRepo, IEntityRepo<TransactionLine>  translinesRepo) {
            _transactionRepo = transactionRepo;
            _translinesRepo = translinesRepo;
        }

        [HttpGet]
        public async Task<IEnumerable<TransactionViewModel>> Get()
        {
            var result = await _transactionRepo.GetAllAsync();

            return result.Select(x => new TransactionViewModel
            {
                ID = x.ID,
                CustomerID = x.CustomerID,
                EmployeeID = x.EmployeeID,
                PaymentMethod = x.PaymentMethod,
                TotalValue = x.TotalValue,
                Date = x.Date
                
            });
        }
        [HttpGet("WholeTransaction")]
        public async Task<IEnumerable<TransactionViewModel>> GetalsoTransactionLines()
        {
            var result = await _transactionRepo.GetAllAsync();
            var newtransviewList = new List<TransactionViewModel>();
            //var transactionViewModel = result.Select(x => new TransactionViewModel
            //{
            //    Id = x.ID,
            //    CustomerID = x.CustomerID,
            //    CarID = x.CarID,
            //    ManagerID = x.ManagerID,
            //    TotalPrice = x.TotalPrice,
            //    Date = x.Date

            //});
            foreach (var trans in result)
            {
                var newtransview = new TransactionViewModel();
                newtransview.ID = trans.ID;
                newtransview.CustomerID = trans.CustomerID;
                newtransview.PaymentMethod = trans.PaymentMethod;
                newtransview.TotalValue = trans.TotalValue;
                
                newtransview.Date = trans.Date;
                newtransview.TransactionLinesList = new();
                foreach (var transline in trans.TransactionLinesList)
                {
                    var translineViewModel = new TransactionLineViewModel()
                    {
                        ItemPrice = transline.ItemPrice,
                        ID = transline.ID,
                        TotalValue = transline.TotalValue,
                        NetValue = transline.NetValue,
                        DiscountPercentage = transline.DiscountPercentage,
                        ItemID = transline.ItemID,
                        DiscountValue = transline.DiscountValue


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



        [HttpPost]
        public async Task Post(TransactionCreateViewModel transactionViewModel) {
            var dbTrans = new Transaction()
            {
                ID = transactionViewModel.ID,
                CustomerID = transactionViewModel.CustomerID,
                EmployeeID = transactionViewModel.EmployeeID,
                PaymentMethod = transactionViewModel.PaymentMethod,
                TotalValue = transactionViewModel.TotalValue,
                Status = true,
                TransactionLinesList = new()               
            };
            foreach (var line in transactionViewModel.TransactionLinesList) {
                var dbLine = new TransactionLine()
                {
                    ItemPrice = line.ItemPrice,
                    ID = line.ID,
                    TotalValue = line.TotalValue,
                    NetValue = line.NetValue,
                    DiscountPercentage = line.DiscountPercentage,
                    ItemID=line.ItemID,
                   DiscountValue= line.DiscountValue

                };

                dbTrans.TransactionLinesList.Add(dbLine);

            }
            await _transactionRepo.CreateAsync(dbTrans);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id) {
            await _transactionRepo.DeleteAsync(id);
        }

    }
}

                    