
namespace Tech2019.Presentation.Forms.Products.ProductFaultryForms
{
    partial class FrmProductTraceList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grcProductTraceList = new DevExpress.XtraGrid.GridControl();
            this.gvwProductTrace = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grcProductTraceList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwProductTrace)).BeginInit();
            this.SuspendLayout();
            // 
            // grcProductTraceList
            // 
            this.grcProductTraceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grcProductTraceList.Location = new System.Drawing.Point(0, 0);
            this.grcProductTraceList.MainView = this.gvwProductTrace;
            this.grcProductTraceList.Name = "grcProductTraceList";
            this.grcProductTraceList.Size = new System.Drawing.Size(1370, 541);
            this.grcProductTraceList.TabIndex = 9;
            this.grcProductTraceList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwProductTrace});
            // 
            // gvwProductTrace
            // 
            this.gvwProductTrace.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.gvwProductTrace.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.gvwProductTrace.Appearance.Row.Options.UseBackColor = true;
            this.gvwProductTrace.Appearance.Row.Options.UseBorderColor = true;
            this.gvwProductTrace.GridControl = this.grcProductTraceList;
            this.gvwProductTrace.Name = "gvwProductTrace";
            this.gvwProductTrace.OptionsView.ShowGroupPanel = false;
            // 
            // FrmProductTraceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.grcProductTraceList);
            this.Name = "FrmProductTraceList";
            this.Text = "Product Trace List";
            this.Load += new System.EventHandler(this.FrmProductTraceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grcProductTraceList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwProductTrace)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraGrid.GridControl grcProductTraceList;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwProductTrace;

        #endregion

    }
}