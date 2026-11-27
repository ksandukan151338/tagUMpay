using System.Windows.Forms;

namespace tagUMpay
{
    public class Admin : User
    {
        private int adminId;

        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }

        public void addEmployee()
        {
            using (AddEmployeeForm addForm = new AddEmployeeForm())
            {
                addForm.ShowDialog();
            }
        }

        public void updateEmployee()
        {
            using (UpdateEmployeeForm updateForm = new UpdateEmployeeForm())
            {
                updateForm.ShowDialog();
            }
        }

        public void deleteEmployee()
        {
            using (DeleteEmployeeForm deleteForm = new DeleteEmployeeForm())
            {
                deleteForm.ShowDialog();
            }
        }

        public void recordAttendance()
        {
            using (AttendanceRecordsForm attendanceForm = new AttendanceRecordsForm(true))
            {
                attendanceForm.ShowDialog();
            }
        }

        public void preparePayroll()
        {
            using (PayrollRecordsForm payrollForm = new PayrollRecordsForm(true))
            {
                payrollForm.ShowDialog();
            }
        }

        public override void getDashboardOptions()
        {
            AdminDashboardForm adminForm = new AdminDashboardForm(this);
            adminForm.ShowDialog();
        }
    }
}