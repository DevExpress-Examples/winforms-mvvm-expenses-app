Imports System.ComponentModel
Imports System.Windows
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Utils.MVVM
Imports MVVMExpenses.Models.MyDbContextDataModel
Imports MVVMExpenses.ViewModels
Imports Common.ViewModel

Namespace MVVMExpenses.ViewModels
    Partial Public Class MyDbContextViewModel
        Private loginViewModel As LoginViewModel

        Protected Sub New()
            MyBase.New(UnitOfWorkSource.GetUnitOfWorkFactory())
            loginViewModel = loginViewModel.Create()
            loginViewModel.SetParentViewModel(Me)
        End Sub
        Protected ReadOnly Property DialogService() As IDialogService
            Get
                Return Me.GetService(Of IDialogService)()
            End Get
        End Property
        Protected ReadOnly Property MessageService() As IMessageBoxService
            Get
                Return Me.GetService(Of IMessageBoxService)()
            End Get
        End Property

        Public Overrides Sub OnLoaded(ByVal [module] As MyDbContextModuleDescription)
            MyBase.OnLoaded([module])
            Login()
        End Sub
        Public Overrides Sub OnClosing(ByVal cancelEventArgs As CancelEventArgs)
            MyBase.OnClosing(cancelEventArgs)
            If Not cancelEventArgs.Cancel Then
                If State = AppState.Authorized AndAlso MessageService.ShowMessage("Do you really want to close the application?", "Confirm", MessageButton.YesNo) = MessageResult.No Then
                    cancelEventArgs.Cancel = True
                End If
            End If
        End Sub
        '
        Public Overridable Property State() As AppState
        ' Shows the Login View
        Public Sub Login()
            OnLogin(DialogService.ShowDialog(MessageButton.OKCancel, "Please enter you credentials", "LoginView", loginViewModel))
        End Sub
        Public Sub Logout()
            State = AppState.ExitQueued
            System.Diagnostics.Process.Start(System.Windows.Forms.Application.ExecutablePath)
        End Sub
        Public Function CanLogout() As Boolean
            Return State = AppState.Authorized
        End Function
        'Occurs whenever the end-user clicks a dialog button
        Private Sub OnLogin(ByVal result As MessageResult)
            If result = MessageResult.Cancel Then
                State = AppState.ExitQueued
            Else
                If loginViewModel.IsCurrentUserCredentialsValid Then
                    State = AppState.Authorized
                Else
                    Login()
                End If
            End If
        End Sub
        Protected Sub OnStateChanged()
            Me.RaiseCanExecuteChanged(Sub(x) x.Logout())
            If State = AppState.Authorized Then
                Messenger.Default.Send(Of String)(loginViewModel.CurrentUser.Login)
            Else
                Messenger.Default.Send(Of String)(String.Empty)
            End If
        End Sub
    End Class

    Public Enum AppState
        NotAuthorized
        Authorized
        ExitQueued
    End Enum
End Namespace