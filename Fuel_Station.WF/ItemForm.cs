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
        ItemViewModel itemLIst = new ItemViewModel();
        public ItemForm()
        {
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            LoadItems(UserID);
            SetDataBindings();
            gridViewItems.OptionsBehavior.Editable = false;
        }

        private async Task LoadItems(Guid UserID)
        {
            var employee = await handlers.LoadEmployeee(UserID, this);

            handlers.LoginConfirmationItems(employee.Value, this);//this will close the form if you are not the correct user

            var itemLIst = await handlers.LoadingItemList(UserID);
        }
        private void SetDataBindings()
        {

            BindingSource bsItems = new BindingSource();
            bsItems.DataSource = itemLIst;
            gridItemList.DataSource = bsItems;



        }
    }
}
