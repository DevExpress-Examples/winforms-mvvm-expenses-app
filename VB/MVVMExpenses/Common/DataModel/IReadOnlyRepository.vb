Imports System
Imports System.Linq
Imports System.Collections.ObjectModel
Imports System.Linq.Expressions
Imports System.Collections
Imports System.Collections.Generic
Namespace Common.DataModel
    ''' <summary>
    ''' The IReadOnlyRepository interface represents the read-only implementation of the Repository pattern 
    ''' such that it can be used to query entities of a given type. 
    ''' </summary>
    ''' <typeparam name="TEntity">Repository entity type.</typeparam>
    Public Interface IReadOnlyRepository(Of TEntity As Class)
        Inherits IRepositoryQuery(Of TEntity)
        ''' <summary>
        ''' The owner unit of work.
        ''' </summary>
        ReadOnly Property UnitOfWork As IUnitOfWork
    End Interface
    ''' <summary>
    ''' The IRepositoryQuery interface represents an extension of IQueryable designed to provide an ability to specify the related objects to include in the query results.
    ''' </summary>
    ''' <typeparam name="T">An entity type.</typeparam>
    Public Interface IRepositoryQuery(Of T)
        Inherits IQueryable(Of T)
        ''' <summary>
        ''' Specifies the related objects to include in the query results.
        ''' </summary>
        ''' <typeparam name="TProperty">The type of the navigation property to be included.</typeparam>
        ''' <param name="path">A lambda expression that represents the path to include.</param>
        Function Include(Of TProperty)(ByVal path As Expression(Of Func(Of T, TProperty))) As IRepositoryQuery(Of T)
        ''' <summary>
        ''' Filters a sequence of entities based on the given predicate.
        ''' </summary>
        ''' <param name="predicate">A function to test each entity for a condition.</param>
        Function Where(ByVal predicate As Expression(Of Func(Of T, Boolean))) As IRepositoryQuery(Of T)
    End Interface
    ''' <summary>
    ''' The base class that helps to implement the IRepositoryQuery interface as a wrapper over an existing IQuerable instance.
    ''' </summary>
    ''' <typeparam name="T">An entity type.</typeparam>
    Public MustInherit Class RepositoryQueryBase(Of T)
        Implements IQueryable(Of T)
        Private ReadOnly _queryable As Lazy(Of IQueryable(Of T))
        Protected ReadOnly Property Queryable As IQueryable(Of T)
            Get
                Return _queryable.Value
            End Get
        End Property
        Protected Sub New(ByVal getQueryable As Func(Of IQueryable(Of T)))
            Me._queryable = New Lazy(Of IQueryable(Of T))(getQueryable)
        End Sub
        Private ReadOnly Property ElementType As Type Implements IQueryable.ElementType
            Get
                Return Me.Queryable.ElementType
            End Get
        End Property
        Private ReadOnly Property Expression As Expression Implements IQueryable.Expression
            Get
                Return Me.Queryable.Expression
            End Get
        End Property
        Private ReadOnly Property Provider As IQueryProvider Implements IQueryable.Provider
            Get
                Return Me.Queryable.Provider
            End Get
        End Property
        Private Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return Me.Queryable.GetEnumerator()
        End Function
        Private Function GetEnumerator_Impl() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
            Return Me.Queryable.GetEnumerator()
        End Function
    End Class
    ''' <summary>
    ''' Provides a set of extension methods to perform commonly used operations with IReadOnlyRepository.
    ''' </summary>
    Public Module ReadOnlyRepositoryExtensions
        ''' <summary>
        ''' Returns IQuerable representing sequence of entities from repository filtered by the given predicate and projected to the specified projection entity type by the given LINQ function.
        ''' </summary>
        ''' <typeparam name="TEntity">A repository entity type.</typeparam>
        ''' <typeparam name="TProjection">A projection entity type.</typeparam>
        ''' <param name="repository">A repository.</param>
        ''' <param name="predicate">A function to test each element for a condition.</param>
        ''' <param name="projection">A LINQ function used to transform entities from repository entity type to projection entity type.</param>
        <System.Runtime.CompilerServices.Extension> _
        Public Function GetFilteredEntities(Of TEntity As Class, TProjection)(ByVal repository As IReadOnlyRepository(Of TEntity), ByVal predicate As Expression(Of Func(Of TEntity, Boolean)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))) As IQueryable(Of TProjection)
            Return AppendToProjection(predicate, projection)(repository)
        End Function
        ''' <summary>
        ''' Combines an initial projection and a predicate into a new projection with the effect of both.
        ''' </summary>
        ''' <typeparam name="TEntity">A repository entity type.</typeparam>
        ''' <typeparam name="TProjection">A projection entity type.</typeparam>
        ''' <param name="predicate">A function to test each element for a condition.</param>
        ''' <param name="projection">A LINQ function used to transform entities from repository entity type to projection entity type.</param>
        ''' <returns></returns>
        Public Function AppendToProjection(Of TEntity As Class, TProjection)(ByVal predicate As Expression(Of Func(Of TEntity, Boolean)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))) As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))
            If predicate Is Nothing AndAlso projection Is Nothing Then
                Return Function(q) CType(q, IQueryable(Of TProjection))
            End If
            If predicate Is Nothing Then
                Return projection
            End If
            If projection Is Nothing Then
                Return Function(q) CType(q.Where(predicate), IQueryable(Of TProjection))
            End If
            Return Function(q) projection(q.Where(predicate))
        End Function
        ''' <summary>
        ''' Returns IQuerable representing sequence of entities from repository filtered by the given predicate.
        ''' </summary>
        ''' <typeparam name="TEntity">A repository entity type.</typeparam>
        ''' <param name="repository">A repository.</param>
        ''' <param name="predicate">A function to test each element for a condition.</param>
        <System.Runtime.CompilerServices.Extension> _
        Public Function GetFilteredEntities(Of TEntity As Class)(ByVal repository As IReadOnlyRepository(Of TEntity), ByVal predicate As Expression(Of Func(Of TEntity, Boolean))) As IQueryable(Of TEntity)
            Return repository.GetFilteredEntities(predicate, Function(x) x)
        End Function
    End Module
End Namespace
