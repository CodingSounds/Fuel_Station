using Fuel_Station.Server.Controllers;
using FuelStation.EF.Context;
using FuelStation.EF.Repositories;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void btnEnter_Click(object sender, EventArgs e)
        {
            string username;
            string password;
           username=txtUsername.Text;
           password=txtPassword.Text;
            var login = await Login(password, username);
            if (login != null){
                


                var f = new MenuForm();
                f.UserID = login.Value;
                f.Show();
                this.Hide();

            }



        }

        private async Task<Guid?> Login(string password, string username)
        {
            FuelStationContext fuelStationContext = new();
            //CustomerRepo customerRepo = new(fuelStationContext);
            EmployeeRepo employee=new(fuelStationContext);
            EmployeeController employeeController = new EmployeeController(employee);
            //findblblb
            var ID =await  employeeController.LoginGet(username, password);
            return ID;









        }
    }
}
