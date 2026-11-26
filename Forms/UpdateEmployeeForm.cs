
using System;
using System.Drawing;
using System.Windows.Forms;

namespace tagUMpay
{
    // WINDOW 1: EMPLOYEE LIST
    public class UpdateEmployeeForm : Form
    {
        private TextBox txtSearch;
        private DataGridView dgvEmployees;

        public UpdateEmployeeForm()
        {
            SetupUI();
            LoadEmployees();
        }

        private void SetupUI()
        {
            Text = "tagUMpay - Update Employee";
            Size = new Size(850, 520);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;

            Label lblTitle = new Label
            {
                Text = "Update Employee",
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
                Text = "Click an employee row to update their information.",
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

                    // Keep the actual employee object in the row.
                    dgvEmployees.Rows[rowIndex].Tag = emp;
                }
            }
        }

        // OPEN THE SELECTED EMPLOYEE
        private void DgvEmployees_CellClick(
            object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Employee selectedEmployee =
                dgvEmployees.Rows[e.RowIndex].Tag as Employee;

            if (selectedEmployee == null)
                return;

            using (EditEmployeeDetailsForm editForm =
                new EditEmployeeDetailsForm(selectedEmployee))
            {
                editForm.ShowDialog(this);
            }

            // Refresh the list after updating.
            LoadEmployees();
        }
    }


    // WINDOW 2: EDIT EMPLOYEE DETAILS
    public class EditEmployeeDetailsForm : Form
    {
        private readonly Employee selectedEmployee;

        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private TextBox txtOtherExtension;
        private TextBox txtPositionId;
        private TextBox txtContactInfo;
        private TextBox txtUsername;
        private TextBox txtPassword;

        private ComboBox cmbExtension;
        private ComboBox cmbStatus;

        private Panel pnlContent;

        public EditEmployeeDetailsForm(Employee employee)
        {
            selectedEmployee = employee;

            SetupUI();
            LoadEmployeeDetails();
        }

        private void SetupUI()
        {
            Text = "tagUMpay - Edit Employee";
            Size = new Size(450, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMinSize = new Size(0, 900)
            };

            Controls.Add(pnlContent);

            Label lblTitle = new Label
            {
                Text = "Update Employee Details",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 28, 28),
                Location = new Point(25, 20),
                AutoSize = true
            };

            pnlContent.Controls.Add(lblTitle);

            // Employee ID (READ ONLY)
            AddLabel("Employee ID (Cannot be changed)", 30, 75);

            TextBox txtEmployeeId = AddTextBox(30, 100);
            txtEmployeeId.ReadOnly = true;
            txtEmployeeId.Text = selectedEmployee.EmployeeId.ToString();
            txtEmployeeId.BackColor = Color.LightGray;

            AddLabel("First Name", 30, 140);
            txtFirstName = AddTextBox(30, 165);

            AddLabel("Middle Name (Optional)", 30, 205);
            txtMiddleName = AddTextBox(30, 230);

            AddLabel("Last Name", 30, 270);
            txtLastName = AddTextBox(30, 295);

            AddLabel("Name Extension", 30, 335);

            cmbExtension = new ComboBox
            {
                Location = new Point(30, 360),
                Width = 360,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };

            cmbExtension.Items.AddRange(new object[]
            {
                "None", "Jr.", "Sr.", "II", "III", "IV", "Other"
            });

            cmbExtension.SelectedIndex = 0;
            cmbExtension.SelectedIndexChanged +=
                CmbExtension_SelectedIndexChanged;

            pnlContent.Controls.Add(cmbExtension);

            AddLabel("Enter Other Extension", 30, 395);
            txtOtherExtension = AddTextBox(30, 420);
            txtOtherExtension.Visible = false;
            txtOtherExtension.Enabled = false;

            AddLabel("Position ID", 30, 460);
            txtPositionId = AddTextBox(30, 485);

            AddLabel("Contact Information", 30, 525);
            txtContactInfo = AddTextBox(30, 550);

            AddLabel("Employment Status", 30, 590);

            cmbStatus = new ComboBox
            {
                Location = new Point(30, 615),
                Width = 360,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };

            cmbStatus.Items.AddRange(new object[]
            {
                "Regular",
                "Probationary",
                "Contractual",
                "Part-Time"
            });

            pnlContent.Controls.Add(cmbStatus);

            AddLabel("Username", 30, 655);
            txtUsername = AddTextBox(30, 680);

            AddLabel("New Password (Leave blank to keep current password)", 30, 720);
            txtPassword = AddTextBox(30, 745);
            txtPassword.UseSystemPasswordChar = true;

            Button btnUpdate = new Button
            {
                Text = "UPDATE EMPLOYEE",
                Location = new Point(30, 805),
                Size = new Size(175, 40),
                BackColor = Color.FromArgb(122, 28, 28),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnUpdate.Click += BtnUpdate_Click;

            Button btnCancel = new Button
            {
                Text = "CANCEL",
                Location = new Point(215, 805),
                Size = new Size(175, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };

            btnCancel.Click += (s, e) => Close();

            pnlContent.Controls.Add(btnUpdate);
            pnlContent.Controls.Add(btnCancel);
        }

        private void LoadEmployeeDetails()
        {
            txtFirstName.Text = selectedEmployee.FirstName;
            txtMiddleName.Text = selectedEmployee.MiddleName;
            txtLastName.Text = selectedEmployee.LastName;

            txtPositionId.Text =
                selectedEmployee.PositionId.ToString();

            txtContactInfo.Text = selectedEmployee.ContactInfo;
            txtUsername.Text = selectedEmployee.Username;

            cmbStatus.SelectedItem =
                selectedEmployee.EmploymentStatus;

            string extension = selectedEmployee.NameExtension;

            if (string.IsNullOrWhiteSpace(extension))
            {
                cmbExtension.SelectedItem = "None";
            }
            else if (cmbExtension.Items.Contains(extension))
            {
                cmbExtension.SelectedItem = extension;
            }
            else
            {
                cmbExtension.SelectedItem = "Other";
                txtOtherExtension.Text = extension;
            }
        }

        private void CmbExtension_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            bool isOther =
                cmbExtension.SelectedItem?.ToString() == "Other";

            txtOtherExtension.Visible = isOther;
            txtOtherExtension.Enabled = isOther;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            // VALIDATE REQUIRED FIELDS
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPositionId.Text) ||
                string.IsNullOrWhiteSpace(txtContactInfo.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please complete all required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (cmbExtension.SelectedItem?.ToString() == "Other" &&
                string.IsNullOrWhiteSpace(txtOtherExtension.Text))
            {
                MessageBox.Show(
                    "Please enter the custom name extension."
                );

                return;
            }

            // VALIDATE POSITION ID
            int positionId;

            if (!int.TryParse(txtPositionId.Text, out positionId) ||
                positionId <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid Position ID."
                );

                return;
            }

            // CREATE UPDATED EMPLOYEE OBJECT
            Employee updatedEmployee = new Employee();

            updatedEmployee.EmployeeId =
                selectedEmployee.EmployeeId;

            updatedEmployee.UserId =
                selectedEmployee.UserId;

            updatedEmployee.FirstName = txtFirstName.Text.Trim();
            updatedEmployee.MiddleName = txtMiddleName.Text.Trim();
            updatedEmployee.LastName = txtLastName.Text.Trim();

            if (cmbExtension.SelectedItem?.ToString() == "Other")
            {
                updatedEmployee.NameExtension =
                    txtOtherExtension.Text.Trim();
            }
            else if (cmbExtension.SelectedItem?.ToString() == "None")
            {
                updatedEmployee.NameExtension = "";
            }
            else
            {
                updatedEmployee.NameExtension =
                    cmbExtension.SelectedItem?.ToString() ?? "";
            }

            updatedEmployee.PositionId = positionId;

            updatedEmployee.ContactInfo =
                txtContactInfo.Text.Trim();

            updatedEmployee.EmploymentStatus =
                cmbStatus.Text;

            updatedEmployee.Username =
                txtUsername.Text.Trim();

            // Blank password means keep the existing password.
            updatedEmployee.PasswordHash =
                txtPassword.Text;

            // UPDATE TEMPORARY STORAGE
            bool result =
                EmployeeManager.UpdateEmployee(updatedEmployee);

            if (result)
            {
                MessageBox.Show(
                    "Employee information successfully updated!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Employee not found or username already exists. " +
                    "Please check your information.",
                    "Update Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void AddLabel(string text, int x, int y)
        {
            Label label = new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            pnlContent.Controls.Add(label);
        }

        private TextBox AddTextBox(int x, int y)
        {
            TextBox textBox = new TextBox
            {
                Location = new Point(x, y),
                Width = 360,
                Font = new Font("Segoe UI", 10)
            };

            pnlContent.Controls.Add(textBox);

            return textBox;
        }
    }
}

