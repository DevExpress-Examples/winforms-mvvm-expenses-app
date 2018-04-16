Imports MVVMExpenses.Models
Imports DevExpress.Mvvm.POCO

Namespace MVVMExpenses.ViewModels
    Public Class LoginViewModel
        Public ReadOnly Property LookUpUsers() As IEnumerable(Of String)
            Get
                Return CredentialsSource.GetUserNames()
            End Get
        End Property

        Public Overridable Property CurrentUser() As MVVMExpenses.DataModels.User
        Private privateIsCurrentUserCredentialsValid As Boolean

        Public Property IsCurrentUserCredentialsValid() As Boolean
            Get
                Return privateIsCurrentUserCredentialsValid
            End Get
            Private Set(ByVal value As Boolean)
                privateIsCurrentUserCredentialsValid = value
            End Set
        End Property

        <DevExpress.Mvvm.DataAnnotations.Command(False)>
        Public Sub Init()
            Me.CurrentUser = New MVVMExpenses.DataModels.User()
        End Sub

        Public Sub Update()
            IsCurrentUserCredentialsValid = CredentialsSource.Check(CurrentUser.Login, CurrentUser.Password)
        End Sub

        Public Shared Function Create() As LoginViewModel
            Return ViewModelSource.Create(Of LoginViewModel)()
        End Function
    End Class
End Namespace
