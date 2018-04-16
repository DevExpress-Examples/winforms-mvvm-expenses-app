Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports System.Data.Entity.Validation
Imports System.Data.Entity.Infrastructure
Imports System.Linq
Imports System.Linq.Expressions
Namespace Common.DataModel.EntityFramework
    ''' <summary>
    ''' A DbUnitOfWork instance represents the implementation of the Unit Of Work pattern 
    ''' such that it can be used to query from a database and group together changes that will then be written back to the store as a unit. 
    ''' </summary>
    ''' <typeparam name="TContext">DbContext type.</typeparam>
    Public MustInherit Class DbUnitOfWork(Of TContext As DbContext)
        Inherits UnitOfWorkBase
        Implements IUnitOfWork
        Private ReadOnly _context As Lazy(Of TContext)
        Public Sub New(ByVal contextFactory As Func(Of TContext))
            _context = New Lazy(Of TContext)(contextFactory)
        End Sub
        ''' <summary>
        ''' Instance of underlying DbContext.
        ''' </summary>
        Public ReadOnly Property Context As TContext
            Get
                Return _context.Value
            End Get
        End Property
        Private Sub SaveChanges() Implements IUnitOfWork.SaveChanges
            Try
                Context.SaveChanges()
            Catch ex As DbEntityValidationException
                Throw DbExceptionsConverter.Convert(ex)
            Catch ex As DbUpdateException
                Throw DbExceptionsConverter.Convert(ex)
            End Try
        End Sub
        Private Function HasChanges() As Boolean Implements IUnitOfWork.HasChanges
            Return Context.ChangeTracker.HasChanges()
        End Function
        Protected Function GetRepository(Of TEntity As Class, TPrimaryKey)(ByVal dbSetAccessor As Func(Of TContext, DbSet(Of TEntity)), ByVal getPrimaryKeyExpression As Expression(Of Func(Of TEntity, TPrimaryKey))) As IRepository(Of TEntity, TPrimaryKey)
            Return GetRepositoryCore(Of IRepository(Of TEntity, TPrimaryKey), TEntity)(Function() New DbRepository(Of TEntity, TPrimaryKey, TContext)(Me, dbSetAccessor, getPrimaryKeyExpression))
        End Function
        Protected Function GetReadOnlyRepository(Of TEntity As Class)(ByVal dbSetAccessor As Func(Of TContext, DbSet(Of TEntity))) As IReadOnlyRepository(Of TEntity)
            Return GetRepositoryCore(Of IReadOnlyRepository(Of TEntity), TEntity)(Function() New DbReadOnlyRepository(Of TEntity, TContext)(Me, dbSetAccessor))
        End Function
    End Class
End Namespace
