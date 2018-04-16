Namespace MVVMExpenses.Common.Views.Category
    Partial Public Class CategoriesView
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
            Me.gridControl1 = New DevExpress.XtraGrid.GridControl()
            Me.gridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.bbiNew = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiEdit = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiDelete = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiDeleteAll = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiClose = New DevExpress.XtraBars.BarButtonItem()
            Me.bbiRefresh = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.mvvmContext1 = New DevExpress.Utils.MVVM.MVVMContext(Me.components)
            CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.gridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'gridControl1
            '
            Me.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.gridControl1.Location = New System.Drawing.Point(0, 0)
            Me.gridControl1.MainView = Me.gridView1
            Me.gridControl1.Name = "gridControl1"
            Me.gridControl1.Size = New System.Drawing.Size(632, 363)
            Me.gridControl1.TabIndex = 0
            Me.gridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gridView1})
            '
            'gridView1
            '
            Me.gridView1.GridControl = Me.gridControl1
            Me.gridView1.Name = "gridView1"
            '
            'ribbonControl1
            '
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.bbiNew, Me.bbiEdit, Me.bbiDelete, Me.bbiDeleteAll, Me.bbiClose, Me.bbiRefresh})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 17
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
            Me.ribbonControl1.Size = New System.Drawing.Size(632, 140)
            '
            'bbiNew
            '
            Me.bbiNew.Caption = "New"
            Me.bbiNew.Id = 1
            Me.bbiNew.ImageUri.Uri = "New"
            Me.bbiNew.Name = "bbiNew"
            '
            'bbiEdit
            '
            Me.bbiEdit.Caption = "Edit"
            Me.bbiEdit.Id = 2
            Me.bbiEdit.ImageUri.Uri = "Edit"
            Me.bbiEdit.Name = "bbiEdit"
            '
            'bbiDelete
            '
            Me.bbiDelete.Caption = "Delete"
            Me.bbiDelete.Id = 3
            Me.bbiDelete.ImageUri.Uri = "Delete"
            Me.bbiDelete.Name = "bbiDelete"
            '
            'bbiDeleteAll
            '
            Me.bbiDeleteAll.Caption = "DeleteAll"
            Me.bbiDeleteAll.Id = 4
            Me.bbiDeleteAll.ImageUri.Uri = "DeleteAll"
            Me.bbiDeleteAll.Name = "bbiDeleteAll"
            '
            'bbiClose
            '
            Me.bbiClose.Caption = "Close"
            Me.bbiClose.Id = 5
            Me.bbiClose.ImageUri.Uri = "Close"
            Me.bbiClose.Name = "bbiClose"
            '
            'bbiRefresh
            '
            Me.bbiRefresh.Caption = "Refresh"
            Me.bbiRefresh.Id = 6
            Me.bbiRefresh.ImageUri.Uri = "Refresh"
            Me.bbiRefresh.Name = "bbiRefresh"
            '
            'ribbonPage1
            '
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.ribbonPageGroup1})
            Me.ribbonPage1.Name = "ribbonPage1"
            Me.ribbonPage1.Text = "Categories"
            '
            'ribbonPageGroup1
            '
            Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiNew)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiEdit)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiDelete)
            Me.ribbonPageGroup1.ItemLinks.Add(Me.bbiClose)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Actions"
            '
            'mvvmContext1
            '
            Me.mvvmContext1.BindingExpressions.AddRange(New DevExpress.Utils.MVVM.BindingExpression() {DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryCollectionViewModel), "New", Me.bbiNew), DevExpress.Utils.MVVM.BindingExpression.CreateParameterizedCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryCollectionViewModel), "Edit", "SelectedEntity", Me.bbiEdit), DevExpress.Utils.MVVM.BindingExpression.CreateParameterizedCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryCollectionViewModel), "DeleteAll", "Selection", Me.bbiDelete), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryCollectionViewModel), "Close", Me.bbiClose), DevExpress.Utils.MVVM.BindingExpression.CreateCommandBinding(GetType(MVVMExpenses.ViewModels.CategoryCollectionViewModel), "Refresh", Me.bbiRefresh)})
            Me.mvvmContext1.ContainerControl = Me
            Me.mvvmContext1.ViewModelType = GetType(MVVMExpenses.ViewModels.CategoryCollectionViewModel)
            '
            'CategoriesView
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.ribbonControl1)
            Me.Controls.Add(Me.gridControl1)
            Me.Name = "CategoriesView"
            Me.Size = New System.Drawing.Size(632, 363)
            CType(Me.gridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.gridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.mvvmContext1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private gridControl1 As DevExpress.XtraGrid.GridControl
        Private gridView1 As DevExpress.XtraGrid.Views.Grid.GridView
        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private mvvmContext1 As DevExpress.Utils.MVVM.MVVMContext
        Private bbiNew As DevExpress.XtraBars.BarButtonItem
        Private bbiEdit As DevExpress.XtraBars.BarButtonItem
        Private bbiDelete As DevExpress.XtraBars.BarButtonItem
        Private bbiDeleteAll As DevExpress.XtraBars.BarButtonItem
        Private bbiClose As DevExpress.XtraBars.BarButtonItem
        Private bbiRefresh As DevExpress.XtraBars.BarButtonItem
    End Class
End Namespace
