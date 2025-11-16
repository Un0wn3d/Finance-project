namespace BudgetPlanningApp.Forms.Systems {
  partial class LoginForm {
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
            this.RegisterLink = new System.Windows.Forms.LinkLabel();
            this.UserNameCBox = new System.Windows.Forms.ComboBox();
            this.UserPasswordValidationLbl = new System.Windows.Forms.Label();
            this.UserNameValiadtionLbl = new System.Windows.Forms.Label();
            this.SubmitBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.UserPasswordTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RegisterLink
            // 
            this.RegisterLink.ActiveLinkColor = System.Drawing.Color.Red;
            this.RegisterLink.AutoSize = true;
            this.RegisterLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterLink.LinkColor = System.Drawing.Color.Green;
            this.RegisterLink.Location = new System.Drawing.Point(8, 93);
            this.RegisterLink.Name = "RegisterLink";
            this.RegisterLink.Size = new System.Drawing.Size(90, 16);
            this.RegisterLink.TabIndex = 59;
            this.RegisterLink.TabStop = true;
            this.RegisterLink.Text = "Реєстрація";
            this.RegisterLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RegisterLink_LinkClicked);
            // 
            // UserNameCBox
            // 
            this.UserNameCBox.BackColor = System.Drawing.Color.Ivory;
            this.UserNameCBox.FormattingEnabled = true;
            this.UserNameCBox.Location = new System.Drawing.Point(86, 30);
            this.UserNameCBox.Name = "UserNameCBox";
            this.UserNameCBox.Size = new System.Drawing.Size(155, 21);
            this.UserNameCBox.TabIndex = 58;
            // 
            // UserPasswordValidationLbl
            // 
            this.UserPasswordValidationLbl.AutoSize = true;
            this.UserPasswordValidationLbl.ForeColor = System.Drawing.Color.Red;
            this.UserPasswordValidationLbl.Location = new System.Drawing.Point(69, 66);
            this.UserPasswordValidationLbl.Name = "UserPasswordValidationLbl";
            this.UserPasswordValidationLbl.Size = new System.Drawing.Size(11, 13);
            this.UserPasswordValidationLbl.TabIndex = 57;
            this.UserPasswordValidationLbl.Text = "*";
            // 
            // UserNameValiadtionLbl
            // 
            this.UserNameValiadtionLbl.AutoSize = true;
            this.UserNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
            this.UserNameValiadtionLbl.Location = new System.Drawing.Point(69, 33);
            this.UserNameValiadtionLbl.Name = "UserNameValiadtionLbl";
            this.UserNameValiadtionLbl.Size = new System.Drawing.Size(11, 13);
            this.UserNameValiadtionLbl.TabIndex = 56;
            this.UserNameValiadtionLbl.Text = "*";
            // 
            // SubmitBtn
            // 
            this.SubmitBtn.BackColor = System.Drawing.Color.Lime;
            this.SubmitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitBtn.ForeColor = System.Drawing.Color.Black;
            this.SubmitBtn.Location = new System.Drawing.Point(156, 89);
            this.SubmitBtn.Name = "SubmitBtn";
            this.SubmitBtn.Size = new System.Drawing.Size(85, 25);
            this.SubmitBtn.TabIndex = 55;
            this.SubmitBtn.Text = "Увійти";
            this.SubmitBtn.UseVisualStyleBackColor = false;
            this.SubmitBtn.Click += new System.EventHandler(this.SubmitBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 54;
            this.label3.Text = "Логін";
            // 
            // UserPasswordTBox
            // 
            this.UserPasswordTBox.BackColor = System.Drawing.Color.Ivory;
            this.UserPasswordTBox.Location = new System.Drawing.Point(86, 63);
            this.UserPasswordTBox.Name = "UserPasswordTBox";
            this.UserPasswordTBox.Size = new System.Drawing.Size(155, 20);
            this.UserPasswordTBox.TabIndex = 53;
            this.UserPasswordTBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(8, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "Пароль";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RegisterLink);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.UserNameCBox);
            this.groupBox1.Controls.Add(this.UserPasswordTBox);
            this.groupBox1.Controls.Add(this.UserPasswordValidationLbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.UserNameValiadtionLbl);
            this.groupBox1.Controls.Add(this.SubmitBtn);
            this.groupBox1.Location = new System.Drawing.Point(8, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(249, 125);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 137);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(285, 176);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(285, 176);
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизація";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.LinkLabel RegisterLink;
    private System.Windows.Forms.ComboBox UserNameCBox;
    private System.Windows.Forms.Label UserPasswordValidationLbl;
    private System.Windows.Forms.Label UserNameValiadtionLbl;
    private System.Windows.Forms.Button SubmitBtn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox UserPasswordTBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.GroupBox groupBox1;
  }
}