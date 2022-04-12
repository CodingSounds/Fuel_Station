﻿using Fuel_Station.Shared;
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

            if (content!= "" )////fix
            {

                int employeeType = Convert.ToInt32(content);
                return employeeType;
            }
            return null;


        }
        public string EmployeeTypeString(int? employeetype)
        {if(employeetype==null)
                return null;
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
        public async Task<List<ItemViewModel>> LoadingItemList(Guid id)
        {
            using var client = new HttpClient();

            var itemListString = await client.GetStringAsync($"https://localhost:7009/Item/GetAllItems{ id}");
            var itemList = JsonConvert.DeserializeObject<List<ItemViewModel>>(itemListString);

            return itemList;



        }
        public async void LoginConfirmationForCustomers_Transactions(int employee, Form f)//douleuei>????
        {
            string employeeType = EmployeeTypeString(employee);
            if (employeeType == "None" || employeeType == "Staff")
            {
                MessageBox.Show("You are not eligible to continue");
                f.Close();
            }


        }
        public async void LoginConfirmationItems(int employee, Form f)//douleuei>????
        {
            string employeeType = EmployeeTypeString(employee);
            if (employeeType == "None" || employeeType == "Cashier")
            {
                MessageBox.Show("You are not eligible to continue");
                f.Close();
            }


        }

        public async Task<int? > LoadEmployeee(Guid UserID,Form f)
        {
            int? employee = await GetEmployee(UserID);

            if (employee > 100)
            {
                
                f.Close();
            };
            return employee;
        }

        public async Task<CustomerViewModel> GetCustomer(Guid UserID,Guid customerID)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync($"https://localhost:7009/Customer/GetOneCustomer{UserID}/{customerID}");
            var customer = JsonConvert.DeserializeObject<CustomerViewModel>(content);
            if (!(content != "" && content.Substring(0, 9) != "<!DOCTYPE"))//fix it
            {
                MessageBox.Show("Invalid Customer ID");
                
                return null;
            }
            return customer;

        }
        public async Task<ItemViewModel> GetItem(Guid id)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync($"https://localhost:7009/Customer/{id}");
            var item = JsonConvert.DeserializeObject<ItemViewModel>(content);
            if (!(content != "" && content.Substring(0, 9) != "<!DOCTYPE"))//fixxxxxxxxxxxx it
            {
                MessageBox.Show("Invalid Item ID");

                return null;
            }
            return item;

        }



    }
}
