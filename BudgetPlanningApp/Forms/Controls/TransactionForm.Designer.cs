namespace BudgetPlanningApp.Forms.Controls {
  partial class TransactionForm {
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.AddGBox = new System.Windows.Forms.GroupBox();
      this.TransactionDateDTP = new System.Windows.Forms.DateTimePicker();
      this.AddressLbl = new System.Windows.Forms.Label();
      this.TransactionTypeCBox = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.BudgetItemValiadtionLbl = new System.Windows.Forms.Label();
      this.BudgetItemCBox = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.BudgetCategoryValiadtionLbl = new System.Windows.Forms.Label();
      this.BudgetCategoryCBox = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.AmountTBox = new System.Windows.Forms.TextBox();
      this.AmountValiadtionLbl = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.AddBtn = new System.Windows.Forms.Button();
      this.DescriptionTBox = new System.Windows.Forms.TextBox();
      this.DescriptionLbl = new System.Windows.Forms.Label();
      this.AddPanel = new System.Windows.Forms.Panel();
      this.TransactionGridView = new System.Windows.Forms.DataGridView();
      this.AddGBox.SuspendLayout();
      this.AddPanel.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.TransactionGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.TransactionDateDTP);
      this.AddGBox.Controls.Add(this.AddressLbl);
      this.AddGBox.Controls.Add(this.TransactionTypeCBox);
      this.AddGBox.Controls.Add(this.label5);
      this.AddGBox.Controls.Add(this.BudgetItemValiadtionLbl);
      this.AddGBox.Controls.Add(this.BudgetItemCBox);
      this.AddGBox.Controls.Add(this.label3);
      this.AddGBox.Controls.Add(this.BudgetCategoryValiadtionLbl);
      this.AddGBox.Controls.Add(this.BudgetCategoryCBox);
      this.AddGBox.Controls.Add(this.label4);
      this.AddGBox.Controls.Add(this.AmountTBox);
      this.AddGBox.Controls.Add(this.AmountValiadtionLbl);
      this.AddGBox.Controls.Add(this.label2);
      this.AddGBox.Controls.Add(this.ExitBtn);
      this.AddGBox.Controls.Add(this.ClearBtn);
      this.AddGBox.Controls.Add(this.AddBtn);
      this.AddGBox.Controls.Add(this.DescriptionTBox);
      this.AddGBox.Controls.Add(this.DescriptionLbl);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(8, 2);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(338, 405);
      this.AddGBox.TabIndex = 0;
      this.AddGBox.TabStop = false;
      // 
      // TransactionDateDTP
      // 
      this.TransactionDateDTP.Location = new System.Drawing.Point(187, 172);
      this.TransactionDateDTP.Name = "TransactionDateDTP";
      this.TransactionDateDTP.Size = new System.Drawing.Size(140, 22);
      this.TransactionDateDTP.TabIndex = 5;
      // 
      // AddressLbl
      // 
      this.AddressLbl.AutoSize = true;
      this.AddressLbl.Location = new System.Drawing.Point(115, 177);
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
      this.TransactionTypeCBox.Location = new System.Drawing.Point(187, 142);
      this.TransactionTypeCBox.Name = "TransactionTypeCBox";
      this.TransactionTypeCBox.Size = new System.Drawing.Size(141, 24);
      this.TransactionTypeCBox.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(53, 145);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(106, 16);
      this.label5.TabIndex = 109;
      this.label5.Text = "Тип транзакції:";
      // 
      // BudgetItemValiadtionLbl
      // 
      this.BudgetItemValiadtionLbl.AutoSize = true;
      this.BudgetItemValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.BudgetItemValiadtionLbl.Location = new System.Drawing.Point(84, 58);
      this.BudgetItemValiadtionLbl.Name = "BudgetItemValiadtionLbl";
      this.BudgetItemValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.BudgetItemValiadtionLbl.TabIndex = 106;
      this.BudgetItemValiadtionLbl.Text = "*";
      // 
      // BudgetItemCBox
      // 
      this.BudgetItemCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.BudgetItemCBox.FormattingEnabled = true;
      this.BudgetItemCBox.Location = new System.Drawing.Point(13, 77);
      this.BudgetItemCBox.Name = "BudgetItemCBox";
      this.BudgetItemCBox.Size = new System.Drawing.Size(319, 24);
      this.BudgetItemCBox.TabIndex = 2;
      this.BudgetItemCBox.SelectedValueChanged += new System.EventHandler(this.BudgetItemCBox_SelectedValueChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(10, 59);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(65, 16);
      this.label3.TabIndex = 105;
      this.label3.Text = "Витрата:";
      // 
      // BudgetCategoryValiadtionLbl
      // 
      this.BudgetCategoryValiadtionLbl.AutoSize = true;
      this.BudgetCategoryValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.BudgetCategoryValiadtionLbl.Location = new System.Drawing.Point(84, 10);
      this.BudgetCategoryValiadtionLbl.Name = "BudgetCategoryValiadtionLbl";
      this.BudgetCategoryValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.BudgetCategoryValiadtionLbl.TabIndex = 103;
      this.BudgetCategoryValiadtionLbl.Text = "*";
      // 
      // BudgetCategoryCBox
      // 
      this.BudgetCategoryCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.BudgetCategoryCBox.FormattingEnabled = true;
      this.BudgetCategoryCBox.Location = new System.Drawing.Point(9, 29);
      this.BudgetCategoryCBox.Name = "BudgetCategoryCBox";
      this.BudgetCategoryCBox.Size = new System.Drawing.Size(319, 24);
      this.BudgetCategoryCBox.TabIndex = 1;
      this.BudgetCategoryCBox.SelectedValueChanged += new System.EventHandler(this.BudgetCategoryCBox_SelectedValueChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(6, 11);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 16);
      this.label4.TabIndex = 102;
      this.label4.Text = "Категорія:";
      // 
      // AmountTBox
      // 
      this.AmountTBox.BackColor = System.Drawing.Color.Ivory;
      this.AmountTBox.Location = new System.Drawing.Point(187, 114);
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
      this.AmountValiadtionLbl.Location = new System.Drawing.Point(166, 117);
      this.AmountValiadtionLbl.Name = "AmountValiadtionLbl";
      this.AmountValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.AmountValiadtionLbl.TabIndex = 25;
      this.AmountValiadtionLbl.Text = "*";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(115, 114);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(44, 16);
      this.label2.TabIndex = 24;
      this.label2.Text = "Сума:";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.Lime;
      this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitBtn.Location = new System.Drawing.Point(246, 372);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(81, 25);
      this.ExitBtn.TabIndex = 23;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // ClearBtn
      // 
      this.ClearBtn.BackColor = System.Drawing.Color.Lime;
      this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ClearBtn.Location = new System.Drawing.Point(144, 372);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(81, 25);
      this.ClearBtn.TabIndex = 22;
      this.ClearBtn.Text = "Очистити";
      this.ClearBtn.UseVisualStyleBackColor = false;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // AddBtn
      // 
      this.AddBtn.BackColor = System.Drawing.Color.Lime;
      this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AddBtn.Location = new System.Drawing.Point(42, 372);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(81, 25);
      this.AddBtn.TabIndex = 21;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // DescriptionTBox
      // 
      this.DescriptionTBox.BackColor = System.Drawing.Color.Ivory;
      this.DescriptionTBox.Location = new System.Drawing.Point(9, 212);
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
      this.DescriptionLbl.Location = new System.Drawing.Point(7, 193);
      this.DescriptionLbl.Name = "DescriptionLbl";
      this.DescriptionLbl.Size = new System.Drawing.Size(43, 16);
      this.DescriptionLbl.TabIndex = 1;
      this.DescriptionLbl.Text = "Опис:";
      // 
      // AddPanel
      // 
      this.AddPanel.Controls.Add(this.AddGBox);
      this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.AddPanel.Location = new System.Drawing.Point(0, 0);
      this.AddPanel.Name = "AddPanel";
      this.AddPanel.Size = new System.Drawing.Size(353, 417);
      this.AddPanel.TabIndex = 136;
      // 
      // TransactionGridView
      // 
      this.TransactionGridView.AllowUserToAddRows = false;
      this.TransactionGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.TransactionGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
      this.TransactionGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.TransactionGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.TransactionGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TransactionGridView.GridColor = System.Drawing.SystemColors.Control;
      this.TransactionGridView.Location = new System.Drawing.Point(353, 0);
      this.TransactionGridView.MultiSelect = false;
      this.TransactionGridView.Name = "TransactionGridView";
      this.TransactionGridView.ReadOnly = true;
      this.TransactionGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TransactionGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
      this.TransactionGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.TransactionGridView.Size = new System.Drawing.Size(447, 417);
      this.TransactionGridView.TabIndex = 137;
      this.TransactionGridView.TabStop = false;
      this.TransactionGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransactionGridView_CellClick);
      // 
      // TransactionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 417);
      this.Controls.Add(this.TransactionGridView);
      this.Controls.Add(this.AddPanel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TransactionForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Трензакції";
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      this.AddPanel.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.TransactionGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.Label BudgetCategoryValiadtionLbl;
    private System.Windows.Forms.ComboBox BudgetCategoryCBox;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox AmountTBox;
    private System.Windows.Forms.Label AmountValiadtionLbl;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.TextBox DescriptionTBox;
    private System.Windows.Forms.Label DescriptionLbl;
    private System.Windows.Forms.Panel AddPanel;
    private System.Windows.Forms.DataGridView TransactionGridView;
    private System.Windows.Forms.Label BudgetItemValiadtionLbl;
    private System.Windows.Forms.ComboBox BudgetItemCBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.ComboBox TransactionTypeCBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.DateTimePicker TransactionDateDTP;
    private System.Windows.Forms.Label AddressLbl;
  }
}