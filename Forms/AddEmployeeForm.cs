
using System;
using System.Drawing;
using System.Windows.Forms;

namespace tagUMpay
{
    public class AddEmployeeForm : Form
    {
        private TextBox txtFullName;
        private TextBox txtPositionId;
        private TextBox txtContactInfo;
        private TextBox txtUsername;
        private TextBox txtPassword;

        private ComboBox cmbStatus;

        private Button btnSave;
        private Button btnCancel;

        public AddEmployeeForm()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            Text = "tagUMpay - Add Employee";
            Size = new Size(450, 570);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            Label lblTitle = new Label
            {
                Text = "Add New Employee",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 28, 28),
                Location = new Point(30, 20),
                AutoSize = true
            };

            Controls.Add(lblTitle);

            // Full Name
            AddLabel("Full Name", 30, 80);

            txtFullName = AddTextBox(30, 105);

            // Position ID
            AddLabel("Position ID", 30, 145);

            txtPositionId = AddTextBox(30, 170);

            // Contact Information
            AddLabel("Contact Information", 30, 210);

            txtContactInfo = AddTextBox(30, 235);

            // Employment Status
            AddLabel("Employment Status", 30, 275);

            cmbStatus = new ComboBox
            {
                Location = new Point(30, 300),
                Width = 360,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };

            cmbStatus.Items.Add("Regular");
            cmbStatus.Items.Add("Probationary");
            cmbStatus.Items.Add("Contractual");
            cmbStatus.Items.Add("Part-Time");

            cmbStatus.SelectedIndex = 0;

            Controls.Add(cmbStatus);

            // Username
            AddLabel("Username", 30, 340);

            txtUsername = AddTextBox(30, 365);

            // Password
            AddLabel("Password", 30, 405);

            txtPassword = AddTextBox(30, 430);
            txtPassword.UseSystemPasswordChar = true;

            // Save Button
            btnSave = new Button
            {
                Text = "SAVE EMPLOYEE",
                Location = new Point(30, 475),
                Size = new Size(175, 40),
                BackColor = Color.FromArgb(122, 28, 28),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            btnSave.Click += BtnSave_Click;

            // Cancel Button
            btnCancel = new Button
            {
                Text = "CANCEL",
                Location = new Point(215, 475),
                Size = new Size(175, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };

            btnCancel.Click += (s, e) => Close();

            Controls.Add(btnSave);
            Controls.Add(btnCancel);
        }

        // Creates a label
        private void AddLabel(string text, int x, int y)
        {
            Label label = new Label
            {
                Text = text,
                Location = new Point(x, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9)
            };

            Controls.Add(label);
        }

        // Creates a textbox
        private TextBox AddTextBox(int x, int y)
        {
            TextBox textBox = new TextBox
            {
                Location = new Point(x, y),
                Width = 360,
                Font = new Font("Segoe UI", 10)
            };

            Controls.Add(textBox);

            return textBox;
        }

        // SAVE EMPLOYEE
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPositionId.Text) ||
                string.IsNullOrWhiteSpace(txtContactInfo.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            // Check if Position ID is a valid number
            int positionId;

            if (!int.TryParse(txtPositionId.Text, out positionId) ||
                positionId <= 0)
            {
                MessageBox.Show("Please enter a valid Position ID.");
                return;
            }

            // Create a new employee object
            Employee newEmployee = new Employee();

            newEmployee.FullName = txtFullName.Text.Trim();
            newEmployee.PositionId = positionId;
            newEmployee.ContactInfo = txtContactInfo.Text.Trim();
            newEmployee.EmploymentStatus = cmbStatus.Text;
            newEmployee.Username = txtUsername.Text.Trim();
            newEmployee.PasswordHash = txtPassword.Text;

            // Save the employee
            bool result = EmployeeManager.AddEmployee(newEmployee);

            if (result)
            {
                MessageBox.Show(
                    "Employee successfully added!\nEmployee ID: " +
                    newEmployee.EmployeeId,
                    "Success"
                );

                Close();
            }
            else
            {
                MessageBox.Show(
                    "Username already exists. Please use another username."
                );
            }
        }
    }
}

