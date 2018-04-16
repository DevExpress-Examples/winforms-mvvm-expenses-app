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
    ''' A POCO view model exposing a read-only collection of entities of a given type. It is designed for quick navigation between collection views.
    ''' This is a partial class that provides an extension point to add custom properties, commands and override methods without modifying the auto-generated code.
    ''' </summary>
    ''' <typeparam name="TNavigationToken">A navigation token type.</typeparam>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    ''' <typeparam name="TUnitOfWork">A unit of work type.</typeparam>
    Partial Public Class PeekCollectionViewModel(Of TNavigationToken, TEntity As Class, TPrimaryKey, TUnitOfWork As IUnitOfWork)
        Inherits CollectionViewModelBase(Of TEntity, TEntity, TPrimaryKey, TUnitOfWork)
        ''' <summary>
        ''' Creates a new instance of PeekCollectionViewModel as a POCO view model.
        ''' </summary>
        ''' <param name="navigationToken">Identifies the module that is the navigation target.</param>
        ''' <param name="unitOfWorkFactory">A factory that is used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of a given type.</param>
        ''' <param name="projection">An optional parameter that provides a LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data.</param>
        Public Shared Function Create(ByVal navigationToken As TNavigationToken, ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing) As PeekCollectionViewModel(Of TNavigationToken, TEntity, TPrimaryKey, TUnitOfWork)
            Return ViewModelSource.Create(Function() New PeekCollectionViewModel(Of TNavigationToken, TEntity, TPrimaryKey, TUnitOfWork)(navigationToken, unitOfWorkFactory, getRepositoryFunc, projection))
        End Function
        Private _navigationToken As TNavigationToken
        Private _pickedEntity As TEntity
        ''' <summary>
        ''' Initializes a new instance of the PeekCollectionViewModel class.
        ''' This constructor is declared protected to avoid an undesired instantiation of the PeekCollectionViewModel type without the POCO proxy factory.
        ''' </summary>
        ''' <param name="navigationToken">Identifies the module that is the navigation target.</param>
        ''' <param name="unitOfWorkFactory">A factory that is used to create a unit of work instance.</param>
        ''' <param name="getRepositoryFunc">A function that returns a repository representing entities of a given type.</param>
        ''' <param name="projection">An optional parameter that provides a LINQ function used to customize a query for entities. The parameter, for example, can be used for sorting data.</param>
        Protected Sub New(ByVal navigationToken As TNavigationToken, ByVal unitOfWorkFactory As IUnitOfWorkFactory(Of TUnitOfWork), ByVal getRepositoryFunc As Func(Of TUnitOfWork, IRepository(Of TEntity, TPrimaryKey)), Optional ByVal projection As Func(Of IRepositoryQuery(Of TEntity), IQueryable(Of TEntity)) = Nothing)
            MyBase.New(unitOfWorkFactory, getRepositoryFunc, projection, Nothing, Nothing, True)
            Me._navigationToken = navigationToken
        End Sub
        ''' <summary>
        ''' Navigates to the corresponding collection view and selects the given entity.
        ''' Since PeekCollectionViewModel is a POCO view model, an instance of this class will also expose the NavigateCommand property that can be used as a binding source in views.
        ''' </summary>
        ''' <param name="projectionEntity">An entity to select within the collection view.</param>
        <Display(AutoGenerateField:=False)> _
        Public Sub Navigate(ByVal projectionEntity As TEntity)
            _pickedEntity = projectionEntity
            SendSelectEntityMessage()
            Messenger.[Default].Send(New NavigateMessage(Of TNavigationToken)(_navigationToken), _navigationToken)
        End Sub
        ''' <summary>
        ''' Determines if a navigation to corresponding collection view can be performed.
        ''' Since PeekCollectionViewModel is a POCO view model, this method will be used as a CanExecute callback for NavigateCommand.
        ''' </summary>
        ''' <param name="projectionEntity">An entity to select in the collection view.</param>
        Public Function CanNavigate(ByVal projectionEntity As TEntity) As Boolean
            Return projectionEntity IsNot Nothing
        End Function
        Protected Overrides Sub OnInitializeInRuntime()
            MyBase.OnInitializeInRuntime()
            Messenger.[Default].Register(Of SelectedEntityRequest)(Me, Sub(x) SendSelectEntityMessage())
        End Sub
        Private Sub SendSelectEntityMessage()
            If IsLoaded AndAlso _pickedEntity IsNot Nothing Then
                Messenger.[Default].Send(New SelectEntityMessage(CreateRepository().GetProjectionPrimaryKey(_pickedEntity)))
            End If
        End Sub
    End Class
End Namespace
