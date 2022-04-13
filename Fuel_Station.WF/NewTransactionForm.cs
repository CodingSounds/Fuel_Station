using Fuel_Station.Shared;
using FuelStation.Models.Enums;
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
    public partial class NewTransactionForm : Form
    {
        public Guid UserID;
       /* public string cardNumberCreate { get; set; }*/

        Handlers handlers = new();

        List<ItemViewModel> _itemList = new List<ItemViewModel>();

        List<TransactionLineViewModel> _transactionLines = new();

        TransactionCreateViewModel _transaction = new();

        List<ItemTypeEnum> _itemTypeList = new();

        EmployeeViewModel _employee = new();
        CustomerViewModel _customer = new();
        ItemViewModel _selectedItem = new();

        PaymentMethodEnum _PaymentMethod;

        bool _CardNUmberFilled = false;

        decimal _TotalPrice;
        string quantityString;
        decimal _quantity;
        string discountPercentString;
        decimal _discountPercent;

        decimal _NetValue;
        decimal _DiscountValue;
        decimal _TotalValue;



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
            await ShowEmployee();

            await ComboboxBind();






            await LoadCustomerList();
            Binding();
            return true;


        }
        private async Task<int> ComboboxBind()
        {
            cmbPaymentMethod.DataSource = Enum.GetValues(typeof(PaymentMethodEnum));
            cmbPaymentMethod.SelectedIndex = -1;
            cmbPaymentMethod.Text = "Choose";

            _itemList = await handlers.LoadingItemList(UserID);

            var itemListCode = _itemList.Select(x => x.Code).ToList();
            cmbItemCode.DataSource = itemListCode;
            cmbItemCode.SelectedIndex = -1;
            cmbItemCode.Text = "Choose";
            return 0;

        }
        private async Task<bool> ShowEmployee()
        {
            _employee = await handlers.GetEmployee(UserID);




            txtEmployeeName.Text = _employee.Name;
            txtEmployeeSurname.Text = _employee.Surname;
            txtDate.Text = DateTime.Now.ToShortDateString();
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
                    _customer.ID = customer.ID;
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
            _CardNUmberFilled =  SearchCardNUmber_andFIllText();
            if (!_CardNUmberFilled && CardValidation(txtCardNumber.Text))
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

                    _CardNUmberFilled=SearchCardNUmber_andFIllText();//xanagemizi ta koutia
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

        private void btn_Add(object sender, EventArgs e)
        {
            quantityString=txtQuantity.Text;
            discountPercentString = txtDiscountPercent.Text;
            if (checkQuantityFuel()&&checkIfNumbers())
            {
                int cmbIndex = cmbItemCode.SelectedIndex;

                _selectedItem = _itemList[cmbIndex];

                _NetValue = _selectedItem.Price * _quantity;

                MoreDiscountLine();

                _DiscountValue = _NetValue * _discountPercent/100;//check

                _TotalValue = _NetValue - _DiscountValue;

                

                CreateTransactionLine();

                _TotalPrice = TotalPrice();
                txtTotalPrice.Text= _TotalPrice.ToString();

                gridViewTransactionLines.RefreshData();

            }
           

        }

        private bool checkIfNumbers()
        {
             var x = Decimal.TryParse(quantityString,out _quantity);
            var y = Decimal.TryParse(discountPercentString, out _discountPercent);

            if (!(x && y))
            {
                MessageBox.Show("Quantity and Discount Percent must be  numbers");
                return false;
            }
            if(_quantity<=0 || _discountPercent<0 || _discountPercent > 100)
            {
                MessageBox.Show("Quantity and Discount Percent must be positive numbers, and discount percent max value is 100.");
                return false;
            }
            return true;

        }
        private bool checkQuantityFuel()
        {
            int nothing;
            var x=int.TryParse(quantityString, out nothing);
            if (!x &&!(_selectedItem.ItemType==ItemTypeEnum.Fuel))
            {
                MessageBox.Show("Quantity must be an integer for this product.");
                return false;
            }
            return true;
        }

        private void Binding()
        {
            BindingSource bsTransactionLines = new BindingSource();
            bsTransactionLines.DataSource = _transactionLines;
            gridTransactionLines.DataSource = bsTransactionLines;
            gridViewTransactionLines.OptionsBehavior.Editable = false;
            cmbPaymentMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbItemCode.DropDownStyle= ComboBoxStyle.DropDownList;
        }
        private void MoreDiscountLine()
        {
            if (_NetValue > 10 && _selectedItem.ItemType == ItemTypeEnum.Fuel)
            {
                _discountPercent = 10;
            }
            
        }
        private bool OnlyOneFuel(TransactionLineViewModel transactionLine)
        {
   
            var itemCodeTransList = _transactionLines.Select(x => x.ItemCode);
            
            foreach(var item in _itemList)
            {
                if (transactionLine.ItemCode==item.Code)
                {
                    if((_itemTypeList.Contains(item.ItemType)&&item.ItemType== ItemTypeEnum.Fuel))
                        {
                        MessageBox.Show("You can not add another fuel to the transaction");
                        return false;

                    }
                    else
                    {
                        _itemTypeList.Add(item.ItemType);
                    }
                }
            }
            return true;
            
        }
        private decimal TotalPrice()
        {
            return _transactionLines.Sum(x => x.TotalValueOfLine);
        }
        private void CreateTransactionLine()
        {
            TransactionLineViewModel newTransactionLine = new();

            newTransactionLine.ItemPrice = _selectedItem.Price;
            newTransactionLine.ItemCode = _selectedItem.Code;
            newTransactionLine.DiscountPercent = _discountPercent;
            newTransactionLine.DiscountValue = _DiscountValue;
            newTransactionLine.ID=Guid.NewGuid();
            newTransactionLine.Quantity = _quantity;
            newTransactionLine.ItemID = _selectedItem.ID;
            newTransactionLine.NetValue = _NetValue;
            newTransactionLine.TotalValueOfLine = _TotalValue;
            
            if (OnlyOneFuel(newTransactionLine))
            {
                _transactionLines.Add(newTransactionLine);


            }

        }
        private bool CheckPaymentMethod()
        {
            if (_TotalPrice > 50 && cmbItemCode.SelectedIndex==2)
            {
                var msg = string.Format("The transaction needs to be with cash. Do you want to proceed?");
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(msg, " Save Transaction ", buttons);

               
                cmbPaymentMethod.SelectedIndex = 1;
                cmbPaymentMethod.AllowDrop = false;//sosto??
             
                return result == DialogResult.Yes;
            }
            return true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (_CardNUmberFilled && _transactionLines!= null)
            {
                if (CheckPaymentMethod())
                {
                    await SaveTransaction();
                    Close();
                }

               
            }
            else
            {
                MessageBox.Show("You need to have a customer and at least one transaction line");
            }
           
        }
        private async Task<bool> SaveTransaction()
        {
            if (_transactionLines == null)
            {
                MessageBox.Show("You need to add at least one transaction line");
            }
            else
            {
                _transaction.TransactionLinesList = _transactionLines;

                GetPaymentTypeFromComboBox();
                _transaction.PaymentMethod = _PaymentMethod;
                _transaction.EmployeeID = UserID;
                _transaction.CustomerID = _customer.ID;
                _transaction.TotalValue = _TotalPrice;
                _transaction.ID=Guid.NewGuid();
                using var client = new HttpClient();
                await client.PostAsJsonAsync($"https://localhost:7009/Transaction/{UserID}", _transaction);

            }
           
           

            return true;
        }
        public void GetPaymentTypeFromComboBox()
        {
            var index = cmbPaymentMethod.SelectedIndex;
            if (index == -1)
            {
                MessageBox.Show("Payment Method will be cash");
                _PaymentMethod = PaymentMethodEnum.Cash;
            }
            if (index == 0)
            {
                _PaymentMethod = PaymentMethodEnum.CreditCard;
            }
            else
            {
                _PaymentMethod = PaymentMethodEnum.Cash;
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
