Namespace MVVMExpenses.Common.Views.Transaction
    Partial Public Class TransactionsEditFormView
        ''' <summary> 
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary> 
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.bbiSave = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiSaveAndClose = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiSaveAndNew = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiReset = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiSaveLayout = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiResetLayout = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiOnLoaded = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiDelete = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonPageGroup4 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.dataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
            Me.lookUpEdit2 = New DevExpress.XtraEditors.LookUpEdit()
            Me.bindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.accountBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.lookUpEdit1 = New DevExpress.XtraEditors.LookUpEdit()
            Me.categoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.dateEdit1 = New DevExpress.XtraEditors.DateEdit()
            Me.spinEdit1 = New DevExpress.XtraEditors.SpinEdit()
            Me.memoEdit1 = New DevExpress.XtraEditors.MemoEdit()
            Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.ItemForAccountID = New DevExpress.XtraLayout.LayoutControlItem()
            Me.ItemForCategoryID = New DevExpress.XtraLayout.LayoutControlItem()
            Me.ItemForDate = New DevExpress.XtraLayout.LayoutControlItem()
            Me.ItemForAmount = New DevExpress.XtraLayout.LayoutControlItem()
            Me.ItemForComment = New DevExpress.XtraLayout.LayoutControlItem()
            Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.dataLayoutControl1.SuspendLayout()
            CType(Me.lookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.accountBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.lookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.categoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dateEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.spinEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForAccountID, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForCategoryID, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForAmount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForComment, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ribbonControl1
            '
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.bbiSave, Me.bbiSaveAndClose, Me.bbiSaveAndNew, Me.bbiReset, Me.bbiSaveLayout, Me.bbiResetLayout, Me.bbiOnLoaded, Me.bbiDelete, Me.bbiClose})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 17
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
            Me.ribbonControl1.Size = New System.Drawing.Size(698, 141)
            '
            'bbiSave
            '
            Me.bbiSave.Caption = "Save"
            Me.bbiSave.Id = 1
            Me.bbiSave.ImageUri.Uri = "Save"
            Me.bbiSave.Name = "bbiSave"
            '
            'bbiSaveAndClose
            '
            Me.bbiSaveAndClose.Caption = "SaveAndClose"
            Me.bbiSaveAndClose.Id = 2
            Me.bbiSaveAndClose.ImageUri.Uri = "SaveAndClose"
            Me.bbiSaveAndClose.Name = "bbiSaveAndClose"
            '
            'bbiSaveAndNew
            '
            Me.bbiSaveAndNew.Caption = "SaveAndNew"
            Me.bbiSaveAndNew.Id = 3
            Me.bbiSaveAndNew.ImageUri.Uri = "SaveAndNew"
            Me.bbiSaveAndNew.Name = "bbiSaveAndNew"
            '
            'bbiReset
            '
            Me.bbiReset.Caption = "Reset Changes"
            Me.bbiReset.Id = 4
            Me.bbiReset.ImageUri.Uri = "Reset"
            Me.bbiReset.Name = "bbiReset"
            '
            'bbiSaveLayout
            '
            Me.bbiSaveLayout.Caption = "SaveLayout"
            Me.bbiSaveLayout.Id = 5
            Me.bbiSaveLayout.ImageUri.Uri = "SaveLayout"
            Me.bbiSaveLayout.Name = "bbiSaveLayout"
            '
            'bbiResetLayout
            '
            Me.bbiResetLayout.Caption = "ResetLayout"
            Me.bbiResetLayout.Id = 6
            Me.bbiResetLayout.ImageUri.Uri = "ResetLayout"
            Me.bbiResetLayout.Name = "bbiResetLayout"
            '
            'bbiOnLoaded
            '
            Me.bbiOnLoaded.Caption = "OnLoaded"
            Me.bbiOnLoaded.Id = 7
            Me.bbiOnLoaded.ImageUri.Uri = "OnLoaded"
            Me.bbiOnLoaded.Name = "bbiOnLoaded"
            '
            'bbiDelete
            '
            Me.bbiDelete.Caption = "Delete"
            Me.bbiDelete.Id = 8
            Me.bbiDelete.ImageUri.Uri = "Delete"
            Me.bbiDelete.Name = "bbiDelete"
            '
            'bbiClose
            '
            Me.bbiClose.Caption = "Close"
            Me.bbiClose.Id = 9
            Me.bbiClose.ImageUri.Uri = "Close"
            Me.bbiClose.Name = "bbiClose"
            '
            'ribbonPage1
            '
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonPageGroup1, Me.ribbonPageGroup3, Me.ribbonPageGroup4})
            Me.ribbonPage1.Name = "ribbonPage1"
            Me.ribbonPage1.Text = "Edit"
            '
            'ribbonPageGroup1
            '
            Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiSave)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiSaveAndClose)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiSaveAndNew)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Save"
            '
            'ribbonPageGroup3
            '
            Me.ribbonPageGroup3.ItemLinks.Add(Me.bbiReset)
            Me.ribbonPageGroup3.ItemLinks.Add(Me.bbiDelete)
            Me.ribbonPageGroup3.Name = "ribbonPageGroup3"
            Me.ribbonPageGroup3.Text = "Edit"
            '
            'ribbonPageGroup4
            '
            Me.ribbonPageGroup4.AllowTextClipping = False
            Me.ribbonPageGroup4.ItemLinks.Add(Me.bbiClose)
            Me.ribbonPageGroup4.Name = "ribbonPageGroup4"
            Me.ribbonPageGroup4.Text = "Close"
            '
            'dataLayoutControl1
            '
            Me.dataLayoutControl1.Controls.Add(Me.lookUpEdit2)
            Me.dataLayoutControl1.Controls.Add(Me.lookUpEdit1)
            Me.dataLayoutControl1.Controls.Add(Me.dateEdit1)
            Me.dataLayoutControl1.Controls.Add(Me.spinEdit1)
            Me.dataLayoutControl1.Controls.Add(Me.memoEdit1)
            Me.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataLayoutControl1.Location = New System.Drawing.Point(0, 141)
            Me.dataLayoutControl1.Name = "dataLayoutControl1"
            Me.dataLayoutControl1.Root = Me.layoutControlGroup1
            Me.dataLayoutControl1.Size = New System.Drawing.Size(698, 256)
            Me.dataLayoutControl1.TabIndex = 1
            Me.dataLayoutControl1.Text = "dataLayoutControl1"
            '
            'lookUpEdit2
            '
            Me.lookUpEdit2.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bindingSource, "AccountID", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.lookUpEdit2.Location = New System.Drawing.Point(60, 12)
            Me.lookUpEdit2.Name = "lookUpEdit2"
            Me.lookUpEdit2.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.lookUpEdit2.Properties.DataSource = Me.accountBindingSource
            Me.lookUpEdit2.Properties.ValueMember = "ID"
            Me.lookUpEdit2.Size = New System.Drawing.Size(626, 20)
            Me.lookUpEdit2.StyleController = Me.dataLayoutControl1
            Me.lookUpEdit2.TabIndex = 4
            '
            'accountBindingSource
            '
            Me.accountBindingSource.DataSource = GetType(MVVMExpenses.DataModels.Account)
            '
            'lookUpEdit1
            '
            Me.lookUpEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bindingSource, "CategoryID", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.lookUpEdit1.Location = New System.Drawing.Point(60, 36)
            Me.lookUpEdit1.Name = "lookUpEdit1"
            Me.lookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.lookUpEdit1.Properties.DataSource = Me.categoryBindingSource
            Me.lookUpEdit1.Properties.ValueMember = "ID"
            Me.lookUpEdit1.Size = New System.Drawing.Size(626, 20)
            Me.lookUpEdit1.StyleController = Me.dataLayoutControl1
            Me.lookUpEdit1.TabIndex = 5
            '
            'categoryBindingSource
            '
            Me.categoryBindingSource.DataSource = GetType(MVVMExpenses.DataModels.Category)
            '
            'dateEdit1
            '
            Me.dateEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bindingSource, "Date", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.dateEdit1.EditValue = Nothing
            Me.dateEdit1.Location = New System.Drawing.Point(60, 60)
            Me.dateEdit1.Name = "dateEdit1"
            Me.dateEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.dateEdit1.Size = New System.Drawing.Size(626, 20)
            Me.dateEdit1.StyleController = Me.dataLayoutControl1
            Me.dateEdit1.TabIndex = 6
            '
            'spinEdit1
            '
            Me.spinEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bindingSource, "Amount", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.spinEdit1.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.spinEdit1.Location = New System.Drawing.Point(60, 84)
            Me.spinEdit1.Name = "spinEdit1"
            Me.spinEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.spinEdit1.Size = New System.Drawing.Size(626, 20)
            Me.spinEdit1.StyleController = Me.dataLayoutControl1
            Me.spinEdit1.TabIndex = 7
            '
            'memoEdit1
            '
            Me.memoEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.bindingSource, "Comment", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.memoEdit1.Location = New System.Drawing.Point(60, 108)
            Me.memoEdit1.Name = "memoEdit1"
            Me.memoEdit1.Size = New System.Drawing.Size(626, 136)
            Me.memoEdit1.StyleController = Me.dataLayoutControl1
            Me.memoEdit1.TabIndex = 8
            '
            'layoutControlGroup1
            '
            Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.layoutControlGroup1.GroupBordersVisible = False
            Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForAccountID, Me.ItemForCategoryID, Me.ItemForDate, Me.ItemForAmount, Me.ItemForComment})
            Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlGroup1.Name = "layoutControlGroup1"
            Me.layoutControlGroup1.Size = New System.Drawing.Size(698, 256)
            Me.layoutControlGroup1.TextVisible = False
            '
            'ItemForAccountID
            '
            Me.ItemForAccountID.Control = Me.lookUpEdit2
            Me.ItemForAccountID.CustomizationFormText = "Account"
            Me.ItemForAccountID.Location = New System.Drawing.Point(0, 0)
            Me.ItemForAccountID.Name = "ItemForAccountID"
            Me.ItemForAccountID.Size = New System.Drawing.Size(678, 24)
            Me.ItemForAccountID.Text = "Account"
            Me.ItemForAccountID.TextSize = New System.Drawing.Size(45, 13)
            '
            'ItemForCategoryID
            '
            Me.ItemForCategoryID.Control = Me.lookUpEdit1
            Me.ItemForCategoryID.CustomizationFormText = "Category"
            Me.ItemForCategoryID.Location = New System.Drawing.Point(0, 24)
            Me.ItemForCategoryID.Name = "ItemForCategoryID"
            Me.ItemForCategoryID.Size = New System.Drawing.Size(678, 24)
            Me.ItemForCategoryID.Text = "Category"
            Me.ItemForCategoryID.TextSize = New System.Drawing.Size(45, 13)
            '
            'ItemForDate
            '
            Me.ItemForDate.Control = Me.dateEdit1
            Me.ItemForDate.CustomizationFormText = "Date"
            Me.ItemForDate.Location = New System.Drawing.Point(0, 48)
            Me.ItemForDate.Name = "ItemForDate"
            Me.ItemForDate.Size = New System.Drawing.Size(678, 24)
            Me.ItemForDate.Text = "Date"
            Me.ItemForDate.TextSize = New System.Drawing.Size(45, 13)
            '
            'ItemForAmount
            '
            Me.ItemForAmount.Control = Me.spinEdit1
            Me.ItemForAmount.CustomizationFormText = "Amount"
            Me.ItemForAmount.Location = New System.Drawing.Point(0, 72)
            Me.ItemForAmount.Name = "ItemForAmount"
            Me.ItemForAmount.Size = New System.Drawing.Size(678, 24)
            Me.ItemForAmount.Text = "Amount"
            Me.ItemForAmount.TextSize = New System.Drawing.Size(45, 13)
            '
            'ItemForComment
            '
            Me.ItemForComment.Control = Me.memoEdit1
            Me.ItemForComment.CustomizationFormText = "Comment"
            Me.ItemForComment.Location = New System.Drawing.Point(0, 96)
            Me.ItemForComment.Name = "ItemForComment"
            Me.ItemForComment.Size = New System.Drawing.Size(678, 140)
            Me.ItemForComment.Text = "Comment"
            Me.ItemForComment.TextSize = New System.Drawing.Size(45, 13)
            '
            'mvvmContext1
            '
            Me.mvvmContext1.BindingExpressions.AddRange(New DevExpress.Utils.MVVM.BindingExpression() {DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.TransactionViewModel), "Save", Me.bbiSave), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.TransactionViewModel), "SaveAndClose", Me.bbiSaveAndClose), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.TransactionViewModel), "SaveAndNew", Me.bbiSaveAndNew), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.TransactionViewModel), "Reset", Me.bbiReset), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.TransactionViewModel), "SaveLayout", Me.bbiSaveLayout), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.TransactionViewModel), "Delete", Me.bbiDelete), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.TransactionViewModel), "Close", Me.bbiClose)})
            Me.mvvmContext1.ContainerControl = Me
            Me.mvvmContext1.ViewModelType = GetType(MVVMExpenses.ViewModels.TransactionViewModel)
            '
            'TransactionsEditFormView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.dataLayoutControl1)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Name = "TransactionsEditFormView"
            Me.Size = New System.Drawing.Size(698, 397)
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.dataLayoutControl1.ResumeLayout(False)
            CType(Me.lookUpEdit2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.bindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.accountBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.lookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.categoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dateEdit1.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dateEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.spinEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.memoEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForAccountID, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForCategoryID, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForAmount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForComment, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private bbiSave As DevExpress.XtraBars.BarButtonItem
        Private bbiSaveAndClose As DevExpress.XtraBars.BarButtonItem
        Private bbiSaveAndNew As DevExpress.XtraBars.BarButtonItem
        Private bbiReset As DevExpress.XtraBars.BarButtonItem
        Private bbiSaveLayout As DevExpress.XtraBars.BarButtonItem
        Private bbiResetLayout As DevExpress.XtraBars.BarButtonItem
        Private bbiOnLoaded As DevExpress.XtraBars.BarButtonItem
        Private bbiDelete As DevExpress.XtraBars.BarButtonItem
        Private bbiClose As DevExpress.XtraBars.BarButtonItem
        Private ribbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private ribbonPageGroup4 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private dataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
        Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Private lookUpEdit2 As DevExpress.XtraEditors.LookUpEdit
        Private bindingSource As System.Windows.Forms.BindingSource
        Private categoryBindingSource As System.Windows.Forms.BindingSource
        Private lookUpEdit1 As DevExpress.XtraEditors.LookUpEdit
        Private accountBindingSource As System.Windows.Forms.BindingSource
        Private dateEdit1 As DevExpress.XtraEditors.DateEdit
        Private spinEdit1 As DevExpress.XtraEditors.SpinEdit
        Private memoEdit1 As DevExpress.XtraEditors.MemoEdit
        Private ItemForAccountID As DevExpress.XtraLayout.LayoutControlItem
        Private ItemForCategoryID As DevExpress.XtraLayout.LayoutControlItem
        Private ItemForDate As DevExpress.XtraLayout.LayoutControlItem
        Private ItemForAmount As DevExpress.XtraLayout.LayoutControlItem
        Private ItemForComment As DevExpress.XtraLayout.LayoutControlItem
        Friend WithEvents mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
    End Class
End Namespace
