Imports System
Imports System.Collections
Imports System.Linq
Namespace Common.Utils
    ''' <summary>
    ''' Provides the extension method for implementations of the IQueryable interface.
    ''' </summary>
    Public Module DbExtensions
        ''' <summary>
        ''' Forces entities to be loaded locally from the IQueryable instance.
        ''' </summary>
        ''' <param name="source">An instance of the IQueryable interface from which to load entities.</param>
        <System.Runtime.CompilerServices.Extension> _
        Public Sub Load(ByVal source As IQueryable)
            Dim enumerator As IEnumerator = source.GetEnumerator()
            While enumerator.MoveNext()
            End While
        End Sub
    End Module
End Namespace
