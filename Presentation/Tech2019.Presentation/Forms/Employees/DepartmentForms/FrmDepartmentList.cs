using System;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Employees.DepartmentForms
{
    public partial class FrmDepartmentList : Form
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public FrmDepartmentList(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            InitializeComponent();
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {
            LoadDepartmentList();
            ClearDepartmentInfo();
            ShowDepartmentListStatsByLinq();
            gvwDepartments.OptionsBehavior.Editable = false;
        }
        private void gvwDepartments_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDepartmentDescription.Text = gvwDepartments.GetFocusedRowCellValue("DepartmentDescription").ToString();
            txtDepartmentId.Text = gvwDepartments.GetFocusedRowCellValue("DepartmentId").ToString();
            txtDepartmentName.Text = gvwDepartments.GetFocusedRowCellValue("DepartmentName").ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDepartmentList();
            ClearDepartmentInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartmentInfo())
                return;

            Department department = new Department();
            AssignDepartmentInfo(department);
            _departmentService.Create(department);
            MessageBox.Show("Department Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDepartmentList();
            ClearDepartmentInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartmentId())
                return;

            int id = int.Parse(txtDepartmentId.Text);
            var department = _departmentService.GetById(id);
            _departmentService.Delete(department);
            MessageBox.Show("Department Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            LoadDepartmentList();
            ClearDepartmentInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartmentId())
                return;

            if (!ValidateDepartmentInfo())
                return;

            int id = int.Parse(txtDepartmentId.Text);
            var department = _departmentService.GetById(id);
            AssignDepartmentInfo(department);
            _departmentService.Update(department);
            MessageBox.Show("Department Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadDepartmentList();
            ClearDepartmentInfo();
        }

        #region Extracted Methods

        private void ShowDepartmentListStatsByLinq()
        {
            lblTotalDepartmentStat.Text = _departmentService.GetDepartmentCount().ToString();
            lblTotalEmployeeStat.Text = _employeeService.GetEmployeeCount().ToString();
            lblMaxEmployeeDepartmentStat.Text = _employeeService.GetMaxEmployeeDepartment();
            lblMinEmployeeDepartmentStat.Text = _employeeService.GetMinEmployeeDepartment();
        }

        private void ClearDepartmentInfo()
        {
            txtDepartmentDescription.Text = string.Empty;
            txtDepartmentId.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
        }

        private void LoadDepartmentList()
        {
            var values = _departmentService.GetDepartments();
            grcDepartmentList.DataSource = values;
        }

        private void AssignDepartmentInfo(Department departmant)
        {
            departmant.DepartmentName = txtDepartmentName.Text;
            departmant.DepartmentDescription = txtDepartmentDescription.Text;
        }

        #endregion
        
        #region Validation Methods

        private bool ValidateDepartmentInfo()
        {
            if (string.IsNullOrWhiteSpace(txtDepartmentName.Text))
            {
                MessageBox.Show("Department Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDepartmentDescription.Text))
            {
                MessageBox.Show("Description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateDepartmentId()
        {
            if (string.IsNullOrWhiteSpace(txtDepartmentId.Text))
            {
                MessageBox.Show("Department ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!byte.TryParse(txtDepartmentId.Text, out _))
            {
                MessageBox.Show("Department ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
    }
}
