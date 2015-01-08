namespace RefillingStation
{
    partial class LogFormcs
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.MonthlyTotalTB = new System.Windows.Forms.TextBox();
            this.TotalYearlyTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PrintButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(438, 339);
            this.dataGridView1.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(597, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // MonthlyTotalTB
            // 
            this.MonthlyTotalTB.Location = new System.Drawing.Point(691, 138);
            this.MonthlyTotalTB.Name = "MonthlyTotalTB";
            this.MonthlyTotalTB.ReadOnly = true;
            this.MonthlyTotalTB.Size = new System.Drawing.Size(106, 20);
            this.MonthlyTotalTB.TabIndex = 3;
            this.MonthlyTotalTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TotalYearlyTB
            // 
            this.TotalYearlyTB.Location = new System.Drawing.Point(691, 172);
            this.TotalYearlyTB.Name = "TotalYearlyTB";
            this.TotalYearlyTB.ReadOnly = true;
            this.TotalYearlyTB.Size = new System.Drawing.Size(106, 20);
            this.TotalYearlyTB.TabIndex = 4;
            this.TotalYearlyTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(545, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Total Monthly Sales: P";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(545, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total Yearly Sales:   P";
            // 
            // PrintButton
            // 
            this.PrintButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrintButton.Location = new System.Drawing.Point(630, 292);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(148, 23);
            this.PrintButton.TabIndex = 7;
            this.PrintButton.Text = "Print Log";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // LogFormcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(848, 369);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TotalYearlyTB);
            this.Controls.Add(this.MonthlyTotalTB);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LogFormcs";
            this.Text = "Logs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogFormcs_FormClosing);
            this.Load += new System.EventHandler(this.LogFormcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox MonthlyTotalTB;
        private System.Windows.Forms.TextBox TotalYearlyTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button PrintButton;
    }
}