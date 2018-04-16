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

Namespace MVVMExpenses.Common.Views.Transaction
    <DevExpress.Utils.MVVM.UI.ViewType("TransactionView")>
    Partial Public Class TransactionsEditFormView
        Inherits DevExpress.XtraEditors.XtraUserControl

        Public Sub New()
            InitializeComponent()
            If Not DesignMode Then
                InitBindings()
            End If
        End Sub

        Private Sub InitBindings()
            Dim fluent = mvvmContext1.OfType(Of TransactionViewModel)()
            fluent.SetObjectDataSourceBinding(bindingSource, Function(x) x.Entity, Sub(x) x.Update())
            fluent.SetBinding(accountBindingSource, Function(abs) abs.DataSource, Function(x) x.LookUpAccounts.Entities)
            fluent.SetBinding(categoryBindingSource, Function(cbs) cbs.DataSource, Function(x) x.LookUpCategories.Entities)
        End Sub
    End Class
End Namespace
