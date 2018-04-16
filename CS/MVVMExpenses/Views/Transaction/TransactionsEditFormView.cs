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

namespace MVVMExpenses.Common.Views.Transaction {
    [DevExpress.Utils.MVVM.UI.ViewType("TransactionView")]
    public partial class TransactionsEditFormView : DevExpress.XtraEditors.XtraUserControl {
        public TransactionsEditFormView() {
            InitializeComponent();
            if(!DesignMode)
                InitBindings();
        }

        void InitBindings() {
            var fluent = mvvmContext1.OfType<TransactionViewModel>();
            fluent.SetObjectDataSourceBinding(
                bindingSource, x => x.Entity, x => x.Update());
            fluent.SetBinding(accountBindingSource,
                abs => abs.DataSource, x => x.LookUpAccounts.Entities);
            fluent.SetBinding(categoryBindingSource,
                cbs => cbs.DataSource, x => x.LookUpCategories.Entities);
        }
    }
}
