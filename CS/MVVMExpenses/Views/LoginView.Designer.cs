namespace MVVMExpenses.Views {
    partial class LoginView {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.PasswordTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LoginTextEdit = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForLogin = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPassword = new DevExpress.XtraLayout.LayoutControlItem();
            this.formAssistant1 = new DevExpress.XtraBars.FormAssistant();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.PasswordTextEdit);
            this.dataLayoutControl1.Controls.Add(this.LoginTextEdit);
            this.dataLayoutControl1.DataSource = this.userBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(399, 142);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // PasswordTextEdit
            // 
            this.PasswordTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.PasswordTextEdit.Location = new System.Drawing.Point(61, 36);
            this.PasswordTextEdit.Name = "PasswordTextEdit";
            this.PasswordTextEdit.Size = new System.Drawing.Size(326, 20);
            this.PasswordTextEdit.StyleController = this.dataLayoutControl1;
            this.PasswordTextEdit.TabIndex = 5;
            // 
            // LoginTextEdit
            // 
            this.LoginTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.userBindingSource, "Login", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.LoginTextEdit.EditValue = "";
            this.LoginTextEdit.Location = new System.Drawing.Point(61, 12);
            this.LoginTextEdit.Name = "LoginTextEdit";
            this.LoginTextEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LoginTextEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.LoginTextEdit.Size = new System.Drawing.Size(326, 20);
            this.LoginTextEdit.StyleController = this.dataLayoutControl1;
            this.LoginTextEdit.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(399, 142);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForLogin,
            this.ItemForPassword});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(379, 122);
            // 
            // ItemForLogin
            // 
            this.ItemForLogin.Control = this.LoginTextEdit;
            this.ItemForLogin.Location = new System.Drawing.Point(0, 0);
            this.ItemForLogin.Name = "ItemForLogin";
            this.ItemForLogin.Size = new System.Drawing.Size(379, 24);
            this.ItemForLogin.Text = "Login";
            this.ItemForLogin.TextSize = new System.Drawing.Size(46, 13);
            // 
            // ItemForPassword
            // 
            this.ItemForPassword.Control = this.PasswordTextEdit;
            this.ItemForPassword.Location = new System.Drawing.Point(0, 24);
            this.ItemForPassword.Name = "ItemForPassword";
            this.ItemForPassword.Size = new System.Drawing.Size(379, 98);
            this.ItemForPassword.Text = "Password";
            this.ItemForPassword.TextSize = new System.Drawing.Size(46, 13);
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(MVVMExpenses.Models.User);
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(MVVMExpenses.ViewModels.LoginViewModel);
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Name = "LoginView";
            this.Size = new System.Drawing.Size(399, 142);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PasswordTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private DevExpress.XtraEditors.TextEdit PasswordTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLogin;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPassword;
        private DevExpress.XtraEditors.ComboBoxEdit LoginTextEdit;
        private DevExpress.XtraBars.FormAssistant formAssistant1;
    }
}
