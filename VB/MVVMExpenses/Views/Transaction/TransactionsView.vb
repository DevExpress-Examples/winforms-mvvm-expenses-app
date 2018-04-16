Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports MVVMExpenses.ViewModels

Namespace MVVMExpenses.Common.Views.Transaction
    <DevExpress.Utils.MVVM.UI.ViewType("TransactionCollectionView")>
    Partial Public Class TransactionsView
        Inherits DevExpress.XtraEditors.XtraUserControl

        Public Sub New()
            InitializeComponent()
            If Not DesignMode Then
                InitBindings()
            End If
            gridView1.OptionsBehavior.Editable = False
            gridView1.OptionsSelection.MultiSelect = True
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect
        End Sub

        Private Sub InitBindings()
            Dim fluentAPI = mvvmContext1.OfType(Of TransactionCollectionViewModel)()
            fluentAPI.SetBinding(gridView1, Function(gView) gView.LoadingPanelVisible, Function(x) x.IsLoading)
            fluentAPI.SetBinding(gridControl1, Function(gControl) gControl.DataSource, Function(x) x.Entities)

            fluentAPI.WithEvent(Of ColumnView, FocusedRowObjectChangedEventArgs)(gridView1, "FocusedRowObjectChanged").SetBinding(Function(x) x.SelectedEntity, Function(args) TryCast(args.Row, DataModels.Transaction), Sub(gView, entity) gView.FocusedRowHandle = gView.FindRow(entity))
            fluentAPI.WithEvent(Of RowCellClickEventArgs)(gridView1, "RowCellClick").EventToCommand(Sub(x) x.Edit(Nothing), Function(x) x.SelectedEntity, Function(args) (args.Clicks = 2) AndAlso (args.Button = MouseButtons.Left))
            fluentAPI.WithEvent(Of DevExpress.Data.SelectionChangedEventArgs)(gridView1, "SelectionChanged").SetBinding(Function(x) x.Selection, Function(e) GetSelectedCategories())
        End Sub

        Private Function GetSelectedCategories() As IEnumerable(Of MVVMExpenses.DataModels.Transaction)
            Return gridView1.GetSelectedRows().Select(Function(r) TryCast(gridView1.GetRow(r), MVVMExpenses.DataModels.Transaction))
        End Function
    End Class
End Namespace
