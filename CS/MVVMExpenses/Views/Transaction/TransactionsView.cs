using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MVVMExpenses.Models.ViewModels;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

namespace MVVMExpenses.Common.Views.Transaction {
    [DevExpress.Utils.MVVM.UI.ViewType("TransactionCollectionView")]
    public partial class TransactionsView : DevExpress.XtraEditors.XtraUserControl {
        public TransactionsView() {
            InitializeComponent();
            if(!DesignMode)
                InitBindings();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }

        void InitBindings() {
            var fluentAPI = mvvmContext1.OfType<TransactionCollectionViewModel>();
            fluentAPI.SetBinding(gridView1, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            fluentAPI.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Entities);

            fluentAPI.WithEvent<ColumnView, FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity,
                    args => args.Row as DataModels.Transaction,
                    (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            fluentAPI.WithEvent<RowCellClickEventArgs>(gridView1, "RowCellClick")
                .EventToCommand(
                    x => x.Edit(null), x => x.SelectedEntity,
                    args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));
            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView1, "SelectionChanged")
                .SetBinding(x => x.Selection, e => GetSelectedCategories());
        }

        IEnumerable<MVVMExpenses.DataModels.Transaction> GetSelectedCategories() {
            return gridView1.GetSelectedRows().Select(r => gridView1.GetRow(r) as MVVMExpenses.DataModels.Transaction);
        }
    }
}
