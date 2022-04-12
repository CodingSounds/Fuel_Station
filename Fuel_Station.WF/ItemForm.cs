using Fuel_Station.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuel_Station.WF
{
    public partial class ItemForm : Form
    {
        public Guid UserID;
        Handlers handlers = new();
        List<ItemViewModel> itemLIst = new();


        public ItemForm()
        {
            InitializeComponent();
        }

        private async void ItemForm_Load(object sender, EventArgs e)
        {
            await LoadItems(UserID);
            SetDataBindings();
            gridViewItems.OptionsBehavior.Editable = false;
        }

        private async Task LoadItems(Guid UserID)
        {
            var employee = await handlers.LoadEmployeeeTypeToInt(UserID, this);

            handlers.LoginConfirmationItems(employee.Value, this);//this will close the form if you are not the correct user

            itemLIst = await handlers.LoadingItemList(UserID);

        }
        private void SetDataBindings()
        {

            BindingSource bsItems = new BindingSource();
            bsItems.DataSource = itemLIst;
            gridItemList.DataSource = bsItems;



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var f = new NewItemForm();
            /* f.formCustomer = this;*/
            f.UserID = UserID;
            f.ShowDialog();
            RefreshData();
        }

        private async void RefreshData()
        {
            itemLIst = await handlers.LoadingItemList(UserID);
            SetDataBindings();
            gridViewItems.RefreshData();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckIfNull())
            {

                var deleteID = GetItemFromGrid().ID;
                var nothing = await handlers.DeleteItem(UserID, deleteID);


                RefreshData();
            }
            else
            {
                MessageBox.Show("Invalid operation. Can not edit customer that does not exist");
            }
        }

        private bool CheckIfNull()
        {
            var x = gridViewItems.RowCount;
            return x > 0;
        }
        private ItemViewModel GetItemFromGrid()//an exoume 0?
        {
            int index = gridViewItems.FocusedRowHandle;

            var itemView = gridViewItems.GetRow(index) as ItemViewModel;
            return itemView;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (CheckIfNull())
            {
                var f = new NewItemForm();
                f.UserID = UserID;
                f.editItemID = GetItemFromGrid().ID;
                

                f.ShowDialog();

                RefreshData();
            }
            else
            {
                MessageBox.Show("Invalid operation. Can not edit customer that does not exist");
            }
        }
    }

}
