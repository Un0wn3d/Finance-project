namespace BudgetPlanningApp.Forms.Controls {
  partial class UpdateTransaction {
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
      this.AddGBox = new System.Windows.Forms.GroupBox();
      this.TransactionDateDTP = new System.Windows.Forms.DateTimePicker();
      this.AddressLbl = new System.Windows.Forms.Label();
      this.TransactionTypeCBox = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.BudgetItemValiadtionLbl = new System.Windows.Forms.Label();
      this.BudgetItemCBox = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.AmountTBox = new System.Windows.Forms.TextBox();
      this.AmountValiadtionLbl = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.DescriptionTBox = new System.Windows.Forms.TextBox();
      this.DescriptionLbl = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.DeleteBtn = new System.Windows.Forms.Button();
      this.SaveBtn = new System.Windows.Forms.Button();
      this.AddGBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.ExitBtn);
      this.AddGBox.Controls.Add(this.DeleteBtn);
      this.AddGBox.Controls.Add(this.SaveBtn);
      this.AddGBox.Controls.Add(this.TransactionDateDTP);
      this.AddGBox.Controls.Add(this.AddressLbl);
      this.AddGBox.Controls.Add(this.TransactionTypeCBox);
      this.AddGBox.Controls.Add(this.label5);
      this.AddGBox.Controls.Add(this.BudgetItemValiadtionLbl);
      this.AddGBox.Controls.Add(this.BudgetItemCBox);
      this.AddGBox.Controls.Add(this.label3);
      this.AddGBox.Controls.Add(this.AmountTBox);
      this.AddGBox.Controls.Add(this.AmountValiadtionLbl);
      this.AddGBox.Controls.Add(this.label2);
      this.AddGBox.Controls.Add(this.DescriptionTBox);
      this.AddGBox.Controls.Add(this.DescriptionLbl);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(6, 4);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(338, 366);
      this.AddGBox.TabIndex = 1;
      this.AddGBox.TabStop = false;
      // 
      // TransactionDateDTP
      // 
      this.TransactionDateDTP.Location = new System.Drawing.Point(183, 131);
      this.TransactionDateDTP.Name = "TransactionDateDTP";
      this.TransactionDateDTP.Size = new System.Drawing.Size(140, 22);
      this.TransactionDateDTP.TabIndex = 5;
      // 
      // AddressLbl
      // 
      this.AddressLbl.AutoSize = true;
      this.AddressLbl.Location = new System.Drawing.Point(111, 136);
      this.AddressLbl.Name = "AddressLbl";
      this.AddressLbl.Size = new System.Drawing.Size(42, 16);
      this.AddressLbl.TabIndex = 111;
      this.AddressLbl.Text = "Дата:";
      // 
      // TransactionTypeCBox
      // 
      this.TransactionTypeCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.TransactionTypeCBox.FormattingEnabled = true;
      this.TransactionTypeCBox.Items.AddRange(new object[] {
            "Витрати",
            "Доходи"});
      this.TransactionTypeCBox.Location = new System.Drawing.Point(183, 101);
      this.TransactionTypeCBox.Name = "TransactionTypeCBox";
      this.TransactionTypeCBox.Size = new System.Drawing.Size(141, 24);
      this.TransactionTypeCBox.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(49, 104);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(106, 16);
      this.label5.TabIndex = 109;
      this.label5.Text = "Тип транзакції:";
      // 
      // BudgetItemValiadtionLbl
      // 
      this.BudgetItemValiadtionLbl.AutoSize = true;
      this.BudgetItemValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.BudgetItemValiadtionLbl.Location = new System.Drawing.Point(80, 17);
      this.BudgetItemValiadtionLbl.Name = "BudgetItemValiadtionLbl";
      this.BudgetItemValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.BudgetItemValiadtionLbl.TabIndex = 106;
      this.BudgetItemValiadtionLbl.Text = "*";
      // 
      // BudgetItemCBox
      // 
      this.BudgetItemCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.BudgetItemCBox.Enabled = false;
      this.BudgetItemCBox.FormattingEnabled = true;
      this.BudgetItemCBox.Location = new System.Drawing.Point(9, 36);
      this.BudgetItemCBox.Name = "BudgetItemCBox";
      this.BudgetItemCBox.Size = new System.Drawing.Size(319, 24);
      this.BudgetItemCBox.TabIndex = 2;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(6, 18);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 16);
      this.label3.TabIndex = 105;
      this.label3.Text = "Витрата:";
      // 
      // AmountTBox
      // 
      this.AmountTBox.BackColor = System.Drawing.Color.Ivory;
      this.AmountTBox.Location = new System.Drawing.Point(183, 73);
      this.AmountTBox.MaxLength = 10;
      this.AmountTBox.Name = "AmountTBox";
      this.AmountTBox.Size = new System.Drawing.Size(141, 22);
      this.AmountTBox.TabIndex = 3;
      this.AmountTBox.Text = "0.00";
      this.AmountTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // AmountValiadtionLbl
      // 
      this.AmountValiadtionLbl.AutoSize = true;
      this.AmountValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.AmountValiadtionLbl.Location = new System.Drawing.Point(162, 76);
      this.AmountValiadtionLbl.Name = "AmountValiadtionLbl";
      this.AmountValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.AmountValiadtionLbl.TabIndex = 25;
      this.AmountValiadtionLbl.Text = "*";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(111, 73);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 16);
      this.label2.TabIndex = 24;
      this.label2.Text = "Сума:";
      // 
      // DescriptionTBox
      // 
      this.DescriptionTBox.BackColor = System.Drawing.Color.Ivory;
      this.DescriptionTBox.Location = new System.Drawing.Point(5, 171);
      this.DescriptionTBox.MaxLength = 1500;
      this.DescriptionTBox.Multiline = true;
      this.DescriptionTBox.Name = "DescriptionTBox";
      this.DescriptionTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.DescriptionTBox.Size = new System.Drawing.Size(319, 154);
      this.DescriptionTBox.TabIndex = 6;
      // 
      // DescriptionLbl
      // 
      this.DescriptionLbl.AutoSize = true;
      this.DescriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.DescriptionLbl.Location = new System.Drawing.Point(3, 152);
      this.DescriptionLbl.Name = "DescriptionLbl";
      this.DescriptionLbl.Size = new System.Drawing.Size(43, 16);
      this.DescriptionLbl.TabIndex = 1;
      this.DescriptionLbl.Text = "Опис:";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.Lime;
      this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitBtn.Location = new System.Drawing.Point(232, 331);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(91, 25);
      this.ExitBtn.TabIndex = 114;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // DeleteBtn
      // 
      this.DeleteBtn.BackColor = System.Drawing.Color.Lime;
      this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DeleteBtn.Location = new System.Drawing.Point(128, 331);
      this.DeleteBtn.Name = "DeleteBtn";
      this.DeleteBtn.Size = new System.Drawing.Size(91, 25);
      this.DeleteBtn.TabIndex = 113;
      this.DeleteBtn.Text = "Видалити";
      this.DeleteBtn.UseVisualStyleBackColor = false;
      this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
      // 
      // SaveBtn
      // 
      this.SaveBtn.BackColor = System.Drawing.Color.Lime;
      this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SaveBtn.Location = new System.Drawing.Point(24, 331);
      this.SaveBtn.Name = "SaveBtn";
      this.SaveBtn.Size = new System.Drawing.Size(92, 25);
      this.SaveBtn.TabIndex = 112;
      this.SaveBtn.Text = "Зберегти";
      this.SaveBtn.UseVisualStyleBackColor = false;
      this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
      // 
      // UpdateTransaction
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(352, 374);
      this.Controls.Add(this.AddGBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UpdateTransaction";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Редагувати";
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.DateTimePicker TransactionDateDTP;
    private System.Windows.Forms.Label AddressLbl;
    private System.Windows.Forms.ComboBox TransactionTypeCBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label BudgetItemValiadtionLbl;
    private System.Windows.Forms.ComboBox BudgetItemCBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox AmountTBox;
    private System.Windows.Forms.Label AmountValiadtionLbl;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox DescriptionTBox;
    private System.Windows.Forms.Label DescriptionLbl;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button DeleteBtn;
    private System.Windows.Forms.Button SaveBtn;
  }
}