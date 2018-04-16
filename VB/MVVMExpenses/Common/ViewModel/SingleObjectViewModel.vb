Imports System
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.Collections.Generic
Imports System.Linq
Imports System.Linq.Expressions
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm.DataAnnotations
Imports Common.Utils
Imports Common.DataModel
Namespace Common.ViewModel
    ''' <summary>
    ''' The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity.
    ''' This is a partial class that provides the extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Partial Public MustInherit Class SingleObjectViewModel(Of TEntity As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits SingleObjectViewModelBase(Of TEntity, TPrimaryKey, TUnitOfWork)
        ''' <summary>
        ''' Initializes a new instance of the SingleObjectViewModel class.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create the unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        ''' <param name="getEntityDisplayNameFunc">An optional parameter that provides a function to obtain the display text for a given entity. If ommited, the primary key value is used as a display text.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), Optional ByVal getEntityDisplayNameFunc As Func(Of TEntity, Object) = Nothing)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, getEntityDisplayNameFunc)
        End Sub
    End Class
    ''' <summary>
    ''' The base class for POCO view models exposing a single entity of a given type and CRUD operations against this entity.
    ''' It is not recommended to inherit directly from this class. Use the SingleObjectViewModel class instead.
    ''' </summary>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    <POCOViewModel> _
    Public MustInherit Class SingleObjectViewModelBase(Of TEntity As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Implements ISupportParameter, IDocumentContent, ISupportLogicalLayout(Of TPrimaryKey), ISingleObjectViewModel(Of TEntity, TPrimaryKey)
        Private _DocumentOwner As IDocumentOwner
        Private _PrimaryKey As TPrimaryKey
        Private _UnitOfWork As TUnitOfWork
        Private _UnitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork)
        Private _title As Object
        Protected ReadOnly getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey))
        Protected ReadOnly getEntityDisplayNameFunc As Func(Of TEntity, Object)
        Private _entityInitializer As Action(Of TEntity)
        Private _isEntityNewAndUnmodified As Boolean
        Private ReadOnly _lookUpViewModels As Dictionary(Of String, IDocumentContent) = New Dictionary(Of String, IDocumentContent)()
        ''' <summary>
        ''' Initializes a new instance of the SingleObjectViewModelBase class.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create the unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns repository representing entities of a given type.</param>
        ''' <param name="getEntityDisplayNameFunc">An optional parameter that provides a function to obtain the display text for a given entity. If ommited, the primary key value is used as a display text.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal getEntityDisplayNameFunc As Func(Of TEntity, Object))
            Me._UnitOfWorkFactory = unitOfWorkFactory
            Me.getRepositoryFunc = getRepositoryFunc
            Me.getEntityDisplayNameFunc = getEntityDisplayNameFunc
            UpdateUnitOfWork()
            If Me.IsInDesignMode() Then
                Me.Entity = Me.Repository.FirstOrDefault()
            Else
                OnInitializeInRuntime()
            End If
        End Sub
        ''' <summary>
        ''' The display text for a given entity used as a title in the corresponding view.
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Title As Object
            Get
                Return _title
            End Get
        End Property
        ''' <summary>
        ''' An entity represented by this view model.
        ''' Since SingleObjectViewModelBase is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        ''' </summary>
        ''' <returns></returns>
        Public Overridable Property Entity As TEntity
        ''' <summary>
        ''' Updates the Title property value and raises CanExecute changed for relevant commands.
        ''' Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the UpdateCommand property that can be used as a binding source in views.
        ''' </summary>
        <Display(AutoGenerateField:=False)> _
        Public Sub Update()
            _isEntityNewAndUnmodified = False
            UpdateTitle()
            UpdateCommands()
        End Sub
        ''' <summary>
        ''' Saves changes in the underlying unit of work.
        ''' Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveCommand property that can be used as a binding source in views.
        ''' </summary>
        Public Overridable Sub Save()
            SaveCore()
        End Sub
        ''' <summary>
        ''' Determines whether entity has local changes that can be saved.
        ''' Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for SaveCommand.
        ''' </summary>
        Public Overridable Function CanSave() As Boolean
            Return Entity IsNot Nothing AndAlso Not HasValidationErrors() AndAlso NeedSave()
        End Function
        ''' <summary>
        ''' Saves changes in the underlying unit of work and closes the corresponding view.
        ''' Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveAndCloseCommand property that can be used as a binding source in views.
        ''' </summary>
        <Command(CanExecuteMethodName:="CanSave")> _
        Public Sub SaveAndClose()
            If SaveCore() Then
                Close()
            End If
        End Sub
        ''' <summary>
        ''' Saves changes in the underlying unit of work and create new entity.
        ''' Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the SaveAndNewCommand property that can be used as a binding source in views.
        ''' </summary>
        <Command(CanExecuteMethodName:="CanSave")> _
        Public Sub SaveAndNew()
            If SaveCore() Then
                CreateAndInitializeEntity(Me._entityInitializer)
            End If
        End Sub
        ''' <summary>
        ''' Reset entity local changes.
        ''' Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the ResetCommand property that can be used as a binding source in views.
        ''' </summary>
        <Display(Name:="Reset Changes")> _
        Public Sub Reset()
            Dim confirmationResult As MessageResult = MessageBoxService.ShowMessage(CommonResources.Confirmation_Reset, CommonResources.Confirmation_Caption, MessageButton.OKCancel)
            If confirmationResult = MessageResult.OK Then
                Reload()
            End If
        End Sub
        ''' <summary>
        ''' Determines whether entity has local changes.
        ''' Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for ResetCommand.
        ''' </summary>
        Public Function CanReset() As Boolean
            Return NeedReset()
        End Function
        Private ReadOnly Property ViewName As String
            Get
                Return GetType(TEntity).Name + "View"
            End Get
        End Property
        <DXImage("Save")> _
        <Display(Name:="Save Layout")> _
        Public Sub SaveLayout()
            If LayoutSerializationService IsNot Nothing Then
                ViewModelLogicalLayoutHelper.PersistentViewsLayout(ViewName) = LayoutSerializationService.Serialize()
            End If
            ViewModelLogicalLayoutHelper.SaveLayout()
        End Sub
        <Display(AutoGenerateField:=False)> _
        Public Sub OnLoaded()
            Dim state As String = Nothing
            If LayoutSerializationService IsNot Nothing AndAlso ViewModelLogicalLayoutHelper.PersistentViewsLayout.TryGetValue(ViewName, state) Then
                LayoutSerializationService.Deserialize(state)
            End If
        End Sub
        ''' <summary>
        ''' Deletes the entity, save changes and closes the corresponding view if confirmed by a user.
        ''' Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the DeleteCommand property that can be used as a binding source in views.
        ''' </summary>
        Public Overridable Sub Delete()
            If MessageBoxService.ShowMessage(String.Format(CommonResources.Confirmation_Delete, GetType(TEntity).Name), GetConfirmationMessageTitle(), MessageButton.YesNo) <> MessageResult.Yes Then
                Return
            End If
            Try
                OnBeforeEntityDeleted(PrimaryKey, Entity)
                Repository.Remove(Entity)
                UnitOfWork.SaveChanges()
                Dim primaryKeyForMessage As TPrimaryKey = PrimaryKey
                Dim entityForMessage As TEntity = Entity
                Entity = Nothing
                OnEntityDeleted(primaryKeyForMessage, entityForMessage)
                Close()
            Catch e As DbException
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.[Error])
            End Try
        End Sub
        ''' <summary>
        ''' Determines whether the entity can be deleted.
        ''' Since SingleObjectViewModelBase is a POCO view model, this method will be used as a CanExecute callback for DeleteCommand.
        ''' </summary>
        Public Overridable Function CanDelete() As Boolean
            Return Entity IsNot Nothing AndAlso Not IsNew()
        End Function
        ''' <summary>
        ''' Closes the corresponding view.
        ''' Since SingleObjectViewModelBase is a POCO view model, an instance of this class will also expose the CloseCommand property that can be used as a binding source in views.
        ''' </summary>
        Public Sub Close()
            If Not TryClose() Then
                Return
            End If
            If DocumentOwner IsNot Nothing Then
                DocumentOwner.Close(Me)
            End If
        End Sub
        Protected ReadOnly Property UnitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork)
            Get
                Return _UnitOfWorkFactory
            End Get
        End Property
        Protected ReadOnly Property UnitOfWork As TUnitOfWork
            Get
                Return _UnitOfWork
            End Get
        End Property
        Protected Overridable Function SaveCore() As Boolean
            Try
                Dim isNewEntity As Boolean = IsNew()
                If Not isNewEntity Then
                    Repository.SetPrimaryKey(Entity, PrimaryKey)
                    Repository.Update(Entity)
                End If
                OnBeforeEntitySaved(PrimaryKey, Entity, isNewEntity)
                UnitOfWork.SaveChanges()
                LoadEntityByKey(Repository.GetPrimaryKey(Entity))
                OnEntitySaved(PrimaryKey, Entity, isNewEntity)
                Return True
            Catch e As DbException
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.[Error])
                Return False
            End Try
        End Function
        Protected Overridable Sub OnBeforeEntitySaved(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity, ByVal isNewEntity As Boolean)
        End Sub
        Protected Overridable Sub OnEntitySaved(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity, ByVal isNewEntity As Boolean)
            Messenger.[Default].Send(New EntityMessage(Of TEntity, TPrimaryKey)(primaryKey, If(isNewEntity, EntityMessageType.Added, EntityMessageType.Changed)))
        End Sub
        Protected Overridable Sub OnBeforeEntityDeleted(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity)
        End Sub
        Protected Overridable Sub OnEntityDeleted(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity)
            Messenger.[Default].Send(New EntityMessage(Of TEntity, TPrimaryKey)(primaryKey, EntityMessageType.Deleted))
        End Sub
        Protected Overridable Sub OnInitializeInRuntime()
            Messenger.[Default].Register(Of EntityMessage(Of TEntity, TPrimaryKey))(Me, Sub(x) OnEntityMessage(x))
            Messenger.[Default].Register(Of SaveAllMessage)(Me, Sub(x) Save())
            Messenger.[Default].Register(Of CloseAllMessage)(Me, Sub(x) OnClosing(x))
        End Sub
        Protected Overridable Sub OnEntityMessage(ByVal message As EntityMessage(Of TEntity, TPrimaryKey))
            If Entity Is Nothing Then
                Return
            End If
            If message.MessageType = EntityMessageType.Deleted AndAlso Object.Equals(message.PrimaryKey, PrimaryKey) Then
                Close()
            End If
        End Sub
        Protected Overridable Sub OnEntityChanged()
            If Entity IsNot Nothing AndAlso Repository.HasPrimaryKey(Entity) Then
                _PrimaryKey = Repository.GetPrimaryKey(Entity)
                RefreshLookUpCollections(True)
            End If
            Update()
        End Sub
        Protected ReadOnly Property Repository As IRepository(Of TEntity, TPrimaryKey)
            Get
                Return getRepositoryFunc(UnitOfWork)
            End Get
        End Property
        Protected ReadOnly Property PrimaryKey As TPrimaryKey
            Get
                Return _PrimaryKey
            End Get
        End Property
        Protected ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return Me.GetRequiredService(Of IMessageBoxService)()
            End Get
        End Property
        Protected ReadOnly Property LayoutSerializationService As ILayoutSerializationService
            Get
                Return Me.GetService(Of ILayoutSerializationService)()
            End Get
        End Property
        Protected Overridable Sub OnParameterChanged(ByVal parameter As Object)
            Dim initializer = TryCast(parameter, Action(Of TEntity))
            If initializer IsNot Nothing Then
                CreateAndInitializeEntity(initializer)
            Else
                If TypeOf parameter Is TPrimaryKey Then
                    LoadEntityByKey(CType(parameter, TPrimaryKey))
                Else
                    Entity = Nothing
                End If
            End If
        End Sub
        Protected Overridable Function CreateEntity() As TEntity
            Return Repository.Create()
        End Function
        Protected Sub Reload()
            If Entity Is Nothing OrElse IsNew() Then
                CreateAndInitializeEntity(Me._entityInitializer)
            Else
                LoadEntityByKey(PrimaryKey)
            End If
        End Sub
        Protected Sub CreateAndInitializeEntity(ByVal entityInitializer As Action(Of TEntity))
            UpdateUnitOfWork()
            Me._entityInitializer = entityInitializer
            Dim entity = CreateEntity()
            If Me._entityInitializer IsNot Nothing Then
                Me._entityInitializer(entity)
            End If
            Me.Entity = entity
            _isEntityNewAndUnmodified = True
        End Sub
        Protected Sub LoadEntityByKey(ByVal primaryKey As TPrimaryKey)
            UpdateUnitOfWork()
            Entity = Repository.Find(primaryKey)
        End Sub
        Private Sub UpdateUnitOfWork()
            _UnitOfWork = UnitOfWorkFactory.CreateUnitOfWork()
        End Sub
        Private Sub UpdateTitle()
            If Entity Is Nothing Then
                _title = Nothing
            Else
                If IsNew() Then
                    _title = GetTitleForNewEntity()
                Else
                    _title = GetTitle(GetState() = EntityState.Modified)
                End If
            End If
            Me.RaisePropertyChanged(Function(x) x.Title)
        End Sub
        Protected Overridable Sub UpdateCommands()
            Me.RaiseCanExecuteChanged(Sub(x) x.Save())
            Me.RaiseCanExecuteChanged(Sub(x) x.SaveAndClose())
            Me.RaiseCanExecuteChanged(Sub(x) x.SaveAndNew())
            Me.RaiseCanExecuteChanged(Sub(x) x.Delete())
            Me.RaiseCanExecuteChanged(Sub(x) x.Reset())
        End Sub
        Protected ReadOnly Property DocumentOwner As IDocumentOwner
            Get
                Return _DocumentOwner
            End Get
        End Property
        Protected Overridable Sub OnDestroy()
            Messenger.[Default].Unregister(Me)
            RefreshLookUpCollections(False)
        End Sub
        Protected Overridable Function TryClose() As Boolean
            If HasValidationErrors() Then
                Dim warningResult As MessageResult = MessageBoxService.ShowMessage(CommonResources.Warning_SomeFieldsContainInvalidData, CommonResources.Warning_Caption, MessageButton.OKCancel)
                Return warningResult = MessageResult.OK
            End If
            If Not NeedReset() Then
                Return True
            End If
            Dim result As MessageResult = MessageBoxService.ShowMessage(CommonResources.Confirmation_Save, GetConfirmationMessageTitle(), MessageButton.YesNoCancel)
            If result = MessageResult.Yes Then
                Return SaveCore()
            End If
            Return result <> MessageResult.Cancel
        End Function
        Protected Overridable Sub OnClosing(ByVal message As CloseAllMessage)
            If Not message.Cancel Then
                message.Cancel = Not TryClose()
            End If
        End Sub
        Protected Overridable Function GetConfirmationMessageTitle() As String
            Return GetTitle()
        End Function
        Public Function IsNew() As Boolean
            Return GetState() = EntityState.Added
        End Function
        Protected Overridable Function NeedSave() As Boolean
            If Entity Is Nothing Then
                Return False
            End If
            Dim state As EntityState = GetState()
            Return state = EntityState.Modified OrElse state = EntityState.Added
        End Function
        Protected Overridable Function NeedReset() As Boolean
            Return NeedSave() AndAlso Not _isEntityNewAndUnmodified
        End Function
        Protected Overridable Function HasValidationErrors() As Boolean
            Dim dataErrorInfo As IDataErrorInfo = TryCast(Entity, IDataErrorInfo)
            Return dataErrorInfo IsNot Nothing AndAlso IDataErrorInfoHelper.HasErrors(dataErrorInfo)
        End Function
        Private Function GetTitle(ByVal entityModified As Boolean) As String
            Return GetTitle() + (If(entityModified, CommonResources.Entity_Changed, String.Empty))
        End Function
        Protected Overridable Function GetTitleForNewEntity() As String
            Return GetType(TEntity).Name + CommonResources.Entity_New
        End Function
        Protected Overridable Function GetTitle() As String
            Return (GetType(TEntity).Name + " - " + Convert.ToString(If(getEntityDisplayNameFunc IsNot Nothing, getEntityDisplayNameFunc(Entity), PrimaryKey))).Split(New String() {"" + vbCr + "", "" + vbLf + ""}, StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()
        End Function
        Protected Function GetState() As EntityState
            Try
                Return Repository.GetState(Entity)
            Catch e As InvalidOperationException
                Repository.SetPrimaryKey(Entity, PrimaryKey)
                Return Repository.GetState(Entity)
            End Try
        End Function
        Protected Overridable Sub RefreshLookUpCollections(ByVal raisePropertyChanged As Boolean)
            Dim values = _lookUpViewModels.ToArray()
            _lookUpViewModels.Clear()
            For Each item In values
                item.Value.OnDestroy()
                If raisePropertyChanged Then
                    CType(Me, IPOCOViewModel).RaisePropertyChanged(item.Key)
                End If
            Next
        End Sub
        Protected Function GetDetailsCollectionViewModel(Of TViewModel, TDetailEntity As Class, TDetailPrimaryKey, TForeignKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, CollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TDetailEntity, TDetailPrimaryKey)), ByVal foreignKeyExpression As Expression(Of Func(Of TDetailEntity, TForeignKey)), ByVal setMasterEntityKeyAction As Action(Of TDetailEntity, TPrimaryKey), Optional ByVal projection As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailEntity)) = Nothing) As CollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork)
            Return GetCollectionViewModelCore(Of CollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork), TDetailEntity, TDetailEntity, TForeignKey)(propertyExpression, Function() CollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork).CreateCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate(Of TDetailEntity, TDetailEntity, TForeignKey)(foreignKeyExpression, projection), CreateForeignKeyPropertyInitializer(setMasterEntityKeyAction, Function() PrimaryKey), Function() CanCreateNewEntity(), True))
        End Function
        Protected Function GetDetailProjectionsCollectionViewModel(Of TViewModel, TDetailEntity As Class, TDetailProjection As Class, TDetailPrimaryKey, TForeignKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, CollectionViewModel(Of TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TDetailEntity, TDetailPrimaryKey)), ByVal foreignKeyExpression As Expression(Of Func(Of TDetailEntity, TForeignKey)), ByVal setMasterEntityKeyAction As Action(Of TDetailEntity, TPrimaryKey), Optional ByVal projection As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailProjection)) = Nothing) As CollectionViewModel(Of TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork)
            Return GetCollectionViewModelCore(Of CollectionViewModel(Of TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork), TDetailEntity, TDetailProjection, TForeignKey)(propertyExpression, Function() CollectionViewModel(Of TDetailEntity, TDetailProjection, TDetailPrimaryKey, TUnitOfWork).CreateProjectionCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate(Of TDetailEntity, TDetailProjection, TForeignKey)(foreignKeyExpression, projection), CreateForeignKeyPropertyInitializer(setMasterEntityKeyAction, Function() PrimaryKey), Function() CanCreateNewEntity(), True))
        End Function
        Protected Function GetDetailsInstantFeedbackCollectionViewModel(Of TViewModel, TDetailEntity As {Class, New}, TDetailPrimaryKey, TForeignKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TDetailEntity, TDetailPrimaryKey)), ByVal foreignKeyExpression As Expression(Of Func(Of TDetailEntity, TForeignKey)), ByVal setMasterEntityKeyAction As Action(Of TDetailEntity, TPrimaryKey), Optional ByVal projection As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailEntity)) = Nothing) As InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork)
            Return GetCollectionViewModelCore(Of InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork), TDetailEntity, TDetailEntity, TForeignKey)(propertyExpression, Function() InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailPrimaryKey, TUnitOfWork).CreateInstantFeedbackCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate(Of TDetailEntity, TDetailEntity, TForeignKey)(foreignKeyExpression, projection), Function() CanCreateNewEntity()))
        End Function
        Protected Function GetDetailsInstantFeedbackCollectionViewModel(Of TViewModel, TDetailEntity As {Class, New}, TDetailEntityProjection As {Class, New}, TDetailPrimaryKey, TForeignKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailEntityProjection, TDetailPrimaryKey, TUnitOfWork))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TDetailEntity, TDetailPrimaryKey)), ByVal foreignKeyExpression As Expression(Of Func(Of TDetailEntity, TForeignKey)), ByVal setMasterEntityKeyAction As Action(Of TDetailEntity, TPrimaryKey), Optional ByVal projection As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailEntityProjection)) = Nothing) As InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailEntityProjection, TDetailPrimaryKey, TUnitOfWork)
            Return GetCollectionViewModelCore(Of InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailEntityProjection, TDetailPrimaryKey, TUnitOfWork), TDetailEntity, TDetailEntity, TForeignKey)(propertyExpression, Function() InstantFeedbackCollectionViewModel(Of TDetailEntity, TDetailEntityProjection, TDetailPrimaryKey, TUnitOfWork).CreateInstantFeedbackCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate(Of TDetailEntity, TDetailEntityProjection, TForeignKey)(foreignKeyExpression, projection), Function() CanCreateNewEntity()))
        End Function
        Protected Function GetReadOnlyDetailsCollectionViewModel(Of TViewModel, TDetailEntity As Class, TForeignKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, ReadOnlyCollectionViewModel(Of TDetailEntity, TDetailEntity, TUnitOfWork))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TDetailEntity)), ByVal foreignKeyExpression As Expression(Of Func(Of TDetailEntity, TForeignKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailEntity)) = Nothing) As ReadOnlyCollectionViewModel(Of TDetailEntity, TUnitOfWork)
            Return GetCollectionViewModelCore(Of ReadOnlyCollectionViewModel(Of TDetailEntity, TUnitOfWork), TDetailEntity, TDetailEntity, TForeignKey)(propertyExpression, Function() ReadOnlyCollectionViewModel(Of TDetailEntity, TUnitOfWork).CreateReadOnlyCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate(Of TDetailEntity, TDetailEntity, TForeignKey)(foreignKeyExpression, projection)))
        End Function
        Protected Function GetReadOnlyDetailProjectionsCollectionViewModel(Of TViewModel, TDetailEntity As Class, TDetailProjection As Class, TForeignKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, ReadOnlyCollectionViewModel(Of TDetailEntity, TDetailProjection, TUnitOfWork))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TDetailEntity)), ByVal foreignKeyExpression As Expression(Of Func(Of TDetailEntity, TForeignKey)), ByVal projection As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailProjection))) As ReadOnlyCollectionViewModel(Of TDetailEntity, TDetailProjection, TUnitOfWork)
            Return GetCollectionViewModelCore(Of ReadOnlyCollectionViewModel(Of TDetailEntity, TDetailProjection, TUnitOfWork), TDetailEntity, TDetailProjection, TForeignKey)(propertyExpression, Function() ReadOnlyCollectionViewModel(Of TDetailEntity, TDetailProjection, TUnitOfWork).CreateReadOnlyProjectionCollectionViewModel(UnitOfWorkFactory, getRepositoryFunc, AppendForeignKeyPredicate(Of TDetailEntity, TDetailProjection, TForeignKey)(foreignKeyExpression, projection)))
        End Function
        Private Function AppendForeignKeyPredicate(Of TDetailEntity As Class, TDetailProjection As Class, TForeignKey)(ByVal foreignKeyExpression As Expression(Of Func(Of TDetailEntity, TForeignKey)), ByVal projection As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailProjection))) As Func(Of IRepositoryQuery(Of TDetailEntity), IQueryable(Of TDetailProjection))
            Dim predicate = ExpressionHelper.GetValueEqualsExpression(foreignKeyExpression, CType(CType(PrimaryKey, Object), TForeignKey))
            Return ReadOnlyRepositoryExtensions.AppendToProjection(predicate, projection)
        End Function
        Protected Function GetLookUpEntitiesViewModel(Of TViewModel, TLookUpEntity As Class, TLookUpEntityKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, IEntitiesViewModel(Of TLookUpEntity))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TLookUpEntity, TLookUpEntityKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TLookUpEntity), IQueryable(Of TLookUpEntity)) = Nothing) As IEntitiesViewModel(Of TLookUpEntity)
            Return GetLookUpProjectionsViewModel(propertyExpression, getRepositoryFunc, projection)
        End Function
        Protected Overridable Function GetLookUpProjectionsViewModel(Of TViewModel, TLookUpEntity As Class, TLookUpProjection As Class, TLookUpEntityKey)(ByVal propertyExpression As Expression(Of Func(Of TViewModel, IEntitiesViewModel(Of TLookUpProjection))), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TLookUpEntity, TLookUpEntityKey)), ByVal projection As Func(Of IRepositoryQuery(Of TLookUpEntity), IQueryable(Of TLookUpProjection))) As IEntitiesViewModel(Of TLookUpProjection)
            Return GetEntitiesViewModelCore(Of IEntitiesViewModel(Of TLookUpProjection), TLookUpProjection)(propertyExpression, Function() LookUpEntitiesViewModel(Of TLookUpEntity, TLookUpProjection, TLookUpEntityKey, TUnitOfWork).Create(UnitOfWorkFactory, getRepositoryFunc, projection))
        End Function
        Private Function CreateForeignKeyPropertyInitializer(Of TDetailEntity As Class, TForeignKey)(ByVal setMasterEntityKeyAction As Action(Of TDetailEntity, TPrimaryKey), ByVal getMasterEntityKey As Func(Of TForeignKey)) As Action(Of TDetailEntity)
            Return Sub(x) setMasterEntityKeyAction(x, CType(CType(getMasterEntityKey(), Object), TPrimaryKey))
        End Function
        Protected Overridable Function CanCreateNewEntity() As Boolean
            If Not IsNew() Then
                Return True
            End If
            Dim message As String = String.Format(CommonResources.Confirmation_SaveParent, GetType(TEntity).Name)
            Dim result = MessageBoxService.ShowMessage(message, CommonResources.Confirmation_Caption, MessageButton.YesNo)
            Return result = MessageResult.Yes AndAlso SaveCore()
        End Function
        Private Function GetCollectionViewModelCore(Of TViewModel As IDocumentContent, TDetailEntity As Class, TDetailProjection As Class, TForeignKey)(ByVal propertyExpression As LambdaExpression, ByVal createViewModelCallback As Func(Of TViewModel)) As TViewModel
            Return GetEntitiesViewModelCore(Of TViewModel, TDetailProjection)(propertyExpression, Function()
                                                                                                      Dim viewModel = createViewModelCallback()
                                                                                                      viewModel.SetParentViewModel(Me)
                                                                                                      Return viewModel
                                                                                                  End Function)
        End Function
        Private Function GetEntitiesViewModelCore(Of TViewModel As IDocumentContent, TDetailEntity As Class)(ByVal propertyExpression As LambdaExpression, ByVal createViewModelCallback As Func(Of TViewModel)) As TViewModel
            Dim result As IDocumentContent = Nothing
            Dim propertyName As String = ExpressionHelper.GetPropertyName(propertyExpression)
            If Not _lookUpViewModels.TryGetValue(propertyName, result) Then
                result = createViewModelCallback()
                _lookUpViewModels(propertyName) = result
            End If
            Return CType(result, TViewModel)
        End Function
        Private Property Parameter As Object Implements ISupportParameter.Parameter
            Get
                Return Nothing
            End Get
            Set(value As Object)
                OnParameterChanged(value)
            End Set
        End Property
        Private ReadOnly Property Title_Impl As Object Implements IDocumentContent.Title
            Get
                Return Title
            End Get
        End Property
        Private Sub OnClose(ByVal e As CancelEventArgs) Implements IDocumentContent.OnClose
            e.Cancel = Not TryClose()
            Messenger.[Default].Send(New DestroyOrphanedDocumentsMessage())
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
        Private ReadOnly Property Entity_Impl As TEntity Implements ISingleObjectViewModel(Of TEntity, TPrimaryKey).Entity
            Get
                Return Entity
            End Get
        End Property
        Private ReadOnly Property PrimaryKey_Impl As TPrimaryKey Implements ISingleObjectViewModel(Of TEntity, TPrimaryKey).PrimaryKey
            Get
                Return PrimaryKey
            End Get
        End Property
        Private ReadOnly Property CanSerialize As Boolean Implements ISupportLogicalLayout.CanSerialize
            Get
                Return Entity IsNot Nothing AndAlso Not IsNew()
            End Get
        End Property
        Private Function SaveState() As TPrimaryKey Implements ISupportLogicalLayout(Of TPrimaryKey).SaveState
            Return PrimaryKey
        End Function
        Private Sub RestoreState(ByVal key As TPrimaryKey) Implements ISupportLogicalLayout(Of TPrimaryKey).RestoreState
            LoadEntityByKey(key)
        End Sub
        Private ReadOnly Property DocumentManagerService As IDocumentManagerService Implements ISupportLogicalLayout.DocumentManagerService
            Get
                Return CType(CType(Me, ISupportParentViewModel).ParentViewModel, ISupportLogicalLayout).DocumentManagerService
            End Get
        End Property
        Private ReadOnly Property LookupViewModels As IEnumerable(Of Object) Implements ISupportLogicalLayout.LookupViewModels
            Get
                Return _lookUpViewModels.[Select](Function(vm) vm.Value).OfType(Of ISupportLogicalLayout)()
            End Get
        End Property
    End Class
End Namespace
