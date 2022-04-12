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
    public partial class MenuForm : Form
    {
        public Guid UserID { get; set; }
        string employeeType;
        
        Handlers handlers = new();
        public  MenuForm()
        {
            InitializeComponent();
            
        }

        private async void MenuForm_Load(object sender, EventArgs e)
        {
            
            var z = await handlers.GetEmployeeTypeToInt(UserID);
            employeeType = handlers.EmployeeTypeString(z);
        }

        private async void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (employeeType=="Manager"|| employeeType=="Cashier")//na balo handler
            {

                CustomersForm f = new CustomersForm();
                f.UserID = UserID;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not authorized to view Customers");
            }

           

        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeType == "Manager" || employeeType == "Cashier")
            {
                TransactionForm f = new TransactionForm();
                f.UserID = UserID;
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("You are not authorized to view Transactions");
            }


        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ItemForm f = new();
            f.UserID = UserID;
            f.ShowDialog();
        }
    }
}
