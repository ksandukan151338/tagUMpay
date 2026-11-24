using System;
using System.Windows.Forms;

namespace tagUMpay
{
    public partial class PayrollRecordsForm : Form
    {
        // Admin can generate and save payroll. Employee view is read-only history of their own records.
        private readonly bool isAdmin;

        public PayrollRecordsForm() : this(true) { }

        public PayrollRecordsForm(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;

            dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            if (!isAdmin)
            {
                lblEmployee.Visible = false;
                cmbEmployee.Visible = false;
                btnGenerate.Visible = false;
                btnSavePayroll.Visible = false;
            }

            LoadPreviewRows(); // TODO: remove once the database is connected
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // TODO: for the selected pay period, count days worked / absences, sum overtime hours,
            // compute basic, overtime and gross pay, and show the results in dgvPayroll.
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            // TODO: load previously saved payroll records for the selected period.
        }

        private void btnSavePayroll_Click(object sender, EventArgs e)
        {
            // TODO: save the generated payroll rows.
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Dummy rows so you can see the layout. Safe to delete.
        private void LoadPreviewRows()
        {
            dgvPayroll.Rows.Add("Nov 1 - Nov 15, 2026", "Juan Dela Cruz", "11", "2", "4.0", "5,500.00", "400.00", "5,900.00");
            dgvPayroll.Rows.Add("Nov 1 - Nov 15, 2026", "Maria Santos", "13", "0", "0.0", "7,800.00", "0.00", "7,800.00");
            lblTotalGross.Text = "Total Gross Pay: ₱13,700.00";
        }
    }
}
