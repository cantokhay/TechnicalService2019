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
            InitializePlaceholderEvents();
        }

        private void btnNewSave_Click(object sender, System.EventArgs e)
        {
            if (!ValidateDepartmentInfo())
                return;

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

        private bool ValidateDepartmentInfo()
        {
            if (string.IsNullOrWhiteSpace(txtDepartmentName.Text) || txtDepartmentName.Text  == "Department Name")
            {
                MessageBox.Show("Department Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDepartmentDescription.Text) || txtDepartmentDescription.Text == "Description")
            {
                MessageBox.Show("Description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtDepartmentName, "Department Name");
            AddPlaceholderEvents(txtDepartmentDescription, "Description");
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
