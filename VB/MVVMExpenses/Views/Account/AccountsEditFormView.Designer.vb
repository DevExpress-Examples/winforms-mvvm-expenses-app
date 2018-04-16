Namespace MVVMExpenses.Common.Views.Account
    Partial Public Class AccountsEditFormView
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
            Me.bbiDelete = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonPageGroup3 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonPageGroup2 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.dataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
            Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.NameTextEdit = New DevExpress.XtraEditors.TextEdit()
            Me.accountBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.AmountTextEdit = New DevExpress.XtraEditors.SpinEdit()
            Me.layoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.layoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
            Me.ItemForName = New DevExpress.XtraLayout.LayoutControlItem()
            Me.ItemForAmount = New DevExpress.XtraLayout.LayoutControlItem()
            Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
            Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.dataLayoutControl1.SuspendLayout()
            CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.accountBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.AmountTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForName, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ItemForAmount, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ribbonControl1
            '
            Me.ribbonControl1.ExpandCollapseItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.bbiSave, Me.bbiSaveAndClose, Me.bbiSaveAndNew, Me.bbiReset, Me.bbiSaveLayout, Me.bbiDelete, Me.bbiClose})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 21
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
            Me.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
            Me.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
            Me.ribbonControl1.ShowQatLocationSelector = False
            Me.ribbonControl1.ShowToolbarCustomizeItem = False
            Me.ribbonControl1.Size = New System.Drawing.Size(709, 116)
            Me.ribbonControl1.Toolbar.ShowCustomizeItem = False
            Me.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
            '
            'bbiSave
            '
            Me.bbiSave.Caption = "Save"
            Me.bbiSave.Id = 14
            Me.bbiSave.ImageUri.Uri = "Save"
            Me.bbiSave.Name = "bbiSave"
            '
            'bbiSaveAndClose
            '
            Me.bbiSaveAndClose.Caption = "SaveAndClose"
            Me.bbiSaveAndClose.Id = 15
            Me.bbiSaveAndClose.ImageUri.Uri = "SaveAndClose"
            Me.bbiSaveAndClose.Name = "bbiSaveAndClose"
            '
            'bbiSaveAndNew
            '
            Me.bbiSaveAndNew.Caption = "SaveAndNew"
            Me.bbiSaveAndNew.Id = 16
            Me.bbiSaveAndNew.ImageUri.Uri = "SaveAndNew"
            Me.bbiSaveAndNew.Name = "bbiSaveAndNew"
            '
            'bbiReset
            '
            Me.bbiReset.Caption = "Reset Changes"
            Me.bbiReset.Id = 17
            Me.bbiReset.ImageUri.Uri = "Reset"
            Me.bbiReset.Name = "bbiReset"
            '
            'bbiSaveLayout
            '
            Me.bbiSaveLayout.Caption = "Save Layout"
            Me.bbiSaveLayout.Id = 18
            Me.bbiSaveLayout.ImageUri.Uri = "Save"
            Me.bbiSaveLayout.Name = "bbiSaveLayout"
            '
            'bbiDelete
            '
            Me.bbiDelete.Caption = "Delete"
            Me.bbiDelete.Id = 19
            Me.bbiDelete.ImageUri.Uri = "Delete"
            Me.bbiDelete.Name = "bbiDelete"
            '
            'bbiClose
            '
            Me.bbiClose.Caption = "Close"
            Me.bbiClose.Id = 20
            Me.bbiClose.ImageUri.Uri = "Close"
            Me.bbiClose.Name = "bbiClose"
            '
            'ribbonPage1
            '
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonPageGroup1, Me.ribbonPageGroup3, Me.ribbonPageGroup2})
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
            'ribbonPageGroup2
            '
            Me.ribbonPageGroup2.AllowTextClipping = False
            Me.ribbonPageGroup2.ItemLinks.Add(Me.bbiClose)
            Me.ribbonPageGroup2.Name = "ribbonPageGroup2"
            Me.ribbonPageGroup2.Text = "Close"
            '
            'dataLayoutControl1
            '
            Me.dataLayoutControl1.Controls.Add(Me.GridControl1)
            Me.dataLayoutControl1.Controls.Add(Me.NameTextEdit)
            Me.dataLayoutControl1.Controls.Add(Me.AmountTextEdit)
            Me.dataLayoutControl1.DataSource = Me.accountBindingSource
            Me.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataLayoutControl1.Location = New System.Drawing.Point(0, 116)
            Me.dataLayoutControl1.Name = "dataLayoutControl1"
            Me.dataLayoutControl1.OptionsView.UseDefaultDragAndDropRendering = False
            Me.dataLayoutControl1.Root = Me.layoutControlGroup1
            Me.dataLayoutControl1.Size = New System.Drawing.Size(709, 317)
            Me.dataLayoutControl1.TabIndex = 1
            Me.dataLayoutControl1.Text = "dataLayoutControl1"
            '
            'accountBindingSource
            '
            Me.accountBindingSource.DataSource = GetType(MVVMExpenses.DataModels.Account)
            '
            'GridControl1
            '
            Me.GridControl1.Location = New System.Drawing.Point(76, 60)
            Me.GridControl1.MainView = Me.GridView1
            Me.GridControl1.MenuManager = Me.ribbonControl1
            Me.GridControl1.Name = "GridControl1"
            Me.GridControl1.Size = New System.Drawing.Size(621, 245)
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
            Me.NameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.accountBindingSource, "Name", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.NameTextEdit.Location = New System.Drawing.Point(76, 12)
            Me.NameTextEdit.MenuManager = Me.ribbonControl1
            Me.NameTextEdit.Name = "NameTextEdit"
            Me.NameTextEdit.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NameTextEdit.Properties.NullValuePrompt = Nothing
            Me.NameTextEdit.Size = New System.Drawing.Size(621, 20)
            Me.NameTextEdit.StyleController = Me.dataLayoutControl1
            Me.NameTextEdit.TabIndex = 4
            '
            'AmountTextEdit
            '
            Me.AmountTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.accountBindingSource, "Amount", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
            Me.AmountTextEdit.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.AmountTextEdit.Location = New System.Drawing.Point(76, 36)
            Me.AmountTextEdit.MenuManager = Me.ribbonControl1
            Me.AmountTextEdit.Name = "AmountTextEdit"
            Me.AmountTextEdit.Properties.Appearance.Options.UseTextOptions = True
            Me.AmountTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.AmountTextEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.AmountTextEdit.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
            Me.AmountTextEdit.Properties.Mask.EditMask = "c"
            Me.AmountTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.AmountTextEdit.Properties.NullValuePrompt = Nothing
            Me.AmountTextEdit.Size = New System.Drawing.Size(621, 20)
            Me.AmountTextEdit.StyleController = Me.dataLayoutControl1
            Me.AmountTextEdit.TabIndex = 5
            '
            'layoutControlGroup1
            '
            Me.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
            Me.layoutControlGroup1.GroupBordersVisible = False
            Me.layoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.layoutControlGroup2})
            Me.layoutControlGroup1.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlGroup1.Name = "layoutControlGroup1"
            Me.layoutControlGroup1.Size = New System.Drawing.Size(709, 317)
            Me.layoutControlGroup1.TextVisible = False
            '
            'layoutControlGroup2
            '
            Me.layoutControlGroup2.AllowDrawBackground = False
            Me.layoutControlGroup2.GroupBordersVisible = False
            Me.layoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForName, Me.ItemForAmount, Me.LayoutControlItem1})
            Me.layoutControlGroup2.Location = New System.Drawing.Point(0, 0)
            Me.layoutControlGroup2.Name = "autoGeneratedGroup0"
            Me.layoutControlGroup2.Size = New System.Drawing.Size(689, 297)
            '
            'ItemForName
            '
            Me.ItemForName.Control = Me.NameTextEdit
            Me.ItemForName.Location = New System.Drawing.Point(0, 0)
            Me.ItemForName.Name = "ItemForName"
            Me.ItemForName.Size = New System.Drawing.Size(689, 24)
            Me.ItemForName.Text = "Name"
            Me.ItemForName.TextSize = New System.Drawing.Size(61, 13)
            '
            'ItemForAmount
            '
            Me.ItemForAmount.Control = Me.AmountTextEdit
            Me.ItemForAmount.Location = New System.Drawing.Point(0, 24)
            Me.ItemForAmount.Name = "ItemForAmount"
            Me.ItemForAmount.Size = New System.Drawing.Size(689, 24)
            Me.ItemForAmount.Text = "Amount"
            Me.ItemForAmount.TextSize = New System.Drawing.Size(61, 13)
            '
            'LayoutControlItem1
            '
            Me.LayoutControlItem1.Control = Me.GridControl1
            Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 48)
            Me.LayoutControlItem1.Name = "LayoutControlItem1"
            Me.LayoutControlItem1.Size = New System.Drawing.Size(689, 249)
            Me.LayoutControlItem1.Text = "Transactions"
            Me.LayoutControlItem1.TextSize = New System.Drawing.Size(61, 13)
            '
            'mvvmContext1
            '
            Me.mvvmContext1.BindingExpressions.AddRange(New DevExpress.Utils.MVVM.BindingExpression() {DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountViewModel), "Save", Me.bbiSave), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountViewModel), "SaveAndClose", Me.bbiSaveAndClose), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountViewModel), "SaveAndNew", Me.bbiSaveAndNew), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountViewModel), "Reset", Me.bbiReset), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountViewModel), "SaveLayout", Me.bbiSaveLayout), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountViewModel), "Delete", Me.bbiDelete), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountViewModel), "Close", Me.bbiClose)})
            Me.mvvmContext1.ContainerControl = Me
            Me.mvvmContext1.ViewModelType = GetType(MVVMExpenses.ViewModels.AccountViewModel)
            '
            'AccountsEditFormView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.dataLayoutControl1)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Name = "AccountsEditFormView"
            Me.Size = New System.Drawing.Size(709, 433)
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.dataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.dataLayoutControl1.ResumeLayout(False)
            CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.accountBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.AmountTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.layoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForName, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ItemForAmount, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private dataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
        Private NameTextEdit As DevExpress.XtraEditors.TextEdit
        Private accountBindingSource As System.Windows.Forms.BindingSource
        Private layoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
        Private layoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
        Private ItemForName As DevExpress.XtraLayout.LayoutControlItem
        Private ItemForAmount As DevExpress.XtraLayout.LayoutControlItem
        Private ribbonPageGroup3 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private ribbonPageGroup2 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private AmountTextEdit As DevExpress.XtraEditors.SpinEdit
        Friend WithEvents mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
        Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents bbiSave As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents bbiSaveAndClose As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents bbiSaveAndNew As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents bbiReset As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents bbiSaveLayout As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents bbiDelete As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents bbiClose As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
        Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    End Class
End Namespace
