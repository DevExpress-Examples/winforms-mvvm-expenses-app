Imports System
Imports System.Linq
Namespace Common.DataModel
    ''' <summary>
    ''' The database-independent exception used in Data Layer and View Model Layer to handle database errors.
    ''' </summary>
    Public Class DbException
        Inherits Exception
        Private _ErrorCaption As String
        Private _ErrorMessage As String
        ''' <summary>
        ''' Initializes a new instance of the DbRepository class.
        ''' </summary>
        ''' <param name="errorMessage">An error message text.</param>
        ''' <param name="errorCaption">An error message caption text.</param>
        ''' <param name="innerException">An underlying exception.</param>
        Public Sub New(ByVal errorMessage As String, ByVal errorCaption As String, ByVal innerException As Exception)
            MyBase.New(innerException.Message, innerException)
            Me._ErrorMessage = errorMessage
            Me._ErrorCaption = errorCaption
        End Sub
        ''' <summary>The error message text.</summary>
        Public ReadOnly Property ErrorMessage As String
            Get
                Return _ErrorMessage
            End Get
        End Property
        ''' <summary>The error message caption text.</summary>
        Public ReadOnly Property ErrorCaption As String
            Get
                Return _ErrorCaption
            End Get
        End Property
    End Class
End Namespace
