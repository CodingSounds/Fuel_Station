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
    public partial class TransactionForm : Form
    {
        public Guid UserID { get; set; }
        Handlers handlers = new();
        public TransactionForm()
        {
            InitializeComponent();
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {

        }

        private async void LoadTransactions()
        {

        }



        private void SetDataBindings()
        {

            BindingSource bsTransaction = new BindingSource();
           // bsTransaction.DataSource = customerList;
            //gridTransaction.DataSource = bsCustomers;



        }
    }
}
