Imports System
Imports System.Linq
Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports System.Collections.ObjectModel
Imports Common.Utils
Imports Common.DataModel
Namespace Common.ViewModel
    ''' <summary>
    ''' Represents a POCO view models used by SingleObjectViewModel to exposing collections of related entities.
    ''' This is a partial class that provides an extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    ''' <typeparam name="TProjection">A projection entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Public Class LookUpEntitiesViewModel(Of TEntity As Class, TProjection As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits EntitiesViewModel(Of TEntity, TProjection, TUnitOfWork)
        Implements IDocumentContent
        ''' <summary>
        ''' Creates a new instance of LookUpEntitiesViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">An optional parameter that provides a LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        Public Shared Function Create(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)) = Nothing) As LookUpEntitiesViewModel(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)
            Return ViewModelSource.Create(Function() New LookUpEntitiesViewModel(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)(unitOfWorkFactory, getRepositoryFunc, projection))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the LookUpEntitiesViewModel class.
        ''' This constructor is declared protected to avoid an undesired instantiation of the LookUpEntitiesViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)))
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection)
        End Sub
        Protected Overrides Function CreateEntitiesChangeTracker() As IEntitiesChangeTracker
            Return New EntitiesChangeTracker(Of TPrimaryKey)(Me)
        End Function
    End Class
End Namespace
