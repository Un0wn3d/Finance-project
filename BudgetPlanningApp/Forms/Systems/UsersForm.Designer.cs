namespace BudgetPlanningApp.Forms.Systems {
  partial class UsersForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      this.PasswordAndRePasswordDontMatchLbl = new System.Windows.Forms.Label();
      this.FirstNameLbl = new System.Windows.Forms.Label();
      this.AddBtn = new System.Windows.Forms.Button();
      this.FirstNameTBox = new System.Windows.Forms.TextBox();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.FirstNameValiadtionLbl = new System.Windows.Forms.Label();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.LastNameValiadtionLbl = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.LastNameTBox = new System.Windows.Forms.TextBox();
      this.UserLoginValidationLbl = new System.Windows.Forms.Label();
      this.LastNameLbl = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.PasswordTbx = new System.Windows.Forms.TextBox();
      this.DescriptionTbx = new System.Windows.Forms.TextBox();
      this.RePasswordValidationLbl = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.RolesCBox = new System.Windows.Forms.ComboBox();
      this.label6 = new System.Windows.Forms.Label();
      this.RePasswordTbx = new System.Windows.Forms.TextBox();
      this.PasswordValidationLbl = new System.Windows.Forms.Label();
      this.UserLoginTbx = new System.Windows.Forms.TextBox();
      this.UsersGridView = new System.Windows.Forms.DataGridView();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // PasswordAndRePasswordDontMatchLbl
      // 
      this.PasswordAndRePasswordDontMatchLbl.AutoSize = true;
      this.PasswordAndRePasswordDontMatchLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.PasswordAndRePasswordDontMatchLbl.ForeColor = System.Drawing.Color.Red;
      this.PasswordAndRePasswordDontMatchLbl.Location = new System.Drawing.Point(148, 223);
      this.PasswordAndRePasswordDontMatchLbl.Name = "PasswordAndRePasswordDontMatchLbl";
      this.PasswordAndRePasswordDontMatchLbl.Size = new System.Drawing.Size(184, 12);
      this.PasswordAndRePasswordDontMatchLbl.TabIndex = 83;
      this.PasswordAndRePasswordDontMatchLbl.Text = "Поля пароль і підтвердити не співпадають";
      this.PasswordAndRePasswordDontMatchLbl.Visible = false;
      // 
      // FirstNameLbl
      // 
      this.FirstNameLbl.AutoSize = true;
      this.FirstNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FirstNameLbl.ForeColor = System.Drawing.Color.Black;
      this.FirstNameLbl.Location = new System.Drawing.Point(67, 52);
      this.FirstNameLbl.Name = "FirstNameLbl";
      this.FirstNameLbl.Size = new System.Drawing.Size(32, 16);
      this.FirstNameLbl.TabIndex = 84;
      this.FirstNameLbl.Text = "Ім\'я:";
      // 
      // AddBtn
      // 
      this.AddBtn.BackColor = System.Drawing.Color.Lime;
      this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AddBtn.ForeColor = System.Drawing.Color.Black;
      this.AddBtn.Location = new System.Drawing.Point(67, 331);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(81, 25);
      this.AddBtn.TabIndex = 21;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // FirstNameTBox
      // 
      this.FirstNameTBox.BackColor = System.Drawing.Color.Ivory;
      this.FirstNameTBox.Location = new System.Drawing.Point(145, 49);
      this.FirstNameTBox.MaxLength = 200;
      this.FirstNameTBox.Name = "FirstNameTBox";
      this.FirstNameTBox.Size = new System.Drawing.Size(214, 22);
      this.FirstNameTBox.TabIndex = 3;
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.Lime;
      this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitBtn.ForeColor = System.Drawing.Color.Black;
      this.ExitBtn.Location = new System.Drawing.Point(278, 331);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(81, 25);
      this.ExitBtn.TabIndex = 23;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // FirstNameValiadtionLbl
      // 
      this.FirstNameValiadtionLbl.AutoSize = true;
      this.FirstNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.FirstNameValiadtionLbl.Location = new System.Drawing.Point(118, 52);
      this.FirstNameValiadtionLbl.Name = "FirstNameValiadtionLbl";
      this.FirstNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.FirstNameValiadtionLbl.TabIndex = 87;
      this.FirstNameValiadtionLbl.Text = "*";
      // 
      // ClearBtn
      // 
      this.ClearBtn.BackColor = System.Drawing.Color.Lime;
      this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ClearBtn.ForeColor = System.Drawing.Color.Black;
      this.ClearBtn.Location = new System.Drawing.Point(173, 331);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(81, 25);
      this.ClearBtn.TabIndex = 22;
      this.ClearBtn.Text = "Очистити";
      this.ClearBtn.UseVisualStyleBackColor = false;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // LastNameValiadtionLbl
      // 
      this.LastNameValiadtionLbl.AutoSize = true;
      this.LastNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.LastNameValiadtionLbl.Location = new System.Drawing.Point(118, 24);
      this.LastNameValiadtionLbl.Name = "LastNameValiadtionLbl";
      this.LastNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.LastNameValiadtionLbl.TabIndex = 86;
      this.LastNameValiadtionLbl.Text = "*";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.ForeColor = System.Drawing.Color.Black;
      this.label2.Location = new System.Drawing.Point(59, 239);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 16);
      this.label2.TabIndex = 74;
      this.label2.Text = "Логін:";
      // 
      // LastNameTBox
      // 
      this.LastNameTBox.BackColor = System.Drawing.Color.Ivory;
      this.LastNameTBox.Location = new System.Drawing.Point(145, 21);
      this.LastNameTBox.MaxLength = 200;
      this.LastNameTBox.Name = "LastNameTBox";
      this.LastNameTBox.Size = new System.Drawing.Size(214, 22);
      this.LastNameTBox.TabIndex = 2;
      // 
      // UserLoginValidationLbl
      // 
      this.UserLoginValidationLbl.AutoSize = true;
      this.UserLoginValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.UserLoginValidationLbl.Location = new System.Drawing.Point(120, 242);
      this.UserLoginValidationLbl.Name = "UserLoginValidationLbl";
      this.UserLoginValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.UserLoginValidationLbl.TabIndex = 79;
      this.UserLoginValidationLbl.Text = "*";
      // 
      // LastNameLbl
      // 
      this.LastNameLbl.AutoSize = true;
      this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LastNameLbl.ForeColor = System.Drawing.Color.Black;
      this.LastNameLbl.Location = new System.Drawing.Point(34, 24);
      this.LastNameLbl.Name = "LastNameLbl";
      this.LastNameLbl.Size = new System.Drawing.Size(72, 16);
      this.LastNameLbl.TabIndex = 85;
      this.LastNameLbl.Text = "Прізвище:";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.ForeColor = System.Drawing.Color.Black;
      this.label9.Location = new System.Drawing.Point(35, 74);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(43, 16);
      this.label9.TabIndex = 80;
      this.label9.Text = "Опис:";
      // 
      // PasswordTbx
      // 
      this.PasswordTbx.BackColor = System.Drawing.Color.Ivory;
      this.PasswordTbx.Location = new System.Drawing.Point(145, 273);
      this.PasswordTbx.MaxLength = 20;
      this.PasswordTbx.Name = "PasswordTbx";
      this.PasswordTbx.Size = new System.Drawing.Size(216, 22);
      this.PasswordTbx.TabIndex = 7;
      this.PasswordTbx.UseSystemPasswordChar = true;
      // 
      // DescriptionTbx
      // 
      this.DescriptionTbx.BackColor = System.Drawing.Color.Ivory;
      this.DescriptionTbx.Location = new System.Drawing.Point(38, 93);
      this.DescriptionTbx.MaxLength = 200;
      this.DescriptionTbx.Multiline = true;
      this.DescriptionTbx.Name = "DescriptionTbx";
      this.DescriptionTbx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.DescriptionTbx.Size = new System.Drawing.Size(321, 94);
      this.DescriptionTbx.TabIndex = 4;
      // 
      // RePasswordValidationLbl
      // 
      this.RePasswordValidationLbl.AutoSize = true;
      this.RePasswordValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.RePasswordValidationLbl.Location = new System.Drawing.Point(120, 303);
      this.RePasswordValidationLbl.Name = "RePasswordValidationLbl";
      this.RePasswordValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.RePasswordValidationLbl.TabIndex = 78;
      this.RePasswordValidationLbl.Text = "*";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.ForeColor = System.Drawing.Color.Black;
      this.label5.Location = new System.Drawing.Point(15, 303);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(93, 16);
      this.label5.TabIndex = 77;
      this.label5.Text = "Підтвердити:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.ForeColor = System.Drawing.Color.Black;
      this.label4.Location = new System.Drawing.Point(49, 276);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(59, 16);
      this.label4.TabIndex = 75;
      this.label4.Text = "Пароль:";
      // 
      // RolesCBox
      // 
      this.RolesCBox.BackColor = System.Drawing.Color.Aquamarine;
      this.RolesCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.RolesCBox.FormattingEnabled = true;
      this.RolesCBox.Location = new System.Drawing.Point(144, 193);
      this.RolesCBox.Name = "RolesCBox";
      this.RolesCBox.Size = new System.Drawing.Size(215, 24);
      this.RolesCBox.TabIndex = 5;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.ForeColor = System.Drawing.Color.Black;
      this.label6.Location = new System.Drawing.Point(66, 196);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(42, 16);
      this.label6.TabIndex = 81;
      this.label6.Text = "Роль:";
      // 
      // RePasswordTbx
      // 
      this.RePasswordTbx.BackColor = System.Drawing.Color.Ivory;
      this.RePasswordTbx.Location = new System.Drawing.Point(144, 300);
      this.RePasswordTbx.MaxLength = 20;
      this.RePasswordTbx.Name = "RePasswordTbx";
      this.RePasswordTbx.Size = new System.Drawing.Size(216, 22);
      this.RePasswordTbx.TabIndex = 8;
      this.RePasswordTbx.UseSystemPasswordChar = true;
      // 
      // PasswordValidationLbl
      // 
      this.PasswordValidationLbl.AutoSize = true;
      this.PasswordValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.PasswordValidationLbl.Location = new System.Drawing.Point(120, 276);
      this.PasswordValidationLbl.Name = "PasswordValidationLbl";
      this.PasswordValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.PasswordValidationLbl.TabIndex = 76;
      this.PasswordValidationLbl.Text = "*";
      // 
      // UserLoginTbx
      // 
      this.UserLoginTbx.BackColor = System.Drawing.Color.Ivory;
      this.UserLoginTbx.Location = new System.Drawing.Point(144, 239);
      this.UserLoginTbx.MaxLength = 50;
      this.UserLoginTbx.Name = "UserLoginTbx";
      this.UserLoginTbx.Size = new System.Drawing.Size(216, 22);
      this.UserLoginTbx.TabIndex = 6;
      // 
      // UsersGridView
      // 
      this.UsersGridView.AllowUserToAddRows = false;
      this.UsersGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.UsersGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
      this.UsersGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.UsersGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.UsersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.UsersGridView.GridColor = System.Drawing.Color.PaleGreen;
      this.UsersGridView.Location = new System.Drawing.Point(393, 0);
      this.UsersGridView.MultiSelect = false;
      this.UsersGridView.Name = "UsersGridView";
      this.UsersGridView.ReadOnly = true;
      this.UsersGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue;
      this.UsersGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
      this.UsersGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.UsersGridView.Size = new System.Drawing.Size(503, 391);
      this.UsersGridView.TabIndex = 80;
      this.UsersGridView.TabStop = false;
      this.UsersGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersGridView_CellClick);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.PasswordAndRePasswordDontMatchLbl);
      this.groupBox1.Controls.Add(this.FirstNameLbl);
      this.groupBox1.Controls.Add(this.AddBtn);
      this.groupBox1.Controls.Add(this.FirstNameTBox);
      this.groupBox1.Controls.Add(this.ExitBtn);
      this.groupBox1.Controls.Add(this.FirstNameValiadtionLbl);
      this.groupBox1.Controls.Add(this.ClearBtn);
      this.groupBox1.Controls.Add(this.LastNameValiadtionLbl);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.LastNameTBox);
      this.groupBox1.Controls.Add(this.UserLoginValidationLbl);
      this.groupBox1.Controls.Add(this.LastNameLbl);
      this.groupBox1.Controls.Add(this.label9);
      this.groupBox1.Controls.Add(this.PasswordTbx);
      this.groupBox1.Controls.Add(this.DescriptionTbx);
      this.groupBox1.Controls.Add(this.RePasswordValidationLbl);
      this.groupBox1.Controls.Add(this.label5);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.RolesCBox);
      this.groupBox1.Controls.Add(this.label6);
      this.groupBox1.Controls.Add(this.RePasswordTbx);
      this.groupBox1.Controls.Add(this.PasswordValidationLbl);
      this.groupBox1.Controls.Add(this.UserLoginTbx);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(9, 0);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(370, 368);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(393, 391);
      this.panel1.TabIndex = 79;
      // 
      // UsersForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(896, 391);
      this.Controls.Add(this.UsersGridView);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UsersForm";
      this.ShowIcon = false;
      this.Text = "Облікові записи";
      ((System.ComponentModel.ISupportInitialize)(this.UsersGridView)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label PasswordAndRePasswordDontMatchLbl;
    private System.Windows.Forms.Label FirstNameLbl;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.TextBox FirstNameTBox;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Label FirstNameValiadtionLbl;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.Label LastNameValiadtionLbl;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox LastNameTBox;
    private System.Windows.Forms.Label UserLoginValidationLbl;
    private System.Windows.Forms.Label LastNameLbl;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.TextBox PasswordTbx;
    private System.Windows.Forms.TextBox DescriptionTbx;
    private System.Windows.Forms.Label RePasswordValidationLbl;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox RolesCBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox RePasswordTbx;
    private System.Windows.Forms.Label PasswordValidationLbl;
    private System.Windows.Forms.TextBox UserLoginTbx;
    private System.Windows.Forms.DataGridView UsersGridView;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel panel1;
  }
}