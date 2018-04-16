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
Imports DevExpress.XtraGrid.Views

Namespace MVVMExpenses.Common.Views.Account
    <DevExpress.Utils.MVVM.UI.ViewType("AccountView")>
    Partial Public Class AccountsEditFormView
        Inherits DevExpress.XtraEditors.XtraUserControl

        Public Sub New()
            InitializeComponent()
            If Not DesignMode Then
                InitBindings()
            End If
        End Sub

        Private Sub InitBindings()
            Dim fluent = mvvmContext1.OfType(Of AccountViewModel)()
            fluent.SetObjectDataSourceBinding(accountBindingSource, Function(x) x.Entity, Sub(x) x.Update())
            fluent.SetBinding(GridControl1, Function(gc) gc.DataSource, Function(x) x.AccountTransactionDetails.Entities)
            CType(GridControl1.MainView, DevExpress.XtraGrid.Views.Grid.GridView).Columns("Account").Visible = False
        End Sub


    End Class
End Namespace
