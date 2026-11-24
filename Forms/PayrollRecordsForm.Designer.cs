namespace tagUMpay
{
    partial class PayrollRecordsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Pay period bar (top)
        private System.Windows.Forms.Panel pnlPeriod;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnView;

        // Payroll grid (center)
        private System.Windows.Forms.DataGridView dgvPayroll;

        // Totals + actions (bottom)
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Label lblTotalGross;
        private System.Windows.Forms.Button btnSavePayroll;
        private System.Windows.Forms.Button btnClose;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlPeriod = new System.Windows.Forms.Panel();
            lblEmployee = new System.Windows.Forms.Label();
            cmbEmployee = new System.Windows.Forms.ComboBox();
            lblFrom = new System.Windows.Forms.Label();
            dtpFrom = new System.Windows.Forms.DateTimePicker();
            lblTo = new System.Windows.Forms.Label();
            dtpTo = new System.Windows.Forms.DateTimePicker();
            btnGenerate = new System.Windows.Forms.Button();
            btnView = new System.Windows.Forms.Button();
            dgvPayroll = new System.Windows.Forms.DataGridView();
            pnlBottom = new System.Windows.Forms.Panel();
            lblTotalGross = new System.Windows.Forms.Label();
            btnSavePayroll = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvPayroll).BeginInit();
            pnlPeriod.SuspendLayout();
            pnlBottom.SuspendLayout();
            SuspendLayout();

            // ---------- pnlPeriod ----------
            pnlPeriod.Dock = System.Windows.Forms.DockStyle.Top;
            pnlPeriod.Height = 70;
            pnlPeriod.Controls.Add(lblEmployee);
            pnlPeriod.Controls.Add(cmbEmployee);
            pnlPeriod.Controls.Add(lblFrom);
            pnlPeriod.Controls.Add(dtpFrom);
            pnlPeriod.Controls.Add(lblTo);
            pnlPeriod.Controls.Add(dtpTo);
            pnlPeriod.Controls.Add(btnGenerate);
            pnlPeriod.Controls.Add(btnView);

            lblEmployee.AutoSize = true;
            lblEmployee.Location = new System.Drawing.Point(15, 12);
            lblEmployee.Text = "Employee";

            cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEmployee.Location = new System.Drawing.Point(15, 33);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new System.Drawing.Size(200, 28);

            lblFrom.AutoSize = true;
            lblFrom.Location = new System.Drawing.Point(230, 12);
            lblFrom.Text = "Pay period from";

            dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFrom.Location = new System.Drawing.Point(230, 33);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new System.Drawing.Size(130, 27);

            lblTo.AutoSize = true;
            lblTo.Location = new System.Drawing.Point(375, 12);
            lblTo.Text = "to";

            dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTo.Location = new System.Drawing.Point(375, 33);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new System.Drawing.Size(130, 27);

            btnGenerate.Location = new System.Drawing.Point(525, 30);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new System.Drawing.Size(130, 32);
            btnGenerate.Text = "Generate Payroll";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;

            btnView.Location = new System.Drawing.Point(665, 30);
            btnView.Name = "btnView";
            btnView.Size = new System.Drawing.Size(110, 32);
            btnView.Text = "View Saved";
            btnView.UseVisualStyleBackColor = true;
            btnView.Click += btnView_Click;

            // ---------- dgvPayroll ----------
            dgvPayroll.AllowUserToAddRows = false;
            dgvPayroll.AllowUserToDeleteRows = false;
            dgvPayroll.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayroll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayroll.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvPayroll.MultiSelect = false;
            dgvPayroll.Name = "dgvPayroll";
            dgvPayroll.ReadOnly = true;
            dgvPayroll.RowHeadersVisible = false;
            dgvPayroll.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvPayroll.Columns.Add("colPeriod", "Payroll Period");
            dgvPayroll.Columns.Add("colEmployee", "Employee");
            dgvPayroll.Columns.Add("colDaysWorked", "Days Worked");
            dgvPayroll.Columns.Add("colDaysAbsent", "Days Absent");
            dgvPayroll.Columns.Add("colOvertimeHrs", "Overtime Hrs");
            dgvPayroll.Columns.Add("colBasicPay", "Basic Pay");
            dgvPayroll.Columns.Add("colOvertimePay", "Overtime Pay");
            dgvPayroll.Columns.Add("colGrossPay", "Gross Pay");
            // Right-align the money columns
            foreach (string name in new[] { "colBasicPay", "colOvertimePay", "colGrossPay" })
            {
                dgvPayroll.Columns[name].DefaultCellStyle.Alignment =
                    System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            }

            // ---------- pnlBottom ----------
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlBottom.Height = 60;
            pnlBottom.Controls.Add(lblTotalGross);
            pnlBottom.Controls.Add(btnSavePayroll);
            pnlBottom.Controls.Add(btnClose);

            lblTotalGross.AutoSize = true;
            lblTotalGross.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            lblTotalGross.Location = new System.Drawing.Point(15, 18);
            lblTotalGross.Text = "Total Gross Pay: ₱0.00";

            btnSavePayroll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSavePayroll.Location = new System.Drawing.Point(540, 12);
            btnSavePayroll.Name = "btnSavePayroll";
            btnSavePayroll.Size = new System.Drawing.Size(130, 36);
            btnSavePayroll.Text = "Save Payroll";
            btnSavePayroll.UseVisualStyleBackColor = true;
            btnSavePayroll.Click += btnSavePayroll_Click;

            btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClose.Location = new System.Drawing.Point(680, 12);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(90, 36);
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;

            // ---------- PayrollRecordsForm ----------
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(790, 480);
            Controls.Add(dgvPayroll);
            Controls.Add(pnlBottom);
            Controls.Add(pnlPeriod);
            MinimumSize = new System.Drawing.Size(810, 460);
            Name = "PayrollRecordsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "tagUMpay - Payroll Records";

            ((System.ComponentModel.ISupportInitialize)dgvPayroll).EndInit();
            pnlPeriod.ResumeLayout(false);
            pnlPeriod.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            ResumeLayout(false);
        }
    }
}
