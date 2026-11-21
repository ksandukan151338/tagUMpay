
using System.Collections.Generic;

namespace tagUMpay
{
    public class EmployeeManager
    {
        // Temporary storage for employee records
        private static List<Employee> employees = new List<Employee>();

        // Automatically generates employee IDs
        private static int nextEmployeeId = 102;

        // ADD EMPLOYEE
        public static bool AddEmployee(Employee employee)
        {
            // Check if the username already exists
            foreach (Employee emp in employees)
            {
                if (emp.Username == employee.Username)
                {
                    return false;
                }
            }

            // Generate a new employee ID
            employee.EmployeeId = nextEmployeeId;
            employee.UserId = nextEmployeeId;

            // Increase the ID for the next employee
            nextEmployeeId++;

            // Add the employee to the list
            employees.Add(employee);

            return true;
        }

        // GET ALL EMPLOYEES
        public static List<Employee> GetAllEmployees()
        {
            return new List<Employee>(employees);
        }

        // FIND EMPLOYEE
        public static Employee GetEmployeeById(int employeeId)
        {
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeId == employeeId)
                {
                    return emp;
                }
            }

            return null;
        }

        // UPDATE EMPLOYEE
        public static bool UpdateEmployee(Employee updatedEmployee)
        {
            foreach (Employee emp in employees)
            {
                if (emp.EmployeeId == updatedEmployee.EmployeeId)
                {
                    // Check if another employee uses the username
                    foreach (Employee other in employees)
                    {
                        if (other.EmployeeId != emp.EmployeeId &&
                            other.Username == updatedEmployee.Username)
                        {
                            return false;
                        }
                    }

                    // Update employee information
                    emp.FullName = updatedEmployee.FullName;
                    emp.PositionId = updatedEmployee.PositionId;
                    emp.ContactInfo = updatedEmployee.ContactInfo;
                    emp.EmploymentStatus = updatedEmployee.EmploymentStatus;
                    emp.Username = updatedEmployee.Username;

                    // Only update password if a new one was entered
                    if (!string.IsNullOrWhiteSpace(updatedEmployee.PasswordHash))
                    {
                        emp.PasswordHash = updatedEmployee.PasswordHash;
                    }

                    return true;
                }
            }

            return false;
        }

        // DELETE EMPLOYEE
        public static bool DeleteEmployee(int employeeId)
        {
            Employee employee = GetEmployeeById(employeeId);

            if (employee != null)
            {
                employees.Remove(employee);
                return true;
            }

            return false;
        }
    }
}

