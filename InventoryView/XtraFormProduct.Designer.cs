namespace InventoryView
{
    partial class XtraFormProduct
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditId = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.textEditName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEditPrice = new DevExpress.XtraEditors.TextEdit();
            this.textEditQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.textEditDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.textEditDateStored = new DevExpress.XtraEditors.TextEdit();
            this.textEditCategoryId = new DevExpress.XtraEditors.LookUpEdit();
            this.textEditVendorId = new DevExpress.XtraEditors.LookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrice.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDateStored.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCategoryId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditVendorId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Id:";
            // 
            // textEditId
            // 
            this.textEditId.EditValue = "0";
            this.textEditId.Location = new System.Drawing.Point(83, 21);
            this.textEditId.Name = "textEditId";
            this.textEditId.Properties.ReadOnly = true;
            this.textEditId.Size = new System.Drawing.Size(189, 20);
            this.textEditId.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Name:";
            // 
            // textEditName
            // 
            this.textEditName.Location = new System.Drawing.Point(83, 56);
            this.textEditName.Name = "textEditName";
            this.textEditName.Size = new System.Drawing.Size(189, 20);
            this.textEditName.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 93);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(27, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Price:";
            // 
            // textEditPrice
            // 
            this.textEditPrice.EditValue = "0";
            this.textEditPrice.Location = new System.Drawing.Point(83, 90);
            this.textEditPrice.Name = "textEditPrice";
            this.textEditPrice.Properties.Mask.EditMask = "c";
            this.textEditPrice.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditPrice.Size = new System.Drawing.Size(189, 20);
            this.textEditPrice.TabIndex = 5;
            // 
            // textEditQuantity
            // 
            this.textEditQuantity.EditValue = "0";
            this.textEditQuantity.Location = new System.Drawing.Point(83, 126);
            this.textEditQuantity.Name = "textEditQuantity";
            this.textEditQuantity.Properties.Mask.EditMask = "d";
            this.textEditQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditQuantity.Size = new System.Drawing.Size(189, 20);
            this.textEditQuantity.TabIndex = 6;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(12, 129);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Quantity:";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(10, 164);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(38, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Vendor:";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 195);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(49, 13);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Category:";
            // 
            // textEditDescription
            // 
            this.textEditDescription.Location = new System.Drawing.Point(83, 229);
            this.textEditDescription.Name = "textEditDescription";
            this.textEditDescription.Size = new System.Drawing.Size(189, 20);
            this.textEditDescription.TabIndex = 12;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 232);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(57, 13);
            this.labelControl7.TabIndex = 13;
            this.labelControl7.Text = "Description:";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(197, 286);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 14;
            this.simpleButton1.Text = "Save";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(12, 263);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(62, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Date Stored:";
            // 
            // textEditDateStored
            // 
            this.textEditDateStored.Location = new System.Drawing.Point(83, 260);
            this.textEditDateStored.Name = "textEditDateStored";
            this.textEditDateStored.Properties.ReadOnly = true;
            this.textEditDateStored.Size = new System.Drawing.Size(189, 20);
            this.textEditDateStored.TabIndex = 15;
            // 
            // textEditCategoryId
            // 
            this.textEditCategoryId.Location = new System.Drawing.Point(83, 192);
            this.textEditCategoryId.Name = "textEditCategoryId";
            this.textEditCategoryId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditCategoryId.Size = new System.Drawing.Size(189, 20);
            this.textEditCategoryId.TabIndex = 17;
            // 
            // textEditVendorId
            // 
            this.textEditVendorId.Location = new System.Drawing.Point(83, 161);
            this.textEditVendorId.Name = "textEditVendorId";
            this.textEditVendorId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.textEditVendorId.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.textEditVendorId.Size = new System.Drawing.Size(189, 20);
            this.textEditVendorId.TabIndex = 18;
            // 
            // XtraFormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 319);
            this.Controls.Add(this.textEditVendorId);
            this.Controls.Add(this.textEditCategoryId);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.textEditDateStored);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.textEditDescription);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.textEditQuantity);
            this.Controls.Add(this.textEditPrice);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEditName);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEditId);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormProduct";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product";
            ((System.ComponentModel.ISupportInitialize)(this.textEditId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPrice.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditDateStored.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCategoryId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditVendorId.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditId;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit textEditName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit textEditPrice;
        private DevExpress.XtraEditors.TextEdit textEditQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit textEditDescription;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.TextEdit textEditDateStored;
        private DevExpress.XtraEditors.LookUpEdit textEditCategoryId;
        private DevExpress.XtraEditors.LookUpEdit textEditVendorId;
    }
}