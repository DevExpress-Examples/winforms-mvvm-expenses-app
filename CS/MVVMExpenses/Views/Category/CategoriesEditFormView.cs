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

namespace MVVMExpenses.Common.Views.Category {
    [DevExpress.Utils.MVVM.UI.ViewType("CategoryView")]
    public partial class CategoriesEditFormView : DevExpress.XtraEditors.XtraUserControl {
        public CategoriesEditFormView() {
            InitializeComponent();
            this.TypeImageComboBoxEdit.Properties.Items.AddEnum<DataModels.TransactionType>();
            if(!DesignMode) InitBindings();
        }

        void InitBindings() {
            var fluent = mvvmContext1.OfType<CategoryViewModel>();
            fluent.SetObjectDataSourceBinding(
                categoryBindingSource, x => x.Entity, x => x.Update());

            fluent.SetBinding(
                gridControl1, gc => gc.DataSource, x => x.CategoryTransactionDetails.Entities);

            ((GridView)gridControl1.MainView).OptionsBehavior.Editable = false;
            ((GridView)gridControl1.MainView).Columns["Category"].Visible = false;
        }
    }
}
