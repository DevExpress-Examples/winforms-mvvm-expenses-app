Imports System
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm.DataAnnotations
Imports System.Collections.ObjectModel
Imports System.Threading
Imports System.Threading.Tasks
Imports Common.Utils
Imports Common.DataModel
Namespace Common.ViewModel
    ''' <summary>
    ''' The base class for POCO view models exposing a collection of entities of the given type.
    ''' This is a partial class that provides an extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    ''' <typeparam name="TProjection">A projection entity type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Partial Public MustInherit Class EntitiesViewModel(Of TEntity As Class, TProjection As Class, TUnitOfWork As IUnitOfWork)
        Inherits EntitiesViewModelBase(Of TEntity, TProjection, TUnitOfWork)
        ''' <summary>
        ''' Initializes a new instance of the EntitiesViewModel class.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)))
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection)
        End Sub
    End Class
    ''' <summary>
    ''' The base class for a POCO view models exposing a collection of entities of the given type.
    ''' It is not recommended to inherit directly from this class. Use the EntitiesViewModel class instead.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    ''' <typeparam name="TProjection">A projection entity type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    <POCOViewModel> _
    Public MustInherit Class EntitiesViewModelBase(Of TEntity As Class, TProjection As Class, TUnitOfWork As IUnitOfWork)
        Implements IEntitiesViewModel(Of TProjection)
        Private _DocumentOwner As IDocumentOwner
        Private _ReadOnlyRepository As IReadOnlyRepository(Of TEntity)
        Private _ChangeTracker As IEntitiesChangeTracker
        Private _Projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))
        Protected Interface IEntitiesChangeTracker
            Sub RegisterMessageHandler()
            Sub UnregisterMessageHandler()
        End Interface
        Protected Class EntitiesChangeTracker(Of TPrimaryKey)
            Implements IEntitiesChangeTracker
            Private ReadOnly _owner As EntitiesViewModelBase(Of TEntity, TProjection, TUnitOfWork)
            Private ReadOnly Property Entities As ObservableCollection(Of TProjection)
                Get
                    Return _owner.Entities
                End Get
            End Property
            Private ReadOnly Property Repository As IRepository(Of TEntity, TPrimaryKey)
                Get
                    Return CType(_owner.ReadOnlyRepository, IRepository(Of TEntity, TPrimaryKey))
                End Get
            End Property
            Public Sub New(ByVal owner As EntitiesViewModelBase(Of TEntity, TProjection, TUnitOfWork))
                Me._owner = owner
            End Sub
            Private Sub RegisterMessageHandler() Implements IEntitiesChangeTracker.RegisterMessageHandler
                Messenger.[Default].Register(Of EntityMessage(Of TEntity, TPrimaryKey))(Me, Sub(x) OnMessage(x))
            End Sub
            Private Sub UnregisterMessageHandler() Implements IEntitiesChangeTracker.UnregisterMessageHandler
                Messenger.[Default].Unregister(Me)
            End Sub
            Public Function FindLocalProjectionByKey(ByVal primaryKey As TPrimaryKey) As TProjection
                Dim primaryKeyEqualsExpression = RepositoryExtensions.GetProjectionPrimaryKeyEqualsExpression(Of TEntity, TProjection, TPrimaryKey)(Repository, primaryKey)
                Return Entities.AsQueryable().FirstOrDefault(primaryKeyEqualsExpression)
            End Function
            Public Function FindActualProjectionByKey(ByVal primaryKey As TPrimaryKey) As TProjection
                Dim projectionEntity = Repository.FindActualProjectionByKey(_owner.Projection, primaryKey)
                If projectionEntity IsNot Nothing AndAlso ExpressionHelper.IsFitEntity(Repository.Find(primaryKey), _owner.GetFilterExpression()) Then
                    _owner.OnEntitiesLoaded(GetUnitOfWork(Repository), New TProjection() {projectionEntity})
                    Return projectionEntity
                End If
                Return Nothing
            End Function
            Private Sub OnMessage(ByVal message As EntityMessage(Of TEntity, TPrimaryKey))
                If Not _owner.IsLoaded Then
                    Return
                End If
                Select Case message.MessageType
                    Case EntityMessageType.Added
                        OnEntityAdded(message.PrimaryKey)
                        Exit Select
                    Case EntityMessageType.Changed
                        OnEntityChanged(message.PrimaryKey)
                        Exit Select
                    Case EntityMessageType.Deleted
                        OnEntityDeleted(message.PrimaryKey)
                        Exit Select
                End Select
            End Sub
            Private Sub OnEntityAdded(ByVal primaryKey As TPrimaryKey)
                Dim projectionEntity = FindActualProjectionByKey(primaryKey)
                If projectionEntity IsNot Nothing Then
                    Entities.Add(projectionEntity)
                End If
            End Sub
            Private Sub OnEntityChanged(ByVal primaryKey As TPrimaryKey)
                Dim existingProjectionEntity = FindLocalProjectionByKey(primaryKey)
                Dim projectionEntity = FindActualProjectionByKey(primaryKey)
                If projectionEntity Is Nothing Then
                    Entities.Remove(existingProjectionEntity)
                    Return
                End If
                If existingProjectionEntity IsNot Nothing Then
                    Entities(Entities.IndexOf(existingProjectionEntity)) = projectionEntity
                    _owner.RestoreSelectedEntity(existingProjectionEntity, projectionEntity)
                    Return
                End If
                OnEntityAdded(primaryKey)
            End Sub
            Private Sub OnEntityDeleted(ByVal primaryKey As TPrimaryKey)
                Entities.Remove(FindLocalProjectionByKey(primaryKey))
            End Sub
        End Class
        Private _entities As ObservableCollection(Of TProjection) = New ObservableCollection(Of TProjection)()
        Private _loadCancellationTokenSource As CancellationTokenSource
        Protected ReadOnly unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork)
        Protected ReadOnly getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity))
        Protected ReadOnly Property Projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))
            Get
                Return _Projection
            End Get
        End Property
        ''' <summary>
        ''' Initializes a new instance of the EntitiesViewModelBase class.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)))
            Me.unitOfWorkFactory = unitOfWorkFactory
            Me.getRepositoryFunc = getRepositoryFunc
            Me._Projection = projection
            Me._ChangeTracker = CreateEntitiesChangeTracker()
            If Not Me.IsInDesignMode() Then
                OnInitializeInRuntime()
            End If
        End Sub
        ''' <summary>
        ''' Used to check whether entities are currently being loaded in the background. The property can be used to show the progress indicator.
        ''' </summary>
        Public Overridable Property IsLoading As Boolean
        ''' <summary>
        ''' The collection of entities loaded from the unit of work.
        ''' </summary>
        Public ReadOnly Property Entities As ObservableCollection(Of TProjection)
            Get
                If Not IsLoaded Then
                    LoadEntities(False)
                End If
                Return _entities
            End Get
        End Property
        Protected ReadOnly Property ChangeTracker As IEntitiesChangeTracker
            Get
                Return _ChangeTracker
            End Get
        End Property
        Protected ReadOnly Property ReadOnlyRepository As IReadOnlyRepository(Of TEntity)
            Get
                Return _ReadOnlyRepository
            End Get
        End Property
        Protected ReadOnly Property IsLoaded As Boolean
            Get
                Return ReadOnlyRepository IsNot Nothing
            End Get
        End Property
        Protected Sub LoadEntities(ByVal forceLoad As Boolean)
            If forceLoad Then
                If _loadCancellationTokenSource IsNot Nothing Then
                    _loadCancellationTokenSource.Cancel()
                End If
            Else
                If IsLoading Then
                    Return
                End If
            End If
            _loadCancellationTokenSource = LoadCore()
        End Sub
        Private Sub CancelLoading()
            If _loadCancellationTokenSource IsNot Nothing Then
                _loadCancellationTokenSource.Cancel()
            End If
            IsLoading = False
        End Sub
        Private Function LoadCore() As CancellationTokenSource
            IsLoading = True
            Dim cancellationTokenSource = New CancellationTokenSource()
            Dim selectedEntityCallback = GetSelectedEntityCallback()
            System.Threading.Tasks.Task.Factory.StartNew(Function()
                                                             Dim repository = CreateReadOnlyRepository()
                                                             Dim entities = New ObservableCollection(Of TProjection)(repository.GetFilteredEntities(GetFilterExpression(), Projection))
                                                             OnEntitiesLoaded(GetUnitOfWork(repository), entities)
                                                             Return New Tuple(Of IReadOnlyRepository(Of TEntity), ObservableCollection(Of TProjection))(repository, entities)
                                                         End Function).ContinueWith(Sub(x)
                                                                                        If Not x.IsFaulted Then
                                                                                            _ReadOnlyRepository = x.Result.Item1
                                                                                            _entities = x.Result.Item2
                                                                                            Me.RaisePropertyChanged(Function(y) y.Entities)
                                                                                            OnEntitiesAssigned(selectedEntityCallback)
                                                                                        End If
                                                                                        IsLoading = False
                                                                                    End Sub, cancellationTokenSource.Token, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext())
            Return cancellationTokenSource
        End Function
        Private Shared Function GetUnitOfWork(ByVal repository As IReadOnlyRepository(Of TEntity)) As TUnitOfWork
            Return CType(repository.UnitOfWork, TUnitOfWork)
        End Function
        Protected Overridable Sub OnEntitiesLoaded(ByVal unitOfWork As TUnitOfWork, ByVal entities As IEnumerable(Of TProjection))
        End Sub
        Protected Overridable Sub OnEntitiesAssigned(ByVal getSelectedEntityCallback As Func(Of TProjection))
        End Sub
        Protected Overridable Function GetSelectedEntityCallback() As Func(Of TProjection)
            Return Nothing
        End Function
        Protected Overridable Sub RestoreSelectedEntity(ByVal existingProjectionEntity As TProjection, ByVal projectionEntity As TProjection)
        End Sub
        Protected Overridable Function GetFilterExpression() As Expression(Of Func(Of TEntity, Boolean))
            Return Nothing
        End Function
        Protected Overridable Sub OnInitializeInRuntime()
            If ChangeTracker IsNot Nothing Then
                ChangeTracker.RegisterMessageHandler()
            End If
        End Sub
        Protected Overridable Sub OnDestroy()
            CancelLoading()
            If ChangeTracker IsNot Nothing Then
                ChangeTracker.UnregisterMessageHandler()
            End If
        End Sub
        Protected Overridable Sub OnIsLoadingChanged()
        End Sub
        Protected Function CreateReadOnlyRepository() As IReadOnlyRepository(Of TEntity)
            Return getRepositoryFunc(CreateUnitOfWork())
        End Function
        Protected Function CreateUnitOfWork() As TUnitOfWork
            Return unitOfWorkFactory.CreateUnitOfWork()
        End Function
        Protected Overridable Function CreateEntitiesChangeTracker() As IEntitiesChangeTracker
            Return Nothing
        End Function
        Protected ReadOnly Property DocumentOwner As IDocumentOwner
            Get
                Return _DocumentOwner
            End Get
        End Property
        Private ReadOnly Property Title As Object Implements IDocumentContent.Title
            Get
                Return Nothing
            End Get
        End Property
        Protected Overridable Sub OnClose(ByVal e As CancelEventArgs)
        End Sub
        Private Sub OnClose_Impl(ByVal e As CancelEventArgs) Implements IDocumentContent.OnClose
            OnClose(e)
        End Sub
        Private Sub OnDestroy_Impl() Implements IDocumentContent.OnDestroy
            OnDestroy()
        End Sub
        Private Property DocumentOwner_Impl As IDocumentOwner Implements IDocumentContent.DocumentOwner
            Get
                Return DocumentOwner
            End Get
            Set(value As IDocumentOwner)
                _DocumentOwner = value
            End Set
        End Property
        Private ReadOnly Property Entities_Impl As ObservableCollection(Of TProjection) Implements IEntitiesViewModel(Of TProjection).Entities
            Get
                Return Entities
            End Get
        End Property
        Private ReadOnly Property IsLoading_Impl As Boolean Implements IEntitiesViewModel(Of TProjection).IsLoading
            Get
                Return IsLoading
            End Get
        End Property
    End Class
    ''' <summary>
    ''' The base interface for view models exposing a collection of entities of the given type.
    ''' </summary>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    Public Interface IEntitiesViewModel(Of TEntity As Class)
        Inherits IDocumentContent
        ''' <summary>
        ''' The loaded collection of entities.
        ''' </summary>
        ReadOnly Property Entities As ObservableCollection(Of TEntity)
        ''' <summary>
        ''' Used to check whether entities are currently being loaded in the background. The property can be used to show the progress indicator.
        ''' </summary>
        ReadOnly Property IsLoading As Boolean
    End Interface
End Namespace
