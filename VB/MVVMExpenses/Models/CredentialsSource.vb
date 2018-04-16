Imports System.Collections.Generic
Imports DevExpress.Mvvm.POCO

Namespace MVVMExpenses.Models
    '
    ' TODO - your implementation
    Friend NotInheritable Class CredentialsSource

        Private Sub New()
        End Sub

        Private Shared credentials As System.Collections.Hashtable
        Shared Sub New()
            credentials = New System.Collections.Hashtable()
            credentials.Add("Guest", GetHash(Nothing))
            credentials.Add("John", GetHash("qwerty"))
            credentials.Add("Administrator", GetHash("admin"))
            credentials.Add("Mary", GetHash("12345"))
        End Sub
        Friend Shared Function Check(ByVal login As String, ByVal pwd As String) As Boolean
            Return Object.Equals(credentials(login), GetHash(pwd))
        End Function
        Private Shared Function GetHash(ByVal password As String) As Object
            Return password
        End Function
        Friend Shared Iterator Function GetUserNames() As System.Collections.Generic.IEnumerable(Of String)
            For Each item As String In credentials.Keys
                Yield item
            Next item
        End Function
    End Class
End Namespace
