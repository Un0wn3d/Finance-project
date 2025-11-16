namespace BudgetPlanningApp.Forms.Acco {
  partial class MonthlyExpensesForm {
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
      this.FormReportBtn = new System.Windows.Forms.Button();
      this.AccTBox = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.ExportBtn = new System.Windows.Forms.Button();
      this.ToDTP = new System.Windows.Forms.DateTimePicker();
      this.ToValidationLbl = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.FromDTP = new System.Windows.Forms.DateTimePicker();
      this.FromValidationLbl = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // FormReportBtn
      // 
      this.FormReportBtn.BackColor = System.Drawing.Color.Lime;
      this.FormReportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.FormReportBtn.Location = new System.Drawing.Point(270, 36);
      this.FormReportBtn.Margin = new System.Windows.Forms.Padding(4);
      this.FormReportBtn.Name = "FormReportBtn";
      this.FormReportBtn.Size = new System.Drawing.Size(101, 25);
      this.FormReportBtn.TabIndex = 127;
      this.FormReportBtn.Text = "Формувати";
      this.FormReportBtn.UseVisualStyleBackColor = false;
      this.FormReportBtn.Click += new System.EventHandler(this.FormReportBtn_Click);
      // 
      // AccTBox
      // 
      this.AccTBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.AccTBox.BackColor = System.Drawing.SystemColors.Info;
      this.AccTBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AccTBox.Location = new System.Drawing.Point(12, 85);
      this.AccTBox.Margin = new System.Windows.Forms.Padding(4);
      this.AccTBox.Multiline = true;
      this.AccTBox.Name = "AccTBox";
      this.AccTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.AccTBox.Size = new System.Drawing.Size(712, 195);
      this.AccTBox.TabIndex = 134;
      this.AccTBox.TabStop = false;
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.ExportBtn);
      this.groupBox1.Controls.Add(this.ToDTP);
      this.groupBox1.Controls.Add(this.FormReportBtn);
      this.groupBox1.Controls.Add(this.ToValidationLbl);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.FromDTP);
      this.groupBox1.Controls.Add(this.FromValidationLbl);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox1.Location = new System.Drawing.Point(12, 4);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(713, 74);
      this.groupBox1.TabIndex = 133;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Період";
      // 
      // ExportBtn
      // 
      this.ExportBtn.BackColor = System.Drawing.Color.Lime;
      this.ExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExportBtn.Location = new System.Drawing.Point(379, 36);
      this.ExportBtn.Margin = new System.Windows.Forms.Padding(4);
      this.ExportBtn.Name = "ExportBtn";
      this.ExportBtn.Size = new System.Drawing.Size(80, 25);
      this.ExportBtn.TabIndex = 135;
      this.ExportBtn.Text = "Експорт";
      this.ExportBtn.UseVisualStyleBackColor = false;
      this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
      // 
      // ToDTP
      // 
      this.ToDTP.Location = new System.Drawing.Point(105, 39);
      this.ToDTP.Name = "ToDTP";
      this.ToDTP.Size = new System.Drawing.Size(158, 22);
      this.ToDTP.TabIndex = 134;
      // 
      // ToValidationLbl
      // 
      this.ToValidationLbl.AutoSize = true;
      this.ToValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.ToValidationLbl.Location = new System.Drawing.Point(87, 43);
      this.ToValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.ToValidationLbl.Name = "ToValidationLbl";
      this.ToValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.ToValidationLbl.TabIndex = 133;
      this.ToValidationLbl.Text = "*";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(13, 41);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 16);
      this.label3.TabIndex = 132;
      this.label3.Text = "Кінець:";
      // 
      // FromDTP
      // 
      this.FromDTP.Location = new System.Drawing.Point(105, 13);
      this.FromDTP.Name = "FromDTP";
      this.FromDTP.Size = new System.Drawing.Size(158, 22);
      this.FromDTP.TabIndex = 131;
      // 
      // FromValidationLbl
      // 
      this.FromValidationLbl.AutoSize = true;
      this.FromValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.FromValidationLbl.Location = new System.Drawing.Point(87, 19);
      this.FromValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.FromValidationLbl.Name = "FromValidationLbl";
      this.FromValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.FromValidationLbl.TabIndex = 130;
      this.FromValidationLbl.Text = "*";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(13, 17);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 16);
      this.label1.TabIndex = 129;
      this.label1.Text = "Початок:";
      // 
      // MonthlyExpensesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(737, 293);
      this.Controls.Add(this.AccTBox);
      this.Controls.Add(this.groupBox1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MonthlyExpensesForm";
      this.ShowIcon = false;
      this.Text = "Помісячні витрати за обраний період";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button FormReportBtn;
    private System.Windows.Forms.TextBox AccTBox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.DateTimePicker ToDTP;
    private System.Windows.Forms.Label ToValidationLbl;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DateTimePicker FromDTP;
    private System.Windows.Forms.Label FromValidationLbl;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button ExportBtn;
  }
}