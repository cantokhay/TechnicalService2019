using System.Linq;
using System.Windows.Forms;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.Presentation.Forms.HomePage
{
    public partial class FrmHomePage : Form
    {
        private readonly IProductService _productService;
        private readonly ICustomerService _customerService;
        private readonly INoteService _noteService;
        private readonly IMessageService _messageService;

        public FrmHomePage(IProductService productService, ICustomerService customerService, INoteService noteService, IMessageService messageService)
        {
            _productService = productService;
            _customerService = customerService;
            _noteService = noteService;
            _messageService = messageService;
            InitializeComponent();
        }

        private void FrmHomePage_Load(object sender, System.EventArgs e)
        {
            grcCriticalStockLevel.DataSource = _productService.GetProductsOnCriticalStockLevel();
            gvwCriticalStockLevel.OptionsBehavior.Editable = false;
            grcPhoneBook.DataSource = _customerService.GetCustomersToHomePage();
            gvwPhoneBook.OptionsBehavior.Editable = false;
            grcCategoryProduct.DataSource = _productService.GetProductCountByCategoryName();
            gvwCategoryProduct.OptionsBehavior.Editable = false;
            grcTodaysToDoList.DataSource = _noteService.GetNotesTodayDueDate();
            gvwTodaysToDoList.OptionsBehavior.Editable = false;

            for (int i = 1; i <= 12; i++)
            {
                string message = _messageService.GetMessageSenderNameAndTitleByOrder(i);
                Control label = this.Controls.Find($"lblMessageNo{i}", true).FirstOrDefault();
                if (label is DevExpress.XtraEditors.LabelControl lbl)
                {
                    lbl.Text = message;
                }
            }
        }
    }
}
