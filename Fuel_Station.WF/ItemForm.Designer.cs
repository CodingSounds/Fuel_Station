namespace Fuel_Station.WF
{
    partial class ItemForm
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
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.gridItemList = new DevExpress.XtraGrid.GridControl();
            this.gridViewItems = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnItemType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCost = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridItemList);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(800, 450);
            this.Root.TextVisible = false;
            // 
            // gridItemList
            // 
            this.gridItemList.Location = new System.Drawing.Point(12, 12);
            this.gridItemList.MainView = this.gridViewItems;
            this.gridItemList.Name = "gridItemList";
            this.gridItemList.Size = new System.Drawing.Size(776, 426);
            this.gridItemList.TabIndex = 4;
            this.gridItemList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewItems});
            // 
            // gridViewItems
            // 
            this.gridViewItems.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCode,
            this.gridColumnDescription,
            this.gridColumnItemType,
            this.gridColumnPrice,
            this.gridColumnCost});
            this.gridViewItems.GridControl = this.gridItemList;
            this.gridViewItems.Name = "gridViewItems";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridItemList;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(780, 430);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Code";
            this.gridColumnCode.FieldName = "Code";
            this.gridColumnCode.MinWidth = 25;
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 0;
            this.gridColumnCode.Width = 94;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.MinWidth = 25;
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 1;
            this.gridColumnDescription.Width = 94;
            // 
            // gridColumnItemType
            // 
            this.gridColumnItemType.Caption = "Type";
            this.gridColumnItemType.FieldName = "ItemType";
            this.gridColumnItemType.MinWidth = 25;
            this.gridColumnItemType.Name = "gridColumnItemType";
            this.gridColumnItemType.Visible = true;
            this.gridColumnItemType.VisibleIndex = 2;
            this.gridColumnItemType.Width = 94;
            // 
            // gridColumnPrice
            // 
            this.gridColumnPrice.Caption = "Price";
            this.gridColumnPrice.FieldName = "Price";
            this.gridColumnPrice.MinWidth = 25;
            this.gridColumnPrice.Name = "gridColumnPrice";
            this.gridColumnPrice.Visible = true;
            this.gridColumnPrice.VisibleIndex = 3;
            this.gridColumnPrice.Width = 94;
            // 
            // gridColumnCost
            // 
            this.gridColumnCost.Caption = "Cost";
            this.gridColumnCost.FieldName = "Cost";
            this.gridColumnCost.MinWidth = 25;
            this.gridColumnCost.Name = "gridColumnCost";
            this.gridColumnCost.Visible = true;
            this.gridColumnCost.VisibleIndex = 4;
            this.gridColumnCost.Width = 94;
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "ItemForm";
            this.Text = "Item";
            this.Load += new System.EventHandler(this.ItemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridItemList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridItemList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewItems;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnItemType;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCost;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}