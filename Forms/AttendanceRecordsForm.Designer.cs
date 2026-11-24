namespace tagUMpay
{
    partial class AttendanceRecordsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Filter bar (top)
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;

        // Records grid (center)
        private System.Windows.Forms.DataGridView dgvAttendance;

        // Summary bar
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblDaysWorked;
        private System.Windows.Forms.Label lblDaysAbsent;

        // Record attendance box (bottom, admin only)
        private System.Windows.Forms.GroupBox grpRecord;
        private System.Windows.Forms.Label lblRecEmployee;
        private System.Windows.Forms.ComboBox cmbRecEmployee;
        private System.Windows.Forms.Label lblRecDate;
        private System.Windows.Forms.DateTimePicker dtpRecDate;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;

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
            pnlFilter = new System.Windows.Forms.Panel();
            lblEmployee = new System.Windows.Forms.Label();
            cmbEmployee = new System.Windows.Forms.ComboBox();
            lblFrom = new System.Windows.Forms.Label();
            dtpFrom = new System.Windows.Forms.DateTimePicker();
            lblTo = new System.Windows.Forms.Label();
            dtpTo = new System.Windows.Forms.DateTimePicker();
            btnSearch = new System.Windows.Forms.Button();
            dgvAttendance = new System.Windows.Forms.DataGridView();
            pnlSummary = new System.Windows.Forms.Panel();
            lblDaysWorked = new System.Windows.Forms.Label();
            lblDaysAbsent = new System.Windows.Forms.Label();
            grpRecord = new System.Windows.Forms.GroupBox();
            lblRecEmployee = new System.Windows.Forms.Label();
            cmbRecEmployee = new System.Windows.Forms.ComboBox();
            lblRecDate = new System.Windows.Forms.Label();
            dtpRecDate = new System.Windows.Forms.DateTimePicker();
            lblStatus = new System.Windows.Forms.Label();
            cmbStatus = new System.Windows.Forms.ComboBox();
            btnSave = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
            pnlFilter.SuspendLayout();
            pnlSummary.SuspendLayout();
            grpRecord.SuspendLayout();
            SuspendLayout();

            // ---------- pnlFilter ----------
            pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilter.Height = 70;
            pnlFilter.Padding = new System.Windows.Forms.Padding(10);
            pnlFilter.Controls.Add(lblEmployee);
            pnlFilter.Controls.Add(cmbEmployee);
            pnlFilter.Controls.Add(lblFrom);
            pnlFilter.Controls.Add(dtpFrom);
            pnlFilter.Controls.Add(lblTo);
            pnlFilter.Controls.Add(dtpTo);
            pnlFilter.Controls.Add(btnSearch);

            lblEmployee.AutoSize = true;
            lblEmployee.Location = new System.Drawing.Point(15, 12);
            lblEmployee.Text = "Employee";

            cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbEmployee.Location = new System.Drawing.Point(15, 33);
            cmbEmployee.Name = "cmbEmployee";
            cmbEmployee.Size = new System.Drawing.Size(200, 28);

            lblFrom.AutoSize = true;
            lblFrom.Location = new System.Drawing.Point(230, 12);
            lblFrom.Text = "From";

            dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFrom.Location = new System.Drawing.Point(230, 33);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new System.Drawing.Size(130, 27);

            lblTo.AutoSize = true;
            lblTo.Location = new System.Drawing.Point(375, 12);
            lblTo.Text = "To";

            dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTo.Location = new System.Drawing.Point(375, 33);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new System.Drawing.Size(130, 27);

            btnSearch.Location = new System.Drawing.Point(525, 30);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new System.Drawing.Size(100, 32);
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // ---------- dgvAttendance ----------
            dgvAttendance.AllowUserToAddRows = false;
            dgvAttendance.AllowUserToDeleteRows = false;
            dgvAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvAttendance.MultiSelect = false;
            dgvAttendance.Name = "dgvAttendance";
            dgvAttendance.ReadOnly = true;
            dgvAttendance.RowHeadersVisible = false;
            dgvAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvAttendance.Columns.Add("colDate", "Date");
            dgvAttendance.Columns.Add("colEmployee", "Employee");
            dgvAttendance.Columns.Add("colTimeIn", "Time In");
            dgvAttendance.Columns.Add("colTimeOut", "Time Out");
            dgvAttendance.Columns.Add("colOvertime", "Overtime Hrs");
            dgvAttendance.Columns.Add("colStatus", "Status");

            // ---------- pnlSummary ----------
            pnlSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlSummary.Height = 40;
            pnlSummary.Controls.Add(lblDaysWorked);
            pnlSummary.Controls.Add(lblDaysAbsent);

            lblDaysWorked.AutoSize = true;
            lblDaysWorked.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblDaysWorked.Location = new System.Drawing.Point(15, 10);
            lblDaysWorked.Text = "Days Worked: 0";

            lblDaysAbsent.AutoSize = true;
            lblDaysAbsent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblDaysAbsent.Location = new System.Drawing.Point(200, 10);
            lblDaysAbsent.Text = "Total Absences: 0";

            // ---------- grpRecord ----------
            grpRecord.Dock = System.Windows.Forms.DockStyle.Bottom;
            grpRecord.Height = 100;
            grpRecord.Text = "Record Attendance";
            grpRecord.Controls.Add(lblRecEmployee);
            grpRecord.Controls.Add(cmbRecEmployee);
            grpRecord.Controls.Add(lblRecDate);
            grpRecord.Controls.Add(dtpRecDate);
            grpRecord.Controls.Add(lblStatus);
            grpRecord.Controls.Add(cmbStatus);
            grpRecord.Controls.Add(btnSave);
            grpRecord.Controls.Add(btnClear);

            lblRecEmployee.AutoSize = true;
            lblRecEmployee.Location = new System.Drawing.Point(15, 28);
            lblRecEmployee.Text = "Employee";

            cmbRecEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbRecEmployee.Location = new System.Drawing.Point(15, 50);
            cmbRecEmployee.Name = "cmbRecEmployee";
            cmbRecEmployee.Size = new System.Drawing.Size(200, 28);

            lblRecDate.AutoSize = true;
            lblRecDate.Location = new System.Drawing.Point(230, 28);
            lblRecDate.Text = "Date";

            dtpRecDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpRecDate.Location = new System.Drawing.Point(230, 50);
            dtpRecDate.Name = "dtpRecDate";
            dtpRecDate.Size = new System.Drawing.Size(130, 27);

            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(375, 28);
            lblStatus.Text = "Status";

            cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbStatus.Items.AddRange(new object[] { "Present", "Absent" });
            cmbStatus.Location = new System.Drawing.Point(375, 50);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new System.Drawing.Size(120, 28);

            btnSave.Location = new System.Drawing.Point(525, 47);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(100, 32);
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;

            btnClear.Location = new System.Drawing.Point(635, 47);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(100, 32);
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;

            // ---------- AttendanceRecordsForm ----------
            // Fill control is added first so the docked bars claim their space before it.
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(780, 520);
            Controls.Add(dgvAttendance);
            Controls.Add(pnlSummary);
            Controls.Add(grpRecord);
            Controls.Add(pnlFilter);
            MinimumSize = new System.Drawing.Size(800, 500);
            Name = "AttendanceRecordsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "tagUMpay - Attendance Records";

            ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlSummary.ResumeLayout(false);
            pnlSummary.PerformLayout();
            grpRecord.ResumeLayout(false);
            grpRecord.PerformLayout();
            ResumeLayout(false);
        }
    }
}
