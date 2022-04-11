using Fuel_Station.Shared;
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
    public partial class NewCustomerForm : MenuForm
    {
        

        public CustomersForm customerForm = new CustomersForm();

        Handlers handlers = new();

        public Guid UserID { get; set; }
        public Guid? editCustomerID { get; set; }=null;
        public NewCustomerForm()
        {
            InitializeComponent();
        }

        private async  void NewCustomerForm_Load(object sender, EventArgs e)
        {
            int? employee = await handlers.GetEmployee(UserID);

            if (employee == null)
            {
                Close();
            };

            handlers.LoginConfirmation(employee.Value,this);//this will close the form if you are not the correct user

           

            
        }

        private async  void LoadCustomer(Guid editCustomerID)
        {
            using var client = new HttpClient();

           /* var customer= await client.GetStringAsync($"https://localhost:7009/Customer/{id}");
            var customerList = JsonConvert.DeserializeObject<List<CustomerViewModel>>(customerListString);*/
        }
    }
}
