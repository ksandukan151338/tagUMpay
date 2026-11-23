using System.Windows.Forms;

namespace tagUMpay
{
    public class Employee : User
    {
        private int employeeId;
        private string? firstName;
        private string? middleName;
        private string? lastName;
        private string? nameExtension;
        private int positionId;
        private string? contactInfo;
        private string? employmentStatus;

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public string FirstName
        {
            get { return firstName ?? ""; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName ?? ""; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName ?? ""; }
            set { lastName = value; }
        }

        public string NameExtension
        {
            get { return nameExtension ?? ""; }
            set { nameExtension = value; }
        }

        public string FullName
        {
            get
            {
                string formattedName = FirstName.Trim();

                if (!string.IsNullOrWhiteSpace(MiddleName))
                {
                    formattedName += " " +
                        MiddleName.Trim().Substring(0, 1).ToUpper() + ".";
                }

                formattedName += " " + LastName.Trim();

                if (!string.IsNullOrWhiteSpace(NameExtension))
                {
                    formattedName += " " + NameExtension.Trim();
                }

                return formattedName;
            }
        }

        public int PositionId
        {
            get { return positionId; }
            set { positionId = value; }
        }

        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo = value; }
        }

        public string EmploymentStatus
        {
            get { return employmentStatus; }
            set { employmentStatus = value; }
        }

        public void viewAttendance()
        {
            MessageBox.Show("Displaying personal attendance summary for " + FullName + ".", "Employee Self-Service");
        }

        public void viewPayroll()
        {
            MessageBox.Show("Displaying historical payroll records for " + FullName + ".", "Employee Self-Service");
        }

        public override void getDashboardOptions()
        {
            EmployeeDashboardForm employeeForm = new EmployeeDashboardForm(this);
            employeeForm.ShowDialog();
        }
        public override string ToString()
        {
            return EmployeeId + " - " + FullName;
        }
    }
}