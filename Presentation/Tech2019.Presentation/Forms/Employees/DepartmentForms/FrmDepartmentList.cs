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
            Department department = new Department();
            AssignDepartmentInfo(department);
            db.Departments.Add(department);
            db.SaveChanges();
            MessageBox.Show("Department Added Successfully", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearDepartmentInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtDepartmentId.Text);
            var departmant = db.Departments.Find(id);
            db.Departments.Remove(departmant);
            db.SaveChanges();
            MessageBox.Show("Department Deleted", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ClearDepartmentInfo();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtDepartmentId.Text);
            var department = db.Departments.Find(id);

            if (department != null)
            {
                AssignDepartmentInfo(department);
                db.SaveChanges();
                MessageBox.Show("Department Updated", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Department Not Found", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
    }
}
