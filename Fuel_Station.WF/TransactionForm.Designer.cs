namespace Fuel_Station.WF
{
    partial class TransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridTransaction = new DevExpress.XtraGrid.GridControl();
            this.gridViewTransaction = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmployeeType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCustomer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridTransactionLines = new DevExpress.XtraGrid.GridControl();
            this.gridViewTransactionLines = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumnItem = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridNetValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDiscountPercent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDiscountValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTotalValue = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTransactionLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridTransactionLines);
            this.layoutControl1.Controls.Add(this.gridTransaction);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridTransaction
            // 
            this.gridTransaction.Location = new System.Drawing.Point(12, 12);
            this.gridTransaction.MainView = this.gridViewTransaction;
            this.gridTransaction.Name = "gridTransaction";
            this.gridTransaction.Size = new System.Drawing.Size(776, 223);
            this.gridTransaction.TabIndex = 4;
            this.gridTransaction.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTransaction});
            // 
            // gridViewTransaction
            // 
            this.gridViewTransaction.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDate,
            this.gridColumnEmployeeType,
            this.gridColumnCustomer});
            this.gridViewTransaction.GridControl = this.gridTransaction;
            this.gridViewTransaction.Name = "gridViewTransaction";
            this.gridViewTransaction.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewTransaction_FocusedRowChanged);
            // 
            // gridColumnDate
            // 
            this.gridColumnDate.Caption = "Date";
            this.gridColumnDate.FieldName = "Date";
            this.gridColumnDate.MinWidth = 25;
            this.gridColumnDate.Name = "gridColumnDate";
            this.gridColumnDate.Visible = true;
            this.gridColumnDate.VisibleIndex = 0;
            this.gridColumnDate.Width = 94;
            // 
            // gridColumnEmployeeType
            // 
            this.gridColumnEmployeeType.Caption = "Employee Type";
            this.gridColumnEmployeeType.FieldName = "EmployeeType";
            this.gridColumnEmployeeType.MinWidth = 25;
            this.gridColumnEmployeeType.Name = "gridColumnEmployeeType";
            this.gridColumnEmployeeType.Visible = true;
            this.gridColumnEmployeeType.VisibleIndex = 1;
            this.gridColumnEmployeeType.Width = 94;
            // 
            // gridColumnCustomer
            // 
            this.gridColumnCustomer.Caption = "Customer Card Number";
            this.gridColumnCustomer.FieldName = "CardNumber";
            this.gridColumnCustomer.MinWidth = 25;
            this.gridColumnCustomer.Name = "gridColumnCustomer";
            this.gridColumnCustomer.Visible = true;
            this.gridColumnCustomer.VisibleIndex = 2;
            this.gridColumnCustomer.Width = 94;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridTransaction;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 227);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridTransactionLines
            // 
            this.gridTransactionLines.Location = new System.Drawing.Point(12, 239);
            this.gridTransactionLines.MainView = this.gridViewTransactionLines;
            this.gridTransactionLines.Name = "gridTransactionLines";
            this.gridTransactionLines.Size = new System.Drawing.Size(776, 199);
            this.gridTransactionLines.TabIndex = 5;
            this.gridTransactionLines.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTransactionLines});
            // 
            // gridViewTransactionLines
            // 
            this.gridViewTransactionLines.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnItem,
            this.gridColumnQuantity,
            this.gridColumnItemPrice,
            this.gridNetValue,
            this.gridDiscountPercent,
            this.gridColumnDiscountValue,
            this.gridColumnTotalValue});
            this.gridViewTransactionLines.GridControl = this.gridTransactionLines;
            this.gridViewTransactionLines.Name = "gridViewTransactionLines";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridTransactionLines;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 227);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(780, 203);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // gridColumnItem
            // 
            this.gridColumnItem.Caption = "Item";
            this.gridColumnItem.FieldName = "Item";
            this.gridColumnItem.MinWidth = 25;
            this.gridColumnItem.Name = "gridColumnItem";
            this.gridColumnItem.Visible = true;
            this.gridColumnItem.VisibleIndex = 0;
            this.gridColumnItem.Width = 94;
            // 
            // gridColumnQuantity
            // 
            this.gridColumnQuantity.Caption = "Quantity";
            this.gridColumnQuantity.FieldName = "Quantity";
            this.gridColumnQuantity.MinWidth = 25;
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 1;
            this.gridColumnQuantity.Width = 94;
            // 
            // gridColumnItemPrice
            // 
            this.gridColumnItemPrice.Caption = "ItemPrice";
            this.gridColumnItemPrice.FieldName = "Item Price";
            this.gridColumnItemPrice.MinWidth = 25;
            this.gridColumnItemPrice.Name = "gridColumnItemPrice";
            this.gridColumnItemPrice.Visible = true;
            this.gridColumnItemPrice.VisibleIndex = 2;
            this.gridColumnItemPrice.Width = 94;
            // 
            // gridNetValue
            // 
            this.gridNetValue.Caption = "Net Value";
            this.gridNetValue.FieldName = "NetValue";
            this.gridNetValue.MinWidth = 25;
            this.gridNetValue.Name = "gridNetValue";
            this.gridNetValue.Visible = true;
            this.gridNetValue.VisibleIndex = 3;
            this.gridNetValue.Width = 94;
            // 
            // gridDiscountPercent
            // 
            this.gridDiscountPercent.Caption = "Discount Percent";
            this.gridDiscountPercent.FieldName = "DiscountPercent";
            this.gridDiscountPercent.MinWidth = 25;
            this.gridDiscountPercent.Name = "gridDiscountPercent";
            this.gridDiscountPercent.Visible = true;
            this.gridDiscountPercent.VisibleIndex = 4;
            this.gridDiscountPercent.Width = 94;
            // 
            // gridColumnDiscountValue
            // 
            this.gridColumnDiscountValue.Caption = "Discount Value";
            this.gridColumnDiscountValue.FieldName = "DiscountValue";
            this.gridColumnDiscountValue.MinWidth = 25;
            this.gridColumnDiscountValue.Name = "gridColumnDiscountValue";
            this.gridColumnDiscountValue.Visible = true;
            this.gridColumnDiscountValue.VisibleIndex = 5;
            this.gridColumnDiscountValue.Width = 94;
            // 
            // gridColumnTotalValue
            // 
            this.gridColumnTotalValue.Caption = "Total Value";
            this.gridColumnTotalValue.FieldName = "TotalValue";
            this.gridColumnTotalValue.MinWidth = 25;
            this.gridColumnTotalValue.Name = "gridColumnTotalValue";
            this.gridColumnTotalValue.Visible = true;
            this.gridColumnTotalValue.VisibleIndex = 6;
            this.gridColumnTotalValue.Width = 94;
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "TransactionForm";
            this.Text = "TransactionForm";
            this.Load += new System.EventHandler(this.TransactionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTransactionLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridTransaction;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTransaction;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmployeeType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCustomer;
        private DevExpress.XtraGrid.GridControl gridTransactionLines;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTransactionLines;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItem;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridNetValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridDiscountPercent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDiscountValue;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTotalValue;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}