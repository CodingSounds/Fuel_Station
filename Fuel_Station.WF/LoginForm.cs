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
            var guidEMployee = await GetID(txtUsername.Text, txtPassword.Text);

            var employee = await GetEmployee(guidEMployee);

            Authentification( guidEMployee, employee);



        }

        private async Task<Guid?> GetID(string password, string username)
        {
            
            using var client = new HttpClient();
            var id= await client.GetStringAsync($"https://localhost:7009/Employee/GetUser{username}/{password}");
            if (id != "" && id.Substring(0,9)!= "<!DOCTYPE")//fix it
            {
                var t = id.Replace('"', ' ');
                Guid idGuid = Guid.Parse(t);
                return idGuid;
            }
            return null;
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       private async Task<int?> GetEmployee(Guid? guidEMployee)
        {
            

           

            if (guidEMployee != null)
            {
                var employee = await handler.GetEmployee(guidEMployee.Value);

                return employee.Value;
            }
            return null;
        }

        private void Authentification(Guid? guidEMployee, int? employee)
        {
            if (handler.EmployeeTypeString(employee) != "None"&& guidEMployee!=null)
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
    }
}
