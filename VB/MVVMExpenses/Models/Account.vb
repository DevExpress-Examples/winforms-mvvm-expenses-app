Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ComponentModel.DataAnnotations

Namespace MVVMExpenses.DataModels
    Public Class Account
        <Key, Display(AutoGenerateField:=False)>
        Public Property ID() As Long
        <Required, StringLength(30, MinimumLength:=4), Display(Name:="ACCOUNT")>
        Public Property Name() As String
        <DataType(DataType.Currency), Display(Name:="AMOUNT")>
        Public Property Amount() As Decimal
        Public Overrides Function ToString() As String
            Return Name & " (" & Amount.ToString("C") & ")"
        End Function
    End Class
End Namespace