Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports DevExpress.Mvvm
Namespace Common.ViewModel
    Public Class ViewModelLogicalLayoutHelper
        Public Shared Property PersistentLogicalLayout As String
            Get
                Return LayoutSettings.[Default].LogicalLayout
            End Get
            Set(value As String)
                LayoutSettings.[Default].LogicalLayout = value
            End Set
        End Property
        Private Shared _persistentViewsLayout As Dictionary(Of String, String)
        Public Shared ReadOnly Property PersistentViewsLayout As Dictionary(Of String, String)
            Get
                If _persistentViewsLayout Is Nothing Then
                    _persistentViewsLayout = LogicalLayoutSerializationHelper.Deserialize(LayoutSettings.[Default].ViewsLayout)
                End If
                Return _persistentViewsLayout
            End Get
        End Property
        Public Shared Sub SaveLayout()
            LayoutSettings.[Default].ViewsLayout = LogicalLayoutSerializationHelper.Serialize(PersistentViewsLayout)
            LayoutSettings.[Default].Save()
        End Sub
        Public Shared Sub ResetLayout()
            PersistentViewsLayout.Clear()
            PersistentLogicalLayout = Nothing
            SaveLayout()
        End Sub
    End Class
End Namespace
