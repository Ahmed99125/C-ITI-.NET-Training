namespace EntityFramework
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            FirstName = new TextBox();
            saveBtn = new Button();
            dgbCustomer = new DataGridView();
            dgID = new DataGridViewTextBoxColumn();
            dgFirstName = new DataGridViewTextBoxColumn();
            dgLastName = new DataGridViewTextBoxColumn();
            dgAddress = new DataGridViewTextBoxColumn();
            LastName = new TextBox();
            label2 = new Label();
            Address = new TextBox();
            label3 = new Label();
            deleteBtn = new Button();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgbCustomer).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(38, 34);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 0;
            label1.Text = "FirstName";
            label1.Click += label1_Click;
            // 
            // FirstName
            // 
            FirstName.Location = new Point(122, 31);
            FirstName.Name = "FirstName";
            FirstName.Size = new Size(285, 27);
            FirstName.TabIndex = 1;
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(38, 214);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 29);
            saveBtn.TabIndex = 2;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // dgbCustomer
            // 
            dgbCustomer.AllowUserToDeleteRows = false;
            dgbCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgbCustomer.Columns.AddRange(new DataGridViewColumn[] { dgID, dgFirstName, dgLastName, dgAddress });
            dgbCustomer.Location = new Point(440, 9);
            dgbCustomer.Name = "dgbCustomer";
            dgbCustomer.ReadOnly = true;
            dgbCustomer.RowHeadersWidth = 51;
            dgbCustomer.Size = new Size(570, 526);
            dgbCustomer.TabIndex = 3;
            dgbCustomer.Click += dgbCustomer_Click;
            // 
            // dgID
            // 
            dgID.DataPropertyName = "ID";
            dgID.HeaderText = "CustomerID";
            dgID.MinimumWidth = 6;
            dgID.Name = "dgID";
            dgID.ReadOnly = true;
            dgID.Visible = false;
            dgID.Width = 125;
            // 
            // dgFirstName
            // 
            dgFirstName.DataPropertyName = "FirstName";
            dgFirstName.HeaderText = "First Name";
            dgFirstName.MinimumWidth = 6;
            dgFirstName.Name = "dgFirstName";
            dgFirstName.ReadOnly = true;
            dgFirstName.Width = 125;
            // 
            // dgLastName
            // 
            dgLastName.DataPropertyName = "LastName";
            dgLastName.HeaderText = "Last Name";
            dgLastName.MinimumWidth = 6;
            dgLastName.Name = "dgLastName";
            dgLastName.ReadOnly = true;
            dgLastName.Width = 125;
            // 
            // dgAddress
            // 
            dgAddress.DataPropertyName = "Address";
            dgAddress.HeaderText = "Address";
            dgAddress.MinimumWidth = 6;
            dgAddress.Name = "dgAddress";
            dgAddress.ReadOnly = true;
            dgAddress.Width = 125;
            // 
            // LastName
            // 
            LastName.Location = new Point(122, 82);
            LastName.Name = "LastName";
            LastName.Size = new Size(285, 27);
            LastName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(38, 85);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 4;
            label2.Text = "LastName";
            // 
            // Address
            // 
            Address.Location = new Point(122, 131);
            Address.Name = "Address";
            Address.Size = new Size(285, 27);
            Address.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(38, 134);
            label3.Name = "label3";
            label3.Size = new Size(62, 20);
            label3.TabIndex = 6;
            label3.Text = "Address";
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(178, 214);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(94, 29);
            deleteBtn.TabIndex = 8;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(313, 214);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 9;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 547);
            Controls.Add(cancelBtn);
            Controls.Add(deleteBtn);
            Controls.Add(Address);
            Controls.Add(label3);
            Controls.Add(LastName);
            Controls.Add(label2);
            Controls.Add(dgbCustomer);
            Controls.Add(saveBtn);
            Controls.Add(FirstName);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgbCustomer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox FirstName;
        private Button saveBtn;
        private DataGridView dgbCustomer;
        private TextBox LastName;
        private Label label2;
        private TextBox Address;
        private Label label3;
        private Button deleteBtn;
        private Button cancelBtn;
        private DataGridViewTextBoxColumn dgID;
        private DataGridViewTextBoxColumn dgFirstName;
        private DataGridViewTextBoxColumn dgLastName;
        private DataGridViewTextBoxColumn dgAddress;
    }
}
