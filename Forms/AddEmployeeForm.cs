
using System;
using System.Drawing;
using System.Windows.Forms;

namespace tagUMpay
{
    public class AddEmployeeForm : Form
    {
        private TextBox txtFirstName;
        private TextBox txtMiddleName;
        private TextBox txtLastName;
        private TextBox txtOtherExtension;
        private ComboBox cmbExtension;
        private TextBox txtPositionId;
        private TextBox txtContactInfo;
        private TextBox txtUsername;
        private TextBox txtPassword;

        private ComboBox cmbStatus;

        private Button btnSave;
        private Button btnCancel;

        private Panel pnlContent;

        public AddEmployeeForm()
        {
            SetupUI();
        }

        private void CmbExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isOther = cmbExtension.SelectedItem?.ToString() == "Other";

            txtOtherExtension.Visible = isOther;
            txtOtherExtension.Enabled = isOther;
        }

        private void SetupUI()
        {
            Text = "tagUMpay - Add Employee";
            Size = new Size(450, 650);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                AutoScrollMinSize = new Size(0, 780)
            };

            Controls.Add(pnlContent);

            Label lblTitle = new Label
            {
                Text = "Add New Employee",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(122, 28, 28),
                Location = new Point(30, 20),
                AutoSize = true
            };

            pnlContent.Controls.Add(lblTitle);

            // First Name
            AddLabel("First Name", 30, 80);
            txtFirstName = AddTextBox(30, 105);

            // Middle Name
            AddLabel("Middle Name (Optional)", 30, 145);
            txtMiddleName = AddTextBox(30, 170);

            // Last Name
            AddLabel("Last Name", 30, 210);
            txtLastName = AddTextBox(30, 235);

            // Name Extension
            AddLabel("Name Extension", 30, 275);

            cmbExtension = new ComboBox
            {
                Location = new Point(30, 300),
                Width = 360,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };

            cmbExtension.Items.AddRange(new object[]
            {
    "None", "Jr.", "Sr.", "II", "III", "IV", "Other"
            });

            cmbExtension.SelectedIndex = 0;
            cmbExtension.SelectedIndexChanged += CmbExtension_SelectedIndexChanged;

            pnlContent.Controls.Add(cmbExtension);

            // Custom Extension
            txtOtherExtension = AddTextBox(30, 360);
            AddLabel("Enter Other Extension", 30, 335);
            txtOtherExtension.Visible = false;
            txtOtherExtension.Enabled = false;

            // Position ID
            AddLabel("Position ID", 30, 410);

            txtPositionId = AddTextBox(30, 435);

            // Contact Information
            AddLabel("Contact Information", 30, 475);

            txtContactInfo = AddTextBox(30, 500);

            // Employment Status
            AddLabel("Employment Status", 30, 540);

            cmbStatus = new ComboBox
            {
                Location = new Point(30, 565),
                Width = 360,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10)
            };

            cmbStatus.Items.Add("Regular");
            cmbStatus.Items.Add("Probationary");
            cmbStatus.Items.Add("Contractual");
            cmbStatus.Items.Add("Part-Time");

            cmbStatus.SelectedIndex = 0;

            pnlContent.Controls.Add(cmbStatus);

            // Username
            AddLabel("Username", 30, 605);

            txtUsername = AddTextBox(30, 630);

            // Password
            AddLabel("Password", 30, 670);

            txtPassword = AddTextBox(30, 695);
            txtPassword.UseSystemPasswordChar = true;

            // Save Button
            btnSave = new Button
            {
                Text = "SAVE EMPLOYEE",
                Location = new Point(30, 740),
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
                Location = new Point(215, 740),
                Size = new Size(175, 40),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat
            };

            btnCancel.Click += (s, e) => Close();

            pnlContent.Controls.Add(btnSave);
            pnlContent.Controls.Add(btnCancel);
            pnlContent.AutoScroll = false;
            pnlContent.AutoScroll = true;
            pnlContent.AutoScrollMinSize = new Size(0, 800);

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

            pnlContent.Controls.Add(label);
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

            pnlContent.Controls.Add(textBox);

            return textBox;
        }

        // SAVE EMPLOYEE
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtPositionId.Text) ||
                string.IsNullOrWhiteSpace(txtContactInfo.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please complete all required fields.");
                return;
            }

            if (cmbExtension.SelectedItem?.ToString() == "Other" &&
                string.IsNullOrWhiteSpace(txtOtherExtension.Text))
            {
                MessageBox.Show("Please enter the custom name extension.");
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

            newEmployee.FirstName = txtFirstName.Text.Trim();
            newEmployee.MiddleName = txtMiddleName.Text.Trim();
            newEmployee.LastName = txtLastName.Text.Trim();

            if (cmbExtension.SelectedItem?.ToString() == "Other")
            {
                newEmployee.NameExtension = txtOtherExtension.Text.Trim();
            }
            else if (cmbExtension.SelectedItem?.ToString() == "None")
            {
                newEmployee.NameExtension = "";
            }
            else
            {
                newEmployee.NameExtension = cmbExtension.SelectedItem?.ToString() ?? "";
            }

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

