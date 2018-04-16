Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports MVVMExpenses.ViewModels


Namespace MVVMExpenses.Common.Views.Category
    <DevExpress.Utils.MVVM.UI.ViewType("CategoryView")>
    Partial Public Class CategoriesEditFormView
        Inherits DevExpress.XtraEditors.XtraUserControl

        Public Sub New()
            InitializeComponent()
            Me.TypeImageComboBoxEdit.Properties.Items.AddEnum(Of DataModels.TransactionType)()
            If Not DesignMode Then
                InitBindings()
            End If
        End Sub

        Private Sub InitBindings()
            Dim fluent = mvvmContext1.OfType(Of CategoryViewModel)()
            fluent.SetObjectDataSourceBinding(categoryBindingSource, Function(x) x.Entity, Sub(x) x.Update())
            fluent.SetBinding(GridControl1, Function(gc) gc.DataSource, Function(x) x.CategoryTransactionDetails.Entities)
            CType(GridControl1.MainView, DevExpress.XtraGrid.Views.Grid.GridView).Columns("Category").Visible = False
        End Sub
    End Class
End Namespace
