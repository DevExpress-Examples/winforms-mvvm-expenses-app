Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ComponentModel.DataAnnotations

Namespace MVVMExpenses.DataModels
    Public Class Category
        <Key, Display(AutoGenerateField:=False)>
        Public Property ID() As Long
        <Required, StringLength(30, MinimumLength:=5), Display(Name:="CATEGORY")>
        Public Property Name() As String
        <EnumDataType(GetType(TransactionType)), Display(Name:="TRANSACTION TYPE")>
        Public Property Type() As TransactionType
        Public Overrides Function ToString() As String
            Return Name & " (" & Type.ToString() & ")"
        End Function
    End Class
End Namespace