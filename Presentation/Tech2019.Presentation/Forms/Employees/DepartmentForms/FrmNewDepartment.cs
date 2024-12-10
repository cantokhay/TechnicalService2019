using System.Windows.Forms;
using Tech2019.DataAccessLayer.Context;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.Presentation.Forms.Employees.DepartmentForms
{
    public partial class FrmNewDepartment : Form
    {
        public FrmNewDepartment()
        {
            InitializeComponent();
        }

        private void btnNewSave_Click(object sender, System.EventArgs e)
        {
            TechDBContext db = new TechDBContext();
            Department department = new Department();
            AssignDepartmentInfo(department);
            db.Departments.Add(department);
            db.SaveChanges();
            MessageBox.Show("Department added succesfully");
            this.Close();
        }

        private void btnNewQuit_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        #region Extracted Methods

        private void AssignDepartmentInfo(Department departmant)
        {
            departmant.DepartmentName = txtDepartmentName.Text;
            departmant.DepartmentDescription = txtDepartmentDescription.Text;
        }

        #endregion
    }
}
