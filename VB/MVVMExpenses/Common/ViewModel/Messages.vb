Imports System
Imports System.Linq
Imports System.ComponentModel
Namespace Common.ViewModel
    ''' <summary>
    ''' Represents the type of an entity state change notification that is shown when the IUnitOfWork.SaveChanges method has been called.
    ''' </summary>
    Public Enum EntityMessageType
        ''' <summary>
        ''' A new entity has been added to the unit of work. 
        ''' </summary>
        Added
        ''' <summary>
        ''' An entity has been removed from the unit of work.
        ''' </summary>
        Deleted
        ''' <summary>
        ''' One of the entity properties has been modified. 
        ''' </summary>
        Changed
    End Enum
    ''' <summary>
    ''' Provides the information about an entity state change notification that is shown when an entity has been added, removed or modified, and the IUnitOfWork.SaveChanges method has been called.
    ''' </summary>
    ''' <typeparam name="TEntity">An entity type.</typeparam>
    ''' <typeparam name="TPrimaryKey">A primary key value type.</typeparam>
    Public Class EntityMessage(Of TEntity, TPrimaryKey)
        Private _MessageType As EntityMessageType
        Private _PrimaryKey As TPrimaryKey
        ''' <summary>
        ''' Initializes a new instance of the EntityMessage class.
        ''' </summary>
        ''' <param name="primaryKey">A primary key of an entity that has been added, removed or modified.</param>
        ''' <param name="messageType">An entity state change notification type.</param>
        Public Sub New(ByVal primaryKey As TPrimaryKey, ByVal messageType As EntityMessageType)
            Me._PrimaryKey = primaryKey
            Me._MessageType = messageType
        End Sub
        ''' <summary>
        ''' The primary key of entity that has been added, deleted or modified.
        ''' </summary>
        Public ReadOnly Property PrimaryKey As TPrimaryKey
            Get
                Return _PrimaryKey
            End Get
        End Property
        ''' <summary>
        ''' The entity state change notification type.
        ''' </summary>
        Public ReadOnly Property MessageType As EntityMessageType
            Get
                Return _MessageType
            End Get
        End Property
    End Class
    ''' <summary>
    ''' A message notifying that all view models should save changes. Usually sent by DocumentsViewModel when the SaveAll command is executed.
    ''' </summary>
    Public Class SaveAllMessage
    End Class
    ''' <summary>
    ''' A message notifying that all view models should close itself. Usually sent by DocumentsViewModel when the CloseAll command is executed.
    ''' </summary>
    Public Class CloseAllMessage
        Private ReadOnly _cancelEventArgs As CancelEventArgs
        ''' <summary>
        ''' Initializes a new instance of the CloseAllMessage class.
        ''' </summary>
        ''' <param name="cancelEventArgs">An argument of the System.ComponentModel.CancelEventArgs type which can be used to cancel closing.</param>
        Public Sub New(ByVal cancelEventArgs As CancelEventArgs)
            Me._cancelEventArgs = cancelEventArgs
        End Sub
        ''' <summary>
        ''' Used to cancel closing and check whether the closing has already been cancelled.
        ''' </summary>
        Public Property Cancel As Boolean
            Get
                Return _cancelEventArgs.Cancel
            End Get
            Set(value As Boolean)
                _cancelEventArgs.Cancel = value
            End Set
        End Property
    End Class
    Public Class DestroyOrphanedDocumentsMessage
    End Class
    ''' <summary>
    ''' Used by the PeekCollectionViewModel to notify that DocumentsViewModel should navigate to the specified module.
    ''' </summary>
    ''' <typeparam name="TNavigationToken">The navigation token type.</typeparam>
    Public Class NavigateMessage(Of TNavigationToken)
        Private _Token As TNavigationToken
        ''' <summary>
        ''' Initializes a new instance of the NavigateMessage class.
        ''' </summary>
        ''' <param name="token">An object that is used to identify the module to which the DocumentsViewModel should navigate.</param>
        Public Sub New(ByVal token As TNavigationToken)
            Me._Token = token
        End Sub
        ''' <summary>
        ''' An object that is used to identify the module to which the DocumentsViewModel should navigate.
        ''' </summary>
        Public ReadOnly Property Token As TNavigationToken
            Get
                Return _Token
            End Get
        End Property
    End Class
End Namespace
