using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Employees.EmployeeForms
{
    public partial class FrmEmployeeList : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
            FillLookUpEditDepartments();
            FillProfileCards();
            ClearEmployeeInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeInfo())
                return;

            Employee employee = new Employee();
            AssignEmployeeInfo(employee);
            _employeeService.Create(employee);
            MessageBox.Show("Employee Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEmployeeList();
            ClearEmployeeInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeId())
                return;

            int id = int.Parse(txtEmployeeId.Text);
            var employee = _employeeService.GetById(id);
            _employeeService.Delete(employee);
            MessageBox.Show("Employee Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadEmployeeList();
            ClearEmployeeInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateEmployeeId())
                return;

            if (!ValidateEmployeeInfo())
                return;

            int id = int.Parse(txtEmployeeId.Text);
            var employee = _employeeService.GetById(id);
            AssignEmployeeInfo(employee);
            _employeeService.Update(employee);
            MessageBox.Show("Employee Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadEmployeeList();
            ClearEmployeeInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployeeList();
            ClearEmployeeInfo();
        }

        private void gvwEmployee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtEmployeeId.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeId").ToString();
            txtEmployeeFirstName.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeFirstName").ToString();
            txtEmployeeLastName.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeLastName").ToString();
            txtEmployeeEmail.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeMail").ToString();
            txtEmployeePhoneNumber.Text = gvwEmployee.GetFocusedRowCellValue("EmployeePhoneNumber").ToString();
            txtEmployeePhoto.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeProfilePhoto").ToString();
            var departmentId = gvwEmployee.GetFocusedRowCellValue("DepartmentId");
            lueEmployeeDepartments.EditValue = departmentId;
        }

        #region ExtractedMethods

        private void ClearEmployeeInfo()
        {
            txtEmployeeId.Text = string.Empty;
            txtEmployeeFirstName.Text = string.Empty;
            txtEmployeeLastName.Text = string.Empty;
            txtEmployeeEmail.Text = string.Empty;
            txtEmployeePhoneNumber.Text = string.Empty;
            txtEmployeePhoto.Text = string.Empty;
            lueEmployeeDepartments.EditValue = null;
        }

        private void FillLookUpEditDepartments()
        {
            var departmentsList = _departmentService.GetDepartments();
            lueEmployeeDepartments.Properties.DataSource = departmentsList;
            lueEmployeeDepartments.Properties.NullText = "Please pick a value";
        }

        private void FillProfileCards()
        {
            var employee1 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentId == 1);
            var employee2 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentId == 2);
            var employee3 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentId == 3);
            var employee4 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentId == 4);

            lblEmployeeFullName1.Text = employee1.EmployeeFirstName + " " + employee1.EmployeeLastName;
            lblEmployeeMail1.Text = employee1.EmployeeMail;
            lblEmployeePhone1.Text = employee1.EmployeePhoneNumber;
            lblEmployeeDepartment1.Text = db.Departments.FirstOrDefault(x => x.DepartmentId == employee1.Department).DepartmentName;
            picEmployee1.Image = GetImageFromUrl(employee1.EmployeeProfilePhoto);

            lblEmployeeFullName2.Text = employee2.EmployeeFirstName + " " + employee2.EmployeeLastName; ;
            lblEmployeeMail2.Text = employee2.EmployeeMail;
            lblEmployeePhone2.Text = employee2.EmployeePhoneNumber;
            lblEmployeeDepartment2.Text = db.Departments.FirstOrDefault(x => x.DepartmentId == employee2.Department).DepartmentName;
            picEmployee2.Image = GetImageFromUrl(employee2.EmployeeProfilePhoto);

            lblEmployeeFullName3.Text = employee3.EmployeeFirstName + " " + employee3.EmployeeLastName; ;
            lblEmployeeMail3.Text = employee3.EmployeeMail;
            lblEmployeePhone3.Text = employee3.EmployeePhoneNumber;
            lblEmployeeDepartment3.Text = db.Departments.FirstOrDefault(x => x.DepartmentId == employee3.Department).DepartmentName;
            picEmployee3.Image = GetImageFromUrl(employee3.EmployeeProfilePhoto);

            lblEmployeeFullName4.Text = employee4.EmployeeFirstName + " " + employee4.EmployeeLastName; ;
            lblEmployeeMail4.Text = employee4.EmployeeMail;
            lblEmployeePhone4.Text = employee4.EmployeePhoneNumber;
            lblEmployeeDepartment4.Text = db.Departments.FirstOrDefault(x => x.DepartmentId == employee4.Department).DepartmentName;
            picEmployee4.Image = GetImageFromUrl(employee4.EmployeeProfilePhoto);
        }

        private Image GetImageFromUrl(string url)
        {
            using (var webClient = new System.Net.WebClient())
            {
                try
                {
                    byte[] imageBytes = webClient.DownloadData(url);
                    if (imageBytes == null || imageBytes.Length == 0)
                    {
                        throw new Exception("Downloaded data is empty.");
                    }

                    using (var ms = new System.IO.MemoryStream(imageBytes))
                    {
                        return Image.FromStream(ms);
                    }
                }
                catch
                {
                    return Image.FromFile("~\\images\\Trash Can.png");
                }
            }
        }

        private void LoadEmployeeList()
        {
            var employeeList = db.Employees.Select(x => new
            {
                x.EmployeeId,
                x.EmployeeFirstName,
                x.EmployeeLastName,
                x.EmployeeMail,
                x.EmployeePhoneNumber,
                x.EmployeeProfilePhoto,
                DepartmentName = x.DepartmentNavigation.DepartmentName,
                DepartmentId = x.Department
            }).ToList();

            grcEmployeeList.DataSource = employeeList;
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

        #endregion

        #region Validation Methods

        private bool ValidateEmployeeInfo()
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeFirstName.Text))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeeLastName.Text))
            {
                MessageBox.Show("Last Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeePhoneNumber.Text))
            {
                MessageBox.Show("Phone Number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeeEmail.Text))
            {
                MessageBox.Show("Email cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmployeePhoto.Text))
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

        private bool ValidateEmployeeId()
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeId.Text))
            {
                MessageBox.Show("Employee ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtEmployeeId.Text, out _))
            {
                MessageBox.Show("Employee ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
    }
}
