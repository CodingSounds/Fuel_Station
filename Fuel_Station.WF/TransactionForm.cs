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
    public partial class TransactionForm : Form
    {
        public Guid UserID { get; set; }
        Handlers handlers = new();
        List<TransactionViewModel> transactionList = new();
        public TransactionForm()
        {
            InitializeComponent();

            EditabilityOfGrids(false);


        }

        private async void TransactionForm_Load(object sender, EventArgs e)
        {
            await LoadTransactions();
            SetDataBindings();
        }

        private async Task LoadTransactions()
        {
            transactionList= await handlers.LoadingTransactionList(UserID);
            gridViewTransaction.RefreshData();

        }



        private void SetDataBindings()
        {

            BindingSource bsTransaction = new BindingSource();
            bsTransaction.DataSource = transactionList;
            gridTransaction.DataSource = bsTransaction;

     
         





        }
        private void EditabilityOfGrids(bool i)
        {
            gridViewTransaction.OptionsBehavior.Editable = i;
            

            gridViewTransaction.OptionsView.ShowDetailButtons = false;
          

            gridViewTransactionLines.OptionsBehavior.Editable = i;
        }

        private void gridViewTransaction_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int index = gridViewTransaction.FocusedRowHandle;
            BindingSource bsLines = new BindingSource();
            var transactionView =gridViewTransaction.GetRow(index) as TransactionViewModel;
            bsLines.DataSource = transactionView.TransactionLinesList;
            gridTransactionLines.DataSource = bsLines;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            NewTransactionForm f = new();
            f.UserID = UserID;
            f.ShowDialog();
            await LoadTransactions();
            

        }

        /* private void gridTransaction_Click(object sender, EventArgs e)
          {

          }*/
    }
}
