using System;
using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.Products.ProductFaultryForms
{
    public partial class FrmNewAction : Form
    {
        private readonly IActionService _actionService;
        private readonly ICustomerService _customerService;
        private readonly IEmployeeService _employeeService;
        public FrmNewAction(IActionService actionService, ICustomerService customerService, IEmployeeService employeeService)
        {
            _actionService = actionService;
            _customerService = customerService;
            _employeeService = employeeService;
            InitializeComponent();
        }

        private void FrmNewAction_Load(object sender, EventArgs e)
        {
            InitializePlaceholderEvents();
            FillLookUpEditCustomerEmployeeAndActionStatusDetail();
        }

        private void btnNewSave_Click(object sender, EventArgs e)
        {
            if (!ValidateActionInfo())
                return;

            EntityLayer.Concrete.Action action = new EntityLayer.Concrete.Action();
            AssignActionInfo(action);
            _actionService.Create(action);
            MessageBox.Show("Action added successfully");
            this.Close();
        }

        private void btnNewQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetCustomerInfo_Click(object sender, EventArgs e)
        {
            if (!IsValidSerialNumber(txtProductSerialNumber.Text))
            {
                MessageBox.Show("Product serial number must be exactly 5 characters long and include only letters and/or digits.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtProductSerialNumber.Text = string.Empty;
                txtProductSerialNumber.Focus();
                return;
            }

            var resultCustomerBySerial = _actionService.GetCustomerInfoBySerial(txtProductSerialNumber.Text);

            if (resultCustomerBySerial != null)
            {
                MessageBox.Show($"Customer information retrieved successfully:\n\n" +
                                $"Customer ID: {resultCustomerBySerial.CustomerId}\n" +
                                $"Customer Name: {resultCustomerBySerial.CustomerFirstName} {resultCustomerBySerial.CustomerLastName}\n" +
                                $"Sale Date: {resultCustomerBySerial.SaleDate.ToShortDateString()}\n",
                                "Valid Serial Number",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No sale found for the provided product serial number.",
                                "No Data Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        #region Extracted Methods
        private bool ValidateActionInfo()
        {
            if (lueCustomers.EditValue == null)
            {
                MessageBox.Show("Please select a customer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueCustomers.Focus();
                return false;
            }

            if (lueEmployees.EditValue == null)
            {
                MessageBox.Show("Please select an employee.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueEmployees.Focus();
                return false;
            }
            
            if (lueActionStatusDetail.EditValue == null)
            {
                MessageBox.Show("Please select an action status detail.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lueActionStatusDetail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAcceptedDate.Text) || !DateTime.TryParse(txtAcceptedDate.Text, out _) || txtAcceptedDate.Text == "Accepted Date")
            {
                MessageBox.Show("Please provide a valid accepted date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAcceptedDate.Focus();
                return false;
            }

            if (!IsValidSerialNumber(txtProductSerialNumber.Text) || txtProductSerialNumber.Text == "Product Serial No")
            {
                MessageBox.Show("Product serial number must be exactly 5 characters long and include only letters and/or digits.",
                                "Invalid Input",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                txtProductSerialNumber.Focus();
                return false;
            }
            return true;
        }

        private void FillLookUpEditCustomerEmployeeAndActionStatusDetail()
        {
            var customersList = _customerService.GetCustomersToSale();
            lueCustomers.Properties.DataSource = customersList;
            lueCustomers.Properties.DisplayMember = "CustomerFullName";
            lueCustomers.Properties.ValueMember = "CustomerId";
            lueCustomers.Properties.NullText = "Please pick a customer";

            var employeesList = _employeeService.GetEmployeesToSale();
            lueEmployees.Properties.DataSource = employeesList;
            lueEmployees.Properties.DisplayMember = "EmployeeFullName";
            lueEmployees.Properties.ValueMember = "EmployeeId";
            lueEmployees.Properties.NullText = "Please pick an employee";

            var actionStatusDetail = Enum.GetValues(typeof(EntityLayer.Enum.ActionStatusDetail))
                                             .Cast<EntityLayer.Enum.ActionStatusDetail>()
                                             .Select(e => new { Value = (int)e, Name = e.ToString() })
                                             .ToList();

            lueActionStatusDetail.Properties.DataSource = actionStatusDetail;
            lueActionStatusDetail.Properties.DisplayMember = "Name";
            lueActionStatusDetail.Properties.ValueMember = "Value";
            lueActionStatusDetail.Properties.NullText = "Please pick an action status detail";
        }

        private void AssignActionInfo(EntityLayer.Concrete.Action action)
        {
            action.Employee = short.Parse(lueEmployees.EditValue.ToString());
            action.Customer = int.Parse(lueCustomers.EditValue.ToString());
            action.AcceptedDate = DateTime.Parse(txtAcceptedDate.Text);
            action.ProductSerialNumber = txtProductSerialNumber.Text;
            action.ActionStatus = EntityLayer.Enum.ActionStatus.OnRepair;
            action.ActionStatusDetail = (EntityLayer.Enum.ActionStatusDetail)Convert.ToInt32(lueActionStatusDetail.EditValue);
        }

        private bool IsValidSerialNumber(string serialNumber)
        {
            return serialNumber.Length == 5 && serialNumber.All(char.IsLetterOrDigit);
        }

        private void InitializePlaceholderEvents()
        {
            AddPlaceholderEvents(txtAcceptedDate, "Accepted Date");
            AddPlaceholderEvents(txtProductSerialNumber, "Product Serial No");
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
