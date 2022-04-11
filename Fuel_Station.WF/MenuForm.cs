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
        public Guid UserID;
        string employeeType;
        LoginForm loginForm = new LoginForm();
        public  MenuForm()
        {
            InitializeComponent();
            
        }

        private async void MenuForm_Load(object sender, EventArgs e)
        {
            loginForm = new LoginForm();
            var z = await loginForm.GetEmployee(UserID);
            employeeType = loginForm.EmployeeTypeString(z);
        }

        private async void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (employeeType=="Manager"|| employeeType=="Cashier")
            {

                CustomersForm f = new CustomersForm();
                f.UserID = UserID;
                f.ShowDialog();
            }

           

        }
    }
}
