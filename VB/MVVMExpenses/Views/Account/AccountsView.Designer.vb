Namespace MVVMExpenses.Common.Views.Account
    Partial Public Class AccountsView
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
            Me.bbiNew = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiEdit = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiDelete = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiRefresh = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ribbonControl1
            '
            Me.ribbonControl1.ExpandCollapseItem.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.bbiNew, Me.bbiEdit, Me.bbiDelete, Me.bbiClose, Me.bbiRefresh})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 23
            Me.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.Always
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
            Me.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
            Me.ribbonControl1.ShowQatLocationSelector = False
            Me.ribbonControl1.ShowToolbarCustomizeItem = False
            Me.ribbonControl1.Size = New System.Drawing.Size(568, 115)
            Me.ribbonControl1.Toolbar.ShowCustomizeItem = False
            Me.ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Hidden
            '
            'bbiNew
            '
            Me.bbiNew.Caption = "New"
            Me.bbiNew.Id = 10
            Me.bbiNew.ImageUri.Uri = "New"
            Me.bbiNew.Name = "bbiNew"
            '
            'bbiEdit
            '
            Me.bbiEdit.Caption = "Edit"
            Me.bbiEdit.Id = 11
            Me.bbiEdit.ImageUri.Uri = "Edit"
            Me.bbiEdit.Name = "bbiEdit"
            '
            'bbiDelete
            '
            Me.bbiDelete.Caption = "Delete"
            Me.bbiDelete.Id = 12
            Me.bbiDelete.ImageUri.Uri = "Delete"
            Me.bbiDelete.Name = "bbiDelete"
            '
            'bbiClose
            '
            Me.bbiClose.Caption = "Close"
            Me.bbiClose.Id = 13
            Me.bbiClose.ImageUri.Uri = "Close"
            Me.bbiClose.Name = "bbiClose"
            '
            'bbiRefresh
            '
            Me.bbiRefresh.Caption = "Refresh"
            Me.bbiRefresh.Id = 14
            Me.bbiRefresh.ImageUri.Uri = "Refresh"
            Me.bbiRefresh.Name = "bbiRefresh"
            '
            'ribbonPage1
            '
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
            Me.ribbonPage1.Name = "ribbonPage1"
            Me.ribbonPage1.Text = "Accounts"
            '
            'RibbonPageGroup1
            '
            Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiNew)
            Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiEdit)
            Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiDelete)
            Me.RibbonPageGroup1.ItemLinks.Add(Me.bbiClose)
            Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
            Me.RibbonPageGroup1.Text = "Actions"
            '
            'gridControl1
            '
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl1.Location = New System.Drawing.Point(0, 115)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.MenuManager = Me.ribbonControl1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.Size = New System.Drawing.Size(568, 234)
            Me.gridControl1.TabIndex = 1
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
            '
            'gridView1
            '
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            '
            'mvvmContext1
            '
            Me.mvvmContext1.BindingExpressions.AddRange(New DevExpress.Utils.MVVM.BindingExpression() {DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountCollectionViewModel), "New", Me.bbiNew), DevExpress.Utils.MVVM.BindingExpression.CreateParameterizedCommandBinding(GetType(MVVMExpenses.ViewModels.AccountCollectionViewModel), "Edit", "SelectedEntity", Me.bbiEdit), DevExpress.Utils.MVVM.BindingExpression.CreateParameterizedCommandBinding(GetType(MVVMExpenses.ViewModels.AccountCollectionViewModel), "DeleteAll", "Selection", Me.bbiDelete), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.AccountCollectionViewModel), "Close", Me.bbiClose)})
            Me.mvvmContext1.ContainerControl = Me
            Me.mvvmContext1.ViewModelType = GetType(MVVMExpenses.ViewModels.AccountCollectionViewModel)
            '
            'AccountsView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.gridControl1)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Name = "AccountsView"
            Me.Size = New System.Drawing.Size(568, 349)
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

#End Region

        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private gridControl1 As DevExpress.XtraGrid.GridControl
        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Private bbiNew As DevExpress.XtraBars.BarButtonItem
        Private bbiEdit As DevExpress.XtraBars.BarButtonItem
        Private bbiDelete As DevExpress.XtraBars.BarButtonItem
        Private bbiClose As DevExpress.XtraBars.BarButtonItem
        Private bbiRefresh As DevExpress.XtraBars.BarButtonItem
        Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Friend WithEvents mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
    End Class
End Namespace