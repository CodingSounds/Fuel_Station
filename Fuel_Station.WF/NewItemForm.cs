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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuel_Station.WF
{
    public partial class NewItemForm : Form
    {
        public Guid UserID { get; set; }
        public Guid? editItemID { get; set; }

        Handlers handlers = new();
        decimal priceNumber;
        decimal costNumber;
        ItemViewModel newItem = new(); 
        


        public NewItemForm()
        {
            InitializeComponent();
        }

        private async void NewItem_Load(object sender, EventArgs e)
        {
            int? employee = await handlers.LoadEmployeee(UserID, this);

            handlers.LoginConfirmationItems(employee.Value, this);//danger cannot await

            EditItem(editItemID);
            LoadComboBox();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void EditItem(Guid? editItemID)
        {
            if (editItemID == null)
            {

            }
            else
            {
                var item = await handlers.GetItem(UserID, editItemID.Value);
                txtCode.Text = item.Code;
                txtDescription.Text = item.Description;
                txtPrice.Text = item.Price.ToString();
                txtItemType.Text = item.ItemType.ToString();
                txtCost.Text = item.Cost.ToString();
                cmbType.SelectedIndex = IndexOFItemtype(item.ItemType);
            }



        }

        private async void btnSave_Click(object sender, EventArgs e)
        {

            int cmbIndex = cmbType.SelectedIndex;
            ItemTypeEnum type = (ItemTypeEnum)cmbIndex;
            if (CodeValidation(txtCode.Text) && CostAndPriceValidation(txtPrice.Text,txtCost.Text)&& EnumValidation(type))
            {
                newItem.Code = txtCode.Text;
                newItem.Description = txtDescription.Text;
                newItem.Price = priceNumber;
                newItem.Status = true;
                newItem.Cost = costNumber;
                

                newItem.ItemType = type;

                using var client = new HttpClient();
                if (editItemID == null)
                {
                    await client.PostAsJsonAsync($"https://localhost:7009/Item/{UserID}", newItem);
                }
                else
                {
                    newItem.ID = editItemID.Value;
                    await client.PutAsJsonAsync($"https://localhost:7009/Item/{UserID}", newItem);
                }
                /* formCustomer.gridView1.RefreshData();//kalo practice?????/ giati den douleuei*/
                Close();
            }
            else
            {
                MessageBox.Show("Invalid Inputs");
            }
        }
        private bool CostAndPriceValidation(string Price,string Cost)
        {
            if (Price == null || Cost == null)
            {
                return false;
            }
            
            bool isNumericPrice = decimal.TryParse(Price, out priceNumber);
           
            bool isNumericCost = decimal.TryParse(Cost, out costNumber);
            return (isNumericPrice && isNumericCost&& priceNumber>=0 && costNumber>=0);
          
        }
       

        private bool CodeValidation(string Code)
        {
            if (Code == null)
                return false;
            int i;
            return(int.TryParse(Code, out i));
        }
        private bool EnumValidation(ItemTypeEnum Code)
        {
           
            return !(Code.ToString()=="None");
        }
        private void LoadComboBox()
        {
            cmbType.DataSource = Enum.GetValues(typeof(ItemTypeEnum));
            
        }
        private int IndexOFItemtype(ItemTypeEnum type)
        {
            if (type.ToString() == "None")
            {
                return 0;
            }
            else if(type.ToString() == "Fuel")
            {
                return 1;
            }
            else if (type.ToString() == "Product")
            {
                return 2;
            }
            return (3);
        }
    }
}


