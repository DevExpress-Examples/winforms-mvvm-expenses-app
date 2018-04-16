Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm.DataAnnotations
Imports System.Collections.ObjectModel
Imports DevExpress.Data.Linq
Imports System.Collections
Imports Common.Utils
Imports Common.DataModel
Namespace Common.ViewModel
    Partial Public Class InstantFeedbackCollectionViewModel(Of TEntity As {Class, New}, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits InstantFeedbackCollectionViewModelBase(Of TEntity, TEntity, TPrimaryKey, TUnitOfWork)
        Public Shared Function CreateInstantFeedbackCollectionViewModel(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing, Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing) As InstantFeedbackCollectionViewModel(Of TEntity, TPrimaryKey, TUnitOfWork)
            Return ViewModelSource.Create(Function() New InstantFeedbackCollectionViewModel(Of TEntity, TPrimaryKey, TUnitOfWork)(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity))
        End Function
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing, Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity)
        End Sub
    End Class
    Partial Public Class InstantFeedbackCollectionViewModel(Of TEntity As {Class, New}, TProjection As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits InstantFeedbackCollectionViewModelBase(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)
        Public Shared Function CreateInstantFeedbackCollectionViewModel(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)), Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing) As InstantFeedbackCollectionViewModel(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)
            Return ViewModelSource.Create(Function() New InstantFeedbackCollectionViewModel(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity))
        End Function
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)), Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection, canCreateNewEntity)
        End Sub
    End Class
    Public MustInherit Class InstantFeedbackCollectionViewModelBase(Of TEntity As {Class, New}, TProjection As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Implements ISupportLogicalLayout, IDocumentContent
        Private _DocumentOwner As IDocumentOwner
        Private _Entities As InstantFeedbackSourceViewModel
        Private _Projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))
        Public Class InstantFeedbackSourceViewModel
            Implements IListSource
            Public Shared Function Create(ByVal getCount As Func(Of Integer), ByVal source As IInstantFeedbackSource(Of TProjection)) As InstantFeedbackSourceViewModel
                Return ViewModelSource.Create(Function() New InstantFeedbackSourceViewModel(getCount, source))
            End Function
            Private ReadOnly _getCount As Func(Of Integer)
            Private ReadOnly _source As IInstantFeedbackSource(Of TProjection)
            Protected Sub New(ByVal getCount As Func(Of Integer), ByVal source As IInstantFeedbackSource(Of TProjection))
                Me._getCount = getCount
                Me._source = source
            End Sub
            Public ReadOnly Property Count As Integer
                Get
                    Return _getCount()
                End Get
            End Property
            Public Sub Refresh()
                _source.Refresh()
                Me.RaisePropertyChanged(Function(x) x.Count)
            End Sub
            Private ReadOnly Property ContainsListCollection As Boolean Implements IListSource.ContainsListCollection
                Get
                    Return _source.ContainsListCollection
                End Get
            End Property
            Private Function GetList() As IList Implements IListSource.GetList
                Return _source.GetList()
            End Function
        End Class
        Protected ReadOnly unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork)
        Protected ReadOnly getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey))
        Protected ReadOnly Property Projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))
            Get
                Return _Projection
            End Get
        End Property
        Private _canCreateNewEntity As Func(Of Boolean)
        Private ReadOnly _helperRepository As IRepository(Of TEntity, TPrimaryKey)
        Private ReadOnly _source As IInstantFeedbackSource(Of TProjection)
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)), Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing)
            Me.unitOfWorkFactory = unitOfWorkFactory
            Me._canCreateNewEntity = canCreateNewEntity
            Me.getRepositoryFunc = getRepositoryFunc
            Me._Projection = projection
            Me._helperRepository = CreateRepository()
            RepositoryExtensions.VerifyProjection(_helperRepository, projection)
            Me._source = unitOfWorkFactory.CreateInstantFeedbackSource(getRepositoryFunc, projection)
            Me._Entities = InstantFeedbackSourceViewModel.Create(Function() _helperRepository.Count(), _source)
            If Not Me.IsInDesignMode() Then
                OnInitializeInRuntime()
            End If
        End Sub
        Public ReadOnly Property Entities As InstantFeedbackSourceViewModel
            Get
                Return _Entities
            End Get
        End Property
        Public Overridable Property SelectedEntity As Object
        Public Overridable Sub [New]()
            If _canCreateNewEntity IsNot Nothing AndAlso Not _canCreateNewEntity() Then
                Return
            End If
            DocumentManagerService.ShowNewEntityDocument(Of TEntity)(Me)
        End Sub
        Public Overridable Sub Edit(ByVal threadSafeProxy As Object)
            If Not _source.IsLoadedProxy(threadSafeProxy) Then
                Return
            End If
            Dim primaryKey As TPrimaryKey = GetProxyPrimaryKey(threadSafeProxy)
            Dim entity As TEntity = _helperRepository.Find(primaryKey)
            If entity Is Nothing Then
                DestroyDocument(DocumentManagerService.FindEntityDocument(Of TEntity, TPrimaryKey)(primaryKey))
                Return
            End If
            DocumentManagerService.ShowExistingEntityDocument(Of TEntity, TPrimaryKey)(Me, primaryKey)
        End Sub
        Public Function CanEdit(ByVal threadSafeProxy As Object) As Boolean
            Return threadSafeProxy IsNot Nothing
        End Function
        Public Overridable Sub Delete(ByVal threadSafeProxy As Object)
            If Not _source.IsLoadedProxy(threadSafeProxy) Then
                Return
            End If
            If MessageBoxService.ShowMessage(String.Format(CommonResources.Confirmation_Delete, GetType(TEntity).Name), CommonResources.Confirmation_Caption, MessageButton.YesNo) <> MessageResult.Yes Then
                Return
            End If
            Try
                Dim primaryKey As TPrimaryKey = GetProxyPrimaryKey(threadSafeProxy)
                Dim entity As TEntity = _helperRepository.Find(primaryKey)
                If entity IsNot Nothing Then
                    OnBeforeEntityDeleted(primaryKey, entity)
                    _helperRepository.Remove(entity)
                    _helperRepository.UnitOfWork.SaveChanges()
                    OnEntityDeleted(primaryKey, entity)
                End If
            Catch e As DbException
                Refresh()
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.[Error])
            End Try
            Refresh()
        End Sub
        Public Function CanDelete(ByVal threadSafeProxy As Object) As Boolean
            Return threadSafeProxy IsNot Nothing
        End Function
        Protected ReadOnly Property LayoutSerializationService As ILayoutSerializationService
            Get
                Return Me.GetService(Of ILayoutSerializationService)()
            End Get
        End Property
        Private ReadOnly Property ViewName As String
            Get
                Return GetType(TEntity).Name + "InstantFeedbackCollectionView"
            End Get
        End Property
        <Display(AutoGenerateField:=False)> _
        Public Overridable Sub OnLoaded()
            Dim state As String = Nothing
            If LayoutSerializationService IsNot Nothing AndAlso ViewModelLogicalLayoutHelper.PersistentViewsLayout.TryGetValue(ViewName, state) Then
                LayoutSerializationService.Deserialize(state)
            End If
        End Sub
        <Display(AutoGenerateField:=False)> _
        Public Overridable Sub OnUnloaded()
            SaveLayout()
        End Sub
        Private Sub SaveLayout()
            If LayoutSerializationService IsNot Nothing Then
                ViewModelLogicalLayoutHelper.PersistentViewsLayout(ViewName) = LayoutSerializationService.Serialize()
            End If
        End Sub
        Public Overridable Sub Refresh()
            Entities.Refresh()
        End Sub
        Protected Function GetProxyPrimaryKey(ByVal threadSafeProxy As Object) As TPrimaryKey
            Dim expression = RepositoryExtensions.GetProjectionPrimaryKeyExpression(Of TEntity, TProjection, TPrimaryKey)(_helperRepository)
            Return GetProxyPropertyValue(threadSafeProxy, expression)
        End Function
        Protected Function GetProxyPropertyValue(Of TProperty)(ByVal threadSafeProxy As Object, ByVal propertyExpression As Expression(Of Func(Of TProjection, TProperty))) As TProperty
            Return _source.GetPropertyValue(threadSafeProxy, propertyExpression)
        End Function
        Protected Overridable Sub OnEntityDeleted(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity)
            Messenger.[Default].Send(New EntityMessage(Of TEntity, TPrimaryKey)(primaryKey, EntityMessageType.Deleted))
        End Sub
        Protected ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return Me.GetRequiredService(Of IMessageBoxService)()
            End Get
        End Property
        Protected ReadOnly Property DocumentManagerService As IDocumentManagerService
            Get
                Return Me.GetService(Of IDocumentManagerService)()
            End Get
        End Property
        Protected Overridable Sub OnBeforeEntityDeleted(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity)
        End Sub
        Protected Sub DestroyDocument(ByVal document As IDocument)
            If document IsNot Nothing Then
                document.Close()
            End If
        End Sub
        Protected Function CreateRepository() As IRepository(Of TEntity, TPrimaryKey)
            Return getRepositoryFunc(CreateUnitOfWork())
        End Function
        Protected Function CreateUnitOfWork() As TUnitOfWork
            Return unitOfWorkFactory.CreateUnitOfWork()
        End Function
        Protected Overridable Sub OnInitializeInRuntime()
            Messenger.[Default].Register(Of EntityMessage(Of TEntity, TPrimaryKey))(Me, Sub(x) OnMessage(x))
        End Sub
        Protected Overridable Sub OnDestroy()
            Messenger.[Default].Unregister(Me)
        End Sub
        Private Sub OnMessage(ByVal message As EntityMessage(Of TEntity, TPrimaryKey))
            Refresh()
        End Sub
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
        Private Sub OnClose(ByVal e As CancelEventArgs) Implements IDocumentContent.OnClose
            SaveLayout()
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
        Private ReadOnly Property CanSerialize As Boolean Implements ISupportLogicalLayout.CanSerialize
            Get
                Return True
            End Get
        End Property
        Private ReadOnly Property DocumentManagerService_Impl As IDocumentManagerService Implements ISupportLogicalLayout.DocumentManagerService
            Get
                Return DocumentManagerService
            End Get
        End Property
        Private ReadOnly Property LookupViewModels As IEnumerable(Of Object) Implements ISupportLogicalLayout.LookupViewModels
            Get
                Return Nothing
            End Get
        End Property
    End Class
End Namespace
