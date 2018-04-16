Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ComponentModel.DataAnnotations

Namespace MVVMExpenses.DataModels
    Public Enum TransactionType
        Expense
        Income
    End Enum
    Public Class Transaction
        <Key, Display(AutoGenerateField:=False)>
        Public Property ID() As Long
        <Display(AutoGenerateField:=False)>
        Public Property AccountID() As Long
        <Display(Name:="ACCOUNT")>
        Public Overridable Property Account() As Account
        <Display(AutoGenerateField:=False)>
        Public Property CategoryID() As Long
        <Display(Name:="CATEGORY")>
        Public Overridable Property Category() As Category
        <DataType(DataType.Date), Display(Name:="DATE")>
        Public Property [Date]() As Date
        <DataType(DataType.Currency), Display(Name:="AMOUNT")>
        Public Property Amount() As Decimal
        <DataType(DataType.MultilineText), Display(Name:="COMMENT")>
        Public Property Comment() As String
    End Class
End Namespace