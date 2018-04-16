Imports System
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Validation
Imports System.Linq
Imports System.Text
Namespace Common.DataModel.EntityFramework
    ''' <summary>
    ''' Provides methods to convert Entity Framework exceptions to database-independent exceptions used in Data Layer and View Model Layer.
    ''' </summary>
    Public Module DbExceptionsConverter
        ''' <summary>
        ''' Converts System.Data.Entity.Infrastructure.DbUpdateException exception to database-independent DbException exception used in Data Layer and View Model Layer.
        ''' </summary>
        ''' <param name="exception">Exception to convert.</param>
        Public Function Convert(ByVal exception As DbUpdateException) As DbException
            Dim originalException As Exception = exception
            While originalException.InnerException IsNot Nothing
                originalException = originalException.InnerException
            End While
            Return New DbException(originalException.Message, CommonResources.Exception_UpdateErrorCaption, exception)
        End Function
        ''' <summary>
        ''' Converts System.Data.Entity.Validation.DbEntityValidationException exception to database-independent DbException exception used in Data Layer and View Model Layer.
        ''' </summary>
        ''' <param name="exception">Exception to convert.</param>
        Public Function Convert(ByVal exception As DbEntityValidationException) As DbException
            Dim stringBuilder As StringBuilder = New StringBuilder()
            For Each validationResult As DbEntityValidationResult In exception.EntityValidationErrors
                For Each [error] As DbValidationError In validationResult.ValidationErrors
                    If stringBuilder.Length > 0 Then
                        stringBuilder.AppendLine()
                    End If
                    stringBuilder.Append([error].PropertyName + ": " + [error].ErrorMessage)
                Next
            Next
            Return New DbException(stringBuilder.ToString(), CommonResources.Exception_ValidationErrorCaption, exception)
        End Function
    End Module
End Namespace
