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
    ''' The base class for a POCO view models exposing a colection of entities of a given type and CRUD operations against these entities.
    ''' This is a partial class that provides extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Partial Public Class CollectionViewModel(Of TEntity As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits CollectionViewModel(Of TEntity, TEntity, TPrimaryKey, TUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of CollectionViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">An optional parameter that provides a LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data.</param>
        ''' <param name="newEntityInitializer">An optional parameter that provides a function to initialize a new entity. This parameter is used in the detail collection view models when creating a single object view model for a new entity.</param>
        ''' <param name="canCreateNewEntity">A function that is called before an attempt to create a new entity is made. This parameter is used together with the newEntityInitializer parameter.</param>
        ''' <param name="ignoreSelectEntityMessage">An optional parameter that used to specify that the selected entity should not be managed by PeekCollectionViewModel.</param>
        Public Shared Function CreateCollectionViewModel(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing, Optional ByVal newEntityInitializer As Action(Of TEntity) = Nothing, Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing, Optional ByVal ignoreSelectEntityMessage As Boolean = False) As CollectionViewModel(Of TEntity, TPrimaryKey, TUnitOfWork)
            Return ViewModelSource.Create(Function() New CollectionViewModel(Of TEntity, TPrimaryKey, TUnitOfWork)(unitOfWorkFactory, getRepositoryFunc, projection, newEntityInitializer, canCreateNewEntity, ignoreSelectEntityMessage))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the CollectionViewModel class.
        ''' This constructor is declared protected to avoid an undesired instantiation of the CollectionViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">An optional parameter that provides a LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data.</param>
        ''' <param name="newEntityInitializer">An optional parameter that provides a function to initialize a new entity. This parameter is used in the detail collection view models when creating a single object view model for a new entity.</param>
        ''' <param name="canCreateNewEntity">A function that is called before an attempt to create a new entity is made. This parameter is used together with the newEntityInitializer parameter.</param>
        ''' <param name="ignoreSelectEntityMessage">An optional parameter that used to specify that the selected entity should not be managed by PeekCollectionViewModel.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing, Optional ByVal newEntityInitializer As Action(Of TEntity) = Nothing, Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing, Optional ByVal ignoreSelectEntityMessage As Boolean = False)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection, newEntityInitializer, canCreateNewEntity, ignoreSelectEntityMessage)
        End Sub
    End Class
    ''' <summary>
    ''' The base class for a POCO view models exposing a collection of entities of a given type and CRUD operations against these entities. 
    ''' This is a partial class that provides extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    ''' <typeparam name="TProjection">A projection entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Partial Public Class CollectionViewModel(Of TEntity As Class, TProjection As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits CollectionViewModelBase(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of CollectionViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        ''' <param name="newEntityInitializer">An optional parameter that provides a function to initialize a new entity. This parameter is used in the detail collection view models when creating a single object view model for a new entity.</param>
        ''' <param name="canCreateNewEntity">A function that is called before an attempt to create a new entity is made. This parameter is used together with the newEntityInitializer parameter.</param>
        ''' <param name="ignoreSelectEntityMessage">An optional parameter that used to specify that the selected entity should not be managed by PeekCollectionViewModel.</param>
        Public Shared Function CreateProjectionCollectionViewModel(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)), Optional ByVal newEntityInitializer As Action(Of TEntity) = Nothing, Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing, Optional ByVal ignoreSelectEntityMessage As Boolean = False) As CollectionViewModel(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)
            Return ViewModelSource.Create(Function() New CollectionViewModel(Of TEntity, TProjection, TPrimaryKey, TUnitOfWork)(unitOfWorkFactory, getRepositoryFunc, projection, newEntityInitializer, canCreateNewEntity, ignoreSelectEntityMessage))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the CollectionViewModel class.
        ''' This constructor is declared protected to avoid an undesired instantiation of the CollectionViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        ''' <param name="newEntityInitializer">An optional parameter that provides a function to initialize a new entity. This parameter is used in the detail collection view models when creating a single object view model for a new entity.</param>
        ''' <param name="canCreateNewEntity">A function that is called before an attempt to create a new entity is made. This parameter is used together with the newEntityInitializer parameter.</param>
        ''' <param name="ignoreSelectEntityMessage">An optional parameter that used to specify that the selected entity should not be managed by PeekCollectionViewModel.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)), Optional ByVal newEntityInitializer As Action(Of TEntity) = Nothing, Optional ByVal canCreateNewEntity As Func(Of Boolean) = Nothing, Optional ByVal ignoreSelectEntityMessage As Boolean = False)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection, newEntityInitializer, canCreateNewEntity, ignoreSelectEntityMessage)
        End Sub
    End Class
    ''' <summary>
    ''' The base class for POCO view models exposing a collection of entities of a given type and CRUD operations against these entities.
    ''' It is not recommended to inherit directly from this class. Use the CollectionViewModel class instead.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    ''' <typeparam name="TProjection">A projection entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Public MustInherit Class CollectionViewModelBase(Of TEntity As Class, TProjection As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits ReadOnlyCollectionViewModel(Of TEntity, TProjection, TUnitOfWork)
        Implements ISupportLogicalLayout
        Private ReadOnly Property ChangeTrackerWithKey As EntitiesChangeTracker(Of TPrimaryKey)
            Get
                Return CType(ChangeTracker, EntitiesChangeTracker(Of TPrimaryKey))
            End Get
        End Property
        Private ReadOnly _newEntityInitializer As Action(Of TEntity)
        Private ReadOnly _canCreateNewEntity As Func(Of Boolean)
        Private ReadOnly Property Repository As IRepository(Of TEntity, TPrimaryKey)
            Get
                Return CType(ReadOnlyRepository, IRepository(Of TEntity, TPrimaryKey))
            End Get
        End Property
        ''' <summary>
        ''' Initializes a new instance of the CollectionViewModelBase class.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        ''' <param name="newEntityInitializer">A function to initialize a new entity. This parameter is used in the detail collection view models when creating a single object view model for a new entity.</param>
        ''' <param name="canCreateNewEntity">A function that is called before an attempt to create a new entity is made. This parameter is used together with the newEntityInitializer parameter.</param>
        ''' <param name="ignoreSelectEntityMessage">A parameter used to specify whether the selected entity should be managed by PeekCollectionViewModel.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)), ByVal newEntityInitializer As Action(Of TEntity), ByVal canCreateNewEntity As Func(Of Boolean), ByVal ignoreSelectEntityMessage As Boolean)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection)
            RepositoryExtensions.VerifyProjection(CreateRepository(), projection)
            Me._newEntityInitializer = newEntityInitializer
            Me._canCreateNewEntity = canCreateNewEntity
            Me._ignoreSelectEntityMessage = ignoreSelectEntityMessage
            If Not Me.IsInDesignMode() Then
                RegisterSelectEntityMessage()
            End If
        End Sub
        ''' <summary>
        ''' Creates and shows a document that contains a single object view model for new entity.
        ''' Since CollectionViewModelBase is a POCO view model, an the instance of this class will also expose the NewCommand property that can be used as a binding source in views.
        ''' </summary>
        Public Overridable Sub [New]()
            If _canCreateNewEntity IsNot Nothing AndAlso Not _canCreateNewEntity() Then
                Return
            End If
            DocumentManagerService.ShowNewEntityDocument(Me, _newEntityInitializer)
        End Sub
        ''' <summary>
        ''' Creates and shows a document that contains a single object view model for the existing entity.
        ''' Since CollectionViewModelBase is a POCO view model, an the instance of this class will also expose the EditCommand property that can be used as a binding source in views.
        ''' </summary>
        ''' <param name="projectionEntity">Entity to edit.</param>
        Public Overridable Sub Edit(ByVal projectionEntity As TProjection)
            If Repository.IsDetached(projectionEntity) Then
                Return
            End If
            Dim primaryKey As TPrimaryKey = Repository.GetProjectionPrimaryKey(projectionEntity)
            Dim index As Integer = Entities.IndexOf(projectionEntity)
            projectionEntity = ChangeTrackerWithKey.FindActualProjectionByKey(primaryKey)
            If index >= 0 Then
                If projectionEntity Is Nothing Then
                    Entities.RemoveAt(index)
                Else
                    Entities(index) = projectionEntity
                End If
            End If
            If projectionEntity Is Nothing Then
                DestroyDocument(DocumentManagerService.FindEntityDocument(Of TEntity, TPrimaryKey)(primaryKey))
                Return
            End If
            DocumentManagerService.ShowExistingEntityDocument(Of TEntity, TPrimaryKey)(Me, primaryKey)
        End Sub
        ''' <summary>
        ''' Determines whether an entity can be edited.
        ''' Since CollectionViewModelBase is a POCO view model, this method will be used as a CanExecute callback for EditCommand.
        ''' </summary>
        ''' <param name="projectionEntity">An entity to edit.</param>
        Public Function CanEdit(ByVal projectionEntity As TProjection) As Boolean
            Return projectionEntity IsNot Nothing AndAlso Not IsLoading
        End Function
        ''' <summary>
        ''' Deletes a given entity from the repository and saves changes if confirmed by the user.
        ''' Since CollectionViewModelBase is a POCO view model, an the instance of this class will also expose the DeleteCommand property that can be used as a binding source in views.
        ''' </summary>
        ''' <param name="projectionEntity">An entity to edit.</param>
        Public Overridable Sub Delete(ByVal projectionEntity As TProjection)
            If MessageBoxService.ShowMessage(String.Format(CommonResources.Confirmation_Delete, GetType(TEntity).Name), CommonResources.Confirmation_Caption, MessageButton.YesNo) <> MessageResult.Yes Then
                Return
            End If
            Try
                Entities.Remove(projectionEntity)
                Dim primaryKey As TPrimaryKey = Repository.GetProjectionPrimaryKey(projectionEntity)
                Dim entity As TEntity = Repository.Find(primaryKey)
                If entity IsNot Nothing Then
                    OnBeforeEntityDeleted(primaryKey, entity)
                    Repository.Remove(entity)
                    Repository.UnitOfWork.SaveChanges()
                    OnEntityDeleted(primaryKey, entity)
                End If
            Catch e As DbException
                Refresh()
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.[Error])
            End Try
        End Sub


        Public Overridable Sub DeleteAll()
            If MessageBoxService.ShowMessage(String.Format(CommonResources.Confirmation_Delete, GetType(TEntity).Name), CommonResources.Confirmation_Caption, MessageButton.YesNo) <> MessageResult.Yes Then
                Return
            End If
            Dim SelectionArray = Selection.ToArray()
            For Each projectionEntity As TProjection In SelectionArray
                Try
                    Dim primaryKey As TPrimaryKey = Repository.GetProjectionPrimaryKey(projectionEntity)
                    Dim entity As TEntity = Repository.Find(primaryKey)
                    If entity IsNot Nothing Then
                        OnBeforeEntityDeleted(primaryKey, entity)
                        Repository.Remove(entity)
                        Entities.Remove(projectionEntity)
                        Repository.UnitOfWork.SaveChanges()
                        'OnEntityDeleted(primaryKey, entity);
                    End If
                Catch e As DbException
                    Refresh()
                    MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.Error)
                End Try
            Next projectionEntity

        End Sub


        ''' <summary>
        ''' Determines whether an entity can be deleted.
        ''' Since CollectionViewModelBase is a POCO view model, this method will be used as a CanExecute callback for DeleteCommand.
        ''' </summary>
        ''' <param name="projectionEntity">An entity to edit.</param>
        Public Overridable Function CanDelete(ByVal projectionEntity As TProjection) As Boolean
            Return projectionEntity IsNot Nothing AndAlso Not IsLoading
        End Function
        ''' <summary>
        ''' Saves the given entity.
        ''' Since CollectionViewModelBase is a POCO view model, the instance of this class will also expose the SaveCommand property that can be used as a binding source in views.
        ''' </summary>
        ''' <param name="projectionEntity">An entity to save.</param>
        <Display(AutoGenerateField:=False)> _
        Public Overridable Sub Save(ByVal projectionEntity As TProjection)
            Dim entity = Repository.FindExistingOrAddNewEntity(projectionEntity, Sub(p, e) ApplyProjectionPropertiesToEntity(p, e))
            Try
                OnBeforeEntitySaved(entity)
                Repository.UnitOfWork.SaveChanges()
                Dim primaryKey = Repository.GetPrimaryKey(entity)
                Repository.SetProjectionPrimaryKey(projectionEntity, primaryKey)
                OnEntitySaved(primaryKey, entity)
            Catch e As DbException
                MessageBoxService.ShowMessage(e.ErrorMessage, e.ErrorCaption, MessageButton.OK, MessageIcon.[Error])
            End Try
        End Sub

        Public Overridable Property Selection() As IEnumerable(Of TProjection)

        Protected Sub OnSelectionChanged()
            Me.RaiseCanExecuteChanged(Sub(x) x.Edit(SelectedEntity))
        End Sub


        ''' <summary>
        ''' Determines whether entity local changes can be saved.
        ''' Since CollectionViewModelBase is a POCO view model, this method will be used as a CanExecute callback for SaveCommand.
        ''' </summary>
        ''' <param name="projectionEntity">An entity to save.</param>
        Public Overridable Function CanSave(ByVal projectionEntity As TProjection) As Boolean
            Return projectionEntity IsNot Nothing AndAlso Not IsLoading
        End Function
        ''' <summary>
        ''' Notifies that SelectedEntity has been changed by raising the PropertyChanged event.
        ''' Since CollectionViewModelBase is a POCO view model, an the instance of this class will also expose the UpdateSelectedEntityCommand property that can be used as a binding source in views.
        ''' </summary>
        <Display(AutoGenerateField:=False)> _
        Public Overridable Sub UpdateSelectedEntity()
            Me.RaisePropertyChanged(Function(x) x.SelectedEntity)
        End Sub
        ''' <summary>
        ''' Closes the corresponding view.
        ''' Since CollectionViewModelBase is a POCO view model, an the instance of this class will also expose the CloseCommand property that can be used as a binding source in views.
        ''' </summary>
        <Display(AutoGenerateField:=True)> _
        Public Sub Close()
            If DocumentOwner IsNot Nothing Then
                DocumentOwner.Close(Me)
            End If
        End Sub
        Protected Overrides ReadOnly Property ViewName As String
            Get
                Return GetType(TEntity).Name + "CollectionView"
            End Get
        End Property
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
        Protected Overridable Sub OnEntityDeleted(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity)
            Messenger.[Default].Send(New EntityMessage(Of TEntity, TPrimaryKey)(primaryKey, EntityMessageType.Deleted))
        End Sub
        Protected Overrides Function GetSelectedEntityCallback() As Func(Of TProjection)
            Dim entity = SelectedEntity
            Return Function() FindLocalProjectionWithSameKey(entity)
        End Function
        Private Function FindLocalProjectionWithSameKey(ByVal projectionEntity As TProjection) As TProjection
            Dim primaryKeyAvailable As Boolean = projectionEntity IsNot Nothing AndAlso Repository.ProjectionHasPrimaryKey(projectionEntity)
            Return If(primaryKeyAvailable, ChangeTrackerWithKey.FindLocalProjectionByKey(Repository.GetProjectionPrimaryKey(projectionEntity)), Nothing)
        End Function
        Protected Overridable Sub OnBeforeEntitySaved(ByVal entity As TEntity)
        End Sub
        Protected Overridable Sub OnEntitySaved(ByVal primaryKey As TPrimaryKey, ByVal entity As TEntity)
            Messenger.[Default].Send(New EntityMessage(Of TEntity, TPrimaryKey)(primaryKey, EntityMessageType.Changed))
        End Sub
        Protected Overridable Sub ApplyProjectionPropertiesToEntity(ByVal projectionEntity As TProjection, ByVal entity As TEntity)
            Throw New NotImplementedException("Override this method in the collection view model class and apply projection properties to the entity so that it can be correctly saved by unit of work.")
        End Sub
        Protected Overrides Sub OnSelectedEntityChanged()
            MyBase.OnSelectedEntityChanged()
            UpdateCommands()
        End Sub
        Protected Overrides Sub RestoreSelectedEntity(ByVal existingProjectionEntity As TProjection, ByVal newProjectionEntity As TProjection)
            MyBase.RestoreSelectedEntity(existingProjectionEntity, newProjectionEntity)
            If ReferenceEquals(SelectedEntity, existingProjectionEntity) Then
                SelectedEntity = newProjectionEntity
            End If
        End Sub
        Protected Overrides Sub OnIsLoadingChanged()
            MyBase.OnIsLoadingChanged()
            UpdateCommands()
            If Not IsLoading Then
                RequestSelectedEntity()
            End If
        End Sub
        Private Sub UpdateCommands()
            Dim projectionEntity As TProjection = Nothing
            Me.RaiseCanExecuteChanged(Sub(x) x.Edit(projectionEntity))
            Me.RaiseCanExecuteChanged(Sub(x) x.Delete(projectionEntity))
            Me.RaiseCanExecuteChanged(Sub(x) x.Save(projectionEntity))
        End Sub
        Protected Sub DestroyDocument(ByVal document As IDocument)
            If document IsNot Nothing Then
                document.Close()
            End If
        End Sub
        Protected Function CreateRepository() As IRepository(Of TEntity, TPrimaryKey)
            Return CType(CreateReadOnlyRepository(), IRepository(Of TEntity, TPrimaryKey))
        End Function
        Protected Overrides Function CreateEntitiesChangeTracker() As IEntitiesChangeTracker
            Return New EntitiesChangeTracker(Of TPrimaryKey)(Me)
        End Function
        Protected Class SelectEntityMessage
            Private _PrimaryKey As TPrimaryKey
            Public Sub New(ByVal primaryKey As TPrimaryKey)
                Me._PrimaryKey = primaryKey
            End Sub
            Public ReadOnly Property PrimaryKey As TPrimaryKey
                Get
                    Return _PrimaryKey
                End Get
            End Property
        End Class
        Protected Class SelectedEntityRequest
        End Class
        Private ReadOnly _ignoreSelectEntityMessage As Boolean
        Private Sub RegisterSelectEntityMessage()
            If Not _ignoreSelectEntityMessage Then
                Messenger.[Default].Register(Of SelectEntityMessage)(Me, Sub(x) OnSelectEntityMessage(x))
            End If
        End Sub
        Private Sub RequestSelectedEntity()
            If Not _ignoreSelectEntityMessage Then
                Messenger.[Default].Send(New SelectedEntityRequest())
            End If
        End Sub
        Private Sub OnSelectEntityMessage(ByVal message As SelectEntityMessage)
            If Not IsLoaded Then
                Return
            End If
            Dim projectionEntity = ChangeTrackerWithKey.FindActualProjectionByKey(message.PrimaryKey)
            If projectionEntity Is Nothing Then
                FilterExpression = Nothing
                projectionEntity = ChangeTrackerWithKey.FindActualProjectionByKey(message.PrimaryKey)
            End If
            SelectedEntity = projectionEntity
        End Sub
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
    ''' <summary>
    ''' Provides the extension methods that are used to implement the IDocumentManagerService interface.
    ''' </summary>
    Public Module DocumentManagerServiceExtensions
        ''' <summary>
        ''' Creates and shows a document containing a single object view model for the existing entity.
        ''' </summary>
        ''' <param name="documentManagerService">An instance of the IDocumentManager interface used to create and show the document.</param>
        ''' <param name="parentViewModel">An object that is passed to the view model of the created view.</param>
        ''' <param name="primaryKey">An entity primary key.</param>
        <System.Runtime.CompilerServices.Extension> _
        Public Function ShowExistingEntityDocument(Of TEntity, TPrimaryKey)(ByVal documentManagerService As IDocumentManagerService, ByVal parentViewModel As Object, ByVal primaryKey As TPrimaryKey) As IDocument
            Dim document As IDocument = If(FindEntityDocument(Of TEntity, TPrimaryKey)(documentManagerService, primaryKey), CreateDocument(Of TEntity)(documentManagerService, primaryKey, parentViewModel))
            If document IsNot Nothing Then
                document.Show()
            End If
            Return document
        End Function
        ''' <summary>
        ''' Creates and shows a document containing a single object view model for new entity.
        ''' </summary>
        ''' <param name="documentManagerService">An instance of the IDocumentManager interface used to create and show the document.</param>
        ''' <param name="parentViewModel">An object that is passed to the view model of the created view.</param>
        ''' <param name="newEntityInitializer">An optional parameter that provides a function that initializes a new entity.</param>
        <System.Runtime.CompilerServices.Extension> _
        Public Sub ShowNewEntityDocument(Of TEntity)(ByVal documentManagerService As IDocumentManagerService, ByVal parentViewModel As Object, Optional ByVal newEntityInitializer As Action(Of TEntity) = Nothing)
            Dim document As IDocument = CreateDocument(Of TEntity)(documentManagerService, If(newEntityInitializer, (Sub(x) DefaultEntityInitializer(x))), parentViewModel)
            If document IsNot Nothing Then
                document.Show()
            End If
        End Sub
        ''' <summary>
        ''' Searches for a document that contains a single object view model editing entity with a specified primary key.
        ''' </summary>
        ''' <param name="documentManagerService">An instance of the IDocumentManager interface used to find a document.</param>
        ''' <param name="primaryKey">An entity primary key.</param>
        <System.Runtime.CompilerServices.Extension> _
        Public Function FindEntityDocument(Of TEntity, TPrimaryKey)(ByVal documentManagerService As IDocumentManagerService, ByVal primaryKey As TPrimaryKey) As IDocument
            If documentManagerService Is Nothing Then
                Return Nothing
            End If
            For Each document As IDocument In documentManagerService.Documents
                Dim entityViewModel As ISingleObjectViewModel(Of TEntity, TPrimaryKey) = TryCast(document.Content, ISingleObjectViewModel(Of TEntity, TPrimaryKey))
                If entityViewModel IsNot Nothing AndAlso Object.Equals(entityViewModel.PrimaryKey, primaryKey) Then
                    Return document
                End If
            Next
            Return Nothing
        End Function
        Private Sub DefaultEntityInitializer(Of TEntity)(ByVal entity As TEntity)
        End Sub
        Private Function CreateDocument(Of TEntity)(ByVal documentManagerService As IDocumentManagerService, ByVal parameter As Object, ByVal parentViewModel As Object) As IDocument
            If documentManagerService Is Nothing Then
                Return Nothing
            End If
            Dim document = documentManagerService.CreateDocument(GetDocumentTypeName(Of TEntity)(), parameter, parentViewModel)
            document.Id = "_" + Guid.NewGuid().ToString().Replace("-"c, "_"c)
            document.DestroyOnClose = False
            Return document
        End Function
        Public Function GetDocumentTypeName(Of TEntity)() As String
            Return GetType(TEntity).Name + "View"
        End Function
    End Module
End Namespace
