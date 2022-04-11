using Fuel_Station.Shared;
using FuelStation.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fuel_Station.WF
{
    public class Handlers
    {

        public Handlers()
        {

        }
        public async Task<int?> GetEmployee(Guid id)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync($"https://localhost:7009/Employee/GetTypeOfEmpl{id}");

            if (content != null)
            {

                int employeeType = Convert.ToInt32(content);
                return employeeType;
            }
            return null;


        }
        public string EmployeeTypeString(int? employeetype)
        {
            return ((EmployeeValueEnum)employeetype).ToString();
        }
        public async Task<List<CustomerViewModel>> LoadingCustomerList(Guid id)
        {
            using var client = new HttpClient();

            var customerListString = await client.GetStringAsync($"https://localhost:7009/Customer/{id}");
            var customerList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(customerListString);

            return customerList;



        }
        public async Task<List<TransactionViewModel>> LoadingTransactionList(Guid id)
        {
            using var client = new HttpClient();

            var transactionListString = await client.GetStringAsync($"https://localhost:7009/Transaction/{id}");
            var transactionList = JsonConvert.DeserializeObject<List<TransactionViewModel>>(transactionListString);

            return transactionList;



        }
        public async void LoginConfirmation(int employee, Form f)//douleuei>????
        {
            string employeeType = EmployeeTypeString(employee);
            if (employeeType == "None" || employeeType == "Staff")
            {
                MessageBox.Show("You are not eligible to continue");
                f.Close();
            }


        }


    }
}
