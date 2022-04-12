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

            await LoadCustomers(UserID);
            SetDataBindings();
            
             gridView1.OptionsBehavior.Editable=false;



        }

        private async Task LoadCustomers(Guid UserID)
        {
            var employee= await handlers.LoadEmployeee(UserID, this);

            handlers.LoginConfirmationForCustomers_Transactions(employee.Value, this);//this will close the form if you are not the correct user

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

        private void btnNew_Click(object sender, EventArgs e)
        {

            var f = new NewCustomerForm();
            f.formCustomer = this;
            f.UserID = UserID;
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckIfNull())
            {
                var f = new NewCustomerForm();
                f.UserID = UserID;
                f.editCustomerID = GetCustomerFromGrid().ID;
                f.formCustomer = this;

                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid operation. Can not edit customer that does not exist");
            }
        }

        private CustomerViewModel GetCustomerFromGrid()//an exoume 0?
        {
            int index = gridView1.FocusedRowHandle;

            var customerView = gridView1.GetRow(index) as CustomerViewModel;
            return customerView;
        }

        private bool CheckIfNull()
        {
            var x = gridView1.RowCount;
           return x > 0;
        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
