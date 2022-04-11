using Fuel_Station.Server.Controllers;
using Fuel_Station.Shared;
using FuelStation.EF.Context;
using FuelStation.EF.Repositories;
using FuelStation.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Fuel_Station.WF
{
    public partial class CustomersForm : Form
    {
        public Guid UserID;
        public string customerListString;

        public List<CustomerViewModel> customerList;

        public LoginForm loginForm=new LoginForm();

        public List<CustomerViewModel> customerViewModels = new();
        public CustomersForm()
        {
            InitializeComponent();
        }

        private async void CustomersForm_Load(object sender, EventArgs e)
        {
            int? employee = await loginForm.GetEmployee(UserID);

            if(employee == null)
            {
                Close();
            };
            


            string employeeType = loginForm.EmployeeTypeString(employee);
            if(employeeType =="None"|| employeeType == "Staff")
            {
                MessageBox.Show("You are not eligible to continue");
                Close();
            }

            customerList= await LoadingCustomerList(UserID);

            SetDataBindings();







        }
        private async Task<List<CustomerViewModel>> LoadingCustomerList(Guid id)
        {
            using var client = new HttpClient();

            customerListString = await client.GetStringAsync($"https://localhost:7009/Customer/{id}");
            customerList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(customerListString);

            return customerList;



        }
        private async void LoginConfirmation(EmployeeController employeeController)
        {
            var type = await employeeController.GetEmployeeType(UserID);
            if (type == EmployeeTypeEnum.Manager || type == EmployeeTypeEnum.Cashier)
            {

            }
            

        }


        private void SetDataBindings()
        {

            BindingSource bsCustomers = new BindingSource();
            bsCustomers.DataSource = customerList;
            gridCustomerList.DataSource = bsCustomers;



        }
    }
}
