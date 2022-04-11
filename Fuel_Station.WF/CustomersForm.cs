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
        public Guid UserID { get; set; }
        public string customerListString;

        private List<CustomerViewModel> customerList { get; set; }

        Handlers handlers = new();

        public List<CustomerViewModel> customerViewModels = new();
        public CustomersForm()
        {
            InitializeComponent();
        }

        private async void CustomersForm_Load(object sender, EventArgs e)
        {

            await LoadCustomers();
            SetDataBindings();
            
             gridView1.OptionsBehavior.Editable=false;//??



        }

        private async Task LoadCustomers()
        {
            int? employee = await handlers.GetEmployee(UserID);

            if (employee == null)
            {
                Close();
            };

            handlers.LoginConfirmation(employee.Value, this);//this will close the form if you are not the correct user

            customerList = await handlers.LoadingCustomerList(UserID);
        }
      /*  private async Task<List<CustomerViewModel>> LoadingCustomerList(Guid id)
        {
            using var client = new HttpClient();

            customerListString = await client.GetStringAsync($"https://localhost:7009/Customer/{id}");
            customerList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(customerListString);

            return customerList;



        }
        public async void LoginConfirmation(int employee)
        {
            string employeeType = handlers.EmployeeTypeString(employee);
            if (employeeType == "None" || employeeType == "Staff")
            {
                MessageBox.Show("You are not eligible to continue");
                Close();
            }


        }*/


        private void SetDataBindings()
        {

            BindingSource bsCustomers = new BindingSource();
            bsCustomers.DataSource = customerList;
            gridCustomerList.DataSource = bsCustomers;



        }
    }
}
