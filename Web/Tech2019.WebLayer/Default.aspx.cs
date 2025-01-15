using System;

using Microsoft.Extensions.DependencyInjection;
using Tech2019.BusinessLayer.AbstractServices;
using Tech2019.EntityLayer.Concrete;

namespace Tech2019.WebLayer
{
    public partial class Default : System.Web.UI.Page
    {
        private readonly IProductService _productService;
        private readonly IMessageService _messageService;

        public Default()
        {
            _productService = Global.ServiceProvider.GetService<IProductService>();
            _messageService = Global.ServiceProvider.GetService<IMessageService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var values = _productService.GetAll();
            ProductRepeater.DataSource = values;
            ProductRepeater.DataBind();
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            Message message = new Message();

            message.SenderName = txtSenderName.Text;
            message.SenderMail = txtSenderEmail.Text;
            message.MessageTitle = txtMessageTitle.Text;
            message.MessageContent = txtMessageContent.Text;

            _messageService.Create(message);

            txtMessageContent.Text = string.Empty;
            txtMessageTitle.Text = string.Empty;
            txtSenderEmail.Text = string.Empty;
            txtSenderName.Text = string.Empty;
        }
    }
}