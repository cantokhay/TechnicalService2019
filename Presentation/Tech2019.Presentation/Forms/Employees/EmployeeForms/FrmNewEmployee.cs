using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Employees.EmployeeForms
{
    public partial class FrmNewEmployee : Form
    {
        public FrmNewEmployee()
        {
            InitializeComponent();
            FillLookUpEditDepartments();
            InitializePlaceholderEvents();
        }

        TechDBContext db = new TechDBContext();

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeInfo())
                return;

            Employee employee = new Employee();
            AssignEmployeeInfo(employee);
            db.Employees.Add(employee);
            db.SaveChanges();
            MessageBox.Show("Employee added successfully");
            this.Close();
        }

        private void btnNewQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Exracted Methods

        private void FillLookUpEditDepartments()
        {
            var departmentsList = db.Departments.Select(x => new
            {
                x.DepartmentId,
                x.DepartmentName
            }).ToList();
            lueEmployeeDepartments.Properties.DataSource = departmentsList;
            lueEmployeeDepartments.Properties.NullText = "Please pick a value";
        }

        private void AssignEmployeeInfo(Employee employee)
        {
            employee.EmployeeFirstName = txtEmployeeFirstName.Text;
            employee.EmployeeLastName = txtEmployeeLastName.Text;
            employee.EmployeeMail = txtEmployeeEmail.Text;
            employee.EmployeePhoneNumber = txtEmployeePhoneNumber.Text;
            employee.EmployeeProfilePhoto = txtEmployeePhoto.Text;
            employee.Department = byte.Parse(lueEmployeeDepartments.EditValue.ToString());
        }

        private bool ValidateEmployeeInfo()
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeFirstName.Text) || txtEmployeeFirstName.Text == "First Name")
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeeLastName.Text) || txtEmployeeLastName.Text == "Last Name")
            {
                MessageBox.Show("Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeeEmail.Text) || txtEmployeeEmail.Text == "Mail")
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeePhoneNumber.Text) || txtEmployeePhoneNumber.Text == "Phone Number")
            {
                MessageBox.Show("Phone Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeePhoto.Text) || txtEmployeePhoto.Text == "Profile Photo Link")
            {
                MessageBox.Show("Photo Link cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (lueEmployeeDepartments.EditValue == null)
            {
                MessageBox.Show("Please select a Department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtEmployeeFirstName, "First Name");
            AddPlaceholderEvents(txtEmployeeLastName, "Last Name");
            AddPlaceholderEvents(txtEmployeeEmail, "Mail");
            AddPlaceholderEvents(txtEmployeePhoneNumber, "Phone Number");
            AddPlaceholderEvents(txtEmployeePhoneNumber, "Profile Photo Link");
        }

        private void AddPlaceholderEvents(DevExpress.XtraEditors.TextEdit textEdit, string placeholder)
        {
            textEdit.GotFocus += (sender, e) =>
            {
                if (textEdit.Text == placeholder)
                {
                    textEdit.Text = string.Empty;
                }
            };

            textEdit.LostFocus += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textEdit.Text))
                {
                    textEdit.Text = placeholder;
                }
            };
        }

        #endregion
    }
}
