using System;
using System.Windows.Forms;

namespace tagUMpay
{
    public partial class AttendanceRecordsForm : Form
    {
        // Admin sees everything. Employee view hides the employee picker and the record box
        // (employees can only view their own records).
        private readonly bool isAdmin;

        public AttendanceRecordsForm() : this(true) { }

        public AttendanceRecordsForm(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;

            cmbStatus.SelectedIndex = 0;
            dtpFrom.Value = DateTime.Today.AddDays(-14);

            if (!isAdmin)
            {
                grpRecord.Visible = false;
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
            }

            LoadPreviewRows(); // TODO: remove once the database is connected
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // TODO: fetch attendance records for the selected employee and date range,
            // fill dgvAttendance, then update the summary labels.
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // TODO: validate input and save the attendance record (Present / Absent).
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbRecEmployee.SelectedIndex = -1;
            dtpRecDate.Value = DateTime.Today;
            cmbStatus.SelectedIndex = 0;
        }

        // Dummy rows so you can see the layout. Safe to delete.
        private void LoadPreviewRows()
        {
            dgvAttendance.Rows.Add("2026-11-23", "Juan Dela Cruz", "08:00", "17:00", "0.0", "Present");
            dgvAttendance.Rows.Add("2026-11-24", "Juan Dela Cruz", "08:00", "19:00", "2.0", "Present");
            dgvAttendance.Rows.Add("2026-11-25", "Juan Dela Cruz", "--", "--", "0.0", "Absent");
            lblDaysWorked.Text = "Days Worked: 2";
            lblDaysAbsent.Text = "Total Absences: 1";
        }
    }
}
