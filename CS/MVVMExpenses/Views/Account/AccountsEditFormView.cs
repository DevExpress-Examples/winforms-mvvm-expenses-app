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
using MVVMExpenses.Models;
using MVVMExpenses.Models.ViewModels;
using DevExpress.XtraGrid.Views.Grid;

namespace MVVMExpenses.Common.Views.Account {
    [DevExpress.Utils.MVVM.UI.ViewType("AccountView")]
    public partial class AccountsEditFormView : DevExpress.XtraEditors.XtraUserControl {
        public AccountsEditFormView() {
            InitializeComponent();
            if(!DesignMode) InitBindings();
        }

        void InitBindings() {
            var fluent = mvvmContext1.OfType<AccountViewModel>();
            fluent.SetObjectDataSourceBinding(
                accountBindingSource, x => x.Entity, x => x.Update());

            fluent.SetBinding(
                gridControl1, gc => gc.DataSource, x => x.AccountTransactionDetails.Entities);

            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridControl1.MainView).Columns["Account"].Visible = false;
        }
    }
}
