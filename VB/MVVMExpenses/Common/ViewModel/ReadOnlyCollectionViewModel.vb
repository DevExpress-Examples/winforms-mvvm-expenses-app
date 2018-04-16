Imports System
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
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
    ''' The base class for POCO view models exposing a read-only collection of entities of a given type. 
    ''' This is a partial class that provides the extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Partial Public Class ReadOnlyCollectionViewModel(Of TEntity As Class, TUnitOfWork As IUnitOfWork)
        Inherits ReadOnlyCollectionViewModel(Of TEntity, TEntity, TUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of ReadOnlyCollectionViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">An optional parameter that provides a LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data.</param>
        Public Shared Function CreateReadOnlyCollectionViewModel(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing) As ReadOnlyCollectionViewModel(Of TEntity, TUnitOfWork)
            Return ViewModelSource.Create(Function() New ReadOnlyCollectionViewModel(Of TEntity, TUnitOfWork)(unitOfWorkFactory, getRepositoryFunc, projection))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the ReadOnlyCollectionViewModel class.
        ''' This constructor is declared protected to avoid an undesired instantiation of the PeekCollectionViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of the given type.</param>
        ''' <param name="projection">An optional parameter that provides a LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection)
        End Sub
    End Class
    ''' <summary>
    ''' The base class for POCO view models exposing a read-only collection of entities of a given type. 
    ''' This is a partial class that provides the extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    ''' <typeparam name="TProjection">A projection entity type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Partial Public Class ReadOnlyCollectionViewModel(Of TEntity As Class, TProjection As Class, TUnitOfWork As IUnitOfWork)
        Inherits ReadOnlyCollectionViewModelBase(Of TEntity, TProjection, TUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of ReadOnlyCollectionViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        Public Shared Function CreateReadOnlyProjectionCollectionViewModel(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection))) As ReadOnlyCollectionViewModel(Of TEntity, TProjection, TUnitOfWork)
            Return ViewModelSource.Create(Function() New ReadOnlyCollectionViewModel(Of TEntity, TProjection, TUnitOfWork)(unitOfWorkFactory, getRepositoryFunc, projection))
        End Function
        ''' <summary>
        ''' Initializes a new instance of the ReadOnlyCollectionViewModel class.
        ''' This constructor is declared protected to avoid an undesired instantiation of the PeekCollectionViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)))
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection)
        End Sub
    End Class
    ''' <summary>
    ''' The base class for POCO view models exposing a read-only collection of entities of a given type. 
    ''' It is not recommended to inherit directly from this class. Use the ReadOnlyCollectionViewModel class instead.
    ''' </summary>
    ''' <typeparam name="TEntity">A repository entity type.</typeparam>
    ''' <typeparam name="TProjection">A projection entity type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    <POCOViewModel> _
    Public MustInherit Class ReadOnlyCollectionViewModelBase(Of TEntity As Class, TProjection As Class, TUnitOfWork As IUnitOfWork)
        Inherits EntitiesViewModel(Of TEntity, TProjection, TUnitOfWork)
        ''' <summary>
        ''' Initializes a new instance of the ReadOnlyCollectionViewModelBase class.
        ''' </summary>
        ''' <param name="unitOfWorkFactory">A factory used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns the repository representing entities of a given type.</param>
        ''' <param name="projection">A LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data and/or for projecting data to a custom type that does not match the repository entity type.</param>
        Protected Sub New(ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IReadOnlyRepository(Of TEntity)), ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TProjection)))
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection)
            Messenger.[Default].Register(Of CloseAllMessage)(Me, Sub(x) SaveLayout())
        End Sub
        ''' <summary>
        ''' The selected enity.
        ''' Since ReadOnlyCollectionViewModelBase is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        ''' </summary>
        Public Overridable Property SelectedEntity As TProjection
        ''' <summary>
        ''' The lambda expression used to filter which entities will be loaded locally from the unit of work.
        ''' Since ReadOnlyCollectionViewModelBase is a POCO view model, this property will raise INotifyPropertyChanged.PropertyEvent when modified so it can be used as a binding source in views.
        ''' </summary>
        Public Overridable Property FilterExpression As Expression(Of Func(Of TEntity, Boolean))
        ''' <summary>
        ''' Reloads entities.
        ''' Since CollectionViewModelBase is a POCO view model, an instance of this class will also expose the RefreshCommand property that can be used as a binding source in views.
        ''' </summary>
        Public Overridable Sub Refresh()
            LoadEntities(False)
        End Sub
        Protected ReadOnly Property LayoutSerializationService As ILayoutSerializationService
            Get
                Return Me.GetService(Of ILayoutSerializationService)()
            End Get
        End Property
        Protected Overridable ReadOnly Property ViewName As String
            Get
                Return GetType(TEntity).Name + "ReadonlyCollectionView"
            End Get
        End Property
        Private _isLoaded As Boolean = False
        <Display(AutoGenerateField:=False)> _
        Public Overridable Sub OnLoaded()
            _isLoaded = True
            Dim state As String = Nothing
            If LayoutSerializationService IsNot Nothing AndAlso ViewModelLogicalLayoutHelper.PersistentViewsLayout.TryGetValue(ViewName, state) Then
                LayoutSerializationService.Deserialize(state)
            End If
        End Sub
        <Display(AutoGenerateField:=False)> _
        Public Overridable Sub OnUnloaded()
            If _isLoaded Then
                SaveLayout()
            End If
        End Sub
        Private Sub SaveLayout()
            If LayoutSerializationService IsNot Nothing Then
                ViewModelLogicalLayoutHelper.PersistentViewsLayout(ViewName) = LayoutSerializationService.Serialize()
            End If
        End Sub
        Protected Overrides Sub OnClose(ByVal e As CancelEventArgs)
            SaveLayout()
            Messenger.[Default].Send(New DestroyOrphanedDocumentsMessage())
            MyBase.OnClose(e)
        End Sub
        ''' <summary>
        ''' Determines whether entities can be reloaded.
        ''' Since CollectionViewModelBase is a POCO view model, this method will be used as a CanExecute callback for RefreshCommand.
        ''' </summary>
        Public Function CanRefresh() As Boolean
            Return Not IsLoading
        End Function
        Protected Overrides Sub OnEntitiesAssigned(ByVal getSelectedEntityCallback As Func(Of TProjection))
            MyBase.OnEntitiesAssigned(getSelectedEntityCallback)
            SelectedEntity = If(getSelectedEntityCallback(), Entities.FirstOrDefault())
        End Sub
        Protected Overrides Function GetSelectedEntityCallback() As Func(Of TProjection)
            Dim selectedItemIndex As Integer = Entities.IndexOf(SelectedEntity)
            Return Function() If((selectedItemIndex >= 0 AndAlso selectedItemIndex < Entities.Count), Entities(selectedItemIndex), Nothing)
        End Function
        Protected Overrides Sub OnIsLoadingChanged()
            MyBase.OnIsLoadingChanged()
            Me.RaiseCanExecuteChanged(Sub(x) x.Refresh())
        End Sub
        Protected Overridable Sub OnSelectedEntityChanged()
        End Sub
        Protected Overridable Sub OnFilterExpressionChanged()
            If IsLoaded OrElse IsLoading Then
                LoadEntities(True)
            End If
        End Sub
        Protected Overrides Function GetFilterExpression() As Expression(Of Func(Of TEntity, Boolean))
            Return FilterExpression
        End Function
    End Class
End Namespace
