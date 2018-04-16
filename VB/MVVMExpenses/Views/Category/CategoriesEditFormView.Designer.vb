Namespace MVVMExpenses.Common.Views.Category
    Partial Public Class CategoriesEditFormView
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
            Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
            Me.bbiSave = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiSaveAndClose = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiSaveAndNew = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiReset = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiDelete = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.bbiSaveLayout = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiResetLayout = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiOnLoaded = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.dataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
            Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.NameTextEdit = New DevExpress.XtraEditors.TextEdit()
            Me.categoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.TypeImageComboBoxEdit = New DevExpress.XtraEditors.ImageComboBoxEdit()
            Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.layoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.ItemForName = New DevExpress.XtraLayout.LayoutControlItem()
            Me.ItemForType = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.dataLayoutControl1.SuspendLayout()
            CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.categoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TypeImageComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForName, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForType, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'mvvmContext1
            '
            Me.mvvmContext1.BindingExpressions.AddRange(New DevExpress.Utils.MVVM.BindingExpression() {DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryViewModel), "Save", Me.bbiSave), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryViewModel), "SaveAndClose", Me.bbiSaveAndClose), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryViewModel), "SaveAndNew", Me.bbiSaveAndNew), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryViewModel), "Reset", Me.bbiReset), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryViewModel), "Close", Me.bbiClose), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryViewModel), "Delete", Me.bbiDelete)})
            Me.mvvmContext1.ContainerControl = Me
            Me.mvvmContext1.ViewModelType = GetType(MVVMExpenses.ViewModels.CategoryViewModel)
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
            'bbiClose
            '
            Me.bbiClose.Caption = "Close"
            Me.bbiClose.Id = 9
            Me.bbiClose.ImageUri.Uri = "Close"
            Me.bbiClose.Name = "bbiClose"
            '
            'bbiDelete
            '
            Me.bbiDelete.Caption = "Delete"
            Me.bbiDelete.Id = 8
            Me.bbiDelete.ImageUri.Uri = "Delete"
            Me.bbiDelete.Name = "bbiDelete"
            '
            'ribbonControl1
            '
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.bbiSave, Me.bbiSaveAndClose, Me.bbiSaveAndNew, Me.bbiReset, Me.bbiSaveLayout, Me.bbiResetLayout, Me.bbiOnLoaded, Me.bbiDelete, Me.bbiClose})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 10
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
            Me.ribbonControl1.Size = New System.Drawing.Size(572, 141)
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
            'ribbonPage1
            '
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonPageGroup1, Me.ribbonPageGroup2, Me.ribbonPageGroup3})
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
            'ribbonPageGroup2
            '
            Me.ribbonPageGroup2.ItemLinks.Add(Me.bbiReset)
            Me.ribbonPageGroup2.ItemLinks.Add(Me.bbiDelete)
            Me.ribbonPageGroup2.Name = "ribbonPageGroup2"
            Me.ribbonPageGroup2.Text = "Edit"
            '
            'ribbonPageGroup3
            '
            Me.ribbonPageGroup3.AllowTextClipping = False
            Me.ribbonPageGroup3.ItemLinks.Add(Me.bbiClose)
            Me.ribbonPageGroup3.Name = "ribbonPageGroup3"
            Me.ribbonPageGroup3.Text = "Close"
            '
            'dataLayoutControl1
            '
            Me.dataLayoutControl1.Controls.Add(Me.GridControl1)
            Me.dataLayoutControl1.Controls.Add(Me.NameTextEdit)
            Me.dataLayoutControl1.Controls.Add(Me.TypeImageComboBoxEdit)
            Me.dataLayoutControl1.DataSource = Me.categoryBindingSource
            Me.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataLayoutControl1.Location = New System.Drawing.Point(0, 141)
            Me.dataLayoutControl1.Name = "dataLayoutControl1"
            Me.dataLayoutControl1.Root = Me.layoutControlGroup1
            Me.dataLayoutControl1.Size = New System.Drawing.Size(572, 203)
            Me.dataLayoutControl1.TabIndex = 1
            Me.dataLayoutControl1.Text = "dataLayoutControl1"
            '
            'GridControl1
            '
            Me.GridControl1.Location = New System.Drawing.Point(98, 60)
            Me.GridControl1.MainView = Me.GridView1
            Me.GridControl1.MenuManager = Me.ribbonControl1
            Me.GridControl1.Name = "GridControl1"
            Me.GridControl1.Size = New System.Drawing.Size(462, 131)
            Me.GridControl1.TabIndex = 6
            Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
            '
            'GridView1
            '
            Me.GridView1.GridControl = Me.GridControl1
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsBehavior.Editable = False
            '
            'NameTextEdit
            '
            Me.NameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.categoryBindingSource, "Name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.NameTextEdit.Location = New System.Drawing.Point(98, 12)
            Me.NameTextEdit.MenuManager = Me.ribbonControl1
            Me.NameTextEdit.Name = "NameTextEdit"
            Me.NameTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NameTextEdit.Properties.NullValuePrompt = Nothing
            Me.NameTextEdit.Size = New System.Drawing.Size(462, 20)
            Me.NameTextEdit.StyleController = Me.dataLayoutControl1
            Me.NameTextEdit.TabIndex = 4
            '
            'categoryBindingSource
            '
            Me.categoryBindingSource.DataSource = GetType(MVVMExpenses.DataModels.Category)
            '
            'TypeImageComboBoxEdit
            '
            Me.TypeImageComboBoxEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.categoryBindingSource, "Type", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.TypeImageComboBoxEdit.Location = New System.Drawing.Point(98, 36)
            Me.TypeImageComboBoxEdit.Name = "TypeImageComboBoxEdit"
            Me.TypeImageComboBoxEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.TypeImageComboBoxEdit.Size = New System.Drawing.Size(462, 20)
            Me.TypeImageComboBoxEdit.StyleController = Me.dataLayoutControl1
            Me.TypeImageComboBoxEdit.TabIndex = 5
            '
            'layoutControlGroup1
            '
            Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.layoutControlGroup1.GroupBordersVisible = False
            Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlGroup2})
            Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlGroup1.Name = "layoutControlGroup1"
            Me.layoutControlGroup1.Size = New System.Drawing.Size(572, 203)
            Me.layoutControlGroup1.TextVisible = False
            '
            'layoutControlGroup2
            '
            Me.layoutControlGroup2.AllowDrawBackground = False
            Me.layoutControlGroup2.GroupBordersVisible = False
            Me.layoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForName, Me.ItemForType, Me.LayoutControlItem1})
            Me.layoutControlGroup2.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlGroup2.Name = "autoGeneratedGroup0"
            Me.layoutControlGroup2.Size = New System.Drawing.Size(552, 183)
            '
            'ItemForName
            '
            Me.ItemForName.Control = Me.NameTextEdit
            Me.ItemForName.Location = New System.Drawing.Point(0, 0)
            Me.ItemForName.Name = "ItemForName"
            Me.ItemForName.Size = New System.Drawing.Size(552, 24)
            Me.ItemForName.Text = "Name"
            Me.ItemForName.TextSize = New System.Drawing.Size(83, 13)
            '
            'ItemForType
            '
            Me.ItemForType.Control = Me.TypeImageComboBoxEdit
            Me.ItemForType.Location = New System.Drawing.Point(0, 24)
            Me.ItemForType.Name = "ItemForType"
            Me.ItemForType.Size = New System.Drawing.Size(552, 24)
            Me.ItemForType.Text = "Transaction Type"
            Me.ItemForType.TextSize = New System.Drawing.Size(83, 13)
            '
            'LayoutControlItem1
            '
            Me.LayoutControlItem1.Control = Me.GridControl1
            Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 48)
            Me.LayoutControlItem1.Name = "LayoutControlItem1"
            Me.LayoutControlItem1.Size = New System.Drawing.Size(552, 135)
            Me.LayoutControlItem1.Text = "Transactions"
            Me.LayoutControlItem1.TextSize = New System.Drawing.Size(83, 13)
            '
            'CategoriesEditFormView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.dataLayoutControl1)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Name = "CategoriesEditFormView"
            Me.Size = New System.Drawing.Size(572, 344)
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.dataLayoutControl1.ResumeLayout(False)
            CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.categoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TypeImageComboBoxEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForName, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForType, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private ribbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private ribbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private bbiSave As DevExpress.XtraBars.BarButtonItem
        Private bbiSaveAndClose As DevExpress.XtraBars.BarButtonItem
        Private bbiSaveAndNew As DevExpress.XtraBars.BarButtonItem
        Private bbiReset As DevExpress.XtraBars.BarButtonItem
        Private bbiClose As DevExpress.XtraBars.BarButtonItem
        Private bbiSaveLayout As DevExpress.XtraBars.BarButtonItem
        Private bbiResetLayout As DevExpress.XtraBars.BarButtonItem
        Private bbiOnLoaded As DevExpress.XtraBars.BarButtonItem
        Private bbiDelete As DevExpress.XtraBars.BarButtonItem
        Private dataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
        Private NameTextEdit As DevExpress.XtraEditors.TextEdit
        Private categoryBindingSource As System.Windows.Forms.BindingSource
        Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Private layoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
        Private ItemForName As DevExpress.XtraLayout.LayoutControlItem
        Private ItemForType As DevExpress.XtraLayout.LayoutControlItem
        Private TypeImageComboBoxEdit As DevExpress.XtraEditors.ImageComboBoxEdit
        Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem

    End Class
End Namespace
