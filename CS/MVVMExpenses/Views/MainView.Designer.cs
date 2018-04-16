namespace MVVMExpenses {
    partial class MainView {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.mvvmContext1 = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.tabbedView1 = new DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.biAccounts = new DevExpress.XtraBars.BarButtonItem();
            this.biCategories = new DevExpress.XtraBars.BarButtonItem();
            this.biTransactions = new DevExpress.XtraBars.BarButtonItem();
            this.biLogout = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.documentManager1 = new DevExpress.XtraBars.Docking2010.DocumentManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            // 
            // mvvmContext1
            // 
            this.mvvmContext1.ContainerControl = this;
            this.mvvmContext1.RegistrationExpressions.AddRange(new DevExpress.Utils.MVVM.RegistrationExpression[] {
            DevExpress.Utils.MVVM.RegistrationExpression.RegisterDocumentManagerService(null, false, this.tabbedView1)});
            this.mvvmContext1.ViewModelType = typeof(MVVMExpenses.Models.ViewModels.MyDbContextViewModel);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.biAccounts,
            this.biCategories,
            this.biTransactions,
            this.biLogout});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.biLogout);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(644, 140);
            // 
            // biAccounts
            // 
            this.biAccounts.Caption = "Accounts";
            this.biAccounts.Glyph = ((System.Drawing.Image)(resources.GetObject("biAccounts.Glyph")));
            this.biAccounts.Id = 1;
            this.biAccounts.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("biAccounts.LargeGlyph")));
            this.biAccounts.Name = "biAccounts";
            // 
            // biCategories
            // 
            this.biCategories.Caption = "Categories";
            this.biCategories.Glyph = ((System.Drawing.Image)(resources.GetObject("biCategories.Glyph")));
            this.biCategories.Id = 2;
            this.biCategories.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("biCategories.LargeGlyph")));
            this.biCategories.Name = "biCategories";
            // 
            // biTransactions
            // 
            this.biTransactions.Caption = "Transactions";
            this.biTransactions.Glyph = ((System.Drawing.Image)(resources.GetObject("biTransactions.Glyph")));
            this.biTransactions.Id = 3;
            this.biTransactions.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("biTransactions.LargeGlyph")));
            this.biTransactions.Name = "biTransactions";
            // 
            // biLogout
            // 
            this.biLogout.Caption = "Logout";
            this.biLogout.Glyph = ((System.Drawing.Image)(resources.GetObject("biLogout.Glyph")));
            this.biLogout.Id = 1;
            this.biLogout.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("biLogout.LargeGlyph")));
            this.biLogout.Name = "biLogout";
            this.biLogout.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.biLogout.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText)));
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Pages";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.biAccounts);
            this.ribbonPageGroup1.ItemLinks.Add(this.biCategories);
            this.ribbonPageGroup1.ItemLinks.Add(this.biTransactions);
            this.ribbonPageGroup1.ItemLinks.Add(this.biLogout);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Navigation";
            // 
            // documentManager1
            // 
            this.documentManager1.ContainerControl = this;
            this.documentManager1.MenuManager = this.ribbonControl1;
            this.documentManager1.RibbonAndBarsMergeStyle = DevExpress.XtraBars.Docking2010.Views.RibbonAndBarsMergeStyle.Always;
            this.documentManager1.View = this.tabbedView1;
            this.documentManager1.ViewCollection.AddRange(new DevExpress.XtraBars.Docking2010.Views.BaseView[] {
            this.tabbedView1});
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 355);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expenses Application";
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabbedView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.documentManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Docking2010.DocumentManager documentManager1;
        private DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView tabbedView1;
        private DevExpress.XtraBars.BarButtonItem biAccounts;
        private DevExpress.XtraBars.BarButtonItem biCategories;
        private DevExpress.XtraBars.BarButtonItem biTransactions;
        private DevExpress.XtraBars.BarButtonItem biLogout;

    }
}

