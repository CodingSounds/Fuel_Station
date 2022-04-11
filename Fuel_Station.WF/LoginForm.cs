using Fuel_Station.Server.Controllers;
using FuelStation.EF.Context;
using FuelStation.EF.Repositories;
using FuelStation.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Fuel_Station.WF
{
    public partial class LoginForm : Form
    {

        Handlers handler = new();
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
            int? employee = 0;

            username =txtUsername.Text;
           password=txtPassword.Text;

            var guidEMployee = await GetID(password, username);

            if(guidEMployee != null)
            {
                employee = await handler.GetEmployee(guidEMployee.Value);
                
            }
           
           

           
            if (handler.EmployeeTypeString(employee) != "None")
            {



                var f = new MenuForm();
                f.UserID = guidEMployee.Value;
                f.Show();
                this.Hide();



                

            }
            else
            {
                MessageBox.Show("You entered wrong username or password");

            }



        }

        private async Task<Guid?> GetID(string password, string username)
        {
            
            using var client = new HttpClient();
            var id= await client.GetStringAsync($"https://localhost:7009/Employee/GetUser{username}/{password}");
            if (id != null)
            {
                var t = id.Replace('"', ' ');
                Guid idGuid = Guid.Parse(t);
                return idGuid;
            }
            return null;
           
        }

       /* public async Task<int?>GetEmployee(Guid id)
        {
            using var client = new HttpClient();
            var content = await client.GetStringAsync($"https://localhost:7009/Employee/GetTypeOfEmpl{id}");

            if(content != null)
            {

                int employeeType = Convert.ToInt32(content);
                return employeeType;
            }
            return null;


        }
        public string EmployeeTypeString(int? employeetype)
        {
            return ((EmployeeValueEnum)employeetype).ToString();
        }*/
    }
}
