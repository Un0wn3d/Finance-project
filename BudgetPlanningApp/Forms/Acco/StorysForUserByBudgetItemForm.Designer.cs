namespace BudgetPlanningApp.Forms.Acco {
  partial class StorysForUserByBudgetItemForm {
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.ExportBtn = new System.Windows.Forms.Button();
      this.BudgetItemValidationLbl = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.BudgetItemCBox = new System.Windows.Forms.ComboBox();
      this.ToDTP = new System.Windows.Forms.DateTimePicker();
      this.FormingBtn = new System.Windows.Forms.Button();
      this.ToValidationLbl = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.FromDTP = new System.Windows.Forms.DateTimePicker();
      this.FromValidationLbl = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.GraphicsCC = new LiveCharts.WinForms.CartesianChart();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.Controls.Add(this.ExportBtn);
      this.panel1.Controls.Add(this.BudgetItemValidationLbl);
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.BudgetItemCBox);
      this.panel1.Controls.Add(this.ToDTP);
      this.panel1.Controls.Add(this.FormingBtn);
      this.panel1.Controls.Add(this.ToValidationLbl);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.FromDTP);
      this.panel1.Controls.Add(this.FromValidationLbl);
      this.panel1.Controls.Add(this.label1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 95);
      this.panel1.TabIndex = 1;
      // 
      // ExportBtn
      // 
      this.ExportBtn.BackColor = System.Drawing.Color.Lime;
      this.ExportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExportBtn.Location = new System.Drawing.Point(401, 66);
      this.ExportBtn.Margin = new System.Windows.Forms.Padding(4);
      this.ExportBtn.Name = "ExportBtn";
      this.ExportBtn.Size = new System.Drawing.Size(80, 25);
      this.ExportBtn.TabIndex = 145;
      this.ExportBtn.Text = "Експорт";
      this.ExportBtn.UseVisualStyleBackColor = false;
      this.ExportBtn.Click += new System.EventHandler(this.ExportBtn_Click);
      // 
      // BudgetItemValidationLbl
      // 
      this.BudgetItemValidationLbl.AutoSize = true;
      this.BudgetItemValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.BudgetItemValidationLbl.Location = new System.Drawing.Point(95, 19);
      this.BudgetItemValidationLbl.Name = "BudgetItemValidationLbl";
      this.BudgetItemValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.BudgetItemValidationLbl.TabIndex = 144;
      this.BudgetItemValidationLbl.Text = "*";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(12, 17);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(64, 16);
      this.label5.TabIndex = 143;
      this.label5.Text = "Рахунок:";
      // 
      // BudgetItemCBox
      // 
      this.BudgetItemCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.BudgetItemCBox.DropDownWidth = 250;
      this.BudgetItemCBox.FormattingEnabled = true;
      this.BudgetItemCBox.Location = new System.Drawing.Point(112, 16);
      this.BudgetItemCBox.Name = "BudgetItemCBox";
      this.BudgetItemCBox.Size = new System.Drawing.Size(281, 24);
      this.BudgetItemCBox.TabIndex = 142;
      // 
      // ToDTP
      // 
      this.ToDTP.Location = new System.Drawing.Point(113, 69);
      this.ToDTP.Name = "ToDTP";
      this.ToDTP.Size = new System.Drawing.Size(164, 22);
      this.ToDTP.TabIndex = 141;
      // 
      // FormingBtn
      // 
      this.FormingBtn.BackColor = System.Drawing.Color.Lime;
      this.FormingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.FormingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormingBtn.Location = new System.Drawing.Point(295, 66);
      this.FormingBtn.Margin = new System.Windows.Forms.Padding(4);
      this.FormingBtn.Name = "FormingBtn";
      this.FormingBtn.Size = new System.Drawing.Size(98, 25);
      this.FormingBtn.TabIndex = 135;
      this.FormingBtn.Text = "Формувати";
      this.FormingBtn.UseVisualStyleBackColor = false;
      this.FormingBtn.Click += new System.EventHandler(this.FormingBtn_Click);
      // 
      // ToValidationLbl
      // 
      this.ToValidationLbl.AutoSize = true;
      this.ToValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.ToValidationLbl.Location = new System.Drawing.Point(95, 73);
      this.ToValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.ToValidationLbl.Name = "ToValidationLbl";
      this.ToValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.ToValidationLbl.TabIndex = 140;
      this.ToValidationLbl.Text = "*";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(10, 67);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 16);
      this.label3.TabIndex = 139;
      this.label3.Text = "Кінець:";
      // 
      // FromDTP
      // 
      this.FromDTP.Location = new System.Drawing.Point(113, 43);
      this.FromDTP.Name = "FromDTP";
      this.FromDTP.Size = new System.Drawing.Size(164, 22);
      this.FromDTP.TabIndex = 138;
      // 
      // FromValidationLbl
      // 
      this.FromValidationLbl.AutoSize = true;
      this.FromValidationLbl.ForeColor = System.Drawing.Color.Red;
      this.FromValidationLbl.Location = new System.Drawing.Point(95, 49);
      this.FromValidationLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.FromValidationLbl.Name = "FromValidationLbl";
      this.FromValidationLbl.Size = new System.Drawing.Size(12, 16);
      this.FromValidationLbl.TabIndex = 137;
      this.FromValidationLbl.Text = "*";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(10, 43);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(66, 16);
      this.label1.TabIndex = 136;
      this.label1.Text = "Початок:";
      // 
      // GraphicsCC
      // 
      this.GraphicsCC.BackColor = System.Drawing.SystemColors.Info;
      this.GraphicsCC.Dock = System.Windows.Forms.DockStyle.Fill;
      this.GraphicsCC.Location = new System.Drawing.Point(0, 95);
      this.GraphicsCC.Name = "GraphicsCC";
      this.GraphicsCC.Size = new System.Drawing.Size(800, 355);
      this.GraphicsCC.TabIndex = 5;
      this.GraphicsCC.Text = "cartesianChart1";
      // 
      // StorysForUserByBudgetItemForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.GraphicsCC);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "StorysForUserByBudgetItemForm";
      this.ShowIcon = false;
      this.Text = "По обраній витраті за період часу";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label BudgetItemValidationLbl;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox BudgetItemCBox;
    private System.Windows.Forms.DateTimePicker ToDTP;
    private System.Windows.Forms.Button FormingBtn;
    private System.Windows.Forms.Label ToValidationLbl;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.DateTimePicker FromDTP;
    private System.Windows.Forms.Label FromValidationLbl;
    private System.Windows.Forms.Label label1;
    private LiveCharts.WinForms.CartesianChart GraphicsCC;
    private System.Windows.Forms.Button ExportBtn;
  }
}