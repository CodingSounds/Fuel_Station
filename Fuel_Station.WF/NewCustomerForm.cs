using Fuel_Station.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuel_Station.WF
{
    public partial class NewCustomerForm : Form
    {
        

        public CustomersForm customerForm = new CustomersForm();

        Handlers handlers = new();
        public CustomersForm formCustomer { get; set; }//kalo practise???
        public Guid UserID { get; set; }
        public Guid? editCustomerID { get; set; }=null;
      
        public NewCustomerForm()
        {
            InitializeComponent();
        }

        private async  void NewCustomerForm_Load(object sender, EventArgs e)
        {
            int? employee = await handlers.LoadEmployeee(UserID, this);

         

            handlers.LoginConfirmationForCustomers_Transactions(employee.Value,this);//danger cannot await

            EditCustomer(editCustomerID);







        }

        private async void EditCustomer(Guid? editCustomerID)
        {
            if (editCustomerID == null)
            {
                
            }
            else
            {
                var customer = await handlers.GetCustomer(UserID,editCustomerID.Value);
                txtCardNumber.Text = customer.CardNumber;
                txtName.Text = customer.Name;
                txtSurname.Text = customer.Surname;
            }
           


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void simpleButton1_Click(object sender, EventArgs e)//SaveButton
        {
            var newcustomer=new CustomerViewModel();
            if (CardValidation(txtCardNumber.Text))
            {
                newcustomer.Name = txtName.Text;
                newcustomer.Surname = txtSurname.Text;
                newcustomer.CardNumber = txtCardNumber.Text;
                newcustomer.Status = true;
                
                using var client = new HttpClient();
                if (editCustomerID == null)
                {
                    await client.PostAsJsonAsync($"https://localhost:7009/Customer/{UserID}", newcustomer);
                }
                else
                {
                    newcustomer.ID = editCustomerID.Value;
                    await client.PutAsJsonAsync($"https://localhost:7009/Customer/{UserID}", newcustomer);
                }
                formCustomer.gridView1.RefreshData();//kalo practice?????/ giati den douleuei
                Close();
/*
                var content = new FormUrlEncodedContent(newcustomer);

                var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

                var responseString = await response.Content.ReadAsStringAsync();*/
                
                
            }
            else
            {
                MessageBox.Show("Invalid Card Number");
            }
            


        }

        private bool CardValidation(string CardNumber)
        {
            if (CardNumber == null|| CardNumber[0]!='A')
            {
                return false;
            }
            var numberofCard=CardNumber.Remove(0, 1);
            BigInteger i = 0;
            return BigInteger.TryParse(numberofCard,out i);
        }
    }
}
