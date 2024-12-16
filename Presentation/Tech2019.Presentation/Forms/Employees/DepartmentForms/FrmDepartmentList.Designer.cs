
namespace Tech2019.Presentation.Forms.Employees.DepartmentForms
{
    partial class FrmDepartmentList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepartmentList));
            this.lblMinEmployeeDepartmentStat = new DevExpress.XtraEditors.LabelControl();
            this.gvwDepartments = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grcDepartmentList = new DevExpress.XtraGrid.GridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lblTotalDepartmentStat = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalDepartmentLabel = new DevExpress.XtraEditors.LabelControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.lblTotalEmployeeStat = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalEmployeeLabel = new DevExpress.XtraEditors.LabelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.lblMaxEmployeeDepartmentStat = new DevExpress.XtraEditors.LabelControl();
            this.lblMaxEmployeeDepartmentLabel = new DevExpress.XtraEditors.LabelControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureEdit4 = new DevExpress.XtraEditors.PictureEdit();
            this.lblMinEmployeeDepartmentLabel = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartmentDescription = new DevExpress.XtraEditors.TextEdit();
            this.txtDepartmentName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtDepartmentId = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gvwDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDepartmentList)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentId.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMinEmployeeDepartmentStat
            // 
            this.lblMinEmployeeDepartmentStat.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMinEmployeeDepartmentStat.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMinEmployeeDepartmentStat.Appearance.Options.UseFont = true;
            this.lblMinEmployeeDepartmentStat.Appearance.Options.UseForeColor = true;
            this.lblMinEmployeeDepartmentStat.Appearance.Options.UseTextOptions = true;
            this.lblMinEmployeeDepartmentStat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMinEmployeeDepartmentStat.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMinEmployeeDepartmentStat.Location = new System.Drawing.Point(8, 50);
            this.lblMinEmployeeDepartmentStat.Name = "lblMinEmployeeDepartmentStat";
            this.lblMinEmployeeDepartmentStat.Size = new System.Drawing.Size(75, 32);
            this.lblMinEmployeeDepartmentStat.TabIndex = 0;
            this.lblMinEmployeeDepartmentStat.Text = "588???";
            // 
            // gvwDepartments
            // 
            this.gvwDepartments.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(255)))), ((int)(((byte)(241)))));
            this.gvwDepartments.Appearance.Row.BorderColor = System.Drawing.Color.Black;
            this.gvwDepartments.Appearance.Row.Options.UseBackColor = true;
            this.gvwDepartments.Appearance.Row.Options.UseBorderColor = true;
            this.gvwDepartments.GridControl = this.grcDepartmentList;
            this.gvwDepartments.Name = "gvwDepartments";
            this.gvwDepartments.OptionsView.ShowGroupPanel = false;
            this.gvwDepartments.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvwDepartments_FocusedRowChanged);
            // 
            // grcDepartmentList
            // 
            this.grcDepartmentList.Location = new System.Drawing.Point(3, 108);
            this.grcDepartmentList.MainView = this.gvwDepartments;
            this.grcDepartmentList.Name = "grcDepartmentList";
            this.grcDepartmentList.Size = new System.Drawing.Size(1018, 430);
            this.grcDepartmentList.TabIndex = 12;
            this.grcDepartmentList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvwDepartments});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(80)))), ((int)(((byte)(57)))));
            this.panel1.Controls.Add(this.pictureEdit1);
            this.panel1.Controls.Add(this.lblTotalDepartmentStat);
            this.panel1.Controls.Add(this.lblTotalDepartmentLabel);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 98);
            this.panel1.TabIndex = 14;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(193, 41);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit1.TabIndex = 2;
            // 
            // lblTotalDepartmentStat
            // 
            this.lblTotalDepartmentStat.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalDepartmentStat.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTotalDepartmentStat.Appearance.Options.UseFont = true;
            this.lblTotalDepartmentStat.Appearance.Options.UseForeColor = true;
            this.lblTotalDepartmentStat.Appearance.Options.UseTextOptions = true;
            this.lblTotalDepartmentStat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotalDepartmentStat.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTotalDepartmentStat.Location = new System.Drawing.Point(12, 42);
            this.lblTotalDepartmentStat.Name = "lblTotalDepartmentStat";
            this.lblTotalDepartmentStat.Size = new System.Drawing.Size(96, 45);
            this.lblTotalDepartmentStat.TabIndex = 0;
            this.lblTotalDepartmentStat.Text = "588???";
            // 
            // lblTotalDepartmentLabel
            // 
            this.lblTotalDepartmentLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalDepartmentLabel.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTotalDepartmentLabel.Appearance.Options.UseFont = true;
            this.lblTotalDepartmentLabel.Appearance.Options.UseForeColor = true;
            this.lblTotalDepartmentLabel.Location = new System.Drawing.Point(54, 13);
            this.lblTotalDepartmentLabel.Name = "lblTotalDepartmentLabel";
            this.lblTotalDepartmentLabel.Size = new System.Drawing.Size(124, 20);
            this.lblTotalDepartmentLabel.TabIndex = 0;
            this.lblTotalDepartmentLabel.Text = "Total Departments";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.panel2.Controls.Add(this.pictureEdit2);
            this.panel2.Controls.Add(this.lblTotalEmployeeStat);
            this.panel2.Controls.Add(this.lblTotalEmployeeLabel);
            this.panel2.Location = new System.Drawing.Point(259, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 98);
            this.panel2.TabIndex = 15;
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = ((object)(resources.GetObject("pictureEdit2.EditValue")));
            this.pictureEdit2.Location = new System.Drawing.Point(193, 41);
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit2.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit2.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit2.TabIndex = 2;
            // 
            // lblTotalEmployeeStat
            // 
            this.lblTotalEmployeeStat.Appearance.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalEmployeeStat.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTotalEmployeeStat.Appearance.Options.UseFont = true;
            this.lblTotalEmployeeStat.Appearance.Options.UseForeColor = true;
            this.lblTotalEmployeeStat.Appearance.Options.UseTextOptions = true;
            this.lblTotalEmployeeStat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotalEmployeeStat.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblTotalEmployeeStat.Location = new System.Drawing.Point(12, 42);
            this.lblTotalEmployeeStat.Name = "lblTotalEmployeeStat";
            this.lblTotalEmployeeStat.Size = new System.Drawing.Size(96, 45);
            this.lblTotalEmployeeStat.TabIndex = 0;
            this.lblTotalEmployeeStat.Text = "588???";
            // 
            // lblTotalEmployeeLabel
            // 
            this.lblTotalEmployeeLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTotalEmployeeLabel.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTotalEmployeeLabel.Appearance.Options.UseFont = true;
            this.lblTotalEmployeeLabel.Appearance.Options.UseForeColor = true;
            this.lblTotalEmployeeLabel.Location = new System.Drawing.Point(63, 13);
            this.lblTotalEmployeeLabel.Name = "lblTotalEmployeeLabel";
            this.lblTotalEmployeeLabel.Size = new System.Drawing.Size(110, 20);
            this.lblTotalEmployeeLabel.TabIndex = 0;
            this.lblTotalEmployeeLabel.Text = "Total Employees";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(185)))), ((int)(((byte)(59)))));
            this.panel3.Controls.Add(this.pictureEdit3);
            this.panel3.Controls.Add(this.lblMaxEmployeeDepartmentStat);
            this.panel3.Controls.Add(this.lblMaxEmployeeDepartmentLabel);
            this.panel3.Location = new System.Drawing.Point(515, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 98);
            this.panel3.TabIndex = 16;
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.EditValue = ((object)(resources.GetObject("pictureEdit3.EditValue")));
            this.pictureEdit3.Location = new System.Drawing.Point(193, 41);
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit3.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit3.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit3.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit3.TabIndex = 2;
            // 
            // lblMaxEmployeeDepartmentStat
            // 
            this.lblMaxEmployeeDepartmentStat.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMaxEmployeeDepartmentStat.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMaxEmployeeDepartmentStat.Appearance.Options.UseFont = true;
            this.lblMaxEmployeeDepartmentStat.Appearance.Options.UseForeColor = true;
            this.lblMaxEmployeeDepartmentStat.Appearance.Options.UseTextOptions = true;
            this.lblMaxEmployeeDepartmentStat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMaxEmployeeDepartmentStat.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblMaxEmployeeDepartmentStat.Location = new System.Drawing.Point(8, 50);
            this.lblMaxEmployeeDepartmentStat.Name = "lblMaxEmployeeDepartmentStat";
            this.lblMaxEmployeeDepartmentStat.Size = new System.Drawing.Size(75, 32);
            this.lblMaxEmployeeDepartmentStat.TabIndex = 0;
            this.lblMaxEmployeeDepartmentStat.Text = "588???";
            // 
            // lblMaxEmployeeDepartmentLabel
            // 
            this.lblMaxEmployeeDepartmentLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMaxEmployeeDepartmentLabel.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMaxEmployeeDepartmentLabel.Appearance.Options.UseFont = true;
            this.lblMaxEmployeeDepartmentLabel.Appearance.Options.UseForeColor = true;
            this.lblMaxEmployeeDepartmentLabel.Location = new System.Drawing.Point(13, 13);
            this.lblMaxEmployeeDepartmentLabel.Name = "lblMaxEmployeeDepartmentLabel";
            this.lblMaxEmployeeDepartmentLabel.Size = new System.Drawing.Size(225, 20);
            this.lblMaxEmployeeDepartmentLabel.TabIndex = 0;
            this.lblMaxEmployeeDepartmentLabel.Text = "Department wtih Most Employees";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(21)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.pictureEdit4);
            this.panel4.Controls.Add(this.lblMinEmployeeDepartmentStat);
            this.panel4.Controls.Add(this.lblMinEmployeeDepartmentLabel);
            this.panel4.Location = new System.Drawing.Point(771, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(250, 98);
            this.panel4.TabIndex = 17;
            // 
            // pictureEdit4
            // 
            this.pictureEdit4.EditValue = ((object)(resources.GetObject("pictureEdit4.EditValue")));
            this.pictureEdit4.Location = new System.Drawing.Point(193, 41);
            this.pictureEdit4.Name = "pictureEdit4";
            this.pictureEdit4.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit4.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit4.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit4.Size = new System.Drawing.Size(50, 50);
            this.pictureEdit4.TabIndex = 2;
            // 
            // lblMinEmployeeDepartmentLabel
            // 
            this.lblMinEmployeeDepartmentLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMinEmployeeDepartmentLabel.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblMinEmployeeDepartmentLabel.Appearance.Options.UseFont = true;
            this.lblMinEmployeeDepartmentLabel.Appearance.Options.UseForeColor = true;
            this.lblMinEmployeeDepartmentLabel.Location = new System.Drawing.Point(14, 13);
            this.lblMinEmployeeDepartmentLabel.Name = "lblMinEmployeeDepartmentLabel";
            this.lblMinEmployeeDepartmentLabel.Size = new System.Drawing.Size(226, 20);
            this.lblMinEmployeeDepartmentLabel.TabIndex = 0;
            this.lblMinEmployeeDepartmentLabel.Text = "Department wtih Least Employees";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(30, 186);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(104, 13);
            this.labelControl11.TabIndex = 8;
            this.labelControl11.Text = "DEPARTMENT NAME :";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.btnRefresh);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.txtDepartmentDescription);
            this.groupControl1.Controls.Add(this.txtDepartmentName);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.txtDepartmentId);
            this.groupControl1.Location = new System.Drawing.Point(1025, 3);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(340, 536);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "DEPARTMENT OPERATIONS";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.ImageOptions.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(34, 489);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(293, 39);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "REFRESH LIST";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.Appearance.Options.UseFont = true;
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(34, 444);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(293, 39);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(34, 399);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(292, 39);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Romantic", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(34, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(293, 39);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(59, 216);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(75, 13);
            this.labelControl12.TabIndex = 8;
            this.labelControl12.Text = "DESCRIPTION :";
            // 
            // txtDepartmentDescription
            // 
            this.txtDepartmentDescription.Location = new System.Drawing.Point(136, 213);
            this.txtDepartmentDescription.Name = "txtDepartmentDescription";
            this.txtDepartmentDescription.Size = new System.Drawing.Size(190, 20);
            this.txtDepartmentDescription.TabIndex = 3;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(136, 183);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(190, 20);
            this.txtDepartmentName.TabIndex = 2;
            // 
            // labelControl7
            // 
            this.labelControl7.Enabled = false;
            this.labelControl7.Location = new System.Drawing.Point(44, 156);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(90, 13);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "DEPARTMENT ID : ";
            // 
            // txtDepartmentId
            // 
            this.txtDepartmentId.Enabled = false;
            this.txtDepartmentId.Location = new System.Drawing.Point(136, 153);
            this.txtDepartmentId.Name = "txtDepartmentId";
            this.txtDepartmentId.Size = new System.Drawing.Size(190, 20);
            this.txtDepartmentId.TabIndex = 1;
            // 
            // FrmDepartmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1370, 541);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.grcDepartmentList);
            this.Controls.Add(this.groupControl1);
            this.Name = "FrmDepartmentList";
            this.Text = "Department List";
            this.Load += new System.EventHandler(this.FrmDepartmentList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvwDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcDepartmentList)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDepartmentId.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.LabelControl lblMinEmployeeDepartmentStat;
        private DevExpress.XtraGrid.Views.Grid.GridView gvwDepartments;
        private DevExpress.XtraGrid.GridControl grcDepartmentList;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lblTotalDepartmentStat;
        private DevExpress.XtraEditors.LabelControl lblTotalDepartmentLabel;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.LabelControl lblTotalEmployeeStat;
        private DevExpress.XtraEditors.LabelControl lblTotalEmployeeLabel;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.LabelControl lblMaxEmployeeDepartmentStat;
        private DevExpress.XtraEditors.LabelControl lblMaxEmployeeDepartmentLabel;
        private System.Windows.Forms.Panel panel4;
        private DevExpress.XtraEditors.PictureEdit pictureEdit4;
        private DevExpress.XtraEditors.LabelControl lblMinEmployeeDepartmentLabel;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit txtDepartmentDescription;
        private DevExpress.XtraEditors.TextEdit txtDepartmentName;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtDepartmentId;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnSave;

        #endregion
    }
}