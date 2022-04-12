using Fuel_Station.Shared;
using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuel_Station.WF
{
    public partial class NewTransactionForm : Form
    {
        public Guid UserID;
       /* public string cardNumberCreate { get; set; }*/

        Handlers handlers = new();

        EmployeeViewModel _employee = new();
        CustomerViewModel _customer = new();



        List<CustomerViewModel> _customerList = new List<CustomerViewModel>();
        public NewTransactionForm()
        {
            InitializeComponent();
        }

        private async void NewTransactionForm_Load(object sender, EventArgs e)
        {
            TextBoxesNotEditable();
            LoadData();
        }

        private void TextBoxesNotEditable()
        {
            txtCustomerName.ReadOnly=true;
            txtCustomerSurname.ReadOnly=true;
            txtEmployeeName.ReadOnly = true;
            txtEmployeeSurname.ReadOnly=true;
            txtDate.ReadOnly=true;
            txtCardNumber.ReadOnly=false;
            txtTotalPrice.ReadOnly = true;
        }
        private async Task<bool>  LoadData()
        {
             _employee = await handlers.GetEmployee(UserID);

            


            txtEmployeeName.Text = _employee.Name;
            txtEmployeeSurname.Text=_employee.Surname;
            txtDate.Text = DateTime.Now.ToShortDateString();

            cmbPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethodEnum));
            cmbPaymentMethod.SelectedIndex = -1;
            cmbPaymentMethod.Text = "Choose";

            var itemList= await handlers.LoadingItemList(UserID);
            var itemListCode = itemList.Select(x => x.Code).ToList();
            cmbItemCode.DataSource = itemListCode;
            cmbItemCode.SelectedIndex = -1;
            cmbItemCode.Text = "Choose";

            



            await LoadCustomerList();
            return true;


        }
        private bool SearchCardNUmber_andFIllText()
        {
            /*if(cardNumberCreate!=null)
                txtCardNumber.Text = cardNumberCreate;*/

            foreach (var customer in _customerList)
            {
                if (txtCardNumber.Text == customer.CardNumber)
                {
                    txtCustomerName.Text = customer.Name;
                    txtCustomerSurname.Text = customer.Surname;
                    txtCardNumber.ReadOnly = true;
                    return true;
                }
            }
            return false;
        }
        private async Task<bool> LoadCustomerList()
        {
            _customerList = await handlers.LoadingCustomerList(UserID);

         
            return true;
        }
      

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            var existCard =  SearchCardNUmber_andFIllText();
            if (!existCard && CardValidation(txtCardNumber.Text))
            {
                var msg = string.Format("Card number is not found.  Do you want to create a new  Customer with this Card number?");
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(msg, " Create Customer ", buttons);
                if (result == DialogResult.Yes)
                {
                    NewCustomerForm f = new NewCustomerForm();
                    f.UserID = UserID;
                    f.cardNumberCreate = txtCardNumber.Text;
                    f.ShowDialog();

                    await LoadCustomerList();

                    SearchCardNUmber_andFIllText();//xanagemizi ta koutia
                }
                

            }
          
        }

        private bool CardValidation(string CardNumber)
        {
            if (CardNumber == "" || CardNumber[0] != 'A')
            {
                MessageBox.Show("It is not in the correct format");
                return false;
            }
            var numberofCard = CardNumber.Remove(0, 1);
            BigInteger i = 0;
            var response = BigInteger.TryParse(numberofCard, out i);
            if (!response)
            {
                MessageBox.Show("It is not in the correct format");
                return false;
            }
            return true;
        }





    }
}
