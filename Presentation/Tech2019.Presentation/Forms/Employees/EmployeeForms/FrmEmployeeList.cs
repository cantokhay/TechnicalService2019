using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Employees.EmployeeForms
{
    public partial class FrmEmployeeList : Form
    {
        public FrmEmployeeList()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmEmployeeList_Load(object sender, EventArgs e)
        {
            EmployeeList();
            FillLookUpEditDepartments();
            FillProfileCards();
            ClearEmployeeInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            AssignEmployeeInfo(employee);
            db.Employees.Add(employee);
            db.SaveChanges();
            MessageBox.Show("Employee Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearEmployeeInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtEmployeeId.Text);
            var employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            MessageBox.Show("Employee Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ClearEmployeeInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtEmployeeId.Text);
            var employee = db.Employees.Find(id);

            if (employee != null)
            {
                AssignEmployeeInfo(employee);
                db.SaveChanges();
                MessageBox.Show("Employee Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Employee Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearEmployeeInfo();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            EmployeeList();
            ClearEmployeeInfo();
        }

        private void gvwEmployee_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gvwEmployee.GetFocusedRowCellValue("EmployeeId") != null)
            {
                txtEmployeeId.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeId").ToString();
                txtEmployeeFirstName.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeFirstName").ToString();
                txtEmployeeLastName.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeLastName").ToString();
                txtEmployeeEmail.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeMail").ToString();
                txtEmployeePhoneNumber.Text = gvwEmployee.GetFocusedRowCellValue("EmployeePhoneNumber").ToString();
                txtEmployeePhoto.Text = gvwEmployee.GetFocusedRowCellValue("EmployeeProfilePhoto").ToString();

                var departmentId = gvwEmployee.GetFocusedRowCellValue("DepartmentId");
                if (departmentId != null)
                {
                    lueEmployeeDepartments.EditValue = Convert.ToInt32(departmentId);
                }
                else
                {
                    lueEmployeeDepartments.EditValue = null;
                }
            }
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
            var departmentsList = db.Departments.Select(x => new
            {
                x.DepartmentId,
                x.DepartmentName
            }).ToList();
            lueEmployeeDepartments.Properties.DataSource = departmentsList;
        }

        private void FillProfileCards()
        {
            var employee1 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentName == "HR");
            var employee2 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentName == "Sales");
            var employee3 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentName == "Marketing");
            var employee4 = db.Employees.FirstOrDefault(x => x.DepartmentNavigation.DepartmentName == "Production");

            lblEmployeeFullName1.Text = $"{employee1.EmployeeFirstName} {employee1.EmployeeLastName}";
            lblEmployeeMail1.Text = employee1.EmployeeMail;
            lblEmployeePhone1.Text = employee1.EmployeePhoneNumber;
            lblEmployeeDepartment1.Text = db.Departments.FirstOrDefault(x => x.DepartmentId == employee1.Department).DepartmentName;
            picEmployee1.Image = GetImageFromUrl(employee1.EmployeeProfilePhoto);

            lblEmployeeFullName2.Text = $"{employee2.EmployeeFirstName} {employee2.EmployeeLastName}";
            lblEmployeeMail2.Text = employee2.EmployeeMail;
            lblEmployeePhone2.Text = employee2.EmployeePhoneNumber;
            lblEmployeeDepartment2.Text = db.Departments.FirstOrDefault(x => x.DepartmentId == employee2.Department).DepartmentName;
            picEmployee2.Image = GetImageFromUrl(employee2.EmployeeProfilePhoto);

            lblEmployeeFullName3.Text = $"{employee3.EmployeeFirstName} {employee3.EmployeeLastName}";
            lblEmployeeMail3.Text = employee3.EmployeeMail;
            lblEmployeePhone3.Text = employee3.EmployeePhoneNumber;
            lblEmployeeDepartment3.Text = db.Departments.FirstOrDefault(x => x.DepartmentId == employee3.Department).DepartmentName;
            picEmployee3.Image = GetImageFromUrl(employee3.EmployeeProfilePhoto);

            lblEmployeeFullName4.Text = $"{employee4.EmployeeFirstName} {employee4.EmployeeLastName}";
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

        private void EmployeeList()
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
    }
}
