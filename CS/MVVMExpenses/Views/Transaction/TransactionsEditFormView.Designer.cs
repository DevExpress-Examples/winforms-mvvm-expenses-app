namespace MVVMExpenses.Common.Views.Transaction {
    partial class TransactionsEditFormView {
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.bbiSave = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveAndNew = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReset = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiResetLayout = new DevExpress.XtraBars.BarButtonItem();
            this.bbiOnLoaded = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDelete = new DevExpress.XtraBars.BarButtonItem();
            this.bbiClose = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.lookUpEdit2 = new DevExpress.XtraEditors.LookUpEdit();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForAccountID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCategoryID = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAmount = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForComment = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComment)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.bbiSave,
            this.bbiSaveAndClose,
            this.bbiSaveAndNew,
            this.bbiReset,
            this.bbiSaveLayout,
            this.bbiResetLayout,
            this.bbiOnLoaded,
            this.bbiDelete,
            this.bbiClose});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 10;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(698, 141);
            // 
            // bbiSave
            // 
            this.bbiSave.Caption = "Save";
            this.bbiSave.Id = 1;
            this.bbiSave.ImageUri.Uri = "Save";
            this.bbiSave.Name = "bbiSave";
            // 
            // bbiSaveAndClose
            // 
            this.bbiSaveAndClose.Caption = "SaveAndClose";
            this.bbiSaveAndClose.Id = 2;
            this.bbiSaveAndClose.ImageUri.Uri = "SaveAndClose";
            this.bbiSaveAndClose.Name = "bbiSaveAndClose";
            // 
            // bbiSaveAndNew
            // 
            this.bbiSaveAndNew.Caption = "SaveAndNew";
            this.bbiSaveAndNew.Id = 3;
            this.bbiSaveAndNew.ImageUri.Uri = "SaveAndNew";
            this.bbiSaveAndNew.Name = "bbiSaveAndNew";
            // 
            // bbiReset
            // 
            this.bbiReset.Caption = "Reset Changes";
            this.bbiReset.Id = 4;
            this.bbiReset.ImageUri.Uri = "Reset";
            this.bbiReset.Name = "bbiReset";
            // 
            // bbiSaveLayout
            // 
            this.bbiSaveLayout.Caption = "SaveLayout";
            this.bbiSaveLayout.Id = 5;
            this.bbiSaveLayout.ImageUri.Uri = "SaveLayout";
            this.bbiSaveLayout.Name = "bbiSaveLayout";
            // 
            // bbiResetLayout
            // 
            this.bbiResetLayout.Caption = "ResetLayout";
            this.bbiResetLayout.Id = 6;
            this.bbiResetLayout.ImageUri.Uri = "ResetLayout";
            this.bbiResetLayout.Name = "bbiResetLayout";
            // 
            // bbiOnLoaded
            // 
            this.bbiOnLoaded.Caption = "OnLoaded";
            this.bbiOnLoaded.Id = 7;
            this.bbiOnLoaded.ImageUri.Uri = "OnLoaded";
            this.bbiOnLoaded.Name = "bbiOnLoaded";
            // 
            // bbiDelete
            // 
            this.bbiDelete.Caption = "Delete";
            this.bbiDelete.Id = 8;
            this.bbiDelete.ImageUri.Uri = "Delete";
            this.bbiDelete.Name = "bbiDelete";
            // 
            // bbiClose
            // 
            this.bbiClose.Caption = "Close";
            this.bbiClose.Id = 9;
            this.bbiClose.ImageUri.Uri = "Close";
            this.bbiClose.Name = "bbiClose";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Edit";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSave);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSaveAndClose);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbiSaveAndNew);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Save";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiReset);
            this.ribbonPageGroup3.ItemLinks.Add(this.bbiDelete);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Edit";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.bbiClose);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Close";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.BindingExpressions.AddRange(new DevExpress.Utils.MVVM.BindingExpression[] {
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "Save", this.bbiSave),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "SaveAndClose", this.bbiSaveAndClose),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "SaveAndNew", this.bbiSaveAndNew),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "Reset", this.bbiReset),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "SaveLayout", this.bbiSaveLayout),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "ResetLayout", this.bbiResetLayout),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "OnLoaded", this.bbiOnLoaded),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "Delete", this.bbiDelete),
            DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel), "Close", this.bbiClose)});
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.ViewModelType = typeof(MVVMExpenses.Models.ViewModels.TransactionViewModel);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.lookUpEdit2);
            this.dataLayoutControl1.Controls.Add(this.lookUpEdit1);
            this.dataLayoutControl1.Controls.Add(this.dateEdit1);
            this.dataLayoutControl1.Controls.Add(this.spinEdit1);
            this.dataLayoutControl1.Controls.Add(this.memoEdit1);
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 141);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(698, 256);
            this.dataLayoutControl1.TabIndex = 1;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // lookUpEdit2
            // 
            this.lookUpEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "AccountID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEdit2.Location = new System.Drawing.Point(60, 12);
            this.lookUpEdit2.Name = "lookUpEdit2";
            this.lookUpEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit2.Properties.DataSource = this.accountBindingSource;
            this.lookUpEdit2.Properties.ValueMember = "ID";
            this.lookUpEdit2.Size = new System.Drawing.Size(626, 20);
            this.lookUpEdit2.StyleController = this.dataLayoutControl1;
            this.lookUpEdit2.TabIndex = 4;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "CategoryID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lookUpEdit1.Location = new System.Drawing.Point(60, 36);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.DataSource = this.categoryBindingSource;
            this.lookUpEdit1.Properties.ValueMember = "ID";
            this.lookUpEdit1.Size = new System.Drawing.Size(626, 20);
            this.lookUpEdit1.StyleController = this.dataLayoutControl1;
            this.lookUpEdit1.TabIndex = 5;
            // 
            // dateEdit1
            // 
            this.dateEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Date", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(60, 60);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(626, 20);
            this.dateEdit1.StyleController = this.dataLayoutControl1;
            this.dateEdit1.TabIndex = 6;
            // 
            // spinEdit1
            // 
            this.spinEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Amount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinEdit1.Location = new System.Drawing.Point(60, 84);
            this.spinEdit1.Name = "spinEdit1";
            this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinEdit1.Size = new System.Drawing.Size(626, 20);
            this.spinEdit1.StyleController = this.dataLayoutControl1;
            this.spinEdit1.TabIndex = 7;
            // 
            // memoEdit1
            // 
            this.memoEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.bindingSource, "Comment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.memoEdit1.Location = new System.Drawing.Point(60, 108);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(626, 136);
            this.memoEdit1.StyleController = this.dataLayoutControl1;
            this.memoEdit1.TabIndex = 8;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForAccountID,
            this.ItemForCategoryID,
            this.ItemForDate,
            this.ItemForAmount,
            this.ItemForComment});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(698, 256);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // ItemForAccountID
            // 
            this.ItemForAccountID.Control = this.lookUpEdit2;
            this.ItemForAccountID.CustomizationFormText = "Account";
            this.ItemForAccountID.Location = new System.Drawing.Point(0, 0);
            this.ItemForAccountID.Name = "ItemForAccountID";
            this.ItemForAccountID.Size = new System.Drawing.Size(678, 24);
            this.ItemForAccountID.Text = "Account";
            this.ItemForAccountID.TextSize = new System.Drawing.Size(45, 13);
            // 
            // ItemForCategoryID
            // 
            this.ItemForCategoryID.Control = this.lookUpEdit1;
            this.ItemForCategoryID.CustomizationFormText = "Category";
            this.ItemForCategoryID.Location = new System.Drawing.Point(0, 24);
            this.ItemForCategoryID.Name = "ItemForCategoryID";
            this.ItemForCategoryID.Size = new System.Drawing.Size(678, 24);
            this.ItemForCategoryID.Text = "Category";
            this.ItemForCategoryID.TextSize = new System.Drawing.Size(45, 13);
            // 
            // ItemForDate
            // 
            this.ItemForDate.Control = this.dateEdit1;
            this.ItemForDate.CustomizationFormText = "Date";
            this.ItemForDate.Location = new System.Drawing.Point(0, 48);
            this.ItemForDate.Name = "ItemForDate";
            this.ItemForDate.Size = new System.Drawing.Size(678, 24);
            this.ItemForDate.Text = "Date";
            this.ItemForDate.TextSize = new System.Drawing.Size(45, 13);
            // 
            // ItemForAmount
            // 
            this.ItemForAmount.Control = this.spinEdit1;
            this.ItemForAmount.CustomizationFormText = "Amount";
            this.ItemForAmount.Location = new System.Drawing.Point(0, 72);
            this.ItemForAmount.Name = "ItemForAmount";
            this.ItemForAmount.Size = new System.Drawing.Size(678, 24);
            this.ItemForAmount.Text = "Amount";
            this.ItemForAmount.TextSize = new System.Drawing.Size(45, 13);
            // 
            // ItemForComment
            // 
            this.ItemForComment.Control = this.memoEdit1;
            this.ItemForComment.CustomizationFormText = "Comment";
            this.ItemForComment.Location = new System.Drawing.Point(0, 96);
            this.ItemForComment.Name = "ItemForComment";
            this.ItemForComment.Size = new System.Drawing.Size(678, 140);
            this.ItemForComment.Text = "Comment";
            this.ItemForComment.TextSize = new System.Drawing.Size(45, 13);
            // 
            // TransactionsEditFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "TransactionsEditFormView";
            this.Size = new System.Drawing.Size(698, 397);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAccountID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCategoryID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForComment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbiSave;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem bbiSaveAndNew;
        private DevExpress.XtraBars.BarButtonItem bbiReset;
        private DevExpress.XtraBars.BarButtonItem bbiSaveLayout;
        private DevExpress.XtraBars.BarButtonItem bbiResetLayout;
        private DevExpress.XtraBars.BarButtonItem bbiOnLoaded;
        private DevExpress.XtraBars.BarButtonItem bbiDelete;
        private DevExpress.XtraBars.BarButtonItem bbiClose;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit2;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private System.Windows.Forms.BindingSource accountBindingSource;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.SpinEdit spinEdit1;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAccountID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCategoryID;
        private DevExpress.XtraLayout.LayoutControlItem ItemForDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAmount;
        private DevExpress.XtraLayout.LayoutControlItem ItemForComment;
    }
}
