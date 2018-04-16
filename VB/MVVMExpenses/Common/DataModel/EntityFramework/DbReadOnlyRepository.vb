Imports System
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Data.Entity
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Namespace Common.DataModel.EntityFramework
    ''' <summary>
    ''' A DbReadOnlyRepository is a IReadOnlyRepository interface implementation representing the collection of all entities in the unit of work, or that can be queried from the database, of a given type. 
    ''' DbReadOnlyRepository objects are created from a DbUnitOfWork using the GetReadOnlyRepository method. 
    ''' DbReadOnlyRepository provides only read-only operations against entities of a given type.
    ''' </summary>
    ''' <typeparam name="TEntity">Repository entity type.</typeparam>
    ''' <typeparam name="TDbContext">DbContext type.</typeparam>
    Public Class DbReadOnlyRepository(Of TEntity As Class, TDbContext As DbContext)
        Inherits DbRepositoryQuery(Of TEntity)
        Implements IReadOnlyRepository(Of TEntity)
        Private ReadOnly _dbSetAccessor As Func(Of TDbContext, DbSet(Of TEntity))
        Private ReadOnly _unitOfWork As DbUnitOfWork(Of TDbContext)
        ''' <summary>
        ''' Initializes a new instance of DbReadOnlyRepository class.
        ''' </summary>
        ''' <param name="unitOfWork">Owner unit of work that provides context for repository entities.</param>
        ''' <param name="dbSetAccessor">Function that returns DbSet entities from Entity Framework DbContext.</param>
        Public Sub New(ByVal unitOfWork As DbUnitOfWork(Of TDbContext), ByVal dbSetAccessor As Func(Of TDbContext, DbSet(Of TEntity)))
            MyBase.New(Function() dbSetAccessor(unitOfWork.Context))
            Me._dbSetAccessor = dbSetAccessor
            Me._unitOfWork = unitOfWork
        End Sub
        Protected ReadOnly Property DbSet As DbSet(Of TEntity)
            Get
                Return _dbSetAccessor(_unitOfWork.Context)
            End Get
        End Property
        Protected ReadOnly Property Context As TDbContext
            Get
                Return _unitOfWork.Context
            End Get
        End Property
        Private ReadOnly Property UnitOfWork As IUnitOfWork Implements IReadOnlyRepository(Of TEntity).UnitOfWork
            Get
                Return _unitOfWork
            End Get
        End Property
    End Class
    ''' <summary>
    ''' DbRepositoryQuery is an IRepositoryQuery interface implementation that is an extension of IQueryable designed to specify the related objects to include in query results.
    ''' </summary>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    Public Class DbRepositoryQuery(Of TEntity As Class)
        Inherits RepositoryQueryBase(Of TEntity)
        Implements IRepositoryQuery(Of TEntity)
        ''' <summary>
        ''' Initializes a new instance of the DesignTimeRepositoryQuery class.
        ''' </summary>
        ''' <param name="getQueryable">A function that returns an IQueryable instance which is used by DbRepositoryQuery to perform queries.</param>
        Public Sub New(ByVal getQueryable As Func(Of IQueryable(Of TEntity)))
            MyBase.New(getQueryable)
        End Sub
        Private Function Include(Of TProperty)(ByVal path As Expression(Of Func(Of TEntity, TProperty))) As IRepositoryQuery(Of TEntity) Implements IRepositoryQuery(Of TEntity).Include
            Return New DbRepositoryQuery(Of TEntity)(Function() Queryable.Include(path))
        End Function
        Private Function Where(ByVal predicate As Expression(Of Func(Of TEntity, Boolean))) As IRepositoryQuery(Of TEntity) Implements IRepositoryQuery(Of TEntity).Where
            Return New DbRepositoryQuery(Of TEntity)(Function() Queryable.Where(predicate))
        End Function
    End Class
End Namespace
