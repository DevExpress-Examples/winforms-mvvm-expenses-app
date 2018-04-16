Imports System
Imports System.Linq
Imports System.Data
Imports System.Data.Entity
Imports System.Linq.Expressions
Imports System.Collections.Generic
Imports Common.Utils
Imports Common.DataModel
Imports System.Data.Entity.Validation
Imports System.Data.Entity.Infrastructure
Namespace Common.DataModel.EntityFramework
    ''' <summary>
    ''' A DbRepository is a IRepository interface implementation representing the collection of all entities in the unit of work, or that can be queried from the database, of a given type. 
    ''' DbRepository objects are created from a DbUnitOfWork using the GetRepository method. 
    ''' DbRepository provides only write operations against entities of a given type in addition to the read-only operation provided DbReadOnlyRepository base class.
    ''' </summary>
    ''' <typeparam name="TEntity">Repository entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">Entity primary key type.</typeparam>
    ''' <typeparam name="TDbContext">DbContext type.</typeparam>
    Public Class DbRepository(Of TEntity As Class, TPrimaryKey, TDbContext As DbContext)
        Inherits DbReadOnlyRepository(Of TEntity, TDbContext)
        Implements IRepository(Of TEntity, TPrimaryKey)
        Private ReadOnly _getPrimaryKeyExpression As Expression(Of Func(Of TEntity, TPrimaryKey))
        Private ReadOnly _entityTraits As EntityTraits(Of TEntity, TPrimaryKey)
        ''' <summary>
        ''' Initializes a new instance of DbRepository class.
        ''' </summary>
        ''' <param name="unitOfWork">Owner unit of work that provides context for repository entities.</param>
        ''' <param name="dbSetAccessor">Function that returns DbSet entities from Entity Framework DbContext.</param>
        ''' <param name="getPrimaryKeyExpression">Lambda-expression that returns entity primary key.</param>
        Public Sub New(ByVal unitOfWork As DbUnitOfWork(Of TDbContext), ByVal dbSetAccessor As Func(Of TDbContext, DbSet(Of TEntity)), ByVal getPrimaryKeyExpression As Expression(Of Func(Of TEntity, TPrimaryKey)))
            MyBase.New(unitOfWork, dbSetAccessor)
            Me._getPrimaryKeyExpression = getPrimaryKeyExpression
            Me._entityTraits = ExpressionHelper.GetEntityTraits(Me, getPrimaryKeyExpression)
        End Sub
        Protected Overridable Function CreateCore(Optional ByVal add As Boolean = True) As TEntity
            Dim newEntity As TEntity = DbSet.Create()
            If add Then
                DbSet.Add(newEntity)
            End If
            Return newEntity
        End Function
        Protected Overridable Sub UpdateCore(ByVal entity As TEntity)
        End Sub
        Protected Overridable Function GetStateCore(ByVal entity As TEntity) As EntityState
            Return GetEntityState(Context.Entry(entity).State)
        End Function
        Private Shared Function GetEntityState(ByVal entityStates As System.Data.Entity.EntityState) As EntityState
            Select Case entityStates
                Case System.Data.Entity.EntityState.Added
                    Return EntityState.Added
                Case System.Data.Entity.EntityState.Deleted
                    Return EntityState.Deleted
                Case System.Data.Entity.EntityState.Detached
                    Return EntityState.Detached
                Case System.Data.Entity.EntityState.Modified
                    Return EntityState.Modified
                Case System.Data.Entity.EntityState.Unchanged
                    Return EntityState.Unchanged
                Case Else
                    Throw New NotImplementedException()
            End Select
        End Function
        Protected Overridable Function FindCore(ByVal primaryKey As TPrimaryKey) As TEntity
            Return DbSet.Find(primaryKey)
        End Function
        Protected Overridable Sub RemoveCore(ByVal entity As TEntity)
            Try
                DbSet.Remove(entity)
            Catch ex As DbEntityValidationException
                Throw DbExceptionsConverter.Convert(ex)
            Catch ex As DbUpdateException
                Throw DbExceptionsConverter.Convert(ex)
            End Try
        End Sub
        Protected Overridable Function ReloadCore(ByVal entity As TEntity) As TEntity
            Context.Entry(entity).Reload()
            Return FindCore(GetPrimaryKeyCore(entity))
        End Function
        Protected Overridable Function GetPrimaryKeyCore(ByVal entity As TEntity) As TPrimaryKey
            Return _entityTraits.GetPrimaryKey(entity)
        End Function
        Protected Overridable Sub SetPrimaryKeyCore(ByVal entity As TEntity, ByVal primaryKey As TPrimaryKey)
            Dim setPrimaryKeyAction = _entityTraits.SetPrimaryKey
            setPrimaryKeyAction(entity, primaryKey)
        End Sub
        Private Function Find(ByVal primaryKey As TPrimaryKey) As TEntity Implements IRepository(Of TEntity, TPrimaryKey).Find
            Return FindCore(primaryKey)
        End Function
        Private Sub Add(ByVal entity As TEntity) Implements IRepository(Of TEntity, TPrimaryKey).Add
            DbSet.Add(entity)
        End Sub
        Private Sub Remove(ByVal entity As TEntity) Implements IRepository(Of TEntity, TPrimaryKey).Remove
            RemoveCore(entity)
        End Sub
        Private Function Create(Optional ByVal add As Boolean = True) As TEntity Implements IRepository(Of TEntity, TPrimaryKey).Create
            Return CreateCore(add)
        End Function
        Private Sub Update(ByVal entity As TEntity) Implements IRepository(Of TEntity, TPrimaryKey).Update
            UpdateCore(entity)
        End Sub
        Private Function GetState(ByVal entity As TEntity) As EntityState Implements IRepository(Of TEntity, TPrimaryKey).GetState
            Return GetStateCore(entity)
        End Function
        Private Function Reload(ByVal entity As TEntity) As TEntity Implements IRepository(Of TEntity, TPrimaryKey).Reload
            Return ReloadCore(entity)
        End Function
        Private ReadOnly Property GetPrimaryKeyExpression As Expression(Of Func(Of TEntity, TPrimaryKey)) Implements IRepository(Of TEntity, TPrimaryKey).GetPrimaryKeyExpression
            Get
                Return Me._getPrimaryKeyExpression
            End Get
        End Property
        Private Sub SetPrimaryKey(ByVal entity As TEntity, ByVal primaryKey As TPrimaryKey) Implements IRepository(Of TEntity, TPrimaryKey).SetPrimaryKey
            SetPrimaryKeyCore(entity, primaryKey)
        End Sub
        Private Function GetPrimaryKey(ByVal entity As TEntity) As TPrimaryKey Implements IRepository(Of TEntity, TPrimaryKey).GetPrimaryKey
            Return GetPrimaryKeyCore(entity)
        End Function
        Private Function HasPrimaryKey(ByVal entity As TEntity) As Boolean Implements IRepository(Of TEntity, TPrimaryKey).HasPrimaryKey
            Return _entityTraits.HasPrimaryKey(entity)
        End Function
    End Class
End Namespace
