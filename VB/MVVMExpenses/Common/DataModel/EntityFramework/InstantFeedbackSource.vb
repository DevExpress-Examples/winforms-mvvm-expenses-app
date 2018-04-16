Imports System
Imports System.Linq
Imports System.Data
Imports System.Data.Entity
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports Common.Utils
Imports Common.DataModel
Imports DevExpress.Mvvm
Imports System.Collections
Imports System.ComponentModel
Imports DevExpress.Data.Linq
Imports DevExpress.Data.Linq.Helpers
Imports DevExpress.Data.Async.Helpers
Namespace Common.DataModel.EntityFramework
    Friend Class InstantFeedbackSource(Of TEntity As Class)
        Implements IInstantFeedbackSource(Of TEntity)
        Private ReadOnly _source As EntityInstantFeedbackSource
        Private ReadOnly _threadSafeProperties As PropertyDescriptorCollection
        Public Sub New(ByVal source As EntityInstantFeedbackSource, ByVal threadSafeProperties As PropertyDescriptorCollection)
            Me._source = source
            Me._threadSafeProperties = threadSafeProperties
        End Sub
        Private ReadOnly Property ContainsListCollection As Boolean Implements IListSource.ContainsListCollection
            Get
                Return CType(_source, IListSource).ContainsListCollection
            End Get
        End Property
        Private Function GetList() As IList Implements IListSource.GetList
            Return CType(_source, IListSource).GetList()
        End Function
        Private Function GetPropertyValue(Of TProperty)(ByVal threadSafeProxy As Object, ByVal propertyExpression As Expression(Of Func(Of TEntity, TProperty))) As TProperty Implements IInstantFeedbackSource(Of TEntity).GetPropertyValue
            Dim propertyName = ExpressionHelper.GetPropertyName(propertyExpression)
            Dim threadSafeProperty = _threadSafeProperties(propertyName)
            Return CType(threadSafeProperty.GetValue(threadSafeProxy), TProperty)
        End Function
        Private Function IsLoadedProxy(ByVal threadSafeProxy As Object) As Boolean Implements IInstantFeedbackSource(Of TEntity).IsLoadedProxy
            Return TypeOf threadSafeProxy Is ReadonlyThreadSafeProxyForObjectFromAnotherThread
        End Function
        Private Sub Refresh() Implements IInstantFeedbackSource(Of TEntity).Refresh
            _source.Refresh()
        End Sub
    End Class
End Namespace
