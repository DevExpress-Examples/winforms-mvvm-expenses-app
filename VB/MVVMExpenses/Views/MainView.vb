Imports System
Imports System.ComponentModel
Imports System.Windows.Forms
Imports DevExpress.Mvvm
Imports DevExpress.XtraEditors
Imports MVVMExpenses.ViewModels

Namespace MVVMExpenses
    Partial Public Class MainView
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
            Me.Opacity = 0
            If Not DesignMode Then
                InitializeNavigation()
            End If
            AddHandler ribbonControl1.Merge, AddressOf ribbonControl1_Merge
        End Sub
        Private Sub ribbonControl1_Merge(ByVal sender As Object, ByVal e As DevExpress.XtraBars.Ribbon.RibbonMergeEventArgs)
            ribbonControl1.SelectedPage = e.MergedChild.SelectedPage
        End Sub
        Private Sub InitializeNavigation()
            Dim fluentAPI = mvvmContext1.OfType(Of MyDbContextViewModel)()
            fluentAPI.BindCommand(biAccounts, Sub(x, m) x.Show(m), Function(x) x.Modules(0))
            fluentAPI.BindCommand(biCategories, Sub(x, m) x.Show(m), Function(x) x.Modules(1))
            fluentAPI.BindCommand(biTransactions, Sub(x, m) x.Show(m), Function(x) x.Modules(2))
            '
            fluentAPI.BindCommand(biLogout, Sub(x) x.Logout())
            '
            fluentAPI.WithEvent(Me, "Load").EventToCommand(Sub(x) x.OnLoaded(Nothing), Function(x) x.DefaultModule)
            fluentAPI.WithEvent(Of FormClosingEventArgs)(Me, "FormClosing").EventToCommand(Sub(x) x.OnClosing(Nothing), New Func(Of CancelEventArgs, Object)(Function(args) args))
            fluentAPI.SetTrigger(Function(x) x.State, Sub(state)
                                                          If state = AppState.Authorized Then
                                                              Opacity = 1
                                                          End If
                                                          If state = AppState.ExitQueued Then
                                                              Close()
                                                          End If
                                                      End Sub)
            Messenger.Default.Register(Of String)(Me, AddressOf OnUserNameMessage)
        End Sub
        Public Sub OnUserNameMessage(ByVal userName As String)
            If String.IsNullOrEmpty(userName) Then
                Me.Text = "Expenses Application"
            Else
                Me.Text = "Expenses Application - (" & userName & ")"
            End If
        End Sub
    End Class
End Namespace
