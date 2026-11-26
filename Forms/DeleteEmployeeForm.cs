
using System;
using System.Drawing;
using System.Windows.Forms;

namespace tagUMpay
{
    // WINDOW 1: EMPLOYEE LIST
    public class DeleteEmployeeForm : Form
    {
        private TextBox txtSearch;
        private DataGridView dgvEmployees;

        public DeleteEmployeeForm()
        {
            SetupUI();
            LoadEmployees();
        }

        private void SetupUI()
        {
            Text = "tagUMpay - Delete Employee";
            Size = new Size(850, 520);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Delete Employee",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 28, 28),
                Location = new Point(25, 20),
                AutoSize = true
            };

            Label lblSearch = new Label
            {
                Text = "Search Employee (Name or ID):",
                Location = new Point(25, 75),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            txtSearch = new TextBox
            {
                Location = new Point(25, 100),
                Width = 780,
                Font = new Font("Segoe UI", 10)
            };

            txtSearch.TextChanged += (s, e) => LoadEmployees();

            dgvEmployees = new DataGridView
            {
                Location = new Point(25, 145),
                Size = new Size(780, 300),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                BackgroundColor = Color.White,
                Font = new Font("Segoe UI", 9),
                AutoGenerateColumns = false
            };

            dgvEmployees.Columns.Add("EmployeeId", "Employee ID");
            dgvEmployees.Columns.Add("FullName", "Full Name");
            dgvEmployees.Columns.Add("PositionId", "Position ID");
            dgvEmployees.Columns.Add("ContactInfo", "Contact");
            dgvEmployees.Columns.Add("EmploymentStatus", "Employment Status");

            dgvEmployees.CellClick += DgvEmployees_CellClick;

            Label lblInstruction = new Label
            {
                Text = "Click an employee row to view their information.",
                Location = new Point(25, 455),
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 8)
            };

            Controls.Add(lblTitle);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvEmployees);
            Controls.Add(lblInstruction);
        }

        // LOAD AND SEARCH EMPLOYEES
        private void LoadEmployees()
        {
            dgvEmployees.Rows.Clear();

            string keyword = txtSearch.Text.Trim();

            foreach (Employee emp in EmployeeManager.GetAllEmployees())
            {
                bool matches =
                    emp.EmployeeId.ToString().Contains(keyword) ||
                    emp.FullName.IndexOf(
                        keyword,
                        StringComparison.OrdinalIgnoreCase) >= 0;

                if (matches)
                {
                    int rowIndex = dgvEmployees.Rows.Add(
                        emp.EmployeeId,
                        emp.FullName,
                        emp.PositionId,
                        emp.ContactInfo,
                        emp.EmploymentStatus
                    );

                    dgvEmployees.Rows[rowIndex].Tag = emp;
                }
            }
        }

        // OPEN SELECTED EMPLOYEE DETAILS
        private void DgvEmployees_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Employee selectedEmployee =
                dgvEmployees.Rows[e.RowIndex].Tag as Employee;

            if (selectedEmployee == null)
                return;

            using (DeleteEmployeeDetailsForm deleteForm =
                new DeleteEmployeeDetailsForm(selectedEmployee))
            {
                deleteForm.ShowDialog(this);
            }

            // Refresh the list after deletion.
            LoadEmployees();
        }
    }


    // WINDOW 2: EMPLOYEE INFORMATION AND DELETE
    public class DeleteEmployeeDetailsForm : Form
    {
        private readonly Employee selectedEmployee;

        public DeleteEmployeeDetailsForm(Employee employee)
        {
            selectedEmployee = employee;

            SetupUI();
        }

        private void SetupUI()
        {
            Text = "tagUMpay - Employee Information";
            Size = new Size(470, 530);
            StartPosition = FormStartPosition.CenterParent;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTitle = new Label
            {
                Text = "Employee Information",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 28, 28),
                Location = new Point(25, 20),
                AutoSize = true
            };

            GroupBox grpDetails = new GroupBox
            {
                Text = "Employee Details",
                Location = new Point(25, 75),
                Size = new Size(405, 340),
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };

            string details =
                "Employee ID: " + selectedEmployee.EmployeeId + "\n\n" +
                "First Name: " + selectedEmployee.FirstName + "\n\n" +
                "Middle Name: " + selectedEmployee.MiddleName + "\n\n" +
                "Last Name: " + selectedEmployee.LastName + "\n\n" +
                "Name Extension: " + selectedEmployee.NameExtension + "\n\n" +
                "Full Name: " + selectedEmployee.FullName + "\n\n" +
                "Position ID: " + selectedEmployee.PositionId + "\n\n" +
                "Contact Information: " + selectedEmployee.ContactInfo + "\n\n" +
                "Employment Status: " + selectedEmployee.EmploymentStatus + "\n\n" +
                "Username: " + selectedEmployee.Username;

            Label lblDetails = new Label
            {
                Text = details,
                Location = new Point(15, 30),
                Size = new Size(375, 295),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            grpDetails.Controls.Add(lblDetails);

            Button btnDelete = new Button
            {
                Text = "DELETE EMPLOYEE",
                Location = new Point(25, 430),
                Size = new Size(195, 40),
                BackColor = Color.FromArgb(122, 28, 28),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnDelete.Click += BtnDelete_Click;

            Button btnCancel = new Button
            {
                Text = "CANCEL",
                Location = new Point(235, 430),
                Size = new Size(195, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };

            btnCancel.Click += (s, e) => Close();

            Controls.Add(lblTitle);
            Controls.Add(grpDetails);
            Controls.Add(btnDelete);
            Controls.Add(btnCancel);
        }

        // DELETE CONFIRMATION
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show(
                "Are you sure you want to delete this employee?\n\n" +
                "Employee ID: " + selectedEmployee.EmployeeId + "\n" +
                "Employee Name: " + selectedEmployee.FullName,
                "Confirm Employee Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmation == DialogResult.Yes)
            {
                bool result = EmployeeManager.DeleteEmployee(
                    selectedEmployee.EmployeeId
                );

                if (result)
                {
                    MessageBox.Show(
                        "Employee successfully deleted!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    Close();
                }
                else
                {
                    MessageBox.Show(
                        "Unable to delete employee. Employee record not found.",
                        "Delete Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }
    }
}

