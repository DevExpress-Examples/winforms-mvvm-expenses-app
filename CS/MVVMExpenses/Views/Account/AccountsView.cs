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
using DevExpress.Utils.MVVM.Services;
using MVVMExpenses.Models.ViewModels;

namespace MVVMExpenses.Common.Views.Account {
    [DevExpress.Utils.MVVM.UI.ViewType("AccountCollectionView")]
    public partial class AccountsView : DevExpress.XtraEditors.XtraUserControl {
        public AccountsView() {
            InitializeComponent();
            if(!DesignMode)
                InitBindings();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelect = true;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
        }

        void InitBindings() {
            var fluentAPI = mvvmContext1.OfType<AccountCollectionViewModel>();
            fluentAPI.SetBinding(gridView1, gView => gView.LoadingPanelVisible, x => x.IsLoading);
            fluentAPI.SetBinding(gridControl1, gControl => gControl.DataSource, x => x.Entities);

            fluentAPI.WithEvent<DevExpress.XtraGrid.Views.Base.ColumnView, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs>(gridView1, "FocusedRowObjectChanged")
                .SetBinding(x => x.SelectedEntity,
                    args => args.Row as DataModels.Account,
                    (gView, entity) => gView.FocusedRowHandle = gView.FindRow(entity));
            fluentAPI.WithEvent<DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs>(gridView1, "RowCellClick")
                .EventToCommand(
                    x => x.Edit(null), x => x.SelectedEntity,
                    args => (args.Clicks == 2) && (args.Button == MouseButtons.Left));

            fluentAPI.WithEvent<DevExpress.Data.SelectionChangedEventArgs>(gridView1, "SelectionChanged")
                .SetBinding(x => x.Selection, e => GetSelectedAccounts());
        }

        IEnumerable<MVVMExpenses.DataModels.Account> GetSelectedAccounts() {
            return gridView1.GetSelectedRows().Select(r => gridView1.GetRow(r) as MVVMExpenses.DataModels.Account);
        }
    }
}
