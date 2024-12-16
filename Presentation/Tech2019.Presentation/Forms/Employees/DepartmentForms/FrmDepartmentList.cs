using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Employees.DepartmentForms
{
    public partial class FrmDepartmentList : Form
    {
        public FrmDepartmentList()
        {
            InitializeComponent();
        }

        TechDBContext db = new TechDBContext();

        private void FrmDepartmentList_Load(object sender, EventArgs e)
        {
            DepartmentList();
            ClearDepartmentInfo();
            ShowDepartmentListStatsByLinq();
        }
        private void gvwDepartments_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            txtDepartmentDescription.Text = gvwDepartments.GetFocusedRowCellValue("DepartmentDescription").ToString();
            txtDepartmentId.Text = gvwDepartments.GetFocusedRowCellValue("DepartmentId").ToString();
            txtDepartmentName.Text = gvwDepartments.GetFocusedRowCellValue("DepartmentName").ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DepartmentList();
            ClearDepartmentInfo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartmentInfo())
                return;

            Department department = new Department();
            AssignDepartmentInfo(department);
            db.Departments.Add(department);
            db.SaveChanges();
            MessageBox.Show("Department Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DepartmentList();
            ClearDepartmentInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartmentId())
                return;

            int id = int.Parse(txtDepartmentId.Text);
            var department = db.Departments.Find(id);

            if (department == null)
            {
                MessageBox.Show("Department Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.Departments.Remove(department);
            db.SaveChanges();
            MessageBox.Show("Department Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            DepartmentList();
            ClearDepartmentInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateDepartmentId())
                return;

            if (!ValidateDepartmentInfo())
                return;

            int id = int.Parse(txtDepartmentId.Text);
            var department = db.Departments.Find(id);

            if (department == null)
            {
                MessageBox.Show("Department Not Found", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AssignDepartmentInfo(department);
            db.SaveChanges();
            MessageBox.Show("Department Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DepartmentList();
            ClearDepartmentInfo();
        }

        #region Extracted Methods

        private void ShowDepartmentListStatsByLinq()
        {
            lblTotalDepartmentStat.Text = db.Departments.Count().ToString();
            lblTotalEmployeeStat.Text = db.Employees.Count().ToString();
            lblMaxEmployeeDepartmentStat.Text = db.Employees
                .GroupBy(x => x.DepartmentNavigation.DepartmentId)
                .OrderByDescending(x => x.Count())
                .Select(x => x.FirstOrDefault().DepartmentNavigation.DepartmentName)
                .FirstOrDefault();

            lblMinEmployeeDepartmentStat.Text = db.Employees
                .GroupBy(x => x.DepartmentNavigation.DepartmentId)
                .OrderBy(x => x.Count())
                .Select(x => x.FirstOrDefault().DepartmentNavigation.DepartmentName)
                .FirstOrDefault();
        }

        private void ClearDepartmentInfo()
        {
            txtDepartmentDescription.Text = string.Empty;
            txtDepartmentId.Text = string.Empty;
            txtDepartmentName.Text = string.Empty;
        }

        private void DepartmentList()
        {
            var values = from d in db.Departments
                         select new
                         {
                             d.DepartmentId,
                             d.DepartmentName,
                             d.DepartmentDescription
                         };
            grcDepartmentList.DataSource = values.ToList();
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
