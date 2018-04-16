Imports System
Imports System.ComponentModel
Imports System.Linq
Imports System.Linq.Expressions
Namespace Common.DataModel
    ''' <summary>
    ''' The IUnitOfWork interface represents the Unit Of Work pattern 
    ''' such that it can be used to query from a database and group together changes that will then be written back to the store as a unit. 
    ''' </summary>
    Public Interface IUnitOfWork
        ''' <summary>
        ''' Saves all changes made in this unit of work to the underlying store.
        ''' </summary>
        Sub SaveChanges()
        ''' <summary>
        ''' Checks if the unit of work is tracking any new, deleted, or changed entities or relationships that will be sent to the store if SaveChanges() is called.
        ''' </summary>
        Function HasChanges() As Boolean
    End Interface
    ''' <summary>
    ''' Provides the method to create a unit of work of a given type.
    ''' </summary>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Public Interface IUnitOfWorkFactory(Of TUnitOfWork As IUnitOfWork)
        ''' <summary>
        ''' Creates a new unit of work.
        ''' </summary>
        Function CreateUnitOfWork() As TUnitOfWork
        Function CreateInstantFeedbackSource(Of TEntity As {Class, New}, TProjection As Class, TPrimaryKey)(ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))) As IInstantFeedbackSource(Of TProjection)
    End Interface
    Public Interface IInstantFeedbackSource(Of TEntity As Class)
        Inherits IListSource
        Sub Refresh()
        Function GetPropertyValue(Of TProperty)(ByVal threadSafeProxy As Object, ByVal propertyExpression As Expression(Of Func(Of TEntity, TProperty))) As TProperty
        Function IsLoadedProxy(ByVal threadSafeProxy As Object) As Boolean
    End Interface
End Namespace
