using System;
using Microsoft.Extensions.DependencyInjection;
using Tech2019.BusinessLayer.AbstractServices;

namespace Tech2019.WebLayer
{
    public partial class Tech2019_WebFormContent : System.Web.UI.Page
    {
        private readonly IProductTraceService _productTraceService;

        public Tech2019_WebFormContent()
        {
            _productTraceService = Global.ServiceProvider.GetService<IProductTraceService>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            var values = _productTraceService.GetProductTracesBySerial(TxtProductSerialNumber.Text);
            Repeater1.DataSource = values;
            Repeater1.DataBind();
        }
    }
}
