namespace BudgetPlanningApp.Forms.Dict {
  partial class BudgetItemForm {
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.BudgetItemGridView = new System.Windows.Forms.DataGridView();
      this.ItemNameValiadtionLbl = new System.Windows.Forms.Label();
      this.DescriptionTBox = new System.Windows.Forms.TextBox();
      this.ItemNameTBox = new System.Windows.Forms.TextBox();
      this.DescriptionLbl = new System.Windows.Forms.Label();
      this.СomputerLbl = new System.Windows.Forms.Label();
      this.AddGBox = new System.Windows.Forms.GroupBox();
      this.BudgetCategoryValiadtionLbl = new System.Windows.Forms.Label();
      this.BudgetCategoryCBox = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.DefaultAmountTBox = new System.Windows.Forms.TextBox();
      this.DefaultAmountValiadtionLbl = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.AddBtn = new System.Windows.Forms.Button();
      this.AddPanel = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.BudgetItemGridView)).BeginInit();
      this.AddGBox.SuspendLayout();
      this.AddPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // BudgetItemGridView
      // 
      this.BudgetItemGridView.AllowUserToAddRows = false;
      this.BudgetItemGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.BudgetItemGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.BudgetItemGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.BudgetItemGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.BudgetItemGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.BudgetItemGridView.GridColor = System.Drawing.SystemColors.Control;
      this.BudgetItemGridView.Location = new System.Drawing.Point(353, 0);
      this.BudgetItemGridView.MultiSelect = false;
      this.BudgetItemGridView.Name = "BudgetItemGridView";
      this.BudgetItemGridView.ReadOnly = true;
      this.BudgetItemGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.BudgetItemGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.BudgetItemGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.BudgetItemGridView.Size = new System.Drawing.Size(447, 368);
      this.BudgetItemGridView.TabIndex = 135;
      this.BudgetItemGridView.TabStop = false;
      this.BudgetItemGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BudgetItemGridView_CellClick);
      // 
      // ItemNameValiadtionLbl
      // 
      this.ItemNameValiadtionLbl.AutoSize = true;
      this.ItemNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.ItemNameValiadtionLbl.Location = new System.Drawing.Point(64, 13);
      this.ItemNameValiadtionLbl.Name = "ItemNameValiadtionLbl";
      this.ItemNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.ItemNameValiadtionLbl.TabIndex = 23;
      this.ItemNameValiadtionLbl.Text = "*";
      // 
      // DescriptionTBox
      // 
      this.DescriptionTBox.BackColor = System.Drawing.Color.Ivory;
      this.DescriptionTBox.Location = new System.Drawing.Point(9, 161);
      this.DescriptionTBox.MaxLength = 1500;
      this.DescriptionTBox.Multiline = true;
      this.DescriptionTBox.Name = "DescriptionTBox";
      this.DescriptionTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.DescriptionTBox.Size = new System.Drawing.Size(319, 154);
      this.DescriptionTBox.TabIndex = 4;
      // 
      // ItemNameTBox
      // 
      this.ItemNameTBox.BackColor = System.Drawing.Color.Ivory;
      this.ItemNameTBox.Location = new System.Drawing.Point(6, 32);
      this.ItemNameTBox.MaxLength = 250;
      this.ItemNameTBox.Name = "ItemNameTBox";
      this.ItemNameTBox.Size = new System.Drawing.Size(323, 22);
      this.ItemNameTBox.TabIndex = 1;
      // 
      // DescriptionLbl
      // 
      this.DescriptionLbl.AutoSize = true;
      this.DescriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.DescriptionLbl.Location = new System.Drawing.Point(7, 142);
      this.DescriptionLbl.Name = "DescriptionLbl";
      this.DescriptionLbl.Size = new System.Drawing.Size(43, 16);
      this.DescriptionLbl.TabIndex = 1;
      this.DescriptionLbl.Text = "Опис:";
      // 
      // СomputerLbl
      // 
      this.СomputerLbl.AutoSize = true;
      this.СomputerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.СomputerLbl.Location = new System.Drawing.Point(6, 13);
      this.СomputerLbl.Name = "СomputerLbl";
      this.СomputerLbl.Size = new System.Drawing.Size(52, 16);
      this.СomputerLbl.TabIndex = 0;
      this.СomputerLbl.Text = "Назва:";
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.BudgetCategoryValiadtionLbl);
      this.AddGBox.Controls.Add(this.BudgetCategoryCBox);
      this.AddGBox.Controls.Add(this.label4);
      this.AddGBox.Controls.Add(this.DefaultAmountTBox);
      this.AddGBox.Controls.Add(this.DefaultAmountValiadtionLbl);
      this.AddGBox.Controls.Add(this.label2);
      this.AddGBox.Controls.Add(this.ExitBtn);
      this.AddGBox.Controls.Add(this.ClearBtn);
      this.AddGBox.Controls.Add(this.AddBtn);
      this.AddGBox.Controls.Add(this.ItemNameValiadtionLbl);
      this.AddGBox.Controls.Add(this.DescriptionTBox);
      this.AddGBox.Controls.Add(this.ItemNameTBox);
      this.AddGBox.Controls.Add(this.DescriptionLbl);
      this.AddGBox.Controls.Add(this.СomputerLbl);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(8, 2);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(338, 360);
      this.AddGBox.TabIndex = 0;
      this.AddGBox.TabStop = false;
      // 
      // BudgetCategoryValiadtionLbl
      // 
      this.BudgetCategoryValiadtionLbl.AutoSize = true;
      this.BudgetCategoryValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.BudgetCategoryValiadtionLbl.Location = new System.Drawing.Point(85, 91);
      this.BudgetCategoryValiadtionLbl.Name = "BudgetCategoryValiadtionLbl";
      this.BudgetCategoryValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.BudgetCategoryValiadtionLbl.TabIndex = 103;
      this.BudgetCategoryValiadtionLbl.Text = "*";
      // 
      // BudgetCategoryCBox
      // 
      this.BudgetCategoryCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.BudgetCategoryCBox.FormattingEnabled = true;
      this.BudgetCategoryCBox.Location = new System.Drawing.Point(9, 110);
      this.BudgetCategoryCBox.Name = "BudgetCategoryCBox";
      this.BudgetCategoryCBox.Size = new System.Drawing.Size(319, 24);
      this.BudgetCategoryCBox.TabIndex = 3;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(6, 92);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 16);
      this.label4.TabIndex = 102;
      this.label4.Text = "Категорія:";
      // 
      // DefaultAmountTBox
      // 
      this.DefaultAmountTBox.BackColor = System.Drawing.Color.Ivory;
      this.DefaultAmountTBox.Location = new System.Drawing.Point(192, 59);
      this.DefaultAmountTBox.MaxLength = 10;
      this.DefaultAmountTBox.Name = "DefaultAmountTBox";
      this.DefaultAmountTBox.Size = new System.Drawing.Size(136, 22);
      this.DefaultAmountTBox.TabIndex = 2;
      this.DefaultAmountTBox.Text = "0.00";
      this.DefaultAmountTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // DefaultAmountValiadtionLbl
      // 
      this.DefaultAmountValiadtionLbl.AutoSize = true;
      this.DefaultAmountValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.DefaultAmountValiadtionLbl.Location = new System.Drawing.Point(174, 62);
      this.DefaultAmountValiadtionLbl.Name = "DefaultAmountValiadtionLbl";
      this.DefaultAmountValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.DefaultAmountValiadtionLbl.TabIndex = 25;
      this.DefaultAmountValiadtionLbl.Text = "*";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(6, 61);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(171, 16);
      this.label2.TabIndex = 24;
      this.label2.Text = "Сума за замовчуванням:";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.Lime;
      this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitBtn.Location = new System.Drawing.Point(247, 321);
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
      this.ClearBtn.Location = new System.Drawing.Point(145, 321);
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
      this.AddBtn.Location = new System.Drawing.Point(43, 321);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(81, 25);
      this.AddBtn.TabIndex = 21;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // AddPanel
      // 
      this.AddPanel.Controls.Add(this.AddGBox);
      this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.AddPanel.Location = new System.Drawing.Point(0, 0);
      this.AddPanel.Name = "AddPanel";
      this.AddPanel.Size = new System.Drawing.Size(353, 368);
      this.AddPanel.TabIndex = 134;
      // 
      // BudgetItemForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 368);
      this.Controls.Add(this.BudgetItemGridView);
      this.Controls.Add(this.AddPanel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "BudgetItemForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Витрати";
      ((System.ComponentModel.ISupportInitialize)(this.BudgetItemGridView)).EndInit();
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      this.AddPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView BudgetItemGridView;
    private System.Windows.Forms.Label ItemNameValiadtionLbl;
    private System.Windows.Forms.TextBox DescriptionTBox;
    private System.Windows.Forms.TextBox ItemNameTBox;
    private System.Windows.Forms.Label DescriptionLbl;
    private System.Windows.Forms.Label СomputerLbl;
    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.Panel AddPanel;
    private System.Windows.Forms.TextBox DefaultAmountTBox;
    private System.Windows.Forms.Label DefaultAmountValiadtionLbl;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label BudgetCategoryValiadtionLbl;
    private System.Windows.Forms.ComboBox BudgetCategoryCBox;
    private System.Windows.Forms.Label label4;
  }
}