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
Imports DevExpress.Utils.MVVM.Services

Namespace MVVMExpenses.Common.Views
    Partial Public Class LoginView
        Inherits DevExpress.XtraEditors.XtraUserControl

        Public Sub New()
            InitializeComponent()
            PasswordTextEdit.Properties.PasswordChar = "*"c
        End Sub

        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            Dim fluentAPI = mvvmContext1.OfType(Of LoginViewModel)()
            fluentAPI.SetObjectDataSourceBinding(UserBindingSource, Function(x) x.CurrentUser, Sub(x) x.Update())


            For Each item As String In mvvmContext1.GetViewModel(Of LoginViewModel)().LookUpUsers
                LoginTextEdit.Properties.Items.Add(item)
            Next item
            fluentAPI.ViewModel.Init()
        End Sub

    End Class
End Namespace
