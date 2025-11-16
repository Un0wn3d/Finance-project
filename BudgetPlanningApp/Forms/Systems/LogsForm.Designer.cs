namespace BudgetPlanningApp.Forms.Systems {
  partial class LogsForm {
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
      this.LogsGridView = new System.Windows.Forms.DataGridView();
      ((System.ComponentModel.ISupportInitialize)(this.LogsGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // LogsGridView
      // 
      this.LogsGridView.AllowUserToAddRows = false;
      this.LogsGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.LogsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
      this.LogsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.LogsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.LogsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LogsGridView.GridColor = System.Drawing.SystemColors.Control;
      this.LogsGridView.Location = new System.Drawing.Point(0, 0);
      this.LogsGridView.MultiSelect = false;
      this.LogsGridView.Name = "LogsGridView";
      this.LogsGridView.ReadOnly = true;
      this.LogsGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue;
      this.LogsGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
      this.LogsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.LogsGridView.Size = new System.Drawing.Size(800, 450);
      this.LogsGridView.TabIndex = 94;
      // 
      // LogsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.LogsGridView);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LogsForm";
      this.ShowIcon = false;
      this.Text = "Дії користувачів";
      ((System.ComponentModel.ISupportInitialize)(this.LogsGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView LogsGridView;
  }
}